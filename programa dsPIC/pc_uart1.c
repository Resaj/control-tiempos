/*
*	Grupo de Robótica Educativa - Departamento de Electrónica - Universidad de Alcalá
*	---------------------------------------------------------------------------------
*
*	Acuerdo de Licencia Software:
*
*	(CC) Creative Commons, Reconocimiento - No Comercial - Compartir Igual 2.5 España
*
*	Usted es libre de:
*		+ copiar, distribuir y comunicar públicamente la obra
*		+ hacer obras derivadas
*
*	Bajo las condiciones siguientes:
*		+ Reconocimiento. Debe reconocer los créditos de la obra de la manera especificada
*		  por el autor o el licenciador (pero no de una manera que sugiera que tiene su apoyo o
*		  apoyan el uso que hace de su obra).
*		+ No comercial. No puede utilizar esta obra para fines comerciales
*		+ Compartir bajo la misma licencia. Si altera o transforma esta obra, o genera una obra
*		  derivada, sólo puede distribuir la obra generada bajo una licencia idéntica a ésta.
*
*		- Al reutilizar o distribuir la obra, tiene que dejar bien claro los términos de la licencia
*		  de esta obra.
*		- Alguna de estas condiciones puede no aplicarse si se obtiene el permiso del titular de
*		  los derechos de autor.
*		- Nada en esta licencia menoscaba o restringe los derechos morales del autor.
*
*******************************************************************************************************
*
*	Grupo de Robótica Educativa - Departamento de Electrónica - Universidad de Alcalá
*	---------------------------------------------------------------------------------
*
*	Software License Agreement:
*
*	(CC) Creative Commons, Attribution - NonCommercial - ShareAlike 2.5 Spain
*
*	You are free:
*		+ to Share — to copy, distribute and transmit the work
*		+ to Remix — to adapt the work
*
*	Under the following conditions:
*		+ Attribution. You must attribute the work in the manner specified by the author or
*		  licensor (but not in any way that suggests that they endorse you or your use of the work).
*		+ Noncommercial. You may not use this work for commercial purposes.
*		+ Share Alike. If you alter, transform, or build upon this work, you may distribute the
*		  resulting work only under the same or similar license to this one.
*
*		- For any reuse or distribution, you must make clear to others the license terms of this work.
*		  The best way to do this is with a link to this web page.
*		- Any of the above conditions can be waived if you get permission from the copyright holder.
*		- Nothing in this license impairs or restricts the author's moral rights.
*/

// pc_uart1.c

#ifndef PC_UARTC1
#define PC_UARTC1

#include "pc_uart1.h"

// Variables internas (globales a 'pc_uart1.c')
char uart1_buffer_tx[UART1_BUFFER_TX_SIZE];
char uart1_buffer_rx[UART1_BUFFER_RX_SIZE];

unsigned char uart1_n_elements_buffer_tx = 0;
unsigned char uart1_prod_tx_pos=0;  // Posicion del puntero productor dentro del buffer circular
unsigned char uart1_cons_tx_pos=0; // Posicion del puntero consumidor dentro del buffer circular

unsigned char uart1_n_elements_buffer_rx = 0;
unsigned char uart1_prod_rx_pos=0;  // Posicion del puntero productor dentro del buffer circular
unsigned char uart1_cons_rx_pos=0; // Posicion del puntero consumidor dentro del buffer circular


// ****************************************************************
// FUNCIONES ESPECIFICAS DE LA UART (internas, no accesibles al usuario)
char UART1_send(unsigned char uart1_data_send);
unsigned char UART1_receive(void);
unsigned char UART1_quest_receive(void);
// ****************************************************************

// Función de inicialización de la UART1 y de los búfferes de transmisión y recepción
void UART1_init (char uart1_baud_config)
{
	// Configuracion para el 30F6010A y el 30F4012
	_TRISF2 = 1; // RX como entrada
	_TRISF3 = 0; // TX como salida

	_U1RXIP = 5; // Prioridad Recepcion
	_U1TXIP = 4; // Prioridad Transmision

	switch(uart1_baud_config)
	{
		case 0:	// Se deshabilita el puerto serie
			U1MODE = 0x0000;
			U1STA = 0;
			return;
			break;

		case 1:
			U1BRG = 15; // 115200 ; 7.3728 MHZ ; PLLXX = 16
			break;

		case 2:
			U1BRG = 32; // 56000 ; 7.3728 MHZ ; PLLXX = 16
			break;

		case 3:
			U1BRG = 48; // 38400 ; 7.3728 MHZ ; PLLXX = 16
			break;

		case 4:
			U1BRG = 97; // 19200 ; 7.3728 MHZ ; PLLXX = 16
			break;

		case 5:
			U1BRG = 194; // 9600 ; 7.3728 MHZ ; PLLXX = 16
			break;

		case 6:
			U1BRG = 780; // 2400 ; 7.3728 MHZ ; PLLXX = 16
			break;

		case 7:
			U1BRG = 1562; // 1200 ; 7.3728 MHZ ; PLLXX = 16
			break;

		default:	// Por defecto se deshabilita el puerto serie
			U1MODE = 0x0000;
			U1STA = 0;
			return;
			break;
	}

	if (uart1_baud_config>0 && uart1_baud_config <8)
	{
		UART1_clear_buffer_tx(); // Borra el búffer de transmisión
		UART1_clear_buffer_rx(); // Borra el búffer de recepción	
#if defined(__dsPIC30F4012__)
		U1MODE = 0x8400;			// Se cambia al puerto serie alternativo
#elif defined(__dsPIC30F6010A__)
		U1MODE = 0x8000;
#else
#error -- Procesador NO soportado (de momento)
#endif
		U1STA = 0x0400;
	}
}


// Productor - Consumidor (Para transmision de Datos por la uart)


// ****************************************************************
//
// BORRRAR BUFFER TX: Pone los punteros Productor y Consumidor a cero.
//
// Parametros que se pasan: ninguno
//
// Parametros que se reciben: ninguno
// 
//
// ****************************************************************

void UART1_clear_buffer_tx (void)
{	
	_U1TXIE = 0;
	uart1_n_elements_buffer_tx=0;
	uart1_prod_tx_pos=0;
	_U1TXIE = 1;
}

// ****************************************************************
//
// BORRRAR BUFFER RX: Pone los punteros Productor y Consumidor a cero.
//
// Parametros que se pasan: ninguno
//
// Parametros que se reciben: ninguno
// 
//
// ****************************************************************

void UART1_clear_buffer_rx (void)
{	
	_U1RXIE = 0;
	uart1_n_elements_buffer_rx=0;
	uart1_prod_rx_pos=0;
	_U1RXIE = 1;

}

// ****************************************************************
//
// PRODUCTOR TX: INSERTA DATOS EN EL BUFFER PARA QUE SEAN ENVIADOS
// 		POR EL CONSUMIDOR
//
// Parametros que se pasan: el DATO en tamaño char
//
// Parametros que se reciben: bit:
// 
// '1' en caso de que se haya insertado correctamente
// '0' en caso de que el buffer se encuentre lleno
//
// ****************************************************************

char UART1_send_char(char uart1_tx_char)
{	
	_U1TXIE = 0;	// Deshabilitamos interrupcion UART TX1

	if(uart1_n_elements_buffer_tx < (UART1_BUFFER_TX_SIZE-1))
	{
		uart1_buffer_tx[uart1_prod_tx_pos] = uart1_tx_char; 
		uart1_n_elements_buffer_tx++;
		uart1_prod_tx_pos++;
		uart1_prod_tx_pos &= (UART1_BUFFER_TX_SIZE-1);

		if(uart1_n_elements_buffer_tx == 1)
			 _U1TXIF = 1;	// si introducimos el primer dato, llamamos a la interrupcion

		_U1TXIE = 1;	// Habilitamos interrupcion UART TX1

		return 1 ;
	}
	else // Búffer de transmisión lleno
	{
		_U1TXIE = 1;	// Habilitamos interrupcion UART TX1
		return 0;
	}
}


// ****************************************************************
//
// PRODUCTOR TX: INSERTA UNA CADENA DE DATOS EN EL BUFFER PARA QUE
//		SEAN ENVIADOS POR EL CONSUMIDOR
//
// Parametros que se pasan: 
//	- el puntero a la cadena de caracteres
//	- Se envian caracteres hasta que se encuentre \0
//
// Parametros que se reciben: bit:
// 
// '1' en caso de que se haya insertado correctamente
// '0' en caso de que el buffer se encuentre lleno
//
// ****************************************************************

char UART1_send_string(char *uart1_tx_string)
{
	char i;

	_U1TXIE = 0;	// Deshabilitamos interrupcion UART TX1

	if(uart1_n_elements_buffer_tx == 0)
			 _U1TXIF = 1;	// si introducimos el primer dato, llamamos a la interrupción
	
	if(uart1_n_elements_buffer_tx < (UART1_BUFFER_TX_SIZE-1)) // Hay espacio en el búffer
	{
		i = 1;
		while( i && (*uart1_tx_string)!= 0) // Mientras que haya espacio y no este el caracter \0
		{
			uart1_buffer_tx[uart1_prod_tx_pos] = *uart1_tx_string; 
			uart1_n_elements_buffer_tx++;
			uart1_prod_tx_pos++;
			uart1_prod_tx_pos &= (UART1_BUFFER_TX_SIZE-1);

			uart1_tx_string++; // incrementamos puntero
			i = UART1_BUFFER_TX_SIZE -1 - uart1_n_elements_buffer_tx;
		}
		if( (i == 0) && (*uart1_tx_string)!= 0) // No hay espacio en el buffer y aun no se llego al final
		{
			_U1TXIE = 1;	// Habilitamos interrupcion UART TX1
			return 0;
		}
		_U1TXIE = 1;	// Habilitamos interrupcion UART TX1
		return 1 ;	// Envio al buffer correcto
	}
	else
	{
		_U1TXIE = 1;	// Habilitamos interrupcion UART TX1
		return 0; // No hay espacio en el buffer
	}
}



// ****************************************************************
//
// CONSUMIDOR RX: DEVUELVE DATOS DEL BUFFER RX
//
// Parametros que se pasan: ninguno
//
// Parametros que se reciben: char con el dato
// 
// '0' Si no hay dato
// char x: el dato si lo hubiera
//
// ****************************************************************

char UART1_receive_char(void)
{
	char uart1_rx_character;
	
	_U1RXIE = 0;	// Deshabilitamos interrupcion UART RX1

	if(uart1_n_elements_buffer_rx > 0)
	{
		uart1_rx_character = uart1_buffer_rx[uart1_cons_rx_pos]; 
		uart1_n_elements_buffer_rx--;
		uart1_cons_rx_pos++;
		uart1_cons_rx_pos &= (UART1_BUFFER_RX_SIZE - 1);

		_U1RXIE = 1;	// Habilitamos interrupcion UART RX1
		return uart1_rx_character;
	}
	else
	{
		_U1RXIE = 1;	// Habilitamos interrupcion UART RX1
		return 0;
	}
}

// ****************************************************************
// 
// ASK CONSUMIDOR RX: DEVUELVE EL NUMERO DE DATOS QUE HAY EN
// EL BUFFER RX
//
// Parametros que se pasan: ninguno
//
// Parametros que se reciben: char con la cantidad de datos
// 
//
// ****************************************************************

char UART1_ask_n_elements_buffer_rx(void)
{
	return uart1_n_elements_buffer_rx;	
}



// ****************************************************************
//
// CONSUMIDOR TX: RECOGE DATOS DEL BUFFER PARA ENVIARLOS POR LA UART
// (esta funcion es la rutina de interrupcion)
//
// Parametros que se pasan: ninguno
//
// Parametros que se reciben: ninguno:
// 
// 	En caso de que el buffer se encuentre vacio (se desactiva
//	la interrupcion por TX de la uart.
//
// ****************************************************************

void __attribute__((__interrupt__)) _U1TXInterrupt(void)
{ 
	_U1TXIF = 0; // Borramos flag de interrupcion

	if(uart1_n_elements_buffer_tx > 0)
	{
		if(UART1_send(uart1_buffer_tx[uart1_cons_tx_pos]))
		{  // El dato se ha enviado: incrementar punteros
			uart1_n_elements_buffer_tx--;
			uart1_cons_tx_pos++;
			uart1_cons_tx_pos &= (UART1_BUFFER_TX_SIZE - 1);
			if(uart1_n_elements_buffer_tx == 0)
				 _U1TXIE = 0;	// si el buffer esta vacio desactivamos las interrupciones
		}
		
	}
	else		// El buffer se encuentra vacio
	{
		_U1TXIE = 0;	// Deshabilitamos interrupcion UART TX1
	}
}



// ****************************************************************
//
// PRODUCTOR RX: RECOGE DATOS DE LA UART Y LOS DEPOSITA EN EL
// BUFFER DE RECEPCION
// (esta funcion es la rutina de interrupcion)
//
// Parametros que se pasan: ninguno
//
// Parametros que se reciben: ninguno:
// 
// 	En caso de que el buffer se encuentre lleno se pierde el
//	dato nuevo.
//
// ****************************************************************

void __attribute__((__interrupt__)) _U1RXInterrupt(void)
{ 
	_U1RXIF = 0; // Borramos flag de interrupcion

	if(uart1_n_elements_buffer_rx < (UART1_BUFFER_RX_SIZE-1))	// Hay espacio en el buffer
	{
		if(U1STAbits.URXDA  == 1) // Hay dato nuevo
		{
			uart1_buffer_rx[uart1_prod_rx_pos] = UART1_receive();
			uart1_n_elements_buffer_rx++;
			uart1_prod_rx_pos++;
			uart1_prod_rx_pos &= (UART1_BUFFER_RX_SIZE - 1);
		}
	}
	else		// El buffer se encuentra lleno, se pierde el dato
	{
		if(UART1_quest_receive() == 1) // Hay dato nuevo
		{
			UART1_receive(); // llamamos a la funcion pero no guardamos el dato.
		}
	}
}



// ****************************************************************
// FUNCIONES ESPECIFICAS DE LA UART (internas)


char UART1_send(unsigned char uart1_data_send)
{
	// Comprobar si el buffer esta lleno	
	if( !(U1STA & 0x0200) )
	{
		U1TXREG = uart1_data_send; // Buffer vacio, enviamos
		return 1;
	}
	else
		return 0; // Buffer lleno, no se puede enviar
}

unsigned char UART1_receive(void)
{
	//while(!(U1STA & 0x0001)); // Esperamos a que llegue al menos un dato: NO BLOQUEANTE
	
	if(U1STA & 0x0001)
		return U1RXREG;

	return 0;
}

unsigned char UART1_quest_receive(void)
{
	if(U1STA & 0x0001)
		return 1;  // Hay dato nuevo
	else
		return 0; // No hay dato.
}


#endif

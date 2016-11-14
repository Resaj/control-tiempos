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

// pc_uart1.h

//! \brief Librería para la comunicacion con el Puerto Serie (tarjetas miniAlcadsPIC, AlcadsPIC)

//! \file pc_uart1.h
//!	Esta librería inicializa y controla el puerto serie 1 del dsPIC 30F6010A.
//! Se implementa un buffer FIFO para la transmisión y otro para la recepción (Sincronización Productor-Consumidor).
//! \version V1.1
//! \date 11 de Marzo de 2009
//! \author Marcelo Salazar Arcucci - Marcelino Camacho Paz
//! \htmlonly <BR><BR> <BR>  <a rel="license" href="http://creativecommons.org/licenses/by-nc-sa/2.5/es/"> <img alt="Creative Commons License" style="border-width:0" src="http://i.creativecommons.org/l/by-nc-sa/2.5/es/88x31.png" /> </a> <br />Esta obra está bajo una <a rel="license" href="http://creativecommons.org/licenses/by-nc-sa/2.5/es/">licencia de Creative Commons</a>. \endhtmlonly

// Versiones:
// V1.2		Ordenado y renombrado de funciones y variables para una mejor comprensión
// V1.1		Agregada compatibilidad con dsPIC30F4012
// V1.0		Creacion con compatibilidad con dsPIC30F6010A

#ifndef PC_UARTH1
#define PC_UARTH1

/*
** includes for dsPIC
*/
#if defined(__dsPIC30F4012__)
#include <p30f4012.h>
#elif defined(__dsPIC30F6010A__)
#include <p30f6010A.h>
#else
#error -- Procesador NO soportado (de momento)
#endif


// Productor - Consumidor (Para transmision de Datos a la UART)

#define UART1_BUFFER_TX_SIZE 64  //!< Número de datos del buffer circular de transmision (su tamaño debe ser siempre 2^x bytes)
#define UART1_BUFFER_RX_SIZE 32  //!< Número de datos del buffer circular de recepcion (su tamaño debe ser siempre 2^x bytes)

#define UART1_BAUDS_DISABLE 0	//!< UART1 deshabilitada
#define UART1_BAUDS_115200 1	//!< 115200 baudios
#define UART1_BAUDS_56000 2	//!< 56000 baudios
#define UART1_BAUDS_38400 3	//!< 38400 baudios
#define UART1_BAUDS_19200 4	//!< 19200 baudios
#define UART1_BAUDS_9600 5	//!< 9600 baudios
#define UART1_BAUDS_2400 6	//!< 2400 baudios
#define UART1_BAUDS_1200 7	//!< 1200 baudios


//! Función para inicializar el puerto serie de la UART.

/*!
	Esta función se debe llamar para inicializar el puerto serie:
	Se implementan buffers FIFO de transmisión y recepción (Productor - Consumidor).
	Inicializa la UART, borrando los bufers TX y RX y sus punteros asociados.

	\param uart1_baud_config permite especificar la velocidad del puerto serie:
        \li 0: deshabilitar
        \li 1: 115200, 8, N, 1
        \li 2: 56000
        \li 3: 38400
        \li 4: 19200
        \li 5: 9600
        \li 6: 2400
        \li 7: 1200

	\sa UART1_send_char, UART1_send_string, UART1_ask_n_elements_buffer_rx, UART1_receive_char

\b Ejemplo: comunicación bidireccional con el ordenador

\verbatim
#include "p30F4012.h"
#include "timer1.h"
#include "pc_uart1.h"
#include "pin.h"

void TIMER1_periodic_control(void)
{

}

int main(void)
{
	char temp;

	TIMER1_soft_init();

	// Inicializa Timer 0 cada 500mS, recargable
	TIMER1_soft_set(0, 500, TIMER_AUTO_RECHARGE); 

	PIN_config(RE5,PORT_OUT);

	UART1_init(UART1_BAUDS_115200);

	while(1)
	{
		if(TIMER1_soft_quest_state(0))
		{
			RE5 ^= 1;
			UART1_send_char('H');
			UART1_send_char('o');
			UART1_send_char('l');
			UART1_send_char('a');
			UART1_send_char('\n');
			UART1_send_char('\r');

			UART1_send_string("DepecaBot\n\r");

			if(UART1_ask_n_elements_buffer_rx() > 0)
			{
				temp = UART1_receive_char();

				if(temp == 'a')
					UART1_send_string("Estoy vivo!\n\r");
			}

		}
	}
}
\endverbatim
*/
void UART1_init (char uart1_baud_config);

//! Función para borrar e inicializar el buffer FIFO de Transmisión.
void UART1_clear_buffer_tx (void);

//! Función para borrar e inicializar el buffer FIFO de Recepción.
void UART1_clear_buffer_rx (void);

//! Función de para escribir un caracter en el búffer FIFO de transmision del puerto serie de la UART.

/*!
	Inserta un carácter en el buffer FIFO de transmision para que sea enviado.

	\param uart1_tx_char carácter a enviar

	\return  '1' en caso de que se haya insertado correctamente, '0' en caso de que el buffer se encuentre lleno
	\sa UART1_init, UART1_send_string, UART1_ask_n_elements_buffer_rx, UART1_receive_char
*/
char UART1_send_char(char uart1_tx_char);

//! Función  para escribir una cadena de caracteres en el buffer FIFO de transmision del puerto serie de la UART.

/*!
	Se envían caracteres hasta que se encuentre un 0 en la cadena de caracteres.

	\param uart1_tx_string puntero a una cadena de caracteres

	\return '1' en caso de que se haya insertado correctamente, '0' en caso de que el buffer se encuentre lleno
	\sa UART1_send_char, UART1_init, UART1_ask_n_elements_buffer_rx, UART1_receive_char
*/
char UART1_send_string(char *uart1_tx_string);

//! Función para recibir un carácter del buffer FIFO de recepcion del puerto serie de la UART.

/*!
	Recoje un carácter del buffer FIFO de recepción.

	\return el carácter a recibir.
	\sa UART1_send_char, UART1_send_string, UART1_ask_n_elements_buffer_rx, UART1_init
*/
char UART1_receive_char(void);


//! Función para comprobar el número de elementos que se encuentran en el búffer de recepción.
/*!
	\return número de elementos que se encuentran en el buffer de recepción.
	\sa UART1_send_char, UART1_send_string, UART1_init, UART1_receive_char
*/
char UART1_ask_n_elements_buffer_rx(void);



#endif

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

// timer1.h

//! \brief Libreria para el uso del TIMER 1 y de los TIMERS SOFTWARE

//! \file timer1.h
//!	Esta librería inicializa y controla los timers para el control del tiempo.
//! \version V1.4
//! \date 31 de Marzo de 2009
//! \author Marcelo Salazar Arcucci - Marcelino Camacho Paz
//! \htmlonly <BR><BR> <BR>  <a rel="license" href="http://creativecommons.org/licenses/by-nc-sa/2.5/es/"> <img alt="Creative Commons License" style="border-width:0" src="http://i.creativecommons.org/l/by-nc-sa/2.5/es/88x31.png" /> </a> <br />Esta obra está bajo una <a rel="license" href="http://creativecommons.org/licenses/by-nc-sa/2.5/es/">licencia de Creative Commons</a>. \endhtmlonly

// Versiones:
// V1.4		Actualizadas librerías para una mejor comprensión
// V1.3		Agregada compatibilidad con dsPIC30F4012
// V1.2		Ampliada la funcionalidad del timer.
//		Ahora el timer se puede recargar automaticamente para no perder el sincronismo.
// 		Se quitan las maquinas o funciones que estaban dentro de la interrupcion y se
//		crea la funcion 'funcion_periodica_1_ms()' (Debe ser definida externamente).
// V1.1		Version depurada de la Campus Party 2006


#ifndef _TIMER1_H
#define _TIMER1_H


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

//! Cantidad de timers software de los que disponemos
#define N_TIMERS	30

//! Configuración para iniciar el timer una sola vez 
#define TIMER_ONE_TIME 0

//! Configuración para autorecargar el timer una vez haya llegado a su fin
#define TIMER_AUTO_RECHARGE 1


// Funcion interna para el cálculo de los timers software
void TIMER1_soft_compute_time(void);


//! Inicialización de un timer software

/*!
	Esta funcion debe ser llamada para inicializar un timer software en concreto

	\param n número de timer que se quiere inicializar
	\param time tiempo, en milisegundos, con el que inicializamos el timer software
	\param flags indicación de que se quiere recargar el timer al cumplirse el tiempo especificado.
*/
void TIMER1_soft_set(unsigned char n, unsigned int time, char flags);

//! Reseteo de un Timer

/*!
	\param n número de timer que se quiere resetear
*/
void TIMER1_soft_reset(unsigned char n);

//! Consulta del estado de un timer software

/*!
	Esta función debe ser llamada para conocer el estado de un timer

	\param n número de timer que se quiere consultar

	\return '1' el timer ha llegado al final de cuenta, '0' el timer aun no ha llegado al final de su cuenta.
*/
unsigned char TIMER1_soft_quest_state(unsigned char n);



//! Inicializacion del Timer 1 (Hardware y Software)

/*!
	Esta funcion debe ser llamada para inicializar el timer 1 y la cuenta de los timers software.

	Tambien se configuran las interrupciones del timer 1 para que todas las funciones que dependan
	de la base de tiempos de 1 mS sean ejecutadas.

	\b Ejemplo: Se hace parpadear un LED con frecuencia variable
\verbatim
#include "p30F4012.h"
#include "timer1.h"
#include "pin.h"

void TIMER1_periodic_control(void)
{

}

int main(void)
{
	unsigned char tiempo = 1,modo=0;

	PIN_config(RE5,PORT_OUT); // Configuración del puerto como salida

	TIMER1_soft_init();

	// Inicializa Timer 0 cada 100mS, recargable
	TIMER1_soft_set(0, 100, TIMER_AUTO_RECHARGE); 

	// Inicializa Timer 1, una vez
	TIMER1_soft_set(1, tiempo, TIMER_ONE_TIME); 

	while(1)
	{
		if(TIMER1_soft_quest_state(0)) // Cada 100mS
		{
			// Ejecución de tarea con período 100mS

		}

		
		if(TIMER1_soft_quest_state(1)) // Ejecución con período variable
		{
			if(modo == 0)
			{
				if(++tiempo > 50)
					modo = 1;

				TIMER1_soft_set(1, tiempo, 0);
			}
			else
			{
				if(--tiempo < 10)
					modo = 0;

				TIMER1_soft_set(1, tiempo, 0);
			}

			RE5 ^= 1; // Cambia el estado del LED
		}
	}
}

\endverbatim

*/
void TIMER1_soft_init(void);

//! Controla el hardware de bajo nivel
/*!
	Esta función periódica controla el hardware de bajo nivel
*/
void TIMER1_periodic_control(void);


#endif

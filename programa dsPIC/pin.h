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


//!	\brief Libreria para la configuracion y uso pines digitales (tarjeta miniAlcadsPIC)

//! \file pin.h
//!	Esta librería permite inicializar los puertos digitales y acceder a ellos
//!	\version V1.0
//!	\date 22 de Febrero de 2009
//!	\author Marcelo Salazar Arcucci
//!	\htmlonly <BR><BR> <BR>  <a rel="license" href="http://creativecommons.org/licenses/by-nc-sa/2.5/es/"> <img alt="Creative Commons License" style="border-width:0" src="http://i.creativecommons.org/l/by-nc-sa/2.5/es/88x31.png" /> </a> <br />Esta obra está bajo una <a rel="license" href="http://creativecommons.org/licenses/by-nc-sa/2.5/es/">licencia de Creative Commons</a>. \endhtmlonly

// Versiones:
// v1.0		Creación

#ifndef PIN_H
#define PIN_H

/* includes for dsPIC */
#if defined(__dsPIC30F4012__)
#include <p30f4012.h>
#else
#error -- Procesador NO soportado (de momento)
#endif

#if defined(__dsPIC30F4012__)

#define IO_RB0  	TRISBbits.TRISB0
#define IO_RB1  	TRISBbits.TRISB1
#define IO_RB2  	TRISBbits.TRISB2
#define IO_RB3  	TRISBbits.TRISB3
#define IO_RB4  	TRISBbits.TRISB4
#define IO_RB5  	TRISBbits.TRISB5

#define IO_RC13  	TRISCbits.TRISC13
#define IO_RC14  	TRISCbits.TRISC14
#define IO_RC15 	TRISCbits.TRISC15

#define IO_RD0	 	TRISDbits.TRISD0
#define IO_RD1 		TRISDbits.TRISD1

#define IO_RE0 		TRISEbits.TRISE0
#define IO_RE1 		TRISEbits.TRISE1
#define IO_RE2	 	TRISEbits.TRISE2
#define IO_RE3 		TRISEbits.TRISE3
#define IO_RE4 		TRISEbits.TRISE4
#define IO_RE5 		TRISEbits.TRISE5
#define IO_RE8 		TRISEbits.TRISE8

#define IO_RF2 		TRISFbits.TRISF2
#define IO_RF3 		TRISFbits.TRISF3

#define RB0 		PORTBbits.RB0
#define RB1		PORTBbits.RB1
#define RB2		PORTBbits.RB2
#define RB3		PORTBbits.RB3
#define RB4		PORTBbits.RB4
#define RB5		PORTBbits.RB5

#define RC13		PORTCbits.RC13
#define RC14		PORTCbits.RC14
#define RC15		PORTCbits.RC15

#define RD0		PORTDbits.RD0
#define RD1		PORTDbits.RD1

#define RE0		PORTEbits.RE0
#define RE1		PORTEbits.RE1
#define RE2		PORTEbits.RE2
#define RE3		PORTEbits.RE3
#define RE4		PORTEbits.RE4
#define RE5		PORTEbits.RE5
#define RE8		PORTEbits.RE8

#define RF2		PORTFbits.RF2
#define RF3		PORTFbits.RF3

#endif

//! Pin como entrada
#define PORT_IN		(1)

//! Pin como salida
#define PORT_OUT	(0)	

//! Inicializa el Pin

/*!
	\param pin nombre de la patilla (ver sección \ref PIN Acceso a pines entrada-salida)
	\param config entrada o salida (\ref PORT_IN, \ref PORT_OUT).

	\b Ejemplo:
    \verbatim
#include "p30F4012.h"
#include "pin.h"
#include "timer1.h"

void TIMER1_periodic_control(void)
{

}

int main(void)
{
	char a;

	TIMER1_soft_init();
	PIN_config(RE5,PORT_OUT);

	TIMER1_soft_set(0, 500, TIMER_AUTO_RECHARGE); // Inicializa Timer 0 cada 500mS, recargable

	while(1)
	{
			if(TIMER1_soft_quest_state(0)) // Cada 100mS
			{
				a++;

				if(a & 0x01)
					PIN_on(RE5);
				else
					PIN_off(RE5);
				
			}
	}
}
\endverbatim
*/
#define PIN_config(pin,config) IO_##pin=config
	
//! Pone pin a nivel alto

/*!
	\param pin nombre de la patilla a poner a nivel alto.
*/
#define PIN_on(pin) pin=1 

//! Pone pin a nivel bajo

/*!
	\param pin nombre de la patilla a poner a nivel bajo.
*/
#define PIN_off(pin) pin=0

//! Lee de un pin

/*!
	\param pin nombre de la patilla a leer su estado.
*/
#define PIN_read(pin) pin



#endif

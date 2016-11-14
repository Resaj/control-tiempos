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

// timer1.c

#ifndef _TIMER1_C
#define _TIMER1_C

#include "timer1.h"



// Estructura para ampliar la funcionalidad del timer. Se permite el re-inicio de la cuenta del timer.
volatile struct t_config_timers
{
	char flags;		// Bit 0, indica que ha finalizado una cuenta, Bit 1: indica que se debe reiniciar la cuenta
	int	valor_reinicio;
	int cuenta;
} MATRIZ_TIMERS[N_TIMERS]; 	

// Interrupcion del Timer 1 (Hardware), periodo 1mS
void __attribute__((__interrupt__)) _T1Interrupt(void);

void TIMER1_soft_init(void)
{
	unsigned char i_timers;

	for(i_timers=0 ; i_timers<N_TIMERS ; i_timers++)
	{
		MATRIZ_TIMERS[i_timers].cuenta = 0;
		MATRIZ_TIMERS[i_timers].flags = 0;
	}

	// Configuracion del TIMER 1
	T1CONbits.TON = 0;  // Deshabilitamos el timer1
	TMR1 = 0;
	PR1 = 29491;	// 1 mS aprox
	IFS0bits.T1IF = 0; // Borramos el flag
	T1CON = 0x0000; // Configuramos timer: interno/ sincron, prescaller 1:1
	_T1IP = 3; // Prioridad
	_T1IE = 1; // Habilitamos el timer
	T1CONbits.TON = 1;  // Habilitamos el timer1
}


void __attribute__((__interrupt__)) _T1Interrupt(void)
{
	_T1IF = 0; // Borramos flag

	TIMER1_soft_compute_time();
	TIMER1_periodic_control();
}



/////////////////////////////////// TIMERS SOFTWARE /////////////////////////////////

void TIMER1_soft_compute_time(void)
{
	unsigned char i_timers;

	for(i_timers=0 ; i_timers<N_TIMERS ; i_timers++)
		if(MATRIZ_TIMERS[i_timers].cuenta > 0)
		{
			if( (--MATRIZ_TIMERS[i_timers].cuenta) == 0) // Se ha llegado a cero
			{
				if(MATRIZ_TIMERS[i_timers].flags & 0x02 ) // Rearme de la cuenta?
				{
					MATRIZ_TIMERS[i_timers].cuenta = MATRIZ_TIMERS[i_timers].valor_reinicio;
					MATRIZ_TIMERS[i_timers].flags |= 0x01;		// Se activa el flag para indicar que se ha cumplido el timer.
				}
			}
		}
}


void TIMER1_soft_set(unsigned char n, unsigned int time, char flags)
{
	_T1IE = 0; // DESHabilitamos el timer

	MATRIZ_TIMERS[n].cuenta = time;

	if(flags)
	{
		MATRIZ_TIMERS[n].valor_reinicio = time;		// Se guarda la cuenta para utilizarla mas adelante.
		MATRIZ_TIMERS[n].flags |= 0x02;				// Habilitar rearme
	}
	else
	{
		MATRIZ_TIMERS[n].flags &= ~0x02;			// se borra el bit
	}

	_T1IE = 1; // Habilitamos el timer
}

void TIMER1_soft_reset(unsigned char n)
{
	_T1IE = 0; // DESHabilitamos el timer
	MATRIZ_TIMERS[n].cuenta = 0;
	MATRIZ_TIMERS[n].flags = 0;	
	_T1IE = 1; // Habilitamos el timer
}

unsigned char TIMER1_soft_quest_state(unsigned char n)
{
	_T1IE = 0; // DesHabilitamos el timer

	if(MATRIZ_TIMERS[n].flags & 0x02 ) // Rearme de la cuenta?
	{
		if(MATRIZ_TIMERS[n].flags & 0x01) // Flag activado?
		{
			MATRIZ_TIMERS[n].flags &= ~0x01;	// Se quita el flag
			_T1IE = 1; // Habilitamos el timer
			return 1;
		}
		else
		{
			_T1IE = 1; // Habilitamos el timer
			return 0;
		}
	}
	else if (MATRIZ_TIMERS[n].cuenta != 0) // No hay Rearme de la cuenta
	{
		_T1IE = 1; // Habilitamos el timer
		return 0;
	}
	else			
	{
		_T1IE = 1; 	// Habilitamos el timer
		return 1;   // Ha finalizado el timer
	}
}



#endif

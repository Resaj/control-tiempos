#include "p30F4012.h"
#include <stdio.h>
#include "timer1.h"
#include "pc_uart1.h"
#include "pin.h"

#define T_timer 10


void INT_Init(void);
void __attribute__((__interrupt__)) _INT1Interrupt(void);
void __attribute__((__interrupt__)) _INT2Interrupt(void);

void TIMER1_periodic_control(void)
{

}


double cont = 0, cont1 = 0, cont2 = 0;
double mejor_T = 0, mejor_S1 = 0, mejor_S2 = 0;
char enable = 'n';
char comienza = 'n';
char en_arco1 = 'n', en_arco2 = 'n';
char en_aux1 = 'n', en_aux2 = 'n';
char tomar_sectores = 'n';
char cadena[30];


int main(void)
{
	char temp;

	PIN_config(RE4,PORT_OUT);	// Láser 1
	PIN_config(RE5,PORT_OUT);	// Láser 2

	PIN_off(RE4);
	PIN_off(RE5);

	UART1_init(UART1_BAUDS_115200);

	INT_Init();
	TIMER1_soft_init();

	// Inicializa Timer 0 cada 10mS, recargable
	TIMER1_soft_set(0, T_timer, TIMER_AUTO_RECHARGE); 

	while(1)
	{
		if(TIMER1_soft_quest_state(0))
		{
			if(UART1_ask_n_elements_buffer_rx() > 0)
			{
				temp = UART1_receive_char();

				if(temp == 'r')
					UART1_send_char('k');
				else if(temp == 's' && enable == 'n')
				{
					enable = 's';
					PIN_on(RE4);
					en_aux1 = 's';
					en_arco1 = 's';
					if(tomar_sectores == 's')
						PIN_on(RE5);
					en_arco2 = tomar_sectores;
					en_aux2 = 'n';
				}
				else if(temp == 'p' && enable == 's')
				{
					enable = 'n';
					comienza = 'n';
					en_aux1 = 'n';
					en_arco1 = 'n';
					PIN_off(RE4);
					en_aux2 = 'n';
					en_arco2 = 'n';
					PIN_off(RE5);
				}
				else if(temp == '1' && enable == 'n')
					tomar_sectores = 'n';
				else if(temp == '2' && enable == 'n')
					tomar_sectores = 's';
				else if(temp == 'b' && enable == 'n')
				{
					mejor_S1 = 0;
					mejor_S2 = 0;
					mejor_T = 0;
				}
			}

			if(comienza == 's')
			{
				if(comienza == 's')
					cont += 1;
				if(en_aux1 == 's')
					cont2 += 1;
				if(en_aux2 == 's')
					cont1 += 1;

				if(en_aux1 == 'n' && tomar_sectores == 'n' && cont*T_timer/1000 > 2)
					en_aux1 = 's';
			}
		}
	}
}


void INT_Init(void)
{
	INTCON2 = 0x0006;       //Setup INT1 & INT2 pin to interrupt on falling edge
	IFS1bits.INT1IF = 0;    //Reset INT1 interrupt flag
	IFS1bits.INT2IF = 0;	//Reset INT2 interrupt flag

	_INT1IP = 1;
	_INT2IP = 2;

	IEC1bits.INT1IE = 1;    //Enable INT0 Interrupt Service Routine
	IEC1bits.INT2IE = 1;    //Enable INT0 Interrupt Service Routine
}

void __attribute__((__interrupt__)) _INT1Interrupt(void)
{
	if(en_arco1 == 's' && en_aux1 == 's')
	{
		if(comienza == 's')
		{
			if(en_arco2 == 's')
			{
				if((mejor_S2 != 0 && cont2*T_timer/1000 < mejor_S2) || mejor_S2 == 0)
				{
					mejor_S2 = cont2*T_timer/1000;
					sprintf(cadena, "S%.3gf", mejor_S2);
				}
				else
					sprintf(cadena, "s%.3gf", cont2*T_timer/1000);

				UART1_send_string(cadena);

				cont1 = 0;

				en_aux2 = 's';
			}

			if((mejor_T != 0 && cont*T_timer/1000 < mejor_T) || mejor_T == 0)
			{
				mejor_T = cont*T_timer/1000;
				sprintf(cadena, "T%.3gf", mejor_T);
			}
			else
				sprintf(cadena, "t%.3gf", cont*T_timer/1000);

			UART1_send_string(cadena);

			cont = 0;
		}
		else
		{
			cont = 0;
			cont1 = 0;
			comienza = 's';

			if(en_arco2 == 's')
				en_aux2 = 's';
		}

		en_aux1 = 'n';
	}

	IFS1bits.INT1IF = 0;
}

void __attribute__((__interrupt__)) _INT2Interrupt(void)
{
	if(comienza == 's' && en_arco2 == 's' && en_aux2 == 's')
	{
		if((mejor_S1 != 0 && cont1*T_timer/1000 < mejor_S1) || mejor_S1 == 0)
		{
			mejor_S1 = cont1*T_timer/1000;
			sprintf(cadena, "P%.3gf", mejor_S1);
		}
		else
			sprintf(cadena, "p%.3gf", cont1*T_timer/1000);

		UART1_send_string(cadena);

		cont2 = 0;

		en_aux1 = 's';
		en_aux2 = 'n';
	}

	IFS1bits.INT2IF = 0;
}

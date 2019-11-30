
using System;
using System.Collections.Generic;
using System.Linq;

namespace juegoIA
{
	public class ComputerPlayer: Jugador
	{
		
		public ComputerPlayer()
		{
		}
		public ArbolGeneral<int> arbol = new ArbolGeneral<int>(0);
		public bool turno = true;
		private List<int> naipes = new List<int>();
		private List<int> naipesoponente = new List<int>();
		private int limite;
		public NodoGeneral<int> nodo;
		public override void  incializar(List<int> cartasPropias, List<int> cartasOponente, int limite)
		{
			
			NodoGeneral<int> root = new NodoGeneral<int>(-1);
            this.naipes = cartasPropias;
            this.naipesoponente = cartasOponente;

            this.limite = limite;
            Creararbol(root, cartasOponente, cartasPropias, false, limite);
            this.arbol.setRaiz(root);

            Console.WriteLine();
			
			}
		public void Creararbol(NodoGeneral<int> nodopadre, List<int> a, List<int> b, bool miTurno, int tope)
        {
            for (int i = 0; i < a.Count; i++)
            {

                List<int> AuxA = Juego.copiar(a);
                int cartaAJugar = a[i];
                AuxA.Remove(cartaAJugar);
                NodoGeneral<int> Nuevohijo = new NodoGeneral<int>(cartaAJugar);
                nodopadre.setHijos(Nuevohijo);

                if (!miTurno && ((tope - cartaAJugar) < 0))
                {
                    Nuevohijo.Datsec = 1;
                }
                else
                {
                    if ((tope - cartaAJugar) == 0)
                    {
                        Nuevohijo.Datsec = 1;
                    }
                    else if ((tope - cartaAJugar) > 0)
                    {
                        Creararbol(Nuevohijo, b, AuxA, !miTurno, (tope - cartaAJugar));
                    }
                }
            }

        }
		
		public override int descartarUnaCarta()
		{
			
			int mejoropcion = -1;
            ArbolGeneral<int> nueopcion=null;
            foreach (ArbolGeneral<int> opciones in arbol.getHijos())
            {
                if (opciones.Raiz.Datpri > mejoropcion)
                {
                    nueopcion = opciones;
                    mejoropcion = opciones.Raiz.Datpri;

                }
            }
            arbol.setRaiz(nueopcion.Raiz);
            Console.WriteLine("La maquina escogio la carta " + nueopcion.getDatoRaiz());
            return nueopcion.getDatoRaiz();
			
		}
		
		public override void cartaDelOponente(int carta)
		{
			
            ArbolGeneral<int> mejor = new ArbolGeneral<int>(0);
            
			
            foreach(ArbolGeneral<int> NuevaRaiz in arbol.getHijos())
            {
                if (NuevaRaiz.getDatoRaiz() == carta)
                    arbol.setRaiz(NuevaRaiz.Raiz);
            }

            limite = limite -carta;
			
		}
		
	}
}

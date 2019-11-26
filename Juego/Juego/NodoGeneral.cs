using System;
using System.Collections.Generic;

namespace juegoIA
{
	/// <summary>
	/// Description of NodoGeneral.
	/// </summary>
	public class NodoGeneral<T>
	{
		private int datpri;
		private int datsec;
		private T dato;
		private List<NodoGeneral<T>> hijos;
		
		public NodoGeneral(T dato){		
			this.dato = dato;
			this.hijos = new List<NodoGeneral<T>>();
		}
		public int Datpri { get {return datpri;} set{ datpri = value;} }
		public int Datsec { get {return datsec;} set{ datsec = value;} }

		public T getDato(){		
			return this.dato; 
		}
		
		public List<NodoGeneral<T>> getHijos(){		
			return this.hijos;
		}

		public void setDato(T dato){		
			this.dato = dato;
		}
		
		public void setHijos(NodoGeneral<T> hijos){		
			this.hijos.Add(hijos);
		}
	
	}
}

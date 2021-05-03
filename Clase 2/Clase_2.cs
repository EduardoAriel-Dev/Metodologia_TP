using System;
using System.Collections.Generic;
using Clase_1;
using Clase_3;

//Pracitica n°2
namespace Clase_2
{
	class Program
	{	
		public static void Main(string[] args)
		{
			Console.ReadKey(true);
		}
		//Ejercicio n°7
		public static void ImprimirElemt(Coleccionable C){
			//para todos los elementos elem del coleccionable
			//imprimir(elem)
		}
	}
	//Jerarquia de Estrategia--//Ejercicio n°1
	//1)CREAR La super clase
	public interface Estrategia_Comp{ //leandro cambio todo aqui**
		bool sosIgual(Comparable a, Comparable b);
		bool sosMayor(Comparable a, Comparable b);
		bool sosMenor(Comparable a, Comparable b);
	}
	//2)CREAR las Sub-Clases
	public class porNombre : Estrategia_Comp{ 
		public bool sosIgual(Comparable a, Comparable b){
			if (((alumno)a).GetNombre().CompareTo(((alumno)b).GetNombre()) == 0)
				return true;
			else
				return false;
		}

		public bool sosMayor(Comparable a, Comparable b)
		{
			return (((alumno)a).GetNombre().CompareTo(((alumno)b).GetNombre()) == 1);
		}

		public bool sosMenor(Comparable a, Comparable b){
			return (((alumno)a).GetNombre().CompareTo(((alumno)b).GetNombre()) == -1);
		}
	}//termiado
	public class porDNI : Estrategia_Comp{
		public bool sosIgual(Comparable a, Comparable b)
		{
			return ((alumno)a).GetDni() == ((alumno)b).GetDni();
		}
		public bool sosMenor(Comparable a, Comparable b)
		{
			return ((alumno)a).GetDni() < ((alumno)b).GetDni();
		}
		public bool sosMayor(Comparable a, Comparable b)
		{
			return ((alumno)a).GetDni() > ((alumno)b).GetDni();
		}
	}//terminado
	public class porPromedio : Estrategia_Comp{
		public bool sosIgual(Comparable a,Comparable b){
			return ((alumno)a).GetPromedio() == ((alumno)a).GetPromedio();
		}
		public bool sosMenor(Comparable a, Comparable b)
		{
			return ((alumno)a).GetPromedio() < ((alumno)b).GetPromedio();
		}
		public bool sosMayor(Comparable a, Comparable b)
		{
			return ((alumno)a).GetPromedio() > ((alumno)b).GetPromedio();
		}
	}//terminado
	public class porlegajo : Estrategia_Comp{
		public bool sosIgual(Comparable a, Comparable b)
		{
			return ((alumno)a).GetLegajo() == ((alumno)b).GetLegajo();
		}
		public bool sosMenor(Comparable a, Comparable b)
		{
			return ((alumno)a).GetLegajo() < ((alumno)b).GetLegajo();
		}
		public bool sosMayor(Comparable a, Comparable b)
		{
			return ((alumno)a).GetLegajo() > ((alumno)b).GetLegajo();
		}
	}//terminado
	
	//Ejercicio n°6
	public interface Iterator{
		void Primero();
		void Siguiente();
		bool Fin();
		Iterable Actual();
	}
	public interface Iterable{
		Iterator crearIterador();
	}
	public class IteradorDeCollection : Iterator{
		private int Cont;
		private List<Comparable> Lista;
		
		public IteradorDeCollection(List<Comparable> L,int Cont){
			L= Lista;
			Cont=0;
		}
		
		public void Primero(){
			Cont=0;
		}
		public void Siguiente(){
			Cont++;
		}
		public bool Fin(){
			if (Cont>=Lista.Count) 
				return true;
			else
				return false;
		}
		public Iterable Actual(){
			return (Iterable)Lista[Cont];
		}
	}
	
	//Ejercicio n°3
	public class Conjunto : Coleccionable{
		private List<Comparable> Conjunt;
		
		public Conjunto(){
        	Conjunt = new List<Comparable>();
    	}
		
		public void push(Comparable p){
    	    Conjunt.Add(p);
    	}
    	public Comparable pop(){
        	Comparable resultado = Conjunt[Conjunt.Count-1];
        	Conjunt.RemoveAt(Conjunt.Count-1);
        	return resultado;
    	}
		
		public void agregar(Comparable C){
			for (int i = 0; i < Conjunt.Count; i++) {
				if (C != Conjunt[i]) {
					Conjunt.Add(C);
				}
			}
		}
		
		public int cuantos(){
			return Conjunt.Count;
		}
		public Comparable minimo(){
			Comparable resultado = Conjunt[0];
        	for (int x = 1; x < Conjunt.Count; x++)
        	{
            	if(Conjunt[x].sosMenor(resultado))
                	resultado = Conjunt[x];
        	}
        	return resultado;
		}
		public Comparable maximo(){
			Comparable resultado = Conjunt[0];
        	for (int x = 1; x < Conjunt.Count; x++)
        	{
            	if(Conjunt[x].sosMayor(resultado))
                	resultado = Conjunt[x];
        	}
        	return resultado;
		}
		public bool contiene(Comparable c){//es el metodo pertenece
			for (int x = 0; x < Conjunt.Count; x++){
            	if(Conjunt[x].sosIgual(c))
                	return true;
        	}
            
        	return false;
		}
		public void cambiarEst_Alumnos(Estrategia_Comp e){
			throw new NotImplementedException();
		}
	}
	//Ejercicio n°4//Ejercicio n°5
	public class ClaveValor : Comparable{
		private Comparable Clave;
		private Comparable Valor;
		
		public ClaveValor(Comparable C, Comparable V){
			Clave=C;
			Valor=V;
		}
		
		public Comparable GetClave(){
			return Clave;
		}
		public void SetValor(Comparable s){
			 Valor=s;
		}
		public Comparable GetValor(){
			return Valor;
		}
		
		public bool sosIgual(Comparable c){
			return Clave.sosIgual(c);
		}
		public bool sosMayor(Comparable c){
			throw new NotImplementedException();
		}
		public bool sosMenor(Comparable c){
			throw new NotImplementedException();
		}
		
	}
	public class Dictionary : ClaveValor , Comparable{
		private List<ClaveValor> ClV;
		private int x = 1;
		
		public Dictionary(Comparable C, Comparable V): base(C, V){
			ClV = new List<ClaveValor>();
		}
		
		public void Agregar(Comparable C,Comparable V){
			for (int i = 0; i < ClV.Count; i++) {
				if (ClV[i].sosIgual(C)){
					ClV[i].SetValor(V);
				}
				ClV.Add(new ClaveValor(C,V));
			}
		}
		
		public Comparable ValorDe(Comparable C, Comparable V){
			for (int i = 0; i < ClV.Count; i++) {
				if (ClV[i].sosIgual(C)) {
					return V;
				}
			}
				return null;
		}
		public int cuantos(){
			return ClV.Count;
		}
		public Comparable minimo(){
			Comparable resultado = ClV[0];
        	for (int x = 0; x < ClV.Count; x++){
            	if(ClV[x].sosMenor(resultado))
                	resultado = ClV[x];
        	}
        	return resultado;
		}
		public Comparable maximo(){
			Comparable resultado = ClV[0];
        	for (int x = 1; x < ClV.Count; x++)
        	{
            	if(ClV[x].sosMayor(resultado))
                	resultado = ClV[x];
        	}
        	return resultado;
		}
		public void agregar(Comparable c){
			Numero n = new Numero(x);
			x++;
			Agregar(n,c);
		}
		public bool contiene(Comparable c){
			for (int x = 0; x < ClV.Count; x++){
            	if(ClV[x].sosIgual(c))
                	return true;
        	}
            
        	return false;
		}
		public void cambiarEst_Alumnos(Estrategia_Comp e){
			throw new NotImplementedException();
		}
	}
	
	

}
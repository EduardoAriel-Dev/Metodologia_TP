using System;
using Clase_1;
using Clase_2;
using Clase_3;
using MetodologíasDeProgramaciónI;
using System.Collections.Generic;


//Practica n°4
namespace Clase_4
{
	public interface Ialumno:Comparable{
		int ResponderPregunta(int Pregunta);
		string GetNombre();
		string MostrarCalificacion();
		string SetCalificacion(int puntaje);
		int GetLegajo();
		int GetDNI();
		double GetPromedio();
		string GetCalificacion();
	}
	class Program
	{
		public static void Main(string[] args)
		{
			Console.ReadKey(true);
		}
	}
	//Ejercicio n°2
	public class AlumnoMuyEstudioso : alumno{
		public AlumnoMuyEstudioso(string nombre,int dni, int l, double p): base(nombre, dni, l, p){
		}
		
		public int ResponderPregunta(int Pregunta){
			return Pregunta % 3;
		}
		
	}
	//Ejercicio n°3----Alumno: Adaptable.
	//				   Student: Objetico.
	public class AdaptadorAlumnos : Student{
		Ialumno AL;
		public AdaptadorAlumnos(Ialumno Alum){
			AL=Alum;
		}
		
		public Ialumno GetAL(){
			return AL;
		}
		
		
		public string getName(){
			return AL.GetNombre();
		}
		public int yourAnswerIs(int question){
			return AL.ResponderPregunta(question);
		}
		public void setScore(int score){
			string puntos = AL.SetCalificacion(score);
		}
		public string showResult(){
			return AL.MostrarCalificacion();
		}
		public bool equals(Student student){
			return AL.sosIgual((Comparable)((AdaptadorAlumnos) student).GetAL());
		}
		public bool lessThan(Student student){
			return AL.sosMenor((Comparable)((AdaptadorAlumnos) student).GetAL());
		}
		public bool greaterThan(Student student){
			return AL.sosMayor((Comparable)((AdaptadorAlumnos) student).GetAL());
		}
		
	}
	//Ejercicio n°6------Componente----->Ialumno
	//					 Componente Concreto --> Alumno --> AlumnoMuyEstudioso.
	
	public abstract class Decorado : Ialumno, Comparable{
		Ialumno componente;
		
		public Decorado(Ialumno Ia){
			componente = Ia;
		}
		
		public string GetCalificacion(){
			return componente.GetCalificacion();
		}
				
		public int ResponderPregunta(int Pregunta){
			return componente.ResponderPregunta(Pregunta);
		}
		public bool sosIgual(Comparable c){
			return componente.sosIgual(c);
		}
		public bool sosMayor(Comparable c){
			return componente.sosMayor(c);
		}
		public bool sosMenor(Comparable c){
			return componente.sosMenor(c);
		}
		public string GetNombre(){
			return  componente.GetNombre();
		}
		public int GetLegajo(){
			return componente.GetLegajo();
		}
		public int GetDNI(){
			return componente.GetDNI();
		}
		public double GetPromedio(){
			return componente.GetPromedio();
		}
		
		public virtual string MostrarCalificacion(){
			return componente.MostrarCalificacion();
		}
		public string SetCalificacion(int puntaje){
			return componente.SetCalificacion(puntaje);
		}
		
		//OVERRIDE DE CALF
	}
	//Decorados
	public class Dec_Legs : Decorado{
		Ialumno componente;
		
		public Dec_Legs(Ialumno Ia) : base(Ia){
			componente = Ia;
		}
		
		public override string MostrarCalificacion(){
			string Menj_leg= base.GetCalificacion();
			return GetNombre()+"  ("+GetLegajo()+")    "+Menj_leg;
		}
	}//Decorado por legajo.//implementar comparable
	
	public class Dec_Letra : Decorado{
		Ialumno componente;
		
		public Dec_Letra(Ialumno Ia) : base(Ia){
			componente = Ia;
		}
		
		public override string MostrarCalificacion(){
			string[] Nota = {"cero","uno","dos","tres","cuatro","cinco","seis","siete","ocho","nueve","diez"};
			int dato = Int32.Parse(base.GetCalificacion());
			string Menj_let = base.GetCalificacion();
			return GetNombre()+"  "+ Menj_let +"("+Nota[dato]+")";
		}
	}//Decorado por Nota(Escrita).
	
	public class Dec_Calificacion : Decorado{
			Ialumno componente;
		
			public Dec_Calificacion(Ialumno Ia) : base(Ia){
				componente = Ia;
			}
			public override string MostrarCalificacion(){
				//int NotaNum = Int32.Parse(base.MostrarCalificacion());
				string Menj_Calf = base.GetCalificacion();
				int mejor_Calf = Int32.Parse(Menj_Calf);
				if (mejor_Calf>= 0&& mejor_Calf<4) {
					return GetNombre()+"  "+ Menj_Calf + "(Desaprobado)";
				}	//Desaprobado.
				if (mejor_Calf>=4 && mejor_Calf<7) {
				 	return GetNombre()+"  "+ Menj_Calf + "(Aprobado)";
				}	//Aprobado.
				else	
					return GetNombre()+"  "+Menj_Calf +"(Promocionado)";
					//Promocionado.
				}
			}//Decorado por Nota(Calificacion).
	
	public class Dec_Asterisco : Decorado{
		Ialumno componente;
		
		public Dec_Asterisco(Ialumno Ia) : base(Ia){
			componente = Ia;
		}
		
		public override string MostrarCalificacion(){
			string Menj_asterisco = base.MostrarCalificacion();
			return "*********************************\n" +
				   "*       "+Menj_asterisco+"      *\n" +
				   "*********************************";
		}
	}//Decorado por Asterisco.
}
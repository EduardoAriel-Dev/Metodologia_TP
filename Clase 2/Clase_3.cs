using System;
using System.Collections.Generic;
using Clase_1;
using Clase_2;


//Practica n°3
namespace Clase_3
{
	class Program
	{
		
		public static void Main(string[] args)
		{
			
			Console.ReadKey(true);
		}
		//Ejercicio n°6
		public static void LlenarUnico(Coleccionable Col,int Option){
			for (int i = 0; i < 20; i++) {
				Comparable comp = Fabrica.CrearAleatorio(Option);
				Col.agregar(comp);
			}
			for (int i = 0; i < 20; i++) {
				Comparable comp = Fabrica.CrearPorTeclado(Option);
				Col.agregar(comp);
			}
		}
		public static void InformarUnico(){
			
		}
	}
	//Ejercicio n°3
	public class GeneradorDeDatos{
		private int x;
		private int Cant;
		public GeneradorDeDatos(int Num,int C){
			x=Num;
			Cant=C;
		}
		Random Num=new Random();
		public int NumeroAleatorio(int Max){
			Console.WriteLine("Se genera un numero aleatorio entre 0 y su numero: "+Max);
			int Numero = Num.Next(0,x);
			return Numero;
		}
		public void StringAleatorio(int Cant){
			string[] nombre = {"a","ab","abc","abcd","abcde","abcdef","abcdefg","abcdefgh","abcdefghi","abcdefghij","abcdefghijk","abcdefghijkl"};
			foreach (var element in nombre) {
				if (Cant!=null || Cant!=0) {
					Console.WriteLine(nombre[Cant-1]);
				}
			}
		}
		
		
	}
	public class LectorDeDatos{
		public int NumeroPorTeclado(){
			Console.WriteLine("Igrese un numero: ");
			int x = int.Parse(Console.ReadLine());
			Console.WriteLine("Su numero es: ");
			return x;
		}
		public void StringPorTeclado(){
			Console.WriteLine("Ingrese un string por teclado:");
			string s=Console.ReadLine();
			Console.WriteLine("Su dato es el: " + s);
		}
	
	}
	//Ejercicio n°4
	public interface FabricaDeComparables{
		Comparable CrearAleatorio();
		Comparable CrearPorTeclado();
	}
	//Ejercicio n°5
	//Factory method
	public abstract class Fabrica: FabricaDeComparables {
		public static Comparable CrearAleatorio(int F){
			Fabrica Fabric = null;
			Console.WriteLine("Elija una opción para crear Fabrica: ");
			Console.WriteLine("1)Crear un Numero.\n2)Crear un Alumno.");
			int Option = int.Parse(Console.ReadLine());
			switch (Option) {
				case 1:
					Fabric = new FabricaDeNumeros();
					break;
				case 2:
					Fabric = new FabricaDeAlumnos();
					break;
				default:
					break;
			}
			return Fabric.CrearAleatorio();
		}
		public abstract Comparable CrearAleatorio();
		public static Comparable CrearPorTeclado(int F){
			Fabrica Fabric = null;
			Console.WriteLine("Elija una opción para crear Fabrica: ");
			Console.WriteLine("1)Crear un Numero.\n2)Crear un Alumno.");
			int Option = int.Parse(Console.ReadLine());
			switch (Option) {
				case 1:
					Fabric = new FabricaDeNumeros();
					break;
				case 2:
					Fabric = new FabricaDeAlumnos();
					break;
				default:
					break;
			}
			return Fabric.CrearPorTeclado();
		}
		public abstract Comparable CrearPorTeclado();
	}
	
	public class FabricaDeNumeros : Fabrica{
		Random num = new Random();
		Random leg = new Random();
		public override Comparable CrearAleatorio(){
			int x = num.Next(100);
			Numero numero = new Numero(x);
			return numero;
		}
		public override Comparable CrearPorTeclado(){
			int x= int.Parse(Console.ReadLine());
			Numero numero = new Numero(x);
			return numero;
		}
	}
	public class FabricaDeAlumnos : Fabrica{
		Random num = new Random();
		Random leg = new Random();
		Random pro = new Random();
		Random DNI = new Random();
		public override Comparable CrearAleatorio(){
			string[] nombre ={"a","b","c","d","e","f","g","h","i","j","k","l","m","n","ñ","o","p","q","r","s","t","u","v","w","x","y","z"};
			int legs = leg.Next(10000,99999);
			double p= pro.NextDouble();
			int dni = DNI.Next(10000000,99999999);
			int numero	= num.Next(26);
			p=Math.Round(p,2)*10;
			alumno l = new alumno(nombre[numero],dni,legs,p);
			return l;
		}
		public override Comparable CrearPorTeclado(){
			Console.WriteLine("Ingrese un nombre: ");
			string nombre = Console.ReadLine();
			Console.WriteLine("Ingrese el DNI: ");
			int dni = int.Parse(Console.ReadLine());
			Console.WriteLine("Ingrese su Legajo: ");
			int Legajo = int.Parse(Console.ReadLine());
			Console.WriteLine("Ingrese su Promedio: ");
			double Promedio = double.Parse(Console.ReadLine());
			alumno l = new alumno(nombre,dni,Legajo,Promedio);
			return l;
		}
	}
	
	
}
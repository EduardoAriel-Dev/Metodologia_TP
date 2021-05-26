using System;
using System.Collections.Generic;
using Clase_1;
using Clase_2;
using Clase_4;
using MetodologíasDeProgramaciónI;


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
			for (int i = 0; i < 3; i++) {
				Comparable comp = Fabrica.CrearPorTeclado(Option);
				Col.agregar(comp);
			}
		}
		public static void InformarUnico(Coleccionable Col, int Option){
			Comparable comp;
			Console.WriteLine("La coleccion tiene: "+Col.cuantos()+" elementos.");
			Console.WriteLine("El valor maximo del coleccionable es: "+Col.maximo());
			Console.WriteLine("La valor minimo del coleccinable es: "+Col.minimo());
			comp = Fabrica.CrearPorTeclado(Option);
			if (Col.contiene(comp)) {
				Console.WriteLine("El elemento esta en la lista");
			}
			else
				Console.WriteLine("El elemento no esta en la lista");
		}
		//Ejercicio n°13
		public static void JornadaDeVentas(Coleccionable Col){
			int monto;
			Random MontRandom=new Random();
			Iterator ite = (Iterator)Col.crearIterador();
			while (!ite.Fin()) {
				Vendedor ven = (Vendedor)ite.Actual();
				ite.Siguiente();
				monto= MontRandom.Next(1,7000);
				ven.Venta(monto);
			}
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
	//Ejercicio n°12
	public abstract class Observado : IObservado{
		List<IObservador> observadores = new List<IObservador>();
		
		
		
		public void AgregarObservador(IObservador O){
			observadores.Add(O);
		}
		
		public void QuitarObservador(IObservador O){
			observadores.Remove(O);
		}
		
		public void Notificar(){
			foreach (IObservador x in observadores) {
				x.Actualizar(this);
			}
		}//Pegar Grito
	}
	public interface IObservado{
		void AgregarObservador(IObservador O);
		
		void QuitarObservador(IObservador O);
		
		void Notificar();//Pegar Grito
	}
	public interface IObservador{
		void Actualizar(IObservado o);//Escucha el grito
	}
	//Ejercicio n°5
	//Factory method
	public abstract class Fabrica: FabricaDeComparables {
		public static Comparable CrearAleatorio(int F){
			Fabrica Fabric = null;
				switch (F) {
					case 1:
							Fabric = new FabricaDeNumeros();
						break;
					case 2:
							Fabric = new FabricaDeAlumnos();
						break;
					case 3:
							Fabric = new FabricaDeVendedores();
						break;
					case 4:
							Fabric = new FabricaDeStudent();
						break;
					default:
						//throw new FormatException();
						break;
				}
			return Fabric.CrearAleatorio();
		}
		public abstract Comparable CrearAleatorio();
		public static Comparable CrearPorTeclado(int F){
			Fabrica Fabric = null;
			switch (F) {
				case 1:
						Fabric = new FabricaDeNumeros();
					break;
				case 2:
						Fabric = new FabricaDeAlumnos();
					break;
				case 3:
						Fabric = new FabricaDeVendedores();
					break;
				case 4:
						Fabric = new FabricaDeStudent();
					break;
				default:
					break;
			}
			return Fabric.CrearPorTeclado();
		}
		public abstract Comparable CrearPorTeclado();
	}
	
	public class FabricaDeNumeros : Fabrica{
		private static Random num = new Random();
			
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
			private static Random num = new Random();
			private static Random leg = new Random();
			private static Random pro = new Random();
			private static Random DNI = new Random();
				
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
	//Ejercicio n°9
	public class FabricaDeVendedores : Fabrica{
		private static Random num = new Random();
		private static Random Sueldo = new Random();
		private static Random DNI = new Random();
		
		public override Comparable CrearAleatorio(){
			string[] nombre ={"a","b","c","d","e","f","g","h","i","j","k","l","m","n","ñ","o","p","q","r","s","t","u","v","w","x","y","z"};
			int Sb = Sueldo.Next(1000,9999);
			int dni = DNI.Next(10000000,99999999);
			int numero	= num.Next(26);
			Vendedor V = new Vendedor(nombre[numero],dni,Sb);
			return V;
		}
		public override Comparable CrearPorTeclado(){
			Console.WriteLine("Ingrese un nombre: ");
			string nombre = Console.ReadLine();
			Console.WriteLine("Ingrese el DNI: ");
			int dni = int.Parse(Console.ReadLine());
			Console.WriteLine("Ingrese su Sueldo: ");
			int Sueldo = int.Parse(Console.ReadLine());
			Console.WriteLine("Ingrese su Bonus(entre 0 y 1): ");
			double Bonus = double.Parse(Console.ReadLine());
			Vendedor V = new Vendedor(nombre,dni,Sueldo);
			return V;
		}
	}
	public class FabricaDeStudent : Fabrica{
		public override Comparable CrearAleatorio(){
			Ialumno decorado = (Ialumno)Fabrica.CrearAleatorio(2);
			decorado = new Dec_Legs(decorado);
			decorado = new Dec_Letra(decorado);
			decorado = new Dec_Asterisco(decorado);
			
			return (Comparable)new AdaptadorAlumnos(decorado);
		}
		public override Comparable CrearPorTeclado(){
			Comparable x=null;
			return x;
		}
	}
	//Ejercicio n°8
	public class Vendedor : Persona{
		private int sueldoBasico;
		private double Bonus=1;
		private int M;
		
		public Vendedor(string nombre,int dni,int SB):base(nombre,dni){
			sueldoBasico=SB;
		}
		
		public void Venta(int Monto){
			M= Monto;
			this.Notificar();
		}
		public int GetMonto(){
			return M;
		}
		
		public int GetSueldo(){
			return sueldoBasico;
		}
		
		public double AumentoBonus(){
			return Bonus+=0.1;
		}
		
		 public override string ToString(){
            string a = ((Vendedor)this).GetNombre();
            int b = ((Vendedor)this).GetDni();
            int c = ((Vendedor)this).GetSueldo();

            return Convert.ToString("("+a + "," + b + "," + c +")");
		}
	}
	//Ejercicio n°10
	//Lo que comparte las clases Fabrica de Vendedor y Alumno es el Nombre y Dni, y para ampliar la jerarquia de clases se podria
	//implementar una SuperClase que Genere esos datos (Aleatorios O  por teclado).

	//Ejercicio n°11
	public class Gerente : Persona,IObservador{
		private List<Vendedor> MejoresVen;
		
		public Gerente(string nombre,int dni) :base(nombre,dni){
			MejoresVen = new List<Vendedor>();
		}
		
		public void Actualizar(IObservado V){
			this.Venta(((Vendedor)V).GetMonto() ,(Vendedor)V);
		}//Escucha el grito.
		
		public void Cerrar(){
			foreach (var element in MejoresVen) {
				Console.WriteLine("La lista de los mejores vendedores es: "+element);
			}
		}
		
		public void Venta(int Monto, Vendedor ven){
			if ( Monto >= 5000) {
				MejoresVen.Add(ven);
			}
			
		}
	}
}
	

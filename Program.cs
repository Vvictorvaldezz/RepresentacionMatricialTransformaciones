/*integrantes del equipo :
VICTOR HUGO VALDEZ ROBLES
MARIA DEL ROSARIO  VALENTIN MONTIEL
JUAN PABLO  GARCIA ALCANTARA
YAZMIN CRUZ INIESTA*/
using System;
namespace hola{
    class Program{
        static void operacion(){
            int lados; //Almacena la cantidad de lados de la figura            
            Console.Write(" ¿DE CUANTOS LADOS ES TU FIGURA ? ");
            lados = Convert.ToInt32(Console.ReadLine()); // Recibe por el usuario         
            double[,] matrizFigura = new double[3, lados];// Almacena la matriz de la figura
                                                          //Ciclos anidados para pedir las coordenadas de la figura           
            for (int z = 0; z < 3; z++){// El tres es porque la matriz siempre sera de 3 filas 
                for (int y = 0; y < lados; y++){//Este ciclo va a servir para las columnas
                    // condicion para llenar de 1's si el punto en la fila es 2
                    if (z == 2){
                        matrizFigura[z, y] = 1;
                    }
                    else{
                        if (z == 0){
                            Console.Write("ingresa  X{0} : ", (y + 1));
                        }
                        else{
                            Console.Write("ingresa  Y{0} : ", (y + 1));
                        }
                        matrizFigura[z, y] = Convert.ToInt32(Console.ReadLine()); ;
                    }
                }
            }
            double[,] matrizResultado = new double[3, lados];
            double[,] matriz = new double[3, 3];           
            double puntox, puntoy;
            Boolean si = true;
            do{
                Console.Write(" ¿QUE TIPO DE TRANSFORMACION DESEA HACER ?  \n 1) TRASLACION \n 2) ROTACION\n 3) ESCALAMIENTO\n INGRESA : ");
                string tra = Console.ReadLine();
                    switch (tra){
                        case "1":
                            Console.WriteLine(" COORDENADAS DE LA TRANSFORMACION( TRASLACION)");
                            Console.Write("X : ");
                            puntox = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("");
                            Console.Write("Y : ");
                            puntoy = Convert.ToDouble(Console.ReadLine());
                            //llena el la matriz con los puntos de traslacion
                            for (int z = 0; z < 3; z++){
                                for (int y = 0; y < 3; y++){
                                    if (z == y){
                                        matriz[z, y] = 1;
                                    }
                                    else if (z == 0 & y == 2){
                                        matriz[z, y] = puntox;
                                    }
                                    else if (z == 1 & y == 2){
                                        matriz[z, y] = puntoy;
                                    }
                                    else{
                                        matriz[z, y] = 0;
                                    }
                                }
                                Console.WriteLine("\n");
                            }
                            matrizResultado = Program.multiplicacion(lados, matriz, matrizFigura);
                            Console.WriteLine(" ---------------TRASLACION---------------");
                            break;

                        case "2":
                            Console.WriteLine(" ANGULO DE LA TRANSFORMACION(ROTACION):");
                            Console.Write(" INGRESE EL ANGULO  (GRADOS) : ");
                            puntox = Convert.ToDouble(Console.ReadLine());                            
                            double angle = Math.PI * puntox / 180.0;
                            double anguloCorecto;
                            for (int z = 0; z < 3; z++){
                                for (int y = 0; y < 3; y++){
                                    if (z == 0 & y == 0){
                                        anguloCorecto = Math.Cos(angle);
                                        matriz[z, y] = anguloCorecto;
                                    }
                                    else if (z == 0 & y == 1){
                                        anguloCorecto = Math.Sin(-angle);                                        
                                        matriz[z, y] = anguloCorecto;
                                    }
                                    else if (z == 1 & y == 0){
                                        anguloCorecto = Math.Sin(angle);                                        
                                        matriz[z, y] = anguloCorecto;
                                    }
                                    else if (z == 1 & y == 1){
                                        anguloCorecto = Math.Cos(angle);
                                        matriz[z, y] = anguloCorecto;
                                    }
                                    else if (z == 2 & y == 2){
                                        matriz[z, y] = 1;
                                    }
                                    else{
                                        matriz[z, y] = 0;
                                    }
                                }
                                Console.WriteLine("\n");
                            }
                            matrizResultado = Program.multiplicacion(lados, matriz, matrizFigura);
                            Console.WriteLine(" ---------------ROTACION---------------");
                            break;

                        case "3":
                            Console.WriteLine("COORDENADAS DE LA TRANSFORMACION(ESCALAMIENTO):");
                            Console.Write("X :");
                            puntox = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("");
                            Console.Write("Y : ");
                            puntoy = Convert.ToDouble(Console.ReadLine());
                            //llena el la matriz con los puntos de traslacion
                            for (int z = 0; z < 3; z++){
                                for (int y = 0; y < 3; y++){
                                    if (z == 2 & y == 2){
                                        matriz[z, y] = 1;
                                    }
                                    else if (z == 0 & y == 0){
                                        matriz[z, y] = puntox;
                                    }
                                    else if (z == 1 & y == 1){
                                        matriz[z, y] = puntoy;
                                    }
                                    else{
                                        matriz[z, y] = 0;
                                    }
                                }
                                Console.WriteLine("\n");
                            }
                            matrizResultado = Program.multiplicacion( lados, matriz,matrizFigura);
                            Console.WriteLine(" ---------------ESCALAMIENTO---------------");
                            break;
                        default:
                            Console.WriteLine(" OPCION NO ENCONTRADA, ADIOS!!");
                            break;
                    }
                    Console.WriteLine(" MATRIZ DE  LA  FIGURA DE {0} LADOS",lados);
                    for (int z = 0; z < 3; z++){
                        for (int y = 0; y < lados; y++){
                            Console.Write(" [" + matrizFigura[z, y] + "] ");
                        }
                        Console.WriteLine("\n");
                    }

                    Console.WriteLine("\n \n MATRIZ DE LA TRANSFORMACION ");

                    for (int z = 0; z < 3; z++){
                        for (int y = 0; y < 3; y++){
                            Console.Write(" [" + matriz[z, y] + "] ");
                        }
                        Console.WriteLine("\n");
                    }

                    Console.WriteLine("\n \n RESULTADO");

                    for (int z = 0; z < 3; z++){
                        for (int y = 0; y < lados; y++){
                            Console.Write(" [" + matrizResultado[z, y] + "] ");
                        }
                        Console.WriteLine("\n");
                    }
                    si = false;
                }
                else{                    
                    Console.WriteLine("OPCION NO ENCONTRADA, ¡INTENTA DE NUEVO!");
                    si = true;
                }                
            } while (si==true);            
        }
        static void Main(string[] args){
            Console.WriteLine("");
            Console.WriteLine("----------REPRESENTACION MATRCIAL DE COORDENADAS BIDIMENCIONALES---------");
            Boolean a = true;
            do{
                operacion();
                Console.WriteLine("\n \n");
                Console.Write(" ¿ QUIERE HACER OTRA TRANSFORMACION ?  \n 1 ) SI \n RESPONDE : ");
                string tra = Console.ReadLine();
                if (tra=="1"){
                    a = true;
                }
                else{
                    a = false;
                }
            } while (a==true);
        }

        static double[,] multiplicacion(int lados, double [,] matriz, double[,] matrizFigura){
            double[,] matrizResultado= new double[3, lados];
            Console.WriteLine("---------------OPERACIONES QUE SE HICIERON PARA CALCULAR EL RESULTADO-------------");
            for (int z = 0; z < 3; z++)
            {
                for (int y = 0; y < lados; y++)
                {
                    Console.Write(" [");
                    for (int tres = 0; tres < 3; tres++)
                    {
                        matrizResultado[z, y] += matriz[z, tres] * matrizFigura[tres, y];
                        Console.Write("(" + matriz[z, tres] + "*" + matrizFigura[tres, y] + ")+");
                    }
                    Console.Write(" ] ");
                }
                Console.WriteLine("\n");
            }
            return matrizResultado;
        }
    }
}

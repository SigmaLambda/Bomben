﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Bomben
{
    static class Importer
    {
        
        //Metod som läser in textfiler med odds för Bomben
        public static int[,] importBomben( )
        {
            int[,] bombenIntStats;

            //try
            //{
            
                //Hämta filnamn
                Console.WriteLine("Skriv in namnet på textfil: ");
                string fileName = Console.ReadLine().ToUpper();


                //Nytt objekt som läser in filen
                string pathFile = @"C:\Users\Christer\Desktop\Bomben\" +fileName;
                //string pathFile = @"C:\Users\Erik\Desktop\Bomben\" +fileName;
                System.IO.StreamReader bombenFile =  new System.IO.StreamReader( pathFile );
            
            
                string line;
                int counter = 0;
                //Gå igenom filen för att se antal rader
                while( ( line = bombenFile.ReadLine() )  != null )
                {
                    counter++;
                }
            
                //Flytta tillbaka till filens början
                bombenFile.BaseStream.Seek(0, SeekOrigin.Begin );
                bombenFile.DiscardBufferedData();
            

                int kolumn = 0;
                int rad = 0;
                string delimiterstring = ";,"; //delare
                char[] delimiters = delimiterstring.ToArray(); //Omständigt sätt att skapa en charArray initialiserad
                string[] tempString = null; 
                string[,] bombenStats = new string[counter, 7];
            
                //Läs in filen, skippa första raden. 
                while( ( line = bombenFile.ReadLine() ) != null )
                {
                    //Skippa första raden
                    if(rad > 0)
                    {
                        //separera saker i raden
                        tempString = line.Split(delimiters);
                        foreach( string str in tempString )
                        {
                            bombenStats[rad-1,kolumn++] = str;
                            //DeubugPrint
                            if(rad<10)
                            {
                                Console.WriteLine(str);
                            }
                            
                        }
                                        
                    }
                    rad++;
                    kolumn=0;
                }
            
                //Stäng filen så andra kan använda den
                bombenFile.Close();


                bombenIntStats = new int[counter, 7];
                //Gör om alla till int
                for( int nyaRader=0 ; nyaRader < counter ; nyaRader++ )
                {
                    for( int nyaKolumner=0 ; nyaKolumner < 7 ; nyaKolumner++ )
                    {
                        bombenIntStats[ nyaRader, nyaKolumner ] = Convert.ToInt32( bombenStats[ nyaRader, nyaKolumner ] );
                        //DebugPrint
                        if( nyaRader < 10 )
                        {
                            Console.WriteLine( bombenIntStats[ nyaRader, nyaKolumner ] );
                        }
                    }
                
                }

                return bombenIntStats;
                
            //}
            /*catch (Exception e) 
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
                //fullösning för att få ett returvärde
                bombenIntStats = new int[ 1, 7 ];
                return bombenIntStats;
            }
            */
            
        }
    }
}
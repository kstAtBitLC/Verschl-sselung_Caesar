using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verschlüsselung_Caesar {
    class Program {
        static void Main ( string [] args ) {
            int offset = 3;
            string ergebnis = Encrypt ( "ZZ TOP", offset );
            Console.WriteLine ( "Ergebnis Verchlüsselung {0}", ergebnis );

            string ergebnisDecrypt = Decrypt ( ergebnis, offset );
            Console.WriteLine ( "Entschlüsselt {0}", ergebnisDecrypt );

            Console.ReadLine ();
        }


        // Entschlüsselung
        public static string Decrypt ( string encryptedText, int offset ) {
            char [] encryptedTextArray = encryptedText.ToUpper ().ToArray ();
            char [] plainTextArray = new char [ encryptedText.Length ];
            char [] vergleichsArray = new char [ 26 ];
            int beginnAlphabet = 65;
            int anzahlBuchstaben = 26;

            // Erzeuge ein, vom Schlüssel abhängiges, Vergleichsarray
            for ( int i = 0 ; i < vergleichsArray.Length ; i++ ) {
                if ( i + offset < anzahlBuchstaben ) {
                    vergleichsArray [ i ] = ( char ) ( i + beginnAlphabet + offset );
                }
                else {
                    vergleichsArray [ i ] = ( char ) ( i + beginnAlphabet + offset - anzahlBuchstaben );
                }
            }

            // Ausgabe Vergleichsarray
            for ( int i = 0 ; i < vergleichsArray.Length ; i++ ) {
                Console.WriteLine ( "index: {0} : {1}", i, vergleichsArray [ i ] );
            }
            Console.WriteLine ();

            // Die eigentliche Entschlüsselung
            int position;
            for ( int i = 0 ; i < encryptedText.Length ; i++ ) {
                if ( encryptedText [ i ] >= 'A' && encryptedText [ i ] <= 'Z' ) {
                    position = Array.IndexOf ( vergleichsArray, encryptedText [ i ] );
                    if ( position - offset >= 0 ) {
                        plainTextArray [ i ] = vergleichsArray [ position - offset ];
                    }
                    else {
                        plainTextArray [ i ] = vergleichsArray [ anzahlBuchstaben + position - offset ];
                    }
                }
            }
            return new string ( plainTextArray );
        }

        // Verschlüsselung
        public static string Encrypt ( string plainText, int offset ) {
            char [] charArray = plainText.ToUpper ().ToArray ();

            for ( int i = 0 ; i < charArray.Length ; i++ ) {
                if ( charArray [ i ] >= 'A' && charArray [ i ] <= 'Z' ) {
                    charArray [ i ] = ( char ) ( ( ( ( int ) charArray [ i ] - 65 + offset ) % 26 ) + 65 );
                }
            }
            return new string ( charArray );
        }
    }
}

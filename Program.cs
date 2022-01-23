using System;

namespace note_to_hz
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Note to Hz";
            double RPR = 440; //Reference Pitch given by user input.
            double RPU = RPR * Math.Pow(0.5, 4); //Reference Pitch used in calculations;

            double[] notesHz = new double[13];
            string[] notes = {"C", "C#", "D", "D#","E", "F", "F#", "G", "G#", "A", "A#", "B"};

            Início:
            Console.SetWindowSize(50, 5);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Note ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("to ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Hz\n");

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Reference Pitch: " + RPR + "Hz (Input 'R' to change)");

            Console.WriteLine("Input note and octave ('A4', for example):");
            
            string noteOctave = Console.ReadLine();
            noteOctave = noteOctave.ToUpper();

            if(noteOctave == "R")
            {
                Console.Clear();
                Console.Write("Input Reference Pitch (in Hz): ");
                RPR = Convert.ToDouble(Console.ReadLine());
                RPU = RPR * Math.Pow(0.5, 4);
                Console.Clear();
                goto Início;
            }

            bool isLetter = Char.IsLetter(Convert.ToChar(noteOctave.Substring(0, 1)));
            bool isDigit = Char.IsDigit(Convert.ToChar(noteOctave.Substring(noteOctave.Length - 1)));

            if (isLetter == true && isDigit == true) {}
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong input. Please input a note and a octave number ('C3', or 'G#2', for example)\n");
                Console.ResetColor();
                goto Início;
            }

            string note = SeparatorNote(noteOctave);

            
            int octave = Convert.ToInt32(SeparatorOctave(noteOctave));

            int noteEquivalent = Array.IndexOf(notes, note) + 1;

            double diffFromA = noteEquivalent - 10;

            double dividerThing = diffFromA / 12;

            notesHz[11] = RPU * Math.Pow(2, octave);


            double result = notesHz[11] * (Math.Pow(2, dividerThing));

            Console.SetWindowSize(50, 3);

            Console.Write("\n"+noteOctave+" = " + Math.Round(result, 2) + "\n");

            Console.WriteLine("Press R to restart, Enter to exit.");

            Ending:
            if (Console.ReadKey().Key == ConsoleKey.R)
            {
                Console.Clear();
                goto Início;
            }
            else if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                goto RealEnding;
            }
            else if (Console.ReadKey().Key != ConsoleKey.R && Console.ReadKey().Key == ConsoleKey.Enter)
            {
                Console.WriteLine("Well, no command for that...");
                goto Ending;
            }
            RealEnding:
            {}
            
            
        
        }

        public static string SeparatorNote(string noteOctave)
        {  
            if (noteOctave.Length == 2) 
            {
                return noteOctave.Substring(0, 1);
            }
            else if (noteOctave.Length == 3)
            {
                return noteOctave.Substring(0, 2);
            }
            else
            {
                return noteOctave;
            }
        }
        public static string SeparatorOctave(string noteOctave)
        {
            return noteOctave.Substring(noteOctave.Length - 1);
        }

    }
}

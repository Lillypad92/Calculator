using static System.Console;

/*Individuell uppgift 1: 
 * skapa en miniräknare som tar tal och matematiska operator från användare via konsol. Varje resultat ska sparas i en lista. 
 * Kopiera pseudo koden som innehåller instruktioner, klistra in i ditt projekt och följa den under kodande. 
 * Analysera och utvärdera gränssnitt, designmönster och lösningar i din kod och föreslå vidare utökningar. 
 * 
Innehållet:
[x]  Välkomnande meddelande. 
[x]	En lista för att spara historik för räkningar.
[x]	Användaren matar in tal och matematiska operation.
[x]	OBS! Användaren måste mata in ett tal för att kunna ta sig vidare i programmet!
[x]	Ifall användaren skulle dela 0 med 0 visa Ogiltig inmatning!
[x]	Lägga resultat till listan.
[x]	Visa resultat. 
[x]	Fråga användaren om den vill visa tidigare resultat. 
[x]	Visa tidigare resultat. 
[x]	Fråga användaren om den vill avsluta eller fortsätta.
*/



namespace LindasCalylator
{
    public class Calculator
    {
        List<string> _savedResult = new List<string>();
        public enum OPERATORS
        {
            NONE,
            ADD,
            SUB,
            MUL,
            DIV,
        }

        public Calculator() { }

        public void Run()
        {
            WriteLine("Välkommen till Lindas miniräknare! Här kan du beräkna matematiska tal.");

            while (true)
            {
                switch (Menu())
                {
                    case 1:
                        double firstNumber = GetNumber();
                        OPERATORS currentOperator = Calculation();
                        double secondNumber = GetNumber();
                        Result(currentOperator, firstNumber, secondNumber);
                        if (ShouldExit()) return;
                        break;
                    case 2:
                        ShowResult();
                        Thread.Sleep(1000);
                        WriteLine();
                        break;
                    case 3:
                        ForegroundColor = ConsoleColor.Red;
                        WriteLine("Programmet kommer avslutas..");
                        return;
                }
            }
        }
        private int Menu()
        {
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine();
            WriteLine("Huvudmeny - Kalkylator");
            WriteLine("Vänligen välj ett alternativ (1 - 3)");
            WriteLine("1. Beräkna");
            WriteLine("2. Visa tidigare resultat");
            WriteLine("3. Avsluta programmet");
            ForegroundColor = ConsoleColor.Cyan;
            Write("Menyval: ");
            int menuChoice = int.Parse(ReadLine());
            
            while (menuChoice <= 0 || menuChoice > 3)
            {
                WriteLine();
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Ogiltigt menyval, försök igen!");
                ForegroundColor = ConsoleColor.Cyan;
                Write("Menyval: ");
                menuChoice = int.Parse(ReadLine());
                ForegroundColor = ConsoleColor.White;
            }

            return menuChoice;
        } // Huvudmeny metod
        //Result
        private void Result(OPERATORS currentOperator, double firstNumber, double secondNumber)
        {
            
            double mathResult;
            if (currentOperator == OPERATORS.ADD)
            {
                mathResult = (firstNumber + secondNumber);
                ForegroundColor = ConsoleColor.Blue;
                WriteLine();
                WriteLine($"Resultat: {firstNumber} + {secondNumber} = {mathResult}");
                _savedResult.Add($"{firstNumber} + {secondNumber} = {mathResult}");
            }
            else if (currentOperator == OPERATORS.SUB)
            {
                mathResult = (firstNumber - secondNumber);
                ForegroundColor = ConsoleColor.Blue;
                WriteLine();
                WriteLine($"Resultat: {firstNumber} - {secondNumber} = {mathResult}");
                _savedResult.Add($"{firstNumber} - {secondNumber} = {mathResult}");
            }
            else if (currentOperator == OPERATORS.MUL)
            {
                mathResult = (firstNumber * secondNumber);
                ForegroundColor = ConsoleColor.Blue;
                WriteLine();
                WriteLine($"Resultat: {firstNumber} * {secondNumber} = {mathResult}");
                _savedResult.Add($"{firstNumber} * {secondNumber} = {mathResult}");
            }
            else if (currentOperator == OPERATORS.DIV)
            {
                if (firstNumber == 0 && secondNumber == 0)
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("Ogiltig inmatning!");
                    ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    mathResult = (firstNumber / secondNumber);
                    ForegroundColor = ConsoleColor.Blue;
                    WriteLine();
                    WriteLine($"Resultat: {firstNumber} / {secondNumber} = {mathResult}");
                    _savedResult.Add($"{firstNumber} / {secondNumber} = {mathResult}");
                }
            }
            else
            {
                WriteLine("Nu blev det lite tokigt...");
            }

            
        } // Här är metoden för att visa resultat, som sedan anropas i Menu metoden som körs i Run. 

        private void ShowResult()
        {
            WriteLine();
            if (_savedResult.Count == 0)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Det finns inget resultat som är sparat.");
                ForegroundColor = ConsoleColor.White;
                return;
            }

            foreach (string items in _savedResult)
            {
                ForegroundColor = ConsoleColor.Blue;
                WriteLine($"Resultat: {items}");
                ForegroundColor = ConsoleColor.White;
            }
        } //Frågar användaren om den vill visa tidigare resultat samt visar resultat.

        private bool ShouldExit() // Frågar användaren om användaren vill fortsätta eller avsluta programmet.
        {
            while (true)
            {
                WriteLine();
                ForegroundColor = ConsoleColor.Yellow;
                WriteLine("Vill du avsluta programmet (Ja / Nej)");
                Write("Ditt svar: ");
                string userInput = ReadLine().ToLower();
                ForegroundColor = ConsoleColor.White;
                
                if (userInput == "ja")
                {
                    WriteLine();
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("Programmet kommer att avslutas!");
                    Thread.Sleep(3000);
                    Clear();
                    return true;
                }
                else if (userInput == "nej")
                {
                    ForegroundColor= ConsoleColor.Cyan;
                    WriteLine();
                    WriteLine("Du har valt att fortsätta, huvudmenyn visar sig strax.");
                    Thread.Sleep(4000);
                    Clear();
                    return false;

                }
                else
                {
                    WriteLine();
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("Du har angett ej ett korrekt svar, du kommer få frågan igen om du vill fortsätta.");
                    Thread.Sleep(2000);
                    continue;
                }
            }
        }

        private double GetNumber()
        {
            Thread.Sleep(1000);
            while (true)
            {
                WriteLine();
                ForegroundColor = ConsoleColor.Cyan;
                Write("Skriv in ett tal: ");
                double userNumber;

                if (double.TryParse(ReadLine(), out userNumber))
                {

                    return userNumber;

                }
                else
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("Ogiltig inmatning, du ska skriva ett tal. Försök igen!");
                    ForegroundColor = ConsoleColor.White;
                    continue;
                }

            }

        } // Frågar användaren efter matematiska tal.
        private OPERATORS GetMathOperator(int userChoice) // Matematiska operatorer: OPERATORS är enum. Matematiska operatorn åker in i metoden Calculation.  
        {
            switch (userChoice)
            {

                case 1: return OPERATORS.ADD;
                case 2: return OPERATORS.SUB;
                case 3: return OPERATORS.MUL;
                case 4: return OPERATORS.DIV;
                default: return OPERATORS.NONE;

            }

        }
        private OPERATORS Calculation() // Metoden returnerar en operator, hämtar en operator från metoden GetMathOperator. OPERATORS är enum.
        {
            while (true) 
            {
                WriteLine();
                Thread.Sleep(1000);
                ForegroundColor = ConsoleColor.Yellow;
                WriteLine("Välj en matematisk operator med knappval (1 - 4)");
                WriteLine("1 = + (Addition)");
                WriteLine("2 = - (Subtraktion)");
                WriteLine("3 = * (Multiplikation)");
                WriteLine("4 = / (Division)");
                ForegroundColor = ConsoleColor.Cyan;
                Write("Val av operator: ");
                int userChoice;
                if (int.TryParse(ReadLine(), out userChoice))
                {

                }
                else
                {
                    WriteLine();
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("Du har ej angett ett korrekt menyval, försök igen.");
                    continue;
                }
                while (userChoice < 1 || userChoice > 4)
                {
                    WriteLine();
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("Du har ej angett ett korrekt menyval, försök igen. (1 - 4)");
                    ForegroundColor = ConsoleColor.Cyan;
                    Write("Val av operator: ");
                    int.TryParse(ReadLine(), out userChoice);
                    ForegroundColor = ConsoleColor.White;
                }
                OPERATORS currentOperator = GetMathOperator(userChoice);
                return currentOperator;
            }
        }
    }
}


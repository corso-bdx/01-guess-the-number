
// === GUESS THE NUMBER ===
// Genera un numero casuale segreto tra 1 e 100, il giocatore
// dovrà indovinare il numero entro un massimo di 6 tentativi.
//
// Ad ogni tentativo, il computer aiuta il giocatore indicandogli
// se il numero che ha provato ad indovinare è maggiore o minore.
//
// Al termine del gioco, viene stampato un messaggio diverso
// in base al numero di tentativi impiegati.
//
// Note:
// - Gestire input non validi
// - Gestire chiusura del terminale (con CTRL + C)
// ========================



// === Configurazione ===

const int NumeroMassimoTentativi = 6;

string[] MessaggioPerTentativi = new string[] {
    "che fortuna!",
    "impressionante!",
    "ottimo!",
    "complimenti.",
    "buono.",
    "ci è mancato poco...",
};



// === Gioco ===

// numero casuale tra 1 (incluso) e 101 (escluso, ovvero 100)
int numeroSegreto = Random.Shared.Next(1, 101);

int tentativiRimanenti = NumeroMassimoTentativi;
Console.WriteLine($"Indovina il numero segreto, hai {tentativiRimanenti} tentativi.");

bool numeroIndovinato = false;
while (tentativiRimanenti > 0) {
    // legge un numero da console
    Console.Write("Inserire un numero da 1 a 100: ");
    string? input = Console.ReadLine();

    // input è null se il giocatore chiude il terminale con "CTRL + C"
    if (input == null) {
        // stampa riga vuota
        Console.WriteLine();

        // break interrompe il ciclo while
        break;
    }

    // verifica se il valore inserito è un numero valido
    bool isNumber = int.TryParse(input, out int parsed);
    if (!isNumber || parsed < 1 || parsed > 100) {
        Console.WriteLine("Il valore inserito non è un numero valido.");

        // continue torna all'inizio del ciclo while
        continue;
    }

    // decrementa il numero di tentativi rimanenti
    tentativiRimanenti = tentativiRimanenti - 1;

    if (numeroSegreto == parsed) {
        numeroIndovinato = true;

        // break interrompe il ciclo while
        break;
    }

    if (tentativiRimanenti > 0) {
        if (numeroSegreto > parsed) {
            Console.WriteLine($"Il numero segreto è maggiore di {parsed}...");
        } else if (numeroSegreto < parsed) {
            Console.WriteLine($"Il numero segreto è minore di {parsed}...");
        }
    } else {
        Console.WriteLine($"Hai esaurito i tentativi...");
    }
}

if (numeroIndovinato) {
    int numeroDiTentativi = NumeroMassimoTentativi - tentativiRimanenti;
    string messaggio = MessaggioPerTentativi[numeroDiTentativi];
    Console.WriteLine($"Hai indovianato il numero segreto in {numeroDiTentativi} tentativi, {messaggio}");
} else {
    Console.WriteLine($"Il numero segreto era {numeroSegreto}.");
}

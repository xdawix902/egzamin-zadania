using System.Collections.Generic;
namespace Project;

class Program
{
    static bool CzyPierwsza(uint liczba){
        for(int i = 2; i < liczba; i++){
            if(liczba % i == 0) return false;
        }
        return true;
    }
    static ulong A1(uint[] T){
        ulong suma = 0;
        foreach(uint liczba in T){
            if(CzyPierwsza(liczba)) suma += liczba;
        }
        return (suma > 0) ? suma : 1;
    }
    
    static uint A2(int liczba){
        liczba = (liczba < 0) ? (-1)*liczba:liczba;
        return (liczba < 7) ? (uint)liczba : A2(liczba/2);
    }
    static bool CzySamogloska(char slowo){
        char[] samo = new char[]{'a','e','o','u','i'};   
        foreach(char c in samo){
            if(slowo == c){
                return false;
            }
        }
        return true;
    }
    static bool CzyDodac(string slowo){
        if(slowo.Length <= 1) return false;
        int samogloski = 0;
        int spolgloski = 0;
        foreach(char c in slowo){
            if(CzySamogloska(c)) samogloski += 1;
            else spolgloski += 1;
        }
        return (spolgloski >= samogloski) ? true : false;
    }
    static bool CzyLitera(char a){
        return ((a >= 'a' && a <= 'z') || (a >= 'A' && a <='Z')) ? true :false;
    }
    static uint A3(string napis){
        List<string> Wyrazy = new List<string>();
        string aktualne = "";
        foreach(char s in napis){
            if(CzyLitera(s)) aktualne += s;
            else{
                Wyrazy.Add(aktualne);
                aktualne = "";
            }
        }
        uint suma = 0;
        foreach(string s in Wyrazy){
            if(CzyDodac(s)) suma +=1;
        }
        return suma;
    }
    static ulong A4(ulong dane){
        ulong maska =0b1111 << 7;
        ulong wartoscNaBitach7Do10 = (dane & maska) >> 7;

        wartoscNaBitach7Do10 = (wartoscNaBitach7Do10 + 1) %16;

        dane &= ~maska;
        dane |= (wartoscNaBitach7Do10 << 7);
        return dane;
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        //System.Console.WriteLine(CzyPierwsza(5));
        System.Console.WriteLine(A2(-123));
    }
}

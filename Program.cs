
using System.Runtime.InteropServices;

static char[,] generar(char[,] ftab)
{
    for (int i = 0; i < ftab.GetLength(0); i++)
    {
        for (int j = 0; j < ftab.GetLength(1); j++)
        {
            ftab[i, j] = '~';
        }
    }
        return ftab;
}
static void imprimir(char[,] ftab)
{
    Console.WriteLine();
    for (int i = 0; i < ftab.GetLength(0); i++)
    {
        //Console.Write(i);
        for (int j = 0; j < ftab.GetLength(1); j++)
        {
            Console.Write($"{ftab[i,j]} ");
        }
        Console.WriteLine();
    }
}

static bool puedeposicion(char[,] ftab, int pdcol, int pdfil, int pdbarco, int pdoff_col, int pdoff_fil)
{
    int  pdsigfil = 0, pdsigcol = 0;
    
    pdsigcol = pdcol + pdoff_col;
    pdsigfil = pdfil + pdoff_fil;

    for (int i = 1; i>pdbarco;i++)
    {
        Console.WriteLine(i);
        if (ftab[pdsigcol, pdsigfil] != '~' ||pdsigcol >= ftab.GetLength(0)  || pdsigfil >= ftab.GetLength(1) )

//ftab[pdsigcol,pdsigfil] != '~' || 
        {
            return false;
        }
        //else if (pdcol == )
        else
        {
            pdsigfil += pdoff_fil;
            pdsigcol += pdoff_col;
        }

    }
    return true;
}

static void posiscionar(char[,]ftab, int pcol, int pfil, int pbarco, int poffcol, int pofffil)
{

   
    if (puedeposicion(ftab, pcol, pfil, pbarco, poffcol, pofffil)==true)
    {
        for (int i = 0; i < pbarco;i++)
        {
            ftab[pcol, pfil] = 'B';

            pcol = pcol + poffcol;
            pfil = pfil + pofffil;
        }
    }
    else
    {
        
    }
}

static void tablerorandom(char[,] rtab, int rbarco)
{
    Random rpos = new Random(), rdir = new Random();
    //rpos.Next(0, 20);
    int rcol = 0, rfil = 0, dir = 0;
    int offsetcol = 0 , offsetfil = 0;

    do
    {
        rcol = rpos.Next(0, 19);
        rfil = rpos.Next(0, 19);
        dir = rdir.Next(0, 2);
        offsetcol = 0;
        offsetfil = 0;

        switch (dir)
        {
            case 0:
                offsetcol = 1;
                break;
            case 1:
                offsetfil = 1;
                break;
         
        }

        posiscionar(rtab, rcol, rfil, rbarco, offsetcol, offsetfil);

    } while (puedeposicion(rtab, rcol, rfil, rbarco, offsetcol, offsetfil) == false); 
    
}

int tam = 20;
char[,] tab = new char[tam, tam];
char[,] utab = new char[tam, tam];

generar(tab);
generar(utab);

for (int i =1; i <= 3; i++)
{
    for (int j = 0; j < 3; j++)
    {
        tablerorandom(tab, 1);
    }
    for (int j = 0; j < 3; j++)
    {
        tablerorandom(tab, 2);
    }
 
}

int intentos = 5, ufila, ucolumna, puntos = 0;

Console.WriteLine("==== battleship ====");


for (int i = 0; i < intentos; i++)
{

    imprimir(utab);

    Console.WriteLine($"intentos restantes = {intentos}");
    Console.WriteLine($"seleccione una coordenada a atacar \n seleccionar columnas (0~{tam-1} columnas)");
    int.TryParse(Console.ReadLine(), out ucolumna);

    Console.WriteLine($"seleccionar fila (0~{tam-1} filas)");
    int.TryParse(Console.ReadLine(), out ufila);
     if (tab[ufila,ucolumna]=='B')
    {
        Console.WriteLine("barco golpeado");
        puntos += 5;
    }
     else
    {
        Console.WriteLine("fallo");
    }
    tab[ufila, ucolumna] = 'X';
    utab[ufila, ucolumna] = 'X';

    intentos--;
    Console.ReadLine();
    Console.Clear();
}
Console.WriteLine("tablero generado\n");

imprimir(tab);

Console.WriteLine($"fin del juego\n punteo final{puntos}");
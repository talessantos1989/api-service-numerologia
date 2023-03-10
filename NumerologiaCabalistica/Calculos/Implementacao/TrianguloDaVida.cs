using NumerologiaCabalistica.Data;
using NumerologiaCabalistica.Models.MapaRelatorio;
using NumerologiaCabalistica.Models.TextosNumericos;
using NumerologiaCabalistica.Util;
using System.Collections;
using System.Drawing;
using System.Linq;

namespace NumerologiaCabalistica.Calculos.Implementacao;

internal class TrianguloDaVida
{
    private ParametroCalculoNumerologia _parametroCalculo;
    private NumerologiaCabalisticaDbContext _context;
    TrianguloDaVidaModel trianguloDaVida = new TrianguloDaVidaModel();
    List<int> valoresDoNome = new List<int>();
    List<int> valoresSubtraidos = new List<int>();
    List<int> sequencialNumerico = new List<int>();

    public TrianguloDaVida(ParametroCalculoNumerologia parametroCalculo, NumerologiaCabalisticaDbContext context)
    {
        this._parametroCalculo = parametroCalculo;
        this._context = context;
    }

    public TrianguloDaVidaModel CalcularTrianguloDaVida()
    {
        trianguloDaVida.Arcanos = new List<Arcano>();
        trianguloDaVida.ArcanoAtual = new Arcano();
        trianguloDaVida.SequenciasNegativas = new List<SequenciaNegativa>();

        List<TextoNumericoModel> textosSequenciaNegativa = _context.TextoNumerico.Where(x => x.CategoriaId == trianguloDaVida.SequenciaNegativaCategoriaId).ToList();
        List<TextoNumericoModel> textosArcanos = _context.TextoNumerico.Where(x => x.CategoriaId == trianguloDaVida.ArcanoCategoriaId).ToList();
       
        string nomeCompleto = _parametroCalculo.NomeCompleto.ToUpper();
        int idade = CalcularIdade(trianguloDaVida);
        var tabelaConversao = MetodosDeExtensao.GetValoresTabelaConversao();



        //pegar só as letras e valores correspondentes ao nome
        for (int i = 0; i < nomeCompleto.Length; i++)
        {
            int valor = 0;

            if (tabelaConversao.ContainsKey(nomeCompleto[i].ToString()))
            {
                //Console.Write(nomeCompleto[i].ToString() + " ");
                tabelaConversao.TryGetValue(nomeCompleto[i].ToString(), out valor);
                valoresDoNome.Add(valor);
            }
        }
       
        PreencheArcanos(trianguloDaVida, textosArcanos, valoresDoNome, nomeCompleto, idade);
        



        int count = 0;

        for (int i = 0; i < valoresDoNome.Count - 1; i++)
        {
            int numero = int.Parse(valoresDoNome[i].ToString() + valoresDoNome[i + 1].ToString());
            trianguloDaVida.Arcanos.Add(new Arcano
            {
                Numero = numero,
                Texto = textosArcanos.FirstOrDefault(texto => texto.Numero == numero).Texto
            });
        }

        count = valoresDoNome.Count;
        //Console.WriteLine();

        //preenche a 2 (segunda) linha do triangulo o valores de cada letra
        if (count == valoresDoNome.Count)
        {

            //preenche a segunda linha com os valores
            for (int i = 0; i < count; i++)
            {
                //Console.Write(valoresDoNome[i] + " ");
                valoresSubtraidos.Add(valoresDoNome[i]);
            }

            count--;
        }

        SequenciaNevativa(trianguloDaVida, valoresSubtraidos, sequencialNumerico, textosSequenciaNegativa);


        Console.WriteLine();
        string espaco = string.Empty;


        //preenche o restante das linhas
        while (valoresDoNome.Count > 1)
        {
            valoresSubtraidos = new List<int>();
            espaco += " ";
            Console.Write(espaco);

            for (int a = 0; a < count; a++)
            {
                int valor = MetodosDeExtensao.ReduzirAUmAlgarismo(valoresDoNome[a] + valoresDoNome[a + 1], true);
                //Console.Write(valor + " ");
                valoresSubtraidos.Add(valor);


            }

            //Tem sequencia repetida maior que 3
            SequenciaNevativa(trianguloDaVida, valoresSubtraidos, sequencialNumerico, textosSequenciaNegativa);

            valoresDoNome.Clear();
            sequencialNumerico.Clear();
            valoresDoNome = valoresSubtraidos;
            //Console.WriteLine();
            count--;
        }

        trianguloDaVida.ArcanoTrianguloDaVida = valoresSubtraidos[0];

        //Calcular periodo dominio do arcano
        List<double> idadesArcano = new List<double>();
        double idadeArcano = 0;
        for (int i = 0; i <= trianguloDaVida.Arcanos.Count(); i++)
        {
            idadeArcano = Math.Round(idadeArcano + trianguloDaVida.PeriodoArcano,2);
            idadesArcano.Add(idadeArcano);
        }

        int index = Convert.ToInt32(Math.Ceiling(idade / trianguloDaVida.PeriodoArcano));
        trianguloDaVida.IdadeArcano = Convert.ToInt32(idadesArcano[index-1]);
        

        return trianguloDaVida;
    }

    private static void PreencheArcanos(TrianguloDaVidaModel trianguloDaVida, List<TextoNumericoModel> textosArcanos, List<int> valoresDoNome, string nomeCompleto, int idade)
    {
        double periodo = nomeCompleto.Replace(" ", "").Length - 1;
        trianguloDaVida.PeriodoArcano = Math.Round(90 / periodo,2);

        //-1 porque o array começa com 0, logo é na posição 7
        double arcanoAtual = Math.Ceiling(idade / trianguloDaVida.PeriodoArcano) - 1;
        int arcanoNumero = int.Parse(arcanoAtual.ToString());
        string arcano = valoresDoNome[arcanoNumero].ToString() + valoresDoNome[arcanoNumero + 1].ToString();

        trianguloDaVida.ArcanoAtual.Numero = int.Parse(arcano);
        trianguloDaVida.ArcanoAtual.Texto = textosArcanos.FirstOrDefault(texto => texto.Numero == trianguloDaVida.ArcanoAtual.Numero).Texto;
    }

    private int CalcularIdade(TrianguloDaVidaModel trianguloDaVida)
    {
        //preencher com a idade o consulente
        int idade = DateTime.Now.Year - _parametroCalculo.DataDeNascimento.Year;

        if (DateTime.Now.DayOfYear < _parametroCalculo.DataDeNascimento.DayOfYear)
            idade -= 1;

        trianguloDaVida.Idade = idade;
        return idade;
    }

    private static void SequenciaNevativa(TrianguloDaVidaModel trianguloDaVida, List<int> valoresSubtraidos, List<int> sequencialNumerico, List<TextoNumericoModel> textosSequenciaNegativa)
    {
        string sequencia = string.Empty;
        for (int i = 1; i < valoresSubtraidos.Count; i++)
        {
            if (valoresSubtraidos[i] == valoresSubtraidos[i - 1])
                sequencialNumerico.Add(valoresSubtraidos[i]);

            else if (sequencialNumerico.Count > 0) sequencialNumerico.Clear();

            if (sequencialNumerico.Count >= 2)
            {
                for (int a = 0; a < sequencialNumerico.Count; a++)
                {
                    sequencia = sequencia + string.Concat(sequencialNumerico[a]) + sequencia;
                }
                int numero = int.Parse(sequencia);
                trianguloDaVida.SequenciasNegativas.Add(new SequenciaNegativa
                {
                    Numero = numero,
                    Texto = textosSequenciaNegativa.FirstOrDefault(texto => texto.Numero == numero).Texto
                });
                sequencialNumerico.Clear();
                sequencia = string.Empty;
            }
        }
    }
}
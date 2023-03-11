using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using NumerologiaCabalistica.Models.MapaRelatorio;
using NumerologiaCabalistica.Util;

namespace NumerologiaCabalistica.PDF
{
    public static class GeradorDePDF
    {
        public static string GerarPDF(MapaModel model, string nomeCompleto)
        {
            List<int> valoresSubtraidos = new List<int>();
            List<int> valoresDoNome = new List<int>();

            string fileName = "map_" + nomeCompleto.Replace(" ", "_") + "_" + DateTime.Now.Ticks + ".pdf";
            using (FileStream arquivo = new FileStream(fileName, FileMode.Create))
            {
                using (PdfWriter pdfWriter = new PdfWriter(arquivo))
                {
                    var pdfDocumento = new PdfDocument(pdfWriter);
                    var font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
                    PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                    Document document = new Document(pdfDocumento, PageSize.A4).SetFont(font).SetFontSize(12F);
                    document.SetMargins(60F, 60F, 60F, 60F);

                    #region Capa

                    //String CAPA = "capa.png";
                    //PdfCanvas canvasCapa = new PdfCanvas(pdfDocumento.AddNewPage());
                    //canvasCapa.AddImageFittedIntoRectangle(ImageDataFactory.Create(CAPA), PageSize.A4, false);
                    //#endregion


                    #region Contracapa
                    //PdfCanvas contracapa = new PdfCanvas(pdfDocumento.AddNewPage()); //adiciono nova pagina
                    //String CONTRACAPA = "contra_capa.png";
                    //contracapa.AddImageFittedIntoRectangle(ImageDataFactory.Create(CONTRACAPA), PageSize.A4, false);
                    //document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

                    //PdfFont fonteFancy = PdfFontFactory.CreateFont(@"C:\\Windows\\Fonts\\Rage Italic.ttf");
                    //Paragraph nomeConsulente = new Paragraph(nomeCompleto).SetTextAlignment(TextAlignment.CENTER).SetMarginTop(430F).SetFont(fonteFancy).SetFontSize(20F);
                    //document.Add(nomeConsulente);

                    #endregion


                    #region Sumário
                    document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

                    PdfCanvas Sumario = new PdfCanvas(pdfDocumento.AddNewPage());

                    Paragraph sumario = new Paragraph($"Estudo Numerológico: {nomeCompleto}").SetBold().SetTextAlignment(TextAlignment.CENTER).SetFontSize(14F);
                    document.Add(sumario);
                    sumario = new Paragraph("(Mapa Numerológico)").SetFontSize(10F).SetTextAlignment(TextAlignment.CENTER);
                    document.Add(sumario);

                    Paragraph summary = new Paragraph($"Orientação\r\nOs Seus Números\r\nMotivação\r\nImpressão\r\nExpressão\r\nTalento Oculto\r\nAptidões e Potencialidades Profissionais\r\nDia Natalício\r\nNúmero Psíquico\r\nDestino\r\nMissão\r\nRelações Intervalores\r\nLições Cármicas\r\nDívidas Cármicas\r\nTendências Ocultas\r\nResposta Subconsciente\r\nCiclos de Vida, Desafios e Momentos Decisivos\r\nAno Pessoal\r\nMês Pessoal\r\nDia Pessoal\r\nDias Favoráveis\r\nNúmeros Harmônicos\r\nHarmonia Conjugal\r\nTriângulo Invertido da Vida\r\nAssinatura\r\nConclusão\r\nSumário - Expressões e Arcanos\r\nNumerologia Cabalística");
                    summary.SetTextAlignment(TextAlignment.JUSTIFIED);

                    document.Add(summary);
                    #endregion


                    #region Termo de Responsabilidade 
                    document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                    PdfCanvas Termo = new PdfCanvas(pdfDocumento.AddNewPage());

                    Paragraph termo = new Paragraph("Termo de Responsabilidade").SetBold().SetTextAlignment(TextAlignment.CENTER).SetFontSize(14F);
                    document.Add(termo);

                    Paragraph termoTexto = new Paragraph($"Todos os estudos contidos neste guia são elaborados baseados no estudo da Numerologia Cabalística, uma ciência hermética.\r\n\r\nUse este mapa com sabedoria, extraia o máximo de coisas boas. Leia, releia quantas vezes quiser Ele é, a partir de hoje, seu livro seu para toda a vida. \r\n\r\nAlgumas informações serão obvias na primeira leitura, outras somente com o tempo e experiências da vida. Mas tome este livro como base pois ele é o desenho da sua vida e uma ajuda para caminhar rumo ao seu destino.Em caso de dúvidas, me envie uma mensagem por e-mail ou por WhatsApp disponibilizado no momento da aquisição do seu mapa.\r\n\r\nA dinâmica do mapa é bem simples: leia de forma clara, calma, simples, sem interrupções externas ou ruídos.Uma coisa eu levo comigo sobre qualquer leitura ou ensinamento que eu recebo: nem tudo pode fazer sentido agora, mas ao longo da jornada, o nível de percepção aumenta e nosso entendimento também. Acredite!\r\n\r\nOs cálculos são baseados no seu Nome e Data de Nascimento. Minha responsabilidade é mostrar os resultados. Não há nenhuma intenção de ludibriar, enganar, difamar, humilhar, insultar, julgar ou menosprezar você. Os cálculos são feitos de maneira imparcial respeitando a individualidade e processo de cada um.\r\n\r\nRessalto que esse trabalho é feito com o máximo de cuidado e amor na esperança sempre de ajudar os meus irmãos de alguma forma. Afinal, esse é o grande propósito do ser humano na terra independente do como.");
                    termoTexto.SetTextAlignment(TextAlignment.JUSTIFIED);
                    document.Add(termoTexto);
                    #endregion


                    #region Orientação

                    document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                    PdfCanvas orientacaoCanvas = new PdfCanvas(pdfDocumento.AddNewPage());

                    Paragraph orientacao = new Paragraph("Orientação").SetBold().SetTextAlignment(TextAlignment.CENTER).SetFontSize(14F);
                    document.Add(orientacao);

                    Paragraph orientecaoTexto = new Paragraph("Não esqueça de ler as outras informações que estão nesse estudo! Prometo que será uma leitura que valerá muito a pena! Use esse estudo numerológico como se fosse um \"Manual de instruções personalizado para você\". Nesse estudo numerológico completo, você verá coisas como: \r\n\r\n- A energia do seu nome; \r\n\r\n- Sua missão de vida;\r\n\r\n- Seu Propósito de vida;\r\n\r\n- Energias de vidas passadas (por mais que você tenha alguma religião ou crença e não acredite nisso, dê uma lida) pois nele, mostrará como você se livrar daqueles problemas que parecem repetitivos e que não somem de sua vida); \r\n\r\n- Seus números positivos para alterar suas senhas, números de celulares, placas do carro e coisas do tipo;\r\n\r\n- Quais são suas características, o que te motiva, qual a impressão que os outros tem de você e que você tem de si próprio(a) e MUITO MAIS!\r\n\r\nLembre-se de aplicar TUDO QUE ESTÁ NO MAPA E COMEÇAR A IMPLEMENTAR EM SUA VIDA! ESSE é um passo importante que você estará dando em sua vida para começar a ter sucesso, prosperar, crescer e abrir os caminhos que antes estavam bloqueados. *PS: Algumas coisas que você ver no mapa, você pode achar que não batem ou não fazem sentido...\r\n\r\n\r\nMas lembre-se: Esse estudo numerológico é algo que abrange SUA VIDA INTEIRA, então, pode ser que algumas coisas já aconteceram, estão acontecendo ou ainda irão acontecer... \r\n\r\nVocê verá também pontos NEGATIVOS E COISAS RUINS SOBRE VOCÊ! \r\nMas não se preocupe! Com isso, você saberá QUAIS SEUS DEFEITOS, QUAIS SUAS FALHAS E COMO CORRIGIR!");
                    orientecaoTexto.SetTextAlignment(TextAlignment.JUSTIFIED);
                    document.Add(orientecaoTexto);

                    #endregion


                    #region Importante

                    document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                    PdfCanvas ImportanteCanvas = new PdfCanvas(pdfDocumento.AddNewPage());
                    Paragraph importante = new Paragraph($"Importante").SetBold().SetTextAlignment(TextAlignment.CENTER).SetFontSize(14F);
                    document.Add(importante);
                    string textoImportante = $"Para facilitar a leitura e ter uma melhor compreensão do";
                    Paragraph importanteTexto = new Paragraph(textoImportante);
                    importanteTexto.SetTextAlignment(TextAlignment.JUSTIFIED);
                    importanteTexto.Add(new Text(" Mapa Numerológico,").SetFont(boldFont));
                    importanteTexto.Add(new Text(" nós colocamos as explicações a seguir:"));
                    document.Add(importanteTexto);


                    Paragraph importante1 = new Paragraph("1. ").SetTextAlignment(TextAlignment.JUSTIFIED);
                    importante1.Add(new Text("Dia de Nascimento ").SetFont(boldFont));
                    importante1.Add("e ");
                    importante1.Add(new Text("Número Psíquico ").SetFont(boldFont));
                    importante1.Add("descrevem a essência do ser, seus dons inatos e seu temperamento. Parte desses elementos se refletem também pelos números de ");
                    importante1.Add(new Text("Destino ").SetFont(boldFont));
                    importante1.Add("e ");
                    importante1.Add(new Text("Missão, ").SetFont(boldFont));
                    importante1.Add("pois número de destino é a síntese da data de nascimento, e o da missão resume a personalidade e o destino.");
                    document.Add(importante1);
                    document.Add(new Paragraph("\r\n"));


                    Paragraph importante2 = new Paragraph("2. ").SetTextAlignment(TextAlignment.JUSTIFIED);
                    importante2.Add(new Text("Motivação, Impressão, Expressão e Talento Oculto ").SetFont(boldFont));
                    importante2.Add("descrevem a personalidade com seus ideais, ambições, ego, talentos e aptidões pessoais e profissionais, e o modo geral de ser da personalidade – Expõe quem é você. ");
                    document.Add(importante2);
                    document.Add(new Paragraph("\r\n"));

                    Paragraph importante3 = new Paragraph("3. ").SetTextAlignment(TextAlignment.JUSTIFIED);
                    importante3.Add(new Text("Destino ").SetFont(boldFont));
                    importante3.Add("e seus ciclos mais importantes – ");
                    importante3.Add(new Text("Ciclo de Vida, Momento Decisivo, Ano Pessoal, ").SetFont(boldFont));
                    importante3.Add("mais a ");
                    importante3.Add(new Text("Missão, ").SetFont(boldFont));
                    importante3.Add("revelam a sua destinação na vida, com as influências, circunstâncias, oportunidades e a sua vocação. Os números de ");
                    importante3.Add(new Text("Destino e Missão ").SetFont(boldFont));
                    importante3.Add("indicam qual é o propósito de vida – Expõe o que veio aprender para evoluir, qual é seu propósito de vida e o que está destinado a construir e compartilhar para se autorrealizar. ");
                    document.Add(importante3);
                    document.Add(new Paragraph("\r\n"));

                    Paragraph importante4 = new Paragraph("4. ").SetTextAlignment(TextAlignment.JUSTIFIED);
                    importante4.Add(new Text("Lições Cármicas, Débitos Cármicos, Tendências Ocultas, Resposta Subconsciente, Desafios, Arcanos e Sequências Numéricas, ").SetFont(boldFont));
                    importante4.Add("no ");
                    importante4.Add(new Text("Triângulo da Vida, ").SetFont(boldFont));
                    importante4.Add("mostram os aprendizados importantes, os desafios e as dificuldades que precisa superar, bem como aquilo que deve reparar relativo aos seus atos contrários a lei de justiça e amor, no passado. – Expõe o que você precisa aprender e regenerar perante a lei de causa e efeito, em suas relações pessoais, em família e nos vários ambientes que vier a percorrer no mundo.");
                    document.Add(importante4);
                    document.Add(new Paragraph("\r\n"));


                    Paragraph importante5 = new Paragraph("5. ").SetTextAlignment(TextAlignment.JUSTIFIED);
                    importante5.Add("O ");
                    importante5.Add(new Text("Nome Social, ").SetFont(boldFont));
                    importante5.Add("como projeção pública, social e profissional fortalece a maneira de atuar no mundo e protege o nome original de ser profanado.");
                    document.Add(importante5);
                    #endregion


                    #region Seus Numeros
                    document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                    PdfCanvas seusNumerosCanvas = new PdfCanvas(pdfDocumento.AddNewPage());

                    Paragraph seusNumeros = new Paragraph("Seus Números").SetBold().SetTextAlignment(TextAlignment.CENTER).SetFontSize(14F);
                    document.Add(seusNumeros);

                    Paragraph name = new Paragraph("Nome ").SetTextAlignment(TextAlignment.JUSTIFIED);
                    name.Add(new Text(nomeCompleto).SetFont(boldFont));
                    document.Add(name);

                    Paragraph dataNascimento = new Paragraph($"Data de Nascimento: ");
                    dataNascimento.Add(new Text(model.DataNascimento.ToShortDateString()).SetFont(boldFont));
                    document.Add(dataNascimento);

                    Paragraph diaNatalicio = new Paragraph($"Dia Natalício: ");
                    diaNatalicio.Add(new Text(model.DiaNascimento.Numero.ToString()).SetFont(boldFont));
                    document.Add(diaNatalicio);

                    Paragraph numeroPsiquico = new Paragraph($"Número Psíquico: ");
                    numeroPsiquico.Add(new Text(model.NumeroPsiquico.Numero.ToString()).SetFont(boldFont));
                    document.Add(numeroPsiquico);

                    Paragraph motivacaoNumero = new Paragraph($"Motivação: ");
                    motivacaoNumero.Add(new Text(model.Motivacao.Numero.ToString()).SetFont(boldFont));
                    document.Add(motivacaoNumero);

                    Paragraph impressaoNumero = new Paragraph($"Impressão: ");
                    impressaoNumero.Add(new Text(model.Impressao.Numero.ToString()).SetFont(boldFont));
                    document.Add(impressaoNumero);

                    Paragraph expressaoNumero = new Paragraph($"Expressão: ");
                    expressaoNumero.Add(new Text(model.Expressao.Numero.ToString()).SetFont(boldFont));
                    document.Add(expressaoNumero);

                    Paragraph talentoOcultoNumero = new Paragraph($"Talento Oculto: ");
                    talentoOcultoNumero.Add(new Text(model.TalentoOculto.Numero.ToString()).SetFont(boldFont));
                    document.Add(talentoOcultoNumero);

                    Paragraph destinoNumero = new Paragraph($"Destino: ");
                    destinoNumero.Add(new Text(model.Destino.Numero.ToString()).SetFont(boldFont));
                    document.Add(destinoNumero);

                    Paragraph missaoNumero = new Paragraph($"Missão: ");
                    missaoNumero.Add(new Text(model.Missao.Numero.ToString()).SetFont(boldFont));
                    document.Add(missaoNumero);

                    string licoes = String.Join(',', model.LicaoCarmica.LicoesCarmicas.Select(x => x.Numero).ToList());
                    Paragraph licoesCarmicasNumero = new Paragraph($"Lições Cármicas: ");
                    licoesCarmicasNumero.Add(new Text(licoes).SetFont(boldFont));
                    document.Add(licoesCarmicasNumero);

                    string tendenciasNumero = String.Join(',', model.TendenciaOculta.TendenciasOcultas.Select(x => x.Numero).ToList());
                    Paragraph tendenciaOcultaNumero = new Paragraph($"Tendências Ocultas: ");
                    tendenciaOcultaNumero.Add(new Text(tendenciasNumero).SetFont(boldFont));
                    document.Add(tendenciaOcultaNumero);


                    Paragraph respostaSub = new Paragraph($"Resposta Subconsciente: ");
                    respostaSub.Add(new Text(model.RespostaSubconsciente.Numero.ToString()).SetFont(boldFont));
                    document.Add(respostaSub);

                    string dividas = model.DividaCarmica.DividasCarmicas.Select(x => x.Numero).Count() > 0 ? String.Join(',', model.DividaCarmica.DividasCarmicas.Select(x => x.Numero).ToList()) : "Não possui";
                    Paragraph dividaCarmicoNumero = new Paragraph($"Dívidas Cármicas: ");
                    dividaCarmicoNumero.Add(new Text(dividas).SetFont(boldFont));
                    document.Add(dividaCarmicoNumero);

                    string ciclos = model.PrimeiroCicloDeVida.Numero + ", " + model.SegundoCicloDeVida.Numero + ", " + model.TerceiroCicloDeVida.Numero;
                    Paragraph ciclo = new Paragraph($"Ciclos de Vida: ");
                    ciclo.Add(new Text(ciclos).SetFont(boldFont));
                    document.Add(ciclo);


                    string desafioMontagem = model.Desafio.PrimeiroDesafio.Numero 
                        + ", " 
                        + model.Desafio.SegundoDesafio.Numero 
                        + ", " 
                        + model.Desafio.TerceiroDesafio.Numero;
                    
                    Paragraph desafiosNumero = new Paragraph($"Desafios: ");
                    desafiosNumero.Add(new Text(desafioMontagem).SetFont(boldFont));
                    document.Add(desafiosNumero);


                    string momentoNumeroMontagem = model.PrimeiroMomentoDecisivo.Numero 
                        + ", " 
                        + model.SegundoMomentoDecisivo.Numero + ", " 
                        + model.TerceiroMomentoDecisivo.Numero + "," 
                        + model.QuartoMomentoDecisivo.Numero;

                    Paragraph momentoNumero = new Paragraph($"Momentos Decisivos ");
                    momentoNumero.Add(new Text(momentoNumeroMontagem).SetFont(boldFont));
                    document.Add(momentoNumero);

                    #endregion


                    #region Motivacao

                    PdfCanvas motivacaoCanva = new PdfCanvas(pdfDocumento.AddNewPage());
                    document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

                    Paragraph motivacaoTitulo = new Paragraph("Motivação").SetBold().SetFontSize(14F);
                    document.Add(motivacaoTitulo);

                    Paragraph motivacaoExplicacao = new Paragraph($"O número de Motivação descreve os motivos e as razões que movem as suas atitudes e o seu modo de agir. Este número revela o aspecto interior da personalidade; reflete as atitudes e comportamentos, principalmente quando você está sozinho, sem ninguém ver, influenciando ainda nas escolhas pessoais.\r\n\r\nNem sempre há coerência, pois, a atitude interior da pessoa, muitas vezes, não é revelada para os outros, mas rege as suas decisões intuitivas.\r\n\r\nO número de Motivação revela as crenças e os valores internos da pessoa, mobilizando seus ideais, seus desejos, suas ambições, a vontade e os sentimentos mais íntimos que o impulsionam a buscar determinados caminhos para as suas realizações na vida. Revela a essência da personalidade.\r\n\r\nOu seja, uns gostam de dinheiro, outros não ligam, outros gostam de fama, e outros não estão nem ai...\r\n\r\nEsse número irá revelar sobre suas motivações e vontades. É a soma das vogais do seu nome.");
                    motivacaoExplicacao.SetTextAlignment(TextAlignment.JUSTIFIED).SetItalic();
                    document.Add(motivacaoExplicacao);


                    document.Add(new Paragraph("\r\n"));
                    Paragraph motivacao = new Paragraph($"Motivação: {model.Motivacao.Numero}").SetBold();
                    document.Add(motivacao);
                    Paragraph motivacaoTexto = new Paragraph(model.Motivacao.Texto).SetTextAlignment(TextAlignment.JUSTIFIED);
                    document.Add(motivacaoTexto);

                    #endregion


                    #region Impressao

                    PdfCanvas impressaoCanva = new PdfCanvas(pdfDocumento.AddNewPage());
                    document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

                    Paragraph impressaoTitulo = new Paragraph("Impressão").SetBold().SetFontSize(14F);
                    document.Add(impressaoTitulo);

                    Paragraph impressaoExplicacao = new Paragraph($"O número de Impressão descreve a personalidade em seu aspecto externo, ou seja, a maneira como os outros te enxergam e como VOCÊ MESMO SE VÊ. É o número que descreve aquela primeira impressão que a pessoa causa quando é vista por outro.\r\n\r\nNem sempre esta primeira impressão é coerente com a atitude interior da pessoa. Será a primeira impressão que as outras pessoas terão de você, e até mesmo como você se enxerga. Esse número é a soma de todas as consoantes do seu nome.");
                    impressaoExplicacao.SetTextAlignment(TextAlignment.JUSTIFIED).SetItalic();
                    document.Add(impressaoExplicacao);


                    document.Add(new Paragraph("\r\n"));
                    Paragraph impressao = new Paragraph($"Impressão: {model.Impressao.Numero}").SetBold();
                    document.Add(impressao);
                    Paragraph impressaoTexto = new Paragraph(model.Impressao.Texto).SetTextAlignment(TextAlignment.JUSTIFIED);
                    document.Add(impressaoTexto);

                    #endregion


                    #region Expressao

                    PdfCanvas expressaoCanva = new PdfCanvas(pdfDocumento.AddNewPage());
                    document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

                    Paragraph expressaoTitulo = new Paragraph("Expressão").SetBold().SetFontSize(14F);
                    document.Add(expressaoTitulo);

                    Paragraph expressaoExplicacao = new Paragraph($"O número de Expressão te mostra a maneira como a pessoa age e interage com os outros e com o mundo, revelando quais são os verdadeiros talentos e aptidões que desenvolverá ao longo da vida, e qual será a melhor forma de expressá-los. \r\n\r\nRevela o seu caráter, as características que se expressam nas ações que toma, e irão refletir nos vários campos da sua vida (pessoal, financeiro, amoroso, familiar). \r\n\r\nA expressão é a própria maneira de agir do ser humano! É uma junção daquilo que te motiva (a Motivação) e daquilo que você aparenta (a Impressão), resumindo o conjunto completo da sua personalidade. É o número do nome da pessoa. É a soma de todas as letras do seu nome. ");
                    expressaoExplicacao.SetTextAlignment(TextAlignment.JUSTIFIED).SetItalic();
                    document.Add(expressaoExplicacao);


                    document.Add(new Paragraph("\r\n"));
                    Paragraph expressao = new Paragraph($"Expressão: {model.Expressao.Numero}").SetBold();
                    document.Add(expressao);
                    Paragraph expressaoTexto = new Paragraph(model.Expressao.Texto).SetTextAlignment(TextAlignment.JUSTIFIED);
                    document.Add(expressaoTexto);

                    #endregion


                    #region Dia de Nascimento

                    PdfCanvas diaNascimentoCanva = new PdfCanvas(pdfDocumento.AddNewPage());
                    document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

                    Paragraph diaNascimentoTitulo = new Paragraph("Dia de Nascimento").SetBold().SetFontSize(14F);
                    document.Add(diaNascimentoTitulo);

                    Paragraph diaNascimentoExplicacao = new Paragraph($"O Dia que você nasceu registra as qualidades inatas, ou seja, aquelas que nasceram e que permanecerão com você toda a vida, e irá mostrar quais são seus dons, personalidade e características. \r\n\r\nCada um nasce em uma data determinada, conforme as suas necessidades evolutivas, e o dia do seu nascimento é mais importante que o mês e o ano, porque determina as suas tendências naturais, as suas características particulares e únicas, e semelhanças com outras pessoas nascidas no mesmo dia de cada mês. \r\n\r\nCada um nasce em uma data determinada, conforme as suas necessidades evolutivas, e o dia do seu nascimento é mais importante que o mês e o ano, porque determina as suas tendências naturais, as suas características particulares e únicas, e semelhanças com outras pessoas nascidas no mesmo dia de cada mês.");
                    diaNascimentoExplicacao.SetTextAlignment(TextAlignment.JUSTIFIED).SetItalic();
                    document.Add(diaNascimentoExplicacao);


                    document.Add(new Paragraph("\r\n"));
                    Paragraph diaNascimento = new Paragraph($"Dia de Nascimento: {model.DiaNascimento.Numero}").SetBold();
                    document.Add(diaNascimento);
                    Paragraph diaNascimentoTexto = new Paragraph(model.DiaNascimento.Texto).SetTextAlignment(TextAlignment.JUSTIFIED);
                    document.Add(diaNascimentoTexto);

                    #endregion


                    #region Destino - Propósito de vida

                    PdfCanvas destinoCanva = new PdfCanvas(pdfDocumento.AddNewPage());
                    document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

                    Paragraph destinoTitulo = new Paragraph("Destino - Propósito de vida").SetBold().SetFontSize(14F);
                    document.Add(destinoTitulo);

                    Paragraph destinoExplicacao = new Paragraph($"O Número de Destino é determinado pela data de nascimento - dia, mês e ano. O destino rege a vida do ser humano e indica qual \"caminho\" evolutivo você deve seguir. \r\n\r\nEle irá te orientar nas decisões mais importantes da sua vida, aquelas que determinam o que acontecerá se você aplicar seus dons e talentos para alcançar sua realização pessoais conforme é a sua vocação e o caminho que você deve seguir. \r\n\r\nO destino é como se fosse você descendo de um avião no lugar que você tem que chegar. É para onde você deve encaminhar sua vida e buscar esse caminho.\r\n\r\nSe você não seguir seu destino, sua vida irá dar errado, começar a travar, pois é uma maneira do universo mostrar que você está errado(a) e deve seguir outro caminho.");
                    destinoExplicacao.SetTextAlignment(TextAlignment.JUSTIFIED).SetItalic();
                    document.Add(diaNascimentoExplicacao);


                    document.Add(new Paragraph("\r\n"));
                    Paragraph destino = new Paragraph($"Destino: {model.Destino.Numero}").SetBold();
                    document.Add(destino);
                    Paragraph destinoTexto = new Paragraph(model.Destino.Texto).SetTextAlignment(TextAlignment.JUSTIFIED);
                    document.Add(destinoTexto);

                    #endregion


                    #region Missão - Missão de vida

                    PdfCanvas missaoCanva = new PdfCanvas(pdfDocumento.AddNewPage());
                    document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

                    Paragraph missaoTitulo = new Paragraph("Missão - Missão de vida").SetBold().SetFontSize(14F);
                    document.Add(missaoTitulo);

                    Paragraph missaoExplicacao = new Paragraph($"Cada pessoa tem uma Missão. A missão é sua vocação para a sua autorrealização. Ela será desenvolvida independentemente de qual profissão se exerça, e estará presente em tudo que você fizer en sua vida, influenciando ainda nos aprendizados, nos compartilhamentos, nos relacionamentos, para o sucesso e a felicidade, de modo positivo ou negativo. \r\n\r\nA Missão estará atuando por toda a vida, porém, é na maturidade, quando temos mais noção e experiência de vida, e pelos conhecimentos adquiridos das experiências que já vivemos, ela será melhor aceita e compreendida. \r\n\r\nA missão sua missão consiste em compartilhar com o mundo o seu talento e seu propósito de vida, para ajudar pessoas, te ajudar e prosperar cada vez mais!");
                    missaoExplicacao.SetTextAlignment(TextAlignment.JUSTIFIED).SetItalic();
                    document.Add(missaoExplicacao);

                    document.Add(new Paragraph("\r\n"));
                    Paragraph missao = new Paragraph($"Missão: {model.Missao.Numero}").SetBold();
                    document.Add(missao);
                    Paragraph missaoTexto = new Paragraph(model.Missao.Texto).SetTextAlignment(TextAlignment.JUSTIFIED);
                    document.Add(missaoTexto);

                    #endregion


                    #region Talento Oculto

                    PdfCanvas talentoOcultoCanva = new PdfCanvas(pdfDocumento.AddNewPage());
                    document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

                    Paragraph talentoOcultoTitulo = new Paragraph("Talento Oculto").SetBold().SetFontSize(14F);
                    document.Add(talentoOcultoTitulo);

                    Paragraph talentoOcultoExplicacao = new Paragraph($"O número do Talento Oculto revela um aspecto secreto da sua personalidade, como se fosse um dom que nasceu com você.\r\n\r\nEle é um talento que se desperta como algo mais além daqueles descritos pelo número de Expressão, em dado momento da sua vida (mais ou menos, entre 21 e 28 anos de idade); uma espécie de melhora das suas aptidões descritas pelo número de Expressão. \r\n\r\nOu seja, é um talento oculto que irá ficar claro para você e você terá certeza de\r\nqual é seu dom.\r\n");
                    talentoOcultoExplicacao.SetTextAlignment(TextAlignment.JUSTIFIED).SetItalic();
                    document.Add(talentoOcultoExplicacao);

                    document.Add(new Paragraph("\r\n"));
                    Paragraph talentoOculto = new Paragraph($"Talento Oculto: {model.TalentoOculto.Numero}").SetBold();
                    document.Add(talentoOculto);
                    Paragraph talentoOcultoTexto = new Paragraph(model.TalentoOculto.Texto).SetTextAlignment(TextAlignment.JUSTIFIED);
                    document.Add(talentoOcultoTexto);

                    #endregion


                    #region Aptidões e Potencialidades Profissionais

                    PdfCanvas aptidoesCanva = new PdfCanvas(pdfDocumento.AddNewPage());
                    document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

                    Paragraph aptidoesTitulo = new Paragraph("Aptidões e Potencialidades Profissionais").SetBold().SetFontSize(14F);
                    document.Add(aptidoesTitulo);

                    Paragraph aptidoesExplicacao = new Paragraph($"De acordo com as características da personalidade, dos seus talentos e das aptidões desenvolvidas ou potencialmente a se desenvolver, cada ser humano possui habilidades peculiares que indicam as melhores profissões para si. Para cada profissão, para cada atividade necessária ao bom desenvolvimento da sociedade humana existem pessoas habilitadas para exercê-las. Mas é preciso que os talentos da personalidade estejam de acordo com as probabilidades do destino.");
                    aptidoesExplicacao.SetTextAlignment(TextAlignment.JUSTIFIED).SetItalic();
                    document.Add(aptidoesExplicacao);
                   

                    document.Add(new Paragraph("\r\n"));
                    Paragraph aptidoes = new Paragraph($"Aptidões e Potencialidades Profissionais: {model.PotencialProfissional.Numero}").SetBold();
                    document.Add(aptidoes);
                    Paragraph aptidoesTexto = new Paragraph(model.PotencialProfissional.Texto).SetTextAlignment(TextAlignment.JUSTIFIED);
                    document.Add(aptidoesTexto);

                    #endregion


                    #region Número psíquico


                    PdfCanvas numeroPsiquicoCanva = new PdfCanvas(pdfDocumento.AddNewPage());
                    document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

                    Paragraph numeroPsiquicoTitulo = new Paragraph("Número Psíquico").SetBold().SetFontSize(14F);
                    document.Add(numeroPsiquicoTitulo);

                    Paragraph numeroPsiquicoExplicacao = new Paragraph($"O Número Psíquico revela as qualidades emocionais que influenciam as suas escolhas pessoais, como por exemplo: alimento, sexo, amizades, relacionamentos, casamento, profissão, ambições e desejos. \r\n\r\nEsse número Revela como a pessoa se vê interiormente e como lida com a sua própria personalidade. É, também, o número que reflete certos padrões interiores e comportamentos compartilhados por grupos de pessoas nascidas em determinados dias iguais. \r\nReflete também, aspectos da sua personalidade.");
                    numeroPsiquicoExplicacao.SetTextAlignment(TextAlignment.JUSTIFIED).SetItalic();
                    document.Add(numeroPsiquicoExplicacao);

                    document.Add(new Paragraph("\r\n"));
                    Paragraph numeroPsiquicoNumero = new Paragraph($"Número Psíquico: {model.NumeroPsiquico.Numero}").SetBold();
                    document.Add(numeroPsiquicoNumero);
                    Paragraph numeroPsiquicoTexto = new Paragraph(model.NumeroPsiquico.Texto).SetTextAlignment(TextAlignment.JUSTIFIED);
                    document.Add(numeroPsiquicoTexto);

                    #endregion


                    #region Lições cármicas

                    PdfCanvas licoesCanva = new PdfCanvas(pdfDocumento.AddNewPage());
                    document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

                    Paragraph licoesTitulo = new Paragraph("Lições Cármicas").SetBold().SetFontSize(14F);
                    document.Add(licoesTitulo);

                    Paragraph licoesExplicacao = new Paragraph($"As lições cármicas podem ser descritas como aprendizados que você tem que ter para a a sua evolução. Elas indicam fraquezas/problemas que o ser humano que precisa identificar, entender e vencer. \r\n\r\nSão problemas e situações ruins com relação a compromissos assumidos perante a vida, a família, a espiritualidade, os relacionamentos e outras pessoas, no passado e no presente. \r\n\r\nSão aqueles aprendizados mais difíceis que ficam atrasados, até que possamos compreender a sua real importância. Existem lições de que serão mais voltadas para você (como aprender a economizar dinheiro, não ser consumista) e outras mais abrangentes (perdoar as pessoas e suas ações, não guardar rancor e ódio no coração) mas todas precisam ser aprendidas. \r\n\r\nSão lições que o ser humano precisa aprender e desenvolver, para conseguir eliminar esses carmas, evoluir e prosperar.");
                    licoesExplicacao.SetTextAlignment(TextAlignment.JUSTIFIED).SetItalic();
                    document.Add(licoesExplicacao);

                    document.Add(new Paragraph("\r\n"));
                    string licoesCarmicas = string.Join(",", model.LicaoCarmica.LicoesCarmicas.Select(x => x.Numero));
                    Paragraph licoesNumero = new Paragraph($"Lições Cármicas: {licoesCarmicas}").SetBold();
                    document.Add(licoesNumero);

                    foreach (var item in model.LicaoCarmica.LicoesCarmicas)
                    {
                        Paragraph licoesTexto = new Paragraph(item.Numero + ": " + item.Texto).SetTextAlignment(TextAlignment.JUSTIFIED);
                        document.Add(licoesTexto);
                        document.Add(new Paragraph("\r\n"));
                    }


                    #endregion


                    #region Dívidas cármicas

                    PdfCanvas dividaPsiquicoCanva = new PdfCanvas(pdfDocumento.AddNewPage());
                    document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

                    Paragraph dividaTitulo = new Paragraph("Dívidas Cármicas").SetBold().SetFontSize(14F);
                    document.Add(dividaTitulo);

                    Paragraph dividaExplicacao = new Paragraph($"As dívidas cármicas são lições de vidas passadas que devem ser aprendidas e corrigidas para que os problemas parem de acontecer. \r\n\r\nSe em vidas passadas você foi descontrolado com dinheiro... Nessa vida sofrerá com a falta dele. Se você cometeu traições e foi uma pessoa que não respeitava seu marido, mulher, parceiro... irá sofrer na pele para entender como é. Mas fique tranquila(o), isso tem como ser corrigido e eliminado. \r\n\r\nAgora apenas de ler e entender isso, você já será uma pessoa que está ciente e consciente desse carma e ficará mais fácil de resolver. Siga as orientações que são ditas no mapa para se livrar e fazer com que essas situações chatas e repetidas parem de acontecer.\r\n\r\n");
                    dividaExplicacao.SetTextAlignment(TextAlignment.JUSTIFIED).SetItalic();
                    document.Add(dividaExplicacao);

                    document.Add(new Paragraph("\r\n"));

                    string dividaCarmicas = string.Join(", ", model.DividaCarmica.DividasCarmicas.Select(x => x.Numero));
                    Paragraph dividaNumero = new Paragraph($"Dívidas Cármicas: {dividaCarmicas}").SetBold();
                    document.Add(dividaNumero);

                    foreach (var item in model.DividaCarmica.DividasCarmicas)
                    {
                        Paragraph dividaTexto = new Paragraph(item.Numero + ": " + item.Texto).SetTextAlignment(TextAlignment.JUSTIFIED);
                        document.Add(dividaTexto);
                        document.Add(new Paragraph("\r\n"));
                    }


                    #endregion


                    #region Tendências ocultas


                    PdfCanvas tendenciaCanva = new PdfCanvas(pdfDocumento.AddNewPage());
                    document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

                    Paragraph tendenciaTitulo = new Paragraph("Tendências ocultas").SetBold().SetFontSize(14F);
                    document.Add(tendenciaTitulo);

                    Paragraph tendenciaExplicacao = new Paragraph($"As tendências ocultas são os comportamentos e condicionamentos de vidas passadas. E caso você não esteja ciente e não saiba disso, irão continuar se repetindo até que você quebre o padrão existente. \r\n\r\nSão certas atitudes e comportamentos, geralmente mais notáveis e visíveis na sua infância, adolescência e juventude. Porém, se você não se educar e não mudar, essas tendências continuarão a ser manifestadas por toda a sua vida. \r\n\r\nAs tendências ocultas são aspectos negativos dos seus números do estudo numerológico.");
                    tendenciaExplicacao.SetTextAlignment(TextAlignment.JUSTIFIED).SetItalic();
                    document.Add(tendenciaExplicacao);

                    document.Add(new Paragraph("\r\n"));

                    string tendencia = string.Join(",", model.TendenciaOculta.TendenciasOcultas.Select(x => x.Numero));
                    Paragraph tendenciaNumero = new Paragraph($"Tendências ocultas: {tendencia}").SetBold();
                    document.Add(tendenciaNumero);

                    foreach (var item in model.TendenciaOculta.TendenciasOcultas)
                    {
                        Paragraph tendenciaTexto = new Paragraph(item.Numero + ": " + item.Texto).SetTextAlignment(TextAlignment.JUSTIFIED);
                        document.Add(tendenciaTexto);
                        document.Add(new Paragraph("\r\n"));
                    }


                    #endregion


                    #region Resposta subconsciente

                    PdfCanvas respostaCanva = new PdfCanvas(pdfDocumento.AddNewPage());
                    document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

                    Paragraph respostaTitulo = new Paragraph("Resposta subconsciente").SetBold().SetFontSize(14F);
                    document.Add(respostaTitulo);

                    Paragraph respostaExplicacao = new Paragraph($"Este número revela como será a sua primeira reação, instintiva e automática, em uma situação de emergência. Esse número reflete como você irá reagir diante dos impactos e coisas inesperadas que sofre na vida, e como lida com as suas emoções\r\nnos primeiros minutos após o acontecimento. \r\n\r\nEstes impulsos podem durar uma fração de segundo ou até levar à depressão, ao\r\npânico e a um prolongado estresse. Muitas vezes esses \"impulsos\" quase não são percebidos, por serem automáticos que vêm do subconsciente.");
                    respostaExplicacao.SetTextAlignment(TextAlignment.JUSTIFIED).SetItalic();
                    document.Add(respostaExplicacao);

                    document.Add(new Paragraph("\r\n"));

                    Paragraph respostaNumero = new Paragraph($"Resposta subconsciente: {model.RespostaSubconsciente.Numero}").SetBold();
                    document.Add(respostaNumero);

                    Paragraph respostaTexto = new Paragraph(model.RespostaSubconsciente.Texto).SetTextAlignment(TextAlignment.JUSTIFIED);
                    document.Add(respostaTexto);


                    #endregion


                    #region Cores favoráveis

                    PdfCanvas corCanva = new PdfCanvas(pdfDocumento.AddNewPage());
                    document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

                    Paragraph corTitulo = new Paragraph("Cores favoráveis").SetBold().SetFontSize(14F);
                    document.Add(corTitulo);

                    Paragraph corExplicacao = new Paragraph($"As cores vibram, assim como os números e as letras. Tudo no Universo vibra, e têm energia.\r\n\r\nDessa maneira, para cada ser humano existem determinadas cores que são harmônicas e irão melhorar a energia de quem usar.");
                    corExplicacao.SetTextAlignment(TextAlignment.JUSTIFIED).SetItalic();
                    document.Add(corExplicacao);

                    document.Add(new Paragraph("\r\n"));

                    Paragraph corNumero = new Paragraph($"Cores favoráveis: {model.CorFavoravel.Numero + " => " + model.CorFavoravel.Texto}").SetBold();
                    document.Add(corNumero);

                    document.Add(new Paragraph("\r\n"));

                    #endregion


                    #region Dias favoráveis

                    //TODO: arrumar os dias favoráveis
                    //PdfCanvas diasCanva = new PdfCanvas(pdfDocumento.AddNewPage());
                    //document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

                    //Paragraph diasTitulo = new Paragraph("Dias favoráveis").SetBold().SetFontSize(14F);
                    //document.Add(diasTitulo);

                    //Paragraph diasExplicacao = new Paragraph($"São os dias do mês que vibram, favoravelmente, de acordo com o dia de nascimento. É sugerido marcar os compromissos mais importantes num desses dias, como: entrevistas, assinatura de contratos, reuniões, transações financeiras e outras decisões importantes.");
                    //document.Add(diasExplicacao);

                    //document.Add(new Paragraph("\r\n"));

                    //string diasFavoraveis = string.Join(",", model.DiasFavoraveis);
                    //Paragraph diasNumero = new Paragraph($"Dias favoráveis: {diasFavoraveis}").SetBold();
                    //document.Add(diasNumero);

                    #endregion


                    #region Ano pessoal

                    PdfCanvas anoCanva = new PdfCanvas(pdfDocumento.AddNewPage());
                    document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

                    Paragraph anoTitulo = new Paragraph("Ano pessoal").SetBold().SetFontSize(14F);
                    document.Add(anoTitulo);

                    Paragraph anoExplicacao = new Paragraph($"Cada ano universal (de 01 de janeiro a 31 de dezembro) possui características específicas e vibrações peculiares que influenciam a humanidade como um TODO. Mas, existem também os anos pessoais que influenciam você e sua vida. \r\n\r\nO Ano Pessoal começa no dia de um aniversário e termina na véspera do próximo, e exerce forte influência sobre a vida da pessoa e sobre o que ocorrerá naquele ano. \r\n\r\nCada Ano Pessoal traz com ele um conjunto de oportunidades e aprendizados que se forem seguidos e aplicados corretamente, trarão mais prosperidade e sucesso para você. \r\n\r\nPor exemplo: Existe ano de casar, ano de começar negócios, ano de economizar dinheiro (pois será mais apertado) ano de mais relacionamentos, ano de mais dinheiro e assim por diante... A tabela de Anos Pessoais a seguir é válida para toda a vida; acabando um ciclo, o outro se inicia.\r\n\r\n\r\nPara calcular o Ano Pessoal:\r\n\r\nSome o dia do SEU ANIVERSÁRIO + MÊS + ANO ATUAL\r\n\r\nExemplo:\r\n\r\nVocê faz aniversário dia 18/06 (dezoito de junho) e quer somar o ano pessoal de 2022.\r\n\r\nEntão a conta será:\r\n\r\n1+8+0+6+2+0+2+2 = 21 = 3\r\n\r\nOs anos pessoais vão do número 1 ao 9, então, você sempre deve reduzir\r\n\r\nsomente a UM número.\r\n\r\nSe der 35 = 3+5 = 8\r\n\r\nSe der 44 = 4+4 = 8");
                    anoExplicacao.SetTextAlignment(TextAlignment.JUSTIFIED).SetItalic();
                    document.Add(anoExplicacao);

                    document.Add(new Paragraph("\r\n"));

                    foreach (var item in model.AnoPessoal.AnosPessoais)
                    {
                        document.Add(new Paragraph("\r\n"));
                        Paragraph anoPessoal = new Paragraph($"Ano pessoal: {item.AnoPessoal + " - de " + item.DataDe.ToShortDateString() + " a " + item.DataAte.ToShortDateString()}").SetBold();
                        document.Add(anoPessoal);

                        Paragraph anoTexto = new Paragraph(item.Texto).SetTextAlignment(TextAlignment.JUSTIFIED);
                        document.Add(anoTexto);

                    }



                    #endregion


                    #region Mês pessoal

                    PdfCanvas mesCanva = new PdfCanvas(pdfDocumento.AddNewPage());
                    document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

                    Paragraph mesTitulo = new Paragraph("Mês pessoal").SetBold().SetFontSize(14F);
                    document.Add(mesTitulo);

                    Paragraph mesExplicacao = new Paragraph("Assim como existem os anos pessoais, também os meses influenciam de certa m neira a vida do ser humano. Cada mês tem a sua vibração peculiar, e cada ser humano segue, de acordo com a sua data de nascimento, uma energia mensal própria, que pode ser aproveitada para orientar as suas tomadas de decisões e atitudes. \r\n\r\nPara calcular o Mês Pessoal:\r\nAno Pessoal + Mês Atual = Resultado reduzido a um único número de 1 a 9; podendo ser considerados também os números 11 e 22.\r\n\r\nExemplo: Ano Pessoal 7 + Mês Atual 5 (Maio) - 7+5=12 - 1+2=3 - Maio será o Mês Pessoal 3.\r\n").SetTextAlignment(TextAlignment.JUSTIFIED);
                    mesExplicacao.SetTextAlignment(TextAlignment.JUSTIFIED).SetItalic();
                    document.Add(mesExplicacao);

                    document.Add(new Paragraph("\r\n"));


                    foreach (var item in model.MesPessoal.MesesPessoais)
                    {
                        document.Add(new Paragraph("\r\n"));
                        Paragraph mesMessoal = new Paragraph($"Mes pessoal: {item.Numero + " - " + item.MesExtenso + " - " + item.MesDe + " até " + item.MesAte}").SetBold();
                        document.Add(mesMessoal);
                        Paragraph mesTexto = new Paragraph(item.Texto).SetTextAlignment(TextAlignment.JUSTIFIED);
                        document.Add(mesTexto);

                    }
                    #endregion


                    #region Dia pessoal

                    PdfCanvas diaCanva = new PdfCanvas(pdfDocumento.AddNewPage());
                    document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

                    Paragraph diaTitulo = new Paragraph("Dia pessoal").SetBold().SetFontSize(14F);
                    document.Add(diaTitulo);

                    Paragraph diaExplicacao = new Paragraph("Cada dia universal possui suas características e influencia a todas as pessoas do planeta. Mas você também tem a ENERGIA do seu dia pessoal, ou seja, como se fosse uma orientação diária. \r\n\r\nEntão sabe aquele dia que você está mais cansada(o), mais exausta, ou até mesmo muito eufórica, se sentindo com sorte e coisas do tipo? Pois é, é isso mesmo. Para calcular o \r\n\r\nDia Pessoal: Mês Pessoal + Dia Atual = Resultado reduzido a um único número de 1 a 9 podendo ser considerados também os números 11 e 22. \r\n\r\nExemplo 1 - Mês Pessoal 5 + Dia Atual 15 - 5+1+5=11 - Dia Pessoal 11. \r\n\r\nExemplo 2 - Mês Pessoal 9 + Dia Atual 15 - 9+1+5=15 - 1+5=6 - Dia Pessoal 6.");
                    diaExplicacao.SetTextAlignment(TextAlignment.JUSTIFIED).SetItalic();
                    document.Add(diaExplicacao);

                    document.Add(new Paragraph("\r\n"));


                    foreach (var item in model.DiaPessoal.DiasPessoais)
                    {
                        document.Add(new Paragraph("\r\n"));
                        Paragraph diaPessoal = new Paragraph($"Dia pessoal: {item.Numero}").SetBold();
                        document.Add(diaPessoal);

                        Paragraph diaTexto = new Paragraph(item.Texto).SetTextAlignment(TextAlignment.JUSTIFIED);
                        document.Add(diaTexto);

                    }
                    #endregion


                    #region Números Harmônicos

                    PdfCanvas numerosHarmonicosCanva = new PdfCanvas(pdfDocumento.AddNewPage());
                    document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

                    Paragraph numerosHarmonicosTitulo = new Paragraph("Números Harmônicos").SetBold().SetFontSize(14F);
                    document.Add(numerosHarmonicosTitulo);

                    Paragraph numerosHarmonicosExplicacao = new Paragraph($"São os números que harmonizam com a pessoa pelo seu dia natalício, e servem para compor e harmonizar endereços, sociedades, placas de carros, senhas, números de telefones, etc.");
                    numerosHarmonicosExplicacao.SetTextAlignment(TextAlignment.JUSTIFIED).SetItalic();
                    document.Add(numerosHarmonicosExplicacao);

                    document.Add(new Paragraph("\r\n"));
                    string numerosH = string.Join(",", model.NumeroHarmonico.NumerosHamonicos.Select(x => x));
                    Paragraph numerosHarmonicos = new Paragraph($"Os seus Números Harmônicos pelo seu Dia Natalício são: {numerosH}").SetBold().SetTextAlignment(TextAlignment.JUSTIFIED);
                    document.Add(numerosHarmonicos);


                    #endregion


                    #region Harmonia conjugal

                    PdfCanvas harmoniaConjugalCanva = new PdfCanvas(pdfDocumento.AddNewPage());
                    document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

                    Paragraph harmoniaConjugalTitulo = new Paragraph("Harmonia conjugal").SetBold().SetFontSize(14F);
                    document.Add(harmoniaConjugalTitulo);

                    Paragraph harmoniaConjugalExplicacao = new Paragraph($"A tabela dos relacionamentos identifica os tipos e padrões dos relacionamentos, pela comparação dos números do casal. Entretanto, esse número único não define com exatidão como será o relacionamento, ou casamento, mas apenas dá algumas referências de possíveis comportamentos dentro dele. \r\n\r\nTemos que levar em conta sempre o conjunto da obra, e dentro desse conjunto as características de comportamento e personalidade são determinantes no modo de se relacionar de cada um. É importante dizer que, nada se revela por apenas um único número, que ninguém é regido por apenas um único número; que todos nós somos revelados por um mapa composto por diversos números. \r\n\r\n*PS: Infelizmente, por a numerologia ser algo muito antigo, essa tabela contempla somente os relacionamentos entre pessoas dos gêneros masculino e feminino. Mas de acordo com os milhares de estudos que já fiz, não achei restrições nos resultados de relacionamentos de pessoas do mesmo sexo.");
                    harmoniaConjugalExplicacao.SetTextAlignment(TextAlignment.JUSTIFIED).SetItalic();
                    document.Add(harmoniaConjugalExplicacao);

                    document.Add(new Paragraph("\r\n"));

                    string numeroVibracao = string.Join(", ", model.HarmoniaConjugal.NumeroVibracao.Select(x => x.Numero));
                    string numeroAtracao = string.Join(", ", model.HarmoniaConjugal.NumeroAtracao.Select(x => x.Numero));
                    string numeroOposto = string.Join(", ", model.HarmoniaConjugal.NumeroOposto.Select(x => x.Numero));
                    string numeroPassivo = string.Join(", ", model.HarmoniaConjugal.NumeroPassivo.Select(x => x.Numero));

                    Paragraph h1 = new Paragraph(String.Format("O seu número é "));
                    h1.Add(new Text(model.HarmoniaConjugal.NumeroHarmoniaConjugal.ToString()).SetFont(boldFont));
                    h1.Add(new Text(" - Vibra com -  "));
                    h1.Add(new Text(numeroVibracao).SetFont(boldFont));
                    h1.Add(new Text(" - Atrai - "));
                    h1.Add(new Text(numeroAtracao).SetFont(boldFont));
                    h1.Add(new Text(" - É oposto a - "));
                    h1.Add(new Text(numeroOposto).SetFont(boldFont));
                    h1.Add(new Text(" - É passivo com - "));
                    h1.Add(new Text(numeroPassivo).SetFont(boldFont));
                    h1.SetTextAlignment(TextAlignment.JUSTIFIED);

                    document.Add(h1);
                    document.Add(new Paragraph("\r\n"));


                    Paragraph h2 = new Paragraph($"Número {model.HarmoniaConjugal.NumeroHarmoniaConjugal}").SetBold();
                    document.Add(h2);


                    Paragraph h3 = new Paragraph(model.HarmoniaConjugal.TextoHarmoniaConjugal).SetTextAlignment(TextAlignment.JUSTIFIED);
                    document.Add(h3);

                    document.Add(new Paragraph("\r\n"));

                    Paragraph h4 = new Paragraph($"Vibra com {numeroVibracao}").SetBold();
                    document.Add(h4);

                    Paragraph h5 = new Paragraph($"Os números que vibram sinalizam forte atração sexual e paixão, o que pode levar a conflitos constantes e até separação por causa de ciúmes exagerados, inconstância sexual, arrogância de um ou ambos os parceiros. No entanto, se a paixão amadurece na compreensão e aceitação mútuas, pelo amor, pode vir a ser um relacionamento promissor.").SetItalic();
                    h5.SetTextAlignment(TextAlignment.JUSTIFIED);
                    document.Add(h5);

                    document.Add(new Paragraph("\r\n"));

                    foreach (var item in model.HarmoniaConjugal.NumeroVibracao)
                    {
                        Paragraph h6 = new Paragraph(item.Numero + ": " + item.Texto).SetTextAlignment(TextAlignment.JUSTIFIED);
                        document.Add(h6);
                        document.Add(new Paragraph("\r\n"));
                    }


                    Paragraph h7 = new Paragraph($"Atrai: {numeroAtracao}").SetBold();
                    document.Add(h7);


                    Paragraph h8 = new Paragraph($"Os relacionamentos classificados pelos números que se atraem, são os mais compatíveis dentre todos, pelo maior número de\r\nsemelhanças entre o casal, e o relacionamento pode fluir em grande harmonia. Tende a ser um relacionamento com muito amor, cordialidade, delicadeza, cumplicidade e compreensão mútuas. \r\n\r\nO relacionamento com essa característica tem tudo para ser bem-sucedido e dar certo. No entanto, nem mesmo todos esses elementos favoráveis são garantia suficientes para o sucesso do relacionamento, pois este sempre dependerá de como as pessoas se respeitam e se amam. (Mas todos que já vi que tem esses números, são grandes casais apaixonados)").SetItalic();
                    h8.SetTextAlignment(TextAlignment.JUSTIFIED);
                    document.Add(h8);


                    document.Add(new Paragraph("\r\n"));

                    foreach (var item in model.HarmoniaConjugal.NumeroAtracao)
                    {
                        Paragraph h9 = new Paragraph(item.Numero + ": " + item.Texto).SetTextAlignment(TextAlignment.JUSTIFIED);
                        document.Add(h9);
                        document.Add(new Paragraph("\r\n"));

                    }


                    Paragraph h10 = new Paragraph($"Passivo com: {numeroPassivo}").SetBold();
                    document.Add(h10);


                    Paragraph h11 = new Paragraph($"São relacionamentos que começam, geralmente, com uma amizade e o casal cultiva muito carinho e respeito entre si, sendo que neste padrão de relacionamento a fidelidade é considerável.Os relacionamentos classificados pelos números passivos indicam que a amizade e a cumplicidade predominam sobre o sexo. \r\n\r\nPode ser que, com o tempo a amizade se sobreponha à relação íntima de casal, e o sexo esfrie ou acabe, vindo a se tornar uma relação mais de amizade do que de casal de fato. O que se tem notado é que mesmo havendo separação a tendência é que a amizade dure para sempre.").SetTextAlignment(TextAlignment.JUSTIFIED).SetItalic();
                    h11.SetTextAlignment(TextAlignment.JUSTIFIED);
                    document.Add(h11);


                    document.Add(new Paragraph("\r\n"));

                    foreach (var item in model.HarmoniaConjugal.NumeroPassivo)
                    {
                        Paragraph h12 = new Paragraph(item.Numero + ": " + item.Texto).SetTextAlignment(TextAlignment.JUSTIFIED);
                        document.Add(h12);
                        document.Add(new Paragraph("\r\n"));

                    }



                    Paragraph h13 = new Paragraph($"Oposto a: {numeroOposto}").SetBold();
                    document.Add(h13);


                    Paragraph h14 = new Paragraph($"Os relacionamentos classificados pelos números opostos não são, necessariamente, os piores. No entanto, trata-se de um padrão de relacionamento que exige muita compreensão, aceitação e respeito pela liberdade e intimidade das DUAS PARTES. \r\n\r\nGeralmente são pessoas de personalidade bem endividada, maduras e espiritualmente mais evoluídas, que se atraem nesse padrão de relacionamento. Pessoas imaturas e pouco evoluídas, dificilmente se suportarão num padrão de relacionamento com estas características.").SetTextAlignment(TextAlignment.JUSTIFIED).SetItalic();
                    h14.SetTextAlignment(TextAlignment.JUSTIFIED);
                    document.Add(h14);


                    document.Add(new Paragraph("\r\n"));

                    foreach (var item in model.HarmoniaConjugal.NumeroOposto)
                    {
                        Paragraph h15 = new Paragraph(item.Numero + ": " + item.Texto).SetTextAlignment(TextAlignment.JUSTIFIED);
                        document.Add(h15);
                        document.Add(new Paragraph("\r\n"));

                    }



                    #endregion


                    #region Ciclos de Vida

                    PdfCanvas ciclosCanva = new PdfCanvas(pdfDocumento.AddNewPage());
                    document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

                    #region Explicações

                    Paragraph ciclosTitulo = new Paragraph("CICLOS DE VIDA, DESAFIOS E MOMENTOS DECISIVOS").SetBold().SetFontSize(14F).SetTextAlignment(TextAlignment.CENTER);
                    document.Add(ciclosTitulo);

                    Paragraph cidoDeVidaSubTitulo = new Paragraph("Ciclos de Vida").SetFont(boldFont);
                    document.Add(cidoDeVidaSubTitulo);

                    Paragraph ciclosExplicacao = new Paragraph($"Os Ciclos de Vida representam as circunstâncias e as condições a que o ser humano estará exposto durante determinadas fases da sua vida. São os desdobramentos cíclicos do destino, que transcorrem de acordo com as características de mês, dia e ano de nascimento. São três os grandes ciclos da vida, cada um com características peculiares influenciando as atitudes e as escolhas do ser humano.\r\n\r\nImportante\r\n\r\nQuando um Ciclo de Vida tiver o mesmo número que uma das Lições Cármicas, o período vigente traz a oportunidade de a Lição Cármica ser aprendida mais rapidamente. Caso haja resistência aos aprendizados da lição cármica, poderão ocorrer algumas dificuldades no período.");
                    ciclosExplicacao.SetTextAlignment(TextAlignment.JUSTIFIED).SetItalic();
                    document.Add(ciclosExplicacao);


                    document.Add(new Paragraph("\r\n"));


                    Paragraph desafiosSubTitulo = new Paragraph("Desafios").SetFont(boldFont);
                    document.Add(desafiosSubTitulo);

                    Paragraph desafiosExplicacao = new Paragraph($"Os Desafios indicam as barreiras que se apresentam em cada fase da vida, decorrentes das carências de certas habilidades. Estão associados ao processo do amadurecimento psicoemocional da personalidade, solicitando o equilíbrio entre os seus extremos. Eles surgem como muralhas interpondo-se no caminho do progresso exigindo superação. \r\n\r\nCada desafio tem sua importância, porém, o principal é o que merece maior atenção, pois tende a ser o mais difícil e ressurge, inesperadamente, diante de qualquer situação mais complicada. Os Desafios são as oportunidades para desenvolver as habilidades fracas ou inexistentes. Quando aparece o desafio 0 (zero), a atenção deve se voltar também para os outros desafios, porquanto, poderão surgir vários ou até mesmo todos eles. \r\n\r\nExiste a probabilidade de que algumas pessoas não enfrentem nenhum dos desafios, mas isto é raríssimo devido ao patamar evolutivo atual da humanidade. O mais provável é a ocorrência de muitos desafios, ou mesmo todos eles. Nesses casos recomenda-se a publicação dos textos de todos os desafios, no Mapa Pessoal, para que o consulente tenha uma noção geral dos mesmos e possa assim compreender cada um deles e avaliar quais deles se apresentam para ele. \r\n\r\nImportante \r\n\r\nQuando o número de um Desafio for igual ao número de um Ciclo de Vida, de um Momento Decisivo ou do Destino, no mesmo período poderá se acentuar o nível de estresse emocional vindo a causar danos à saúde. É importante considerar que isto não determinará que o ser humano adoecerá, mas que poderá ocorrer um aumento das tensões emocionais, que, naturalmente causarão prejuízos à saúde. A tabela a seguir mostra como as tensões emocionais e o estresse poderão afetar alguns dos principais órgãos do corpo humano:\r\n\r\nNúmero 1 - Coração, cabeça e emocional;\r\n\r\nNúmero 2 - Rins, estômago e sistema nervoso;\r\n\r\nNúmero 3 - Garganta e fígado;\r\n\r\nNúmero 4 - Dentes, ossos e circulação sanguínea;\r\n\r\nNúmero 5 - Sistemas reprodutivo e nervoso;\r\n\r\nNúmero 6 - Coração e pescoço;\r\n\r\nNúmero 7 - Glândulas e sistema nervoso;\r\n\r\nNúmero 8 - Estômago e sistema nervoso.");
                    desafiosExplicacao.SetTextAlignment(TextAlignment.JUSTIFIED).SetItalic();
                    document.Add(desafiosExplicacao);

                    document.Add(new Paragraph("\r\n"));


                    Paragraph momentosDecisivosSubTitulo = new Paragraph("Momentos Decisivos").SetFont(boldFont);
                    document.Add(momentosDecisivosSubTitulo);

                    Paragraph momentosDecisivosExplicacao = new Paragraph($"Os Momentos Decisivos são ciclos importantes dentro do destino, indicando probabilidades, possibilidades e oportunidades em cada Ciclo de Vida. São as oportunidades que surgem nas suas várias áreas da vida, porém com grande ênfase no âmbito profissional. Cada Momento Decisivo indicará qual será a melhor atitude e a melhor escolha a ser feita naquele momento de assumir uma mudança, uma promoção, uma nova empreitada, um novo rumo na vida. O momento decisivo indica que há uma decisão importante a ser tomada, com base na escolha consciente, ou por imposição das circunstâncias quando o ser humano se acomoda na zona de conforto.\r\n\r\nImportante\r\n\r\nNúmero de Momento Decisivo igual ao número da Motivação significa que durante os anos do Momento Decisivo, o cenário estará favorável às realizações dos ideais, das ambições, da vontade ou dos desejos.\r\n\r\nNúmero de Momento Decisivo igual ao número da Expressão significa que durante os anos do Momento Decisivo, o cenário estará mais favorável ao desenvolvimento dos talentos e das aptidões da personalidade nas suas realizações pessoais e profissionais, principalmente.\r\n\r\nNúmero de Momento Decisivo igual ao número do Destino significa que, no período vigente do Momento Decisivo, o cenário estará mais favorável às realizações dos projetos pessoais e profissionais, ao progresso humano e sua evolução espiritual.\r\n\r\nNúmero do Momento Decisivo igual ao número de uma das Lições Cármicas significa que, no período vigente do Momento Decisivo se apresentarão as melhores oportunidades de aprendizados relacionados com aquela Lição Cármica, bem como poderão se apresentar algumas complicações se houver resistência.");
                    momentosDecisivosExplicacao.SetTextAlignment(TextAlignment.JUSTIFIED).SetItalic();
                    document.Add(momentosDecisivosExplicacao);

                    document.Add(new Paragraph("\r\n"));

                    #endregion

                    #region Primeiro Ciclo De vida

                    Paragraph primeiroCicloDeVidaSubTitulo = new Paragraph("Primeiro Ciclo de Vida").SetFont(boldFont);
                    document.Add(primeiroCicloDeVidaSubTitulo);

                    Paragraph primeiroCicloDeVidaExplicacao = new Paragraph($"O Ciclo Formativo\r\n\r\nMostra como foi, ou será, o palco nesta primeira etapa da vida – a chegada ao planeta, a adaptação ao cenário familiar, na infância, as primeiras experiências independentes na adolescência e na juventude até a maturidade. Revela como a criança absorveu, ou está absorvendo, a presença do pai e da mãe, como ela vivencia as suas primeiras experiências emocionais no cenário da família. Representa a transição da criança para o adolescente e para o ser adulto.");
                    primeiroCicloDeVidaExplicacao.SetTextAlignment(TextAlignment.JUSTIFIED).SetItalic();
                    document.Add(primeiroCicloDeVidaExplicacao);

                    document.Add(new Paragraph("\r\n"));
                    Paragraph primeirocicloDeVida = new Paragraph($"Ciclo de Vida {model.PrimeiroCicloDeVida.Numero} - {model.PrimeiroCicloDeVida.AnoDe} a {model.PrimeiroCicloDeVida.AnoAte} (de {model.PrimeiroCicloDeVida.IdadeDe} a {model.PrimeiroCicloDeVida.IdadeAte} anos)");
                    primeirocicloDeVida.SetTextAlignment(TextAlignment.JUSTIFIED).SetBold();
                    document.Add(primeirocicloDeVida);

                    Paragraph primeirocicloDeVidatexto = new Paragraph(model.PrimeiroCicloDeVida.Texto);
                    document.Add(primeirocicloDeVidatexto);
                    document.Add(new Paragraph("\r\n"));

                    #endregion


                    #region Primeiro Desafio
                    Paragraph primeirodesafioDeVida = new Paragraph($"Primeiro Desafio").SetBold();
                    primeirodesafioDeVida.SetTextAlignment(TextAlignment.JUSTIFIED);
                    document.Add(primeirodesafioDeVida);

                    Paragraph aparecePD = new Paragraph("Aparece junto com o primeiro ciclo de Vida").SetItalic().SetFontSize(12F);
                    document.Add(aparecePD);

                    Paragraph desafio = new Paragraph($"Desafio {model.Desafio.PrimeiroDesafio.Numero} - {model.Desafio.PrimeiroDesafio.AnoDe} a " +
                        $"{model.Desafio.PrimeiroDesafio.AnoAte} (de {model.Desafio.PrimeiroDesafio.IdadeDe} a {model.Desafio.PrimeiroDesafio.IdadeAte} anos)");
                    desafio.SetTextAlignment(TextAlignment.JUSTIFIED).SetBold();
                    document.Add(desafio);

                    Paragraph desafioTexto = new Paragraph(model.Desafio.PrimeiroDesafio.Texto).SetTextAlignment(TextAlignment.JUSTIFIED);
                    document.Add(desafioTexto);
                    document.Add(new Paragraph("\r\n"));

                    #endregion


                    #region Primeiro Momento Decisivo

                    Paragraph primeiroMomentoDecisivo = new Paragraph("Primeiro Momento Decisivo").SetFont(boldFont);
                    document.Add(primeiroMomentoDecisivo);

                    Paragraph apareceMD = new Paragraph("Reflete o início da vida, quando o ser humano se encontra mais influenciável, e apresenta as primeiras oportunidades que surgem de reagir, agir e decidir.").SetItalic().SetFontSize(12F);
                    document.Add(apareceMD);


                    Paragraph primeiroMomentoDecisivoDados = new Paragraph($"Momento Decisivo {model.PrimeiroMomentoDecisivo.Numero} - " +
                        $"{model.PrimeiroMomentoDecisivo.AnoDe} a {model.PrimeiroMomentoDecisivo.AnoAte} (de {model.PrimeiroMomentoDecisivo.IdadeDe} a {model.PrimeiroMomentoDecisivo.IdadeAte} anos de idade)").SetBold();

                    document.Add(primeiroMomentoDecisivoDados);

                    Paragraph primeiroMomentoDecisivoTxt = new Paragraph(model.PrimeiroMomentoDecisivo.Texto).SetTextAlignment(TextAlignment.JUSTIFIED);
                    document.Add(primeiroMomentoDecisivoTxt);
                    document.Add(new Paragraph("\r\n"));

                    #endregion


                    #region Segundo Ciclo De vida

                    Paragraph segundoCicloDeVidaSubTitulo = new Paragraph("Segundo Ciclo de Vida").SetFont(boldFont);
                    document.Add(segundoCicloDeVidaSubTitulo);

                    Paragraph segundoCicloDeVidaExplicacao = new Paragraph($"O Ciclo Produtivo\r\n\r\nÉ o centro da vida e reflete a disposição para as realizações pessoais. Mostra como o ser humano vai aparecer no palco da vida e o que veio fazer para si mesmo e para os outros. É cenário da vida no qual o ser humano atua com todas as suas energias empenhadas na construção dos seus patrimônios pessoais. Se não realizar, se sentirá frustrado!");
                    segundoCicloDeVidaExplicacao.SetTextAlignment(TextAlignment.JUSTIFIED).SetItalic();
                    document.Add(segundoCicloDeVidaExplicacao);

                    document.Add(new Paragraph("\r\n"));

                    Paragraph segundocicloDeVida = new Paragraph($"Ciclo de Vida {model.SegundoCicloDeVida.Numero} - {model.SegundoCicloDeVida.AnoDe} a {model.SegundoCicloDeVida.AnoAte} (de {model.SegundoCicloDeVida.IdadeDe} a " +
                        $"{model.SegundoCicloDeVida.IdadeAte} anos)");
                    segundocicloDeVida.SetTextAlignment(TextAlignment.JUSTIFIED).SetBold();
                    document.Add(segundocicloDeVida);

                    Paragraph segundocicloDeVidatexto = new Paragraph(model.SegundoCicloDeVida.Texto);
                    document.Add(segundocicloDeVidatexto);
                    document.Add(new Paragraph("\r\n"));

                    #endregion


                    #region Segundo Desafio
                    Paragraph segundodesafioDeVida = new Paragraph($"Segundo Desafio").SetBold();
                    segundodesafioDeVida.SetTextAlignment(TextAlignment.JUSTIFIED);
                    document.Add(segundodesafioDeVida);

                    Paragraph apareceSD = new Paragraph("Aparece junto com o segundo ciclo de Vida").SetItalic().SetFontSize(12F);
                    document.Add(apareceSD);

                    Paragraph desafioSegundo = new Paragraph($"Desafio {model.Desafio.SegundoDesafio.Numero} - {model.Desafio.SegundoDesafio.AnoDe} a " +
                        $"{model.Desafio.SegundoDesafio.AnoAte} (de {model.Desafio.SegundoDesafio.IdadeDe} a {model.Desafio.SegundoDesafio.IdadeAte} anos)");

                    desafioSegundo.SetTextAlignment(TextAlignment.JUSTIFIED).SetBold();
                    document.Add(desafioSegundo);

                    Paragraph segundodesafioTexto = new Paragraph(model.Desafio.SegundoDesafio.Texto).SetTextAlignment(TextAlignment.JUSTIFIED);
                    document.Add(segundodesafioTexto);
                    document.Add(new Paragraph("\r\n"));

                    #endregion


                    #region Segundo Momento Decisivo

                    Paragraph segundoMomentoDecisivo = new Paragraph("Segundo Momento Decisivo").SetFont(boldFont);
                    document.Add(segundoMomentoDecisivo);

                    Paragraph apareceSegundoMD = new Paragraph("Reflete uma fase na vida em que as obrigações com família, trabalho e negócios ocupam a maior parte do tempo. Surgem as primeiras oportunidades decisivas para o progresso pessoal e profissional, especialmente.").SetItalic().SetFontSize(12F);
                    document.Add(apareceSegundoMD);


                    Paragraph segundoMomentoDecisivoDados = new Paragraph($"Momento Decisivo {model.SegundoMomentoDecisivo.Numero} - " +
                        $"{model.SegundoMomentoDecisivo.AnoDe} a {model.SegundoMomentoDecisivo.AnoAte} (de {model.SegundoMomentoDecisivo.IdadeDe} a {model.SegundoMomentoDecisivo.IdadeAte} anos de idade)").SetBold();

                    document.Add(segundoMomentoDecisivoDados);

                    Paragraph segundoMomentoDecisivoTxt = new Paragraph(model.SegundoMomentoDecisivo.Texto).SetTextAlignment(TextAlignment.JUSTIFIED);
                    document.Add(segundoMomentoDecisivoTxt);
                    document.Add(new Paragraph("\r\n"));

                    #endregion


                    #region Terceiro Momento Decisivo

                    Paragraph terceiroMomentoDecisivo = new Paragraph("Terceiro Momento Decisivo").SetFont(boldFont);
                    document.Add(terceiroMomentoDecisivo);

                    Paragraph apareceTerceiroMD = new Paragraph("Reflete a fase da vida em que, geralmente, o ser humano alcança uma posição mais estável na vida, principalmente na carreira profissional. As oportunidades que surgem agora geralmente são mais decisivas para a consolidação da carreira profissional.").SetItalic().SetFontSize(12F);
                    document.Add(apareceSegundoMD);


                    Paragraph terceiroMomentoDecisivoDados = new Paragraph($"Momento Decisivo {model.TerceiroMomentoDecisivo.Numero} - " +
                        $"{model.TerceiroMomentoDecisivo.AnoDe} a {model.TerceiroMomentoDecisivo.AnoAte} (de {model.TerceiroMomentoDecisivo.IdadeDe} a {model.TerceiroMomentoDecisivo.IdadeAte} anos de idade)").SetBold();

                    document.Add(terceiroMomentoDecisivoDados);

                    Paragraph terceiroMomentoDecisivoTxt = new Paragraph(model.TerceiroMomentoDecisivo.Texto).SetTextAlignment(TextAlignment.JUSTIFIED);
                    document.Add(terceiroMomentoDecisivoTxt);
                    document.Add(new Paragraph("\r\n"));

                    #endregion


                    #region Quarto Momento Decisivo

                    Paragraph quartoMomentoDecisivo = new Paragraph("Quarto Momento Decisivo").SetFont(boldFont);
                    document.Add(quartoMomentoDecisivo);

                    Paragraph apareceQuartoMD = new Paragraph("Reflete a fase na vida em que, geralmente, o ser humano já está em uma posição mais estável na vida, principalmente na carreira profissional, e traz novas oportunidades que se estenderão pelos anos seguintes, quase sempre sem grandes mudanças até o final da vida.").SetItalic().SetFontSize(12F);
                    document.Add(apareceQuartoMD);


                    Paragraph quartoMomentoDecisivoDados = new Paragraph($"Momento Decisivo {model.QuartoMomentoDecisivo.Numero} - " +
                        $"{model.QuartoMomentoDecisivo.AnoDe} ({model.QuartoMomentoDecisivo.IdadeDe} {model.QuartoMomentoDecisivo.IdadeAte})").SetBold();

                    document.Add(quartoMomentoDecisivoDados);

                    Paragraph quartoMomentoDecisivoTxt = new Paragraph(model.QuartoMomentoDecisivo.Texto).SetTextAlignment(TextAlignment.JUSTIFIED);
                    document.Add(quartoMomentoDecisivoTxt);
                    document.Add(new Paragraph("\r\n"));

                    #endregion



                    #region Terceiro Ciclo De vida

                    Paragraph terceiroCicloDeVidaSubTitulo = new Paragraph("Terceiro Ciclo de Vida").SetFont(boldFont);
                    document.Add(terceiroCicloDeVidaSubTitulo);

                    Paragraph terceiroCicloDeVidaExplicacao = new Paragraph($"O Ciclo da Colheita e do Compartilhamento\r\n\r\nÉ o último ciclo da vida, a fase da maturidade plena quando a riqueza das experiências forma o cenário das realizações pessoais. Há uma desaceleração no ritmo alucinante das conquistas, porém, ocorre um aumento na produtividade decorrente das escolhas mais assertivas. É uma fase de colheitas e compartilhamentos, de buscas por valores atemporais e sabedoria. \r\nUma fase na qual o ser humano se volta mais para o seu mundo interior. A maturidade proporciona reflexões que antes não aconteciam, e desperta o senso da responsabilidade de exemplificar virtudes e valores éticos para os mais jovens.");
                    terceiroCicloDeVidaExplicacao.SetTextAlignment(TextAlignment.JUSTIFIED).SetItalic();
                    document.Add(terceiroCicloDeVidaExplicacao);

                    document.Add(new Paragraph("\r\n"));

                    Paragraph terceirocicloDeVida = new Paragraph($"Ciclo de Vida {model.TerceiroCicloDeVida.Numero} - {model.TerceiroCicloDeVida.AnoDe} (de {model.TerceiroCicloDeVida.IdadeDe} " +
                        $"{model.TerceiroCicloDeVida.IdadeAte})");
                    terceirocicloDeVida.SetTextAlignment(TextAlignment.JUSTIFIED).SetBold();
                    document.Add(terceirocicloDeVida);

                    Paragraph terceirocicloDeVidatexto = new Paragraph(model.TerceiroCicloDeVida.Texto);
                    document.Add(terceirocicloDeVidatexto);
                    document.Add(new Paragraph("\r\n"));

                    #endregion

                    #region Desafio Principal
                    Paragraph desafioPrincipal = new Paragraph($"Desafio Principal").SetBold();
                    desafioPrincipal.SetTextAlignment(TextAlignment.JUSTIFIED);
                    document.Add(desafioPrincipal);

                    Paragraph apareceDP = new Paragraph("Este desafio é o mais difícil de ser vencido. Ele pode ressurgir inesperadamente diante de alguma situação um pouco mais complicada, independente de qual Ciclo de Vida a pessoa esteja.").SetItalic().SetFontSize(12F);
                    document.Add(apareceDP);

                    Paragraph desafioPrincipalDados = new Paragraph($"Desafio {model.Desafio.TerceiroDesafio.Numero} - {model.Desafio.TerceiroDesafio.AnoDe} " +
                        $"({model.Desafio.TerceiroDesafio.IdadeDe} até o final da vida)");

                    desafioPrincipalDados.SetTextAlignment(TextAlignment.JUSTIFIED).SetBold();
                    document.Add(desafioPrincipalDados);

                    Paragraph desafioPrincipalTexto = new Paragraph(model.Desafio.TerceiroDesafio.Texto).SetTextAlignment(TextAlignment.JUSTIFIED);
                    document.Add(desafioPrincipalTexto);
                    document.Add(new Paragraph("\r\n"));

                    #endregion


                    #endregion


                    #region Triangulo Invertido

                    #region Triangulo

                    PdfCanvas trianguloCanvas = new PdfCanvas(pdfDocumento.AddNewPage());
                    document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

                    Paragraph tituloTriangulo = new Paragraph("Triangulo da Vida").SetBold().SetFontSize(14F);
                    document.Add(tituloTriangulo);

                    Paragraph triantuloExplicacao = new Paragraph("O Triângulo da Vida, também denominado Triângulo Invertido da Vida ou Pirâmide Invertida, é uma formação triangular dos números que compõe o conjunto das vibrações do nome de um ser humano. São códigos “secretos” que revelam, aos iniciados nos estudos da Numerologia Cabalística, probabilidades e possibilidades na vida do ser humano, como eventos, ocorrências e aprendizados. \r\n\r\nCada nome é um holograma que se projeta com suas vibrações direcionando a formação da personalidade. Portanto, não tem como separar o nome da personalidade, e uma vez que a personalidade se cristalizou com os padrões do nome, este vindo a ser mudado não vai mudar a personalidade e sim dar-lhe novo direcionamento nas atitudes e nos comportamentos.\r\n\r\nPor meio dos trânsitos entre as letras do nome, caracterizados em períodos, vibram padrões diversos de frequências marcando eventos e prevendo ocorrências que podem acontecer, ou serem modificados em seu curso, conforme a vontade e a disciplina de cada um. Na primeira linha abaixo das letras do nome estão os arcanos que ditam os principais eventos – Arcanos Dominantes. \r\n\r\nDentro dos triângulos invertidos podem aparecer, ainda, as mais diversas combinações de números, todas importantes sinalizações de eventuais dificuldades, obstáculos, desafios ou favorecimentos. \r\n\r\nDentre essas outras combinações numéricas, destacam-se as sequências de três ou mais números iguais (Sequências Numéricas), apontando para situações de dificuldade em determinadas áreas da vida; são barreiras a serem transpostas. \r\n\r\nCada pessoa tem, no seu nome, as configurações necessárias para atrair os eventos que ajudarão no fortalecimento da sua personalidade, para o seu crescimento pessoal e a sua evolução espiritual, conforme são os seus méritos. \r\n\r\nÉ importante considerar que a ninguém é dado castigo por ter feito mal as lições no passado, mas que cada um recebe as melhores oportunidades de aprendizado e ajustamentos. Por isso, tudo pode ser modificado se não estiver de acordo com o caminho da autorrealização e da felicidade.").SetItalic();
                    triantuloExplicacao.SetTextAlignment(TextAlignment.JUSTIFIED).SetItalic();
                    document.Add(triantuloExplicacao);


                    PdfCanvas trianguloCanvas2 = new PdfCanvas(pdfDocumento.AddNewPage());
                    document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

                    Paragraph tituloTriangulo2 = new Paragraph("Triangulo da Vida").SetBold().SetTextAlignment(TextAlignment.CENTER);
                    document.Add(tituloTriangulo2);

                    document.Add(new Paragraph("\r\n"));


                    Paragraph paragrafo = new Paragraph().SetTextAlignment(TextAlignment.CENTER).SetFixedLeading(4F).SetFontSize(13.5F);
                    var tabelaConversao = MetodosDeExtensao.GetValoresTabelaConversao();

                    var nome = nomeCompleto.ToUpper();
                    //pegar só as letras e valores correspondentes ao nome e preenche a primeira linha
                    for (int i = 0; i < nome.Length; i++)
                    {
                        int valor = 0;

                        if (tabelaConversao.ContainsKey(nome[i].ToString()))
                        {
                            paragrafo.Add(nomeCompleto[i].ToString() + " ");
                            tabelaConversao.TryGetValue(nome[i].ToString(), out valor);
                            valoresDoNome.Add(valor);
                        }
                    }
                    document.Add(paragrafo);

                    int count = 0;


                    count = valoresDoNome.Count;
                    paragrafo = new Paragraph().SetTextAlignment(TextAlignment.CENTER).SetFixedLeading(6F);

                    //preenche a 2 (segunda) linha do triangulo o valores de cada letra
                    if (count == valoresDoNome.Count)
                    {

                        //preenche a segunda linha com os valores
                        for (int i = 0; i < count; i++)
                        {
                            paragrafo.Add(valoresDoNome[i] + " ");
                            valoresSubtraidos.Add(valoresDoNome[i]);
                        }
                        document.Add(paragrafo);

                        count--;
                    }

                    //preenche o restante das linhas

                    paragrafo = new Paragraph().SetTextAlignment(TextAlignment.CENTER).SetFixedLeading(3.3F);

                    string espaco = string.Empty;
                    while (valoresDoNome.Count > 1)
                    {
                        valoresSubtraidos = new List<int>();
                        espaco += " ";
                        paragrafo.Add(espaco);

                        for (int a = 0; a < count; a++)
                        {
                            int valor = MetodosDeExtensao.ReduzirAUmAlgarismo(valoresDoNome[a] + valoresDoNome[a + 1], true);
                            valoresSubtraidos.Add(valor);
                            paragrafo.Add(valor + " ");
                        }
                        valoresDoNome.Clear();
                        document.Add(paragrafo);
                        valoresDoNome = valoresSubtraidos;
                        paragrafo = new Paragraph().SetTextAlignment(TextAlignment.CENTER).SetFixedLeading(3.3F);
                        count--;
                    }
                    document.Add(new Paragraph("\r\n"));

                    #endregion

                    #region Sequencias Negativas
                    string triangulos = string.Join(",", model.TrianguloDaVida.SequenciasNegativas.Select(x => x.Numero.ToString()));
                    Paragraph t1 = new Paragraph($"No Triangulo da Vida acima, aparecem sequências de números repetidos {triangulos}. Estas sequências refletem dificuldades ou obstáculos em determinadas áreas da vida, como demonstrado a seguir:");
                    t1.SetTextAlignment(TextAlignment.JUSTIFIED);
                    document.Add(t1);

                    foreach (var item in model.TrianguloDaVida.SequenciasNegativas)
                    {
                        Paragraph t2 = new Paragraph($"{item.Numero} - {item.Texto}").SetTextAlignment(TextAlignment.JUSTIFIED);
                        document.Add(t2);
                    }
                    document.Add(new Paragraph("\r\n"));

                    #endregion

                    #region Arcano

                    Paragraph arcano = new Paragraph($"Neste momento - {model.TrianguloDaVida.Idade} anos de idade - localizamos dominando no seu nome " +
                        $"de nascimento o Arcano {model.TrianguloDaVida.ArcanoAtual.Numero}. Este Arcano é o dominante na sua vida pelo período mais ou menos até " +
                        $"{model.TrianguloDaVida.IdadeArcano} anos de idade.").SetTextAlignment(TextAlignment.JUSTIFIED);
                    document.Add(arcano);

                    Paragraph arcano2 = new Paragraph($"O Triângulo da Vida do seu nome de nascimento é regido pelo Arcano " +
                        $"{model.TrianguloDaVida.ArcanoTrianguloDaVida}.").SetTextAlignment(TextAlignment.JUSTIFIED);
                    document.Add(arcano2);

                    document.Add(new Paragraph("\r\n"));

                    string arcanos = string.Join(",", model.TrianguloDaVida.Arcanos.Select(x => x.Numero));
                    Paragraph arcanosTriangulo = new Paragraph($"O seu nome de nascimento é formado pelos seguintes Arcanos: {arcanos} ");
                    document.Add(arcanosTriangulo);

                    Paragraph periodoArcano = new Paragraph($"Cada Arcano no seu nome de nascimento vibra dominando por cerca de {model.TrianguloDaVida.PeriodoArcano} anos");
                    document.Add(periodoArcano);
                    document.Add(new Paragraph("\r\n"));

                    Paragraph importanteArcano = new Paragraph($"Importante\r\nO período de domínio de cada Arcano pode variar para mais " +
                        $"ou para menos de acordo com fatores particulares da vida de cada pessoa. " +
                        $"Os cálculos aqui aplicados não são exatos, e sim estimativos podendo " +
                        $"ocorrer variações nos períodos. Além disso, nas transições de um arcano para outro ocorrem sobreposições de ambos.");

                    document.Add(importanteArcano);

                    document.Add(new Paragraph("\r\n"));

                    #endregion

                    #region Explicação Arcanos

                    Paragraph explicacaoArcanos = new Paragraph("Explicação Arcanos do Nome").SetTextAlignment(TextAlignment.CENTER).SetBold();
                    document.Add(explicacaoArcanos);

                    foreach (var item in model.TrianguloDaVida.Arcanos)
                    {
                        Paragraph arcanosNumero = new Paragraph($"Arcano {item.Numero}").SetBold();
                        document.Add(arcanosNumero);
                        Paragraph arcanosText = new Paragraph(item.Texto);
                        document.Add(arcanosText);
                        document.Add(new Paragraph("\r\n"));

                    }
                    #endregion

                    #region Conclusao

                    PdfCanvas conclusaoCanvas = new PdfCanvas(pdfDocumento.AddNewPage());
                    document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

                    Paragraph conclusao = new Paragraph($"Prezada(o) {nomeCompleto}, ");
                    document.Add(conclusao);

                    Paragraph conclusaoText = new Paragraph($"Este mapa revela muitas coisas a seu respeito que talvez nunca tenha percebido antes. Faça dele seu orientador constante e desenvolva todas as suas potencialidades nele reveladas. Preste atenção, também, nas lições que precisa aprender e nos desafios e obstáculos que precisa superar.\r\nTudo o que este mapa revela pode ser aceito ou não por você, porém, se pelo menos prestar atenção poderá perceber que tudo o que está escrito nele faz algum sentido para você. Muitas coisas você já modificou e outras ainda não se apresentaram por não ter chegado seu momento. Não caia na ilusão de que tudo já está predeterminado em sua vida, e que deve apenas seguir o que está escrito em seu destino. O mapa revela como você chegou a esta vida, o que traz em sua alma de suas experiências e aprendizados passados, e o que está previsto acontecer seguindo esta linha da vida. Mas é você quem decide o que vai acrescentar à sua alma, e quando vai fazer, porque tem liberdade para isso. O destino é uma construção da alma.\r\nAlguns textos podem parecer rigorosos demais, mas isso não deve ser levado literalmente ao pé da letra. Eles refletem uma ordem geral das coisas, e cabe a você escolher entre o melhor para si ou deixar que os fatos aconteçam pela ordem do padrão vindo do passado. Modificar o padrão significa fazer escolhas conscientes e assumir a responsabilidade por sua vida, e não mais se deixar levar pelas circunstancias aleatoriamente. Neste sentido a Numerologia Cabalística ajudará muito, ou pelo menos despertará o seu interesse pelo seu autoconhecimento.\r\nGratidão por sua confiança!\r\nPaz e prosperidade,");

                    conclusaoText.SetTextAlignment(TextAlignment.JUSTIFIED);
                    document.Add(conclusaoText);
                    #endregion

                    PdfCanvas numerologiaCanvas = new PdfCanvas(pdfDocumento.AddNewPage());
                    document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

                    Paragraph numerologiaCabalistica = new Paragraph($"Numerologia Cabalística").SetFont(boldFont).SetTextAlignment(TextAlignment.CENTER);
                    document.Add(numerologiaCabalistica);


                    Paragraph numerologiaCabalisticatxt = new Paragraph($"Segundo a tradição cabalista, cada número contém um mistério e um atributo que se refere à divindade ou a alguma inteligência. Tudo o que existe na natureza forma uma unidade pelo encadeamento de causas e efeitos, que se multiplicam ao infinito, e cada uma dessas causas refere-se a um número determinado. Existe uma ordem no Universo, do átomo ao sistema solar e as Galáxias. Um interesse crescente no ritmo dessa ordem fez surgir novos esforços para sintetizar os diferentes métodos empregados através dos tempos para compreendê-la. Em algum lugar, entre o microcosmo e o macrocosmo, procuramos pela chave que poderá colocar o nosso mundo numa perspectiva lógica. Acreditamos que a ciência dos números pode proporcionar fórmulas que ajudem a esclarecer o padrão de evolução da existência na Terra. Esta sabedoria antiga tem sobrevivido às vicissitudes do tempo para sugerir alguma base na qual podemos construir novos métodos de analisar a personalidade humana, ou, pelo menos, de lançar uma nova luz nos sistemas usados no passado.\r\nEmbora contendo o elemento mistério, os nossos métodos procedem de modo ordeiro e prático, usando os números envolvidos no nome e data de nascimento para solucionar os enigmas da individualidade, personalidade, e os padrões de propósito e destino carregados através da vida por todo ser humano. Nascemos todos numa certa data, hora e minuto no campo energético da Terra. As condições vibratórias desse campo de energia determinam, em grande medida, as ações e reações particulares que caracterizarão toda a nossa vida. Estamos condicionados pelo conjunto básico de vibrações que estava em ação quando fizemos a nossa primeira inspiração. A data de nascimento proporciona o padrão por nós denominado de destino.\r\nO nome que recebemos ao nascer, transformado em números através do código de números-letras, usado desde a antiguidade, proporciona conhecer os padrões que caracterizam a personalidade em seus três aspectos principais - a Motivação, que reflete a alma; a Impressão, que reflete o ego; a Expressão, que reflete as características gerais da personalidade, seus talentos e aptidões. Mas o nome revela muito mais que só isso.\r\nA Numerologia Cabalística é uma das mais antigas ciências que estuda e aplica os valores dos números e das letras para identificar a essência metafísica das coisas. A Cabala ensina, entre outras coisas, que cada letra, número e acento da escrita possui um sentido escondido, e ensina os métodos de interpretação para compreender esses significados velados. Podemos, através da decodificação do nome e data de nascimento, desvendar muitos enigmas da nossa existência e fazer um verdadeiro mapa que nos orienta com segurança e sabedoria na realização de nosso destino. Todos os eventos da vida estão representados por números. Nossos dons e talentos, aptidões e potencialidades; desafios, obstáculos, oportunidades e circunstâncias as quais estaremos expostos durante toda a vida; o que trazemos do passado (de outras vidas), e como será o nosso futuro. A nossa existência está toda codificada em números, e é possível decifrar esses códigos através da Numerologia Cabalística.").SetTextAlignment(TextAlignment.JUSTIFIED);
                    document.Add(numerologiaCabalisticatxt);
                    document.Add(new Paragraph("\r\n"));

                    Paragraph nomeNumerologo = new Paragraph("Talles Yossef").SetTextAlignment(TextAlignment.RIGHT);
                    document.Add(nomeNumerologo);

                    Paragraph emailNumerologo = new Paragraph("contato@talesyossef.com.br").SetTextAlignment(TextAlignment.RIGHT);
                    document.Add(emailNumerologo);

                    #endregion

                    pdfDocumento.Close();

                }
                string file = System.IO.Path.GetFileName(fileName);
                return file;
            }
        }
    }
}

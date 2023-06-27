using MyTarget.Application.Configurations;
using MyTarget.Application.Entities;
using MyTarget.Application.Interfaces;

namespace MyTarget.Application.Commands
{
    public class ExecuteCommand : ScreenConfiguration
    {
        private readonly IResultDrawService _resultDrawService;
        private readonly IStandardStructureService _standardStructureService;
        private readonly ITrendService _trendService;
        private readonly IAverageFrequencyRepetitionService _averageFrequencyRepetitionService;
        private readonly IDrawTotalService _drawTotalService;
        private readonly IPossibilityHitService _possibilityHitService;
        private readonly IAmountTensBetService _amountTensBetService;
        public ExecuteCommand(IResultDrawService resultDrawService, 
                              IStandardStructureService standardStructureService,
                              ITrendService trendService,
                              IAverageFrequencyRepetitionService averageFrequencyRepetitionService,
                              IDrawTotalService drawTotalService,
                              IPossibilityHitService possibilityHitService,
                              IAmountTensBetService amountTensBetService)
        {
            _resultDrawService = resultDrawService;
            _standardStructureService = standardStructureService;
            _trendService = trendService;
            _averageFrequencyRepetitionService = averageFrequencyRepetitionService;
            _drawTotalService = drawTotalService;
            _possibilityHitService = possibilityHitService;
            _amountTensBetService = amountTensBetService;
        }

        public void Execute()
        {
            //mensagem do tipo de jogos
            var info = this.InfoType();

            //busca os números padrões
            var standardStructure = _standardStructureService.StandardStructureAll();

            //busca possibilidades de acerto
            var possibilityHit = _possibilityHitService.PossibilityHitAll();

            //busca qtde de apostas possíveis
            var amountTensBet = _amountTensBetService.AmountTensBetAll();


            //busca os resultados no Excel
            var resultDraw = _resultDrawService.ResultDrawAll();
            if (resultDraw == null)
            {
                //mensagem de dados não encontrados
                this.DataNotFound();
                return;
            }

            //mensagem de opções de análise
            var analysis = this.AnalysisOption();

            if (analysis == 5)
            {

            }
            else
            {
                //mensagem do tipo de filtro
                var filter = this.FilterType();

                ContestBreakEntity range = new ContestBreakEntity();
                if (filter == 2)
                {
                    //mensagem de todos ou intervalo
                    range = this.RangeFilter(resultDraw);

                    resultDraw = resultDraw.Where(a => a.contestNumber >= range.initialContest
                                                    && a.contestNumber <= range.finalContest).ToList();
                }

                //executa conforme parametros escolhidos
                switch (analysis)
                {
                    case 1:
                        _trendService.GenerateTrend(resultDraw, standardStructure, false);
                        this.FinalizeProcess();
                        this.Execute();
                        break;
                    case 2:
                        _trendService.GenerateTrend(resultDraw, standardStructure, true);
                        this.FinalizeProcess();
                        this.Execute();
                        break;
                    case 3:
                        _averageFrequencyRepetitionService.GenerateAverageFrequency(resultDraw, standardStructure);
                        this.FinalizeProcess();
                        this.Execute();
                        break;
                    case 4:
                        _drawTotalService.GenerateDrawTotal(resultDraw, standardStructure);
                        this.FinalizeProcess();
                        this.Execute();
                        break;
                    default:
                        Console.WriteLine("O P Ç Ã O   I N D I S P O N Í V E L   N O   M O M E N T O");
                        ConsoleKeyInfo key = Console.ReadKey();
                        break;
                }
            }
            
            
            
        }

        

    }
}

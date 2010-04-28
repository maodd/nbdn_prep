using System.Collections.Generic;

namespace nothinbutdotnetprep.collections
{
    public class StudioRanking
    {
        public static readonly Dictionary<ProductionStudio, int> Ranking
            = new Dictionary<ProductionStudio, int>
                  {
                      {ProductionStudio.MGM, 0},
                      {ProductionStudio.Pixar, 1},
                      {ProductionStudio.Dreamworks, 2},
                      {ProductionStudio.Universal, 3},
                      {ProductionStudio.Disney, 4},
    
    };

    }
}
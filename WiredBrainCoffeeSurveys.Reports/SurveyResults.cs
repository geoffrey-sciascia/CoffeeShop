using System;
using System.Collections.Generic;
using System.Text;

namespace WiredBrainCoffeeSurveys.Reports
{
    public class SurveyResults
    {
        // Aggregate ratings, Get rid of hardcoded data, and static typing.
        public double ServiceScore { get; set; }

        public double CoffeeScore { get; set; }

        public double PriceScore { get; set; }

        public double FoodScore { get; set; }

        public double WouldRecommend { get; set; }

        public string FavoriteProduct { get; set; }

        public string LeastFavoriteProduct { get; set; }

        public string AreaToImprove { get; set; }

        // Aggregate counts, Get rid of hardcoded data, and static typing.
        public double NumberSurveyed { get; set; }

        public double NumberResponded { get; set; }

        public double NumberRewardsMembers { get; set; }

        // Individual survey, responses Get rid of hardcoded data, and static typing.
        public List<SurveyResponse> Responses { get; set; }
    }
}

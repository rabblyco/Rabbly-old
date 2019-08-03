using System;
using System.ComponentModel.DataAnnotations.Schema;
using Rabbly.Data.Models;
using RabblyApi.Data.Utils;
using RabblyApi.Users.Models;

namespace RabblyApi.ScoreCards.Models
{
    public class ScoreCard : BaseModel
    {
        public User User { get; set; }
        public Opinion Opinion { get; set; }
        public int AdHominem { get; set; }
        public int Strawman { get; set; }
        public int FalseCause { get; set; }
        public int EmotionAppeal { get; set; }
        public int FallacyFallacy { get; set; }
        public int SlipperySlope { get; set; }
        public int TuQuoque { get; set; }
        public int PersonalIncredulity { get; set; }
        public int SpecialPleading { get; set; }
        public int LoadedQuestion { get; set; }
        public int BurdenProof { get; set; }
        public int Ambiguity { get; set; }
        public int GamblerFallacy { get; set; }
        public int Bandwagon { get; set; }
        public int AuthorityAppeal { get; set; }
        public int CompositionDivision { get; set; }
        public int NoTrueScotsman { get; set; }
        public int Genetic { get; set; }
        public int FalseDilemma { get; set; }
        public int BeggingQuestion { get; set; }
        public int AppealToNature { get; set; }
        public int Anecdotal { get; set; }
        public int CherryPick { get; set; }
        public int MiddleGround { get; set; }
    }
}
using Rabbly.Data.Models;
using RabblyApi.Data.Utils;
using RabblyApi.Users.Models;
using RabblyApi.Debates.Models;
using RabblyApi.Polls.Models;
using RabblyApi.Comments.Models;

namespace RabblyApi.ScoreCards.Models
{
    public class ScoreCard : BaseModel
    {
        public User User { get; set; }
        public Debate Debate { get; set; }
        public Poll Poll { get; set; }
        public Comment Comment { get; set; }
        public Opinion Opinion { get; set; }
        /*
        Emotional Fallacies
        */
        // Use emotion to distract from the facts.
        public int SentimentalAppeal { get; set; }

        // Use misleading or unrelated evidence to support a conclusion.
        public int RedHerring { get; set; }
        // Attempt to frighten people into agreeing or face dire consequences.

        public int ScareTactic { get; set; }

        // Encourage everyone to agree because everyone else is doing so.
        public int Bandwagon { get; set; }

        // Suggests that one action will inevitably lead to another.
        public int SlipperySlope { get; set; }

        // States that there are only two possible options.
        public int FalseDilemma { get; set; }

        // Argument to create an unnecessary desire.
        public int FalseNeed { get; set; }

        /*
        Ethical Fallacies
        */
        // Asks for people to agree based upon the authority (well-known person, government officals, etc.).
        public int FalseAuthority { get; set; }

        // States that because someone associates with another, that they must hold their position.
        public int FalseAssociation { get; set; }

        // States that the writer's beliefs are the only acceptable ones.
        public int Dogmatism { get; set; }

        // compares minor crimes with much more serious ones (or vice versa).
        public int MoralEquivalence { get; set; }

        // Attacks a persons character rather than the argument.
        public int AdHominem { get; set; }

        // Set up an argument to easily misrepresent it in order to defeat.
        public int StrawPerson { get; set; }

        /*
        Logical fallacies
        */
        // Draw a conclusion from scant or flimsy evidence.
        public int HastyGeneralization { get; set; }

        // Confuse chronological evidence with causation
        public int FaultyCausality { get; set; }

        // A statement which does not logically relate to the one before it.
        public int NonSequitor { get; set; }

        // A half-truth that is used to obscure the whole truth.
        public int Equivocation { get; set; }

        // The writer restates the claim in a different way in order to refute the claim
        public int BeggingTheQuestion { get; set; }

        // An inaccurate or faulty comparison between two things.
        public int FaultyAnalogy { get; set; }

        // Represents only one side of the issue
        public int StackedEvidence { get; set; }
    }
}
export class ScoreCard {
    user: string;
    debate?: string;
    poll?: string;
    comment?: string;
    opinion: number;
    /*
    Emotional Fallacies
    */
    // Use emotion to distract from the facts.
    senitmentalAppeal: number;
    // Use misleading or unrelated evidence to support a conclusion.
    redHerring: number;
    // Attempt to frighten people into agreeing or face dire consequences.
    scareTactic: number;
    // Encourage everyone to agree because everyone else is doing so.
    bandWagon: number;
    // Suggests that one action will inevitably lead to another.
    slipperySlope: number;
    // States that there are only two possible options.
    falseDilemma: number;
    // Argument to create an unnecessary desire.
    falseNeed: number;
    /*
    Ethical Fallacies
    */
    // Asks for people to agree based upon the authority (well-known person, government officals, etc.).
    falseAuthority: number;
    // States that because someone associates with another, that they must hold their position.
    falseAssociation: number;
    // States that the writer's beliefs are the only acceptable ones.
    dogmatism: number;
    // compares minor crimes with much more serious ones (or vice versa).
    moralEquivalence: number;
    // Attacks a persons character rather than the argument.
    adHominem: number;
    // Set up an argument to easily misrepresent it in order to defeat.
    strawPerson: number;
    /*
    Logical fallacies
    */
    // Draw a conclusion from scant or flimsy evidence.
    hastGeneralization: number;
    // Confuse chronological evidence with causation
    faultyCausality: number;
    // A statement which does not logically relate to the one before it.
    nonSequitor: number;
    // A half-truth that is used to obscure the whole truth.
    equivocation: number;
    // The writer restates the claim in a different way in order to refute the claim
    beggingTheQuestion: number;
    // An inaccurate or faulty comparison between two things.
    faultyAnalogy: number;
    // Represents only one side of the issue
    stackedEvidence: number;
}
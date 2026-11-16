// ReSharper disable InconsistentNaming
// Rider want both the public getter and private backing field to have the same name.

using System.Security.Cryptography;
using DataModel;
using DataModel.Constants;

namespace Tests.Common;

public static class Mocks
{
    private static readonly BallotType _ballotType = new()
    {
        Id = 1,
        Description = "Type 1",
        ExternalId = "HangingChad"
    };

    private static readonly BallotTypeContest _ballotTypeContest = new()
    {
        BallotTypeId = 1,
        ContestId = 1
    };

    private static readonly Candidate _candidate = new()
    {
        Id = 1,
        Description = "George Washington",
        ExternalId = "The First",
        ContestId = 1,
        CandidateTypeId = 1,
        Disabled = false
    };

    private static readonly CandidateType _candidateType = new()
    {
        Id = 1,
        Description = "President"
    };

    private static readonly CandidateAffiliation _candidateAffiliation = new()
    {
        CandidateId = 1,
        PartyId = 1
    };

    private static readonly Card _card = new()
    {
        Id = 1,
        CardId = 1,
        KeyInId = 1,
        PaperIndex = 1,
        OriginalId = 1
    };

    private static readonly CardContest _cardContest = new()
    {
        Id = 1,
        ManifestationId = 1,
        CardId = 1,
        ContestId = 1,
        Undervotes = 0,
        Overvotes = 0
    };

    private static readonly CardContestOutstackCondition _cardContestOutstackCondition = new()
    {
        CardContestId = 1,
        OutstackConditionId = 1
    };

    private static readonly CardOutstackCondition _cardOutstackCondition = new()
    {
        CardId = 1,
        OutstackConditionId = 1
    };

    private static readonly CollectionVersion _collectionVersion = new()
    {
        Id = 1,
        Name = CollectionNames.BallotType,
        Version = "1.0.0.0"
    };

    private static readonly Configuration _configuration = new()
    {
        Id = 1,
        IncludeTabulatorFilter = false,
        TabulatorFilterValue = 0,
        IncludeResultContainerFilter = false,
        ResultContainerFilterValue = 0,
        IncludeBallotTypeFilter = false,
        BallotTypeFilterValue = 0,
        SplitFilesPerBatch = false,
        IncludeOnlyPublishedResultContainers = false,
        UseTabulatorFormat = false,
        IncludeSessionDetails = false,
        IncludeMarkDensity = false,
        CvrType = 0,
        CvrTurnoutTest = 0,
        CvrSuppressionType = 0,
        TurnoutThreshold = 0
    };

    private static readonly Contest _contest = new()
    {
        Id = 1,
        Description = "Governor",
        ExternalId = "Da Governorship",
        DistrictId = 1,
        VoteFor = 1,
        NumOfRanks = 5,
        NumOfWriteins = 1,
        Disabled = false,
        ContestTypeId = 1
    };

    private static readonly ContestFilter _contestFilter = new()
    {
        Id = 1,
        ConfigurationId = 1
    };

    private static readonly ContestType _contestType = new()
    {
        Id = 1,
        Description = "Comedy"
    };

    private static readonly CountingGroup _countingGroup = new()
    {
        Id = 1,
        Description = "Count Countula",
        ExternalId = "That Numbers Guy"
    };

    private static readonly District _district = new()
    {
        Id = 1,
        Description = "The Flying First",
        ExternalId = "Aeronauts 1",
        DistrictTypeId = DistrictGuid,
        DistrictType = null,
        Contests = null,
        PrecinctPortions = null
    };

    private static readonly DistrictPrecinctPortion _districtPrecinctPortion = new()
    {
        DistrictId = 1,
        PrecinctPortionId = 1
    };

    private static readonly DistrictType _districtType = new()
    {
        Id = DistrictGuid,
        Description = "Gerrymandered",
        ExternalId = "Solid"
    };

    private static readonly ElectionEvent _electionEvent = new()
    {
        Id = 1,
        Description = "General 1776",
        ExternalId = "The Original",
        JurisdictionId = 1,
        ElectionDate = new DateOnly(1776, 1, 1),
        ElectionSignature = SHA256.HashData("1776"u8)
    };

    private static readonly Jurisdiction _jurisdiction = new()
    {
        Id = 1,
        Description = "Judge Dredd's"
    };

    private static readonly Mark _mark = new()
    {
        Id = 1,
        ManifestationId = 1,
        CardContestId = 1,
        CandidateId = 1,
        PartyId = 1,
        Rank = 1,
        MarkDensity = 98,
        IsAmbiguous = false,
        IsVote = true
    };

    private static readonly MarkOutstackCondition _markOutstackCondition = new()
    {
        MarkId = 1,
        OutstackConditionId = 1
    };

    private static readonly Original _original = new()
    {
        Id = 1,
        PrecinctPortionId = 1,
        BallotTypeId = 1,
        IsCurrent = true,
        SessionId = 1
    };

    private static readonly OutstackCondition _outstackCondition = new()
    {
        Id = 1,
        Description = "Way out there"
    };

    private static readonly Party _party = new()
    {
        Id = 1,
        Description = "Gettin' Whiggy Wit' It",
        ExternalId = "None"
    };

    private static readonly Precinct _precinct = new()
    {
        Id = 1,
        Description = "Central",
        ExternalId = "Central Precinct"
    };

    private static readonly PrecinctPortion _precinctPortion = new()
    {
        Id = 1,
        Description = "Center",
        ExternalId = "Center of Central Precinct",
        PrecinctId = 1
    };

    private static readonly PrecinctPortionFilter _precinctPortionFilter = new()
    {
        Id = 1,
        ConfigurationId = 1
    };

    private static readonly Session _session = new()
    {
        Id = 1,
        ElectionEventId = 1,
        TabulatorId = 1,
        BatchId = 1,
        RecordId = 1,
        CountingGroupId = 1,
        ImageMask = @"C:\AllTheBallots\1776_*.*.bmp",
        SessionTypeId = 1,
        VotingSessionIdentifier = "1",
        UniqueVotingIdentifier = "1"
    };

    private static readonly SessionType _sessionType = new()
    {
        Id = 1,
        Description = "Quick"
    };

    private static readonly Tabulator _tabulator = new()
    {
        Id = 1,
        Description = "Mary Rose",
        ExternalId = "987654321",
        VotingLocationId = 1,
        TabulatorTypeId = 1,
        ThresholdMin = 0,
        ThresholdMax = 0,
        WriteThresholdMin = 0,
        WriteThresholdMax = 0
    };

    private static readonly TabulatorType _tabulatorType = new()
    {
        Id = 1,
        Description = "Efficient"
    };

    private static readonly VotingLocation _votingLocation = new()
    {
        Id = 1,
        Description = "Fishing Pier 6"
    };

    public static Contest Contest => _contest.ShallowCopy();

    public static BallotType BallotType => _ballotType.ShallowCopy();

    public static BallotTypeContest BallotTypeContest => _ballotTypeContest.ShallowCopy();

    public static Candidate Candidate => _candidate.ShallowCopy();
    public static CandidateAffiliation CandidateAffiliation => _candidateAffiliation.ShallowCopy();

    public static CandidateType CandidateType => _candidateType.ShallowCopy();

    public static Card Card => _card.ShallowCopy();

    public static CardContest CardContest => _cardContest.ShallowCopy();

    public static CardContestOutstackCondition CardContestOutstackCondition =>
        _cardContestOutstackCondition.ShallowCopy();

    public static CardOutstackCondition CardOutstackCondition => _cardOutstackCondition.ShallowCopy();

    public static CollectionVersion CollectionVersion => _collectionVersion.ShallowCopy();

    public static Configuration Configuration => _configuration.ShallowCopy();

    public static ContestFilter ContestFilter => _contestFilter.ShallowCopy();
    public static ContestType ContestType => _contestType.ShallowCopy();
    public static CountingGroup CountingGroup => _countingGroup.ShallowCopy();

    private static Guid DistrictGuid => Guid.NewGuid();
    public static District District => _district.ShallowCopy();
    public static DistrictPrecinctPortion DistrictPrecinctPortion => _districtPrecinctPortion.ShallowCopy();
    public static DistrictType DistrictType => _districtType.ShallowCopy();
    public static ElectionEvent ElectionEvent => _electionEvent.ShallowCopy();

    public static Jurisdiction Jurisdiction => _jurisdiction.ShallowCopy();

    public static Mark Mark => _mark.ShallowCopy();

    public static MarkOutstackCondition MarkOutstackCondition => _markOutstackCondition.ShallowCopy();

    public static Original Original => _original.ShallowCopy();

    public static OutstackCondition OutstackCondition => _outstackCondition.ShallowCopy();

    public static Party Party => _party.ShallowCopy();

    public static Precinct Precinct => _precinct.ShallowCopy();

    public static PrecinctPortion PrecinctPortion => _precinctPortion.ShallowCopy();

    public static PrecinctPortionFilter PrecinctPortionFilter => _precinctPortionFilter.ShallowCopy();

    public static Session Session => _session.ShallowCopy();

    public static SessionType SessionType => _sessionType.ShallowCopy();

    public static Tabulator Tabulator => _tabulator.ShallowCopy();

    public static TabulatorType TabulatorType => _tabulatorType.ShallowCopy();

    public static VotingLocation VotingLocation => _votingLocation.ShallowCopy();
}

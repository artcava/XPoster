# Graph Report - XPoster  (2026-06-14)

## Summary
- 652 nodes · 1082 edges · 93 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Services` - 2 edges
2. `XPoster.Tests.Implementation` - 2 edges
3. `XPoster.Implementation` - 2 edges
4. `XPoster.Models` - 2 edges
5. `XPoster.SenderPlugins` - 2 edges
6. `XPoster.Services` - 2 edges
7. `XPoster.Abstraction` - 2 edges
8. `XPoster.Tests` - 2 edges
9. `XPoster.Tests.SenderPlugins` - 2 edges
10. `XPoster.Tests.SenderPlugins` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.13
Nodes (30): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GetImagePromptAsync_WhenApiReturns200_ReturnsTrimmedContent(), GenerateImageAsync_WhenResponseBodyIsMalformedJson_ReturnsEmptyArray(), GenerateImageAsync_WhenB64JsonIsNull_ReturnsEmptyArray(), GenerateImageAsync_WhenApiReturnsTooManyRequests_ReturnsEmptyArray(), GenerateImageAsync_WhenApiReturnsError_ReturnsEmptyArray(), GenerateImageAsync_WhenApiReturns200_ReturnsDecodedBytes() (+22 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.15
Nodes (27): AzureFoundryServiceTests.cs, AzureFoundryServiceTests.cs, GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetImagePromptAsync_WhenApiReturnsValidResponse_ReturnsPrompt(), GenerateImageAsync_WhenResponseBodyIsMalformedJson_ReturnsEmptyByteArray(), GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsTrimmedContent(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString() (+19 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.19
Nodes (21): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, GetSummaryAsync_WhenTextWithinLimit_DoesNotCallApi(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsContent(), GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString() (+13 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.19
Nodes (20): FalAiImageServiceTests.cs, FalAiImageServiceTests.cs, GenerateImageAsync_ModelIdWithMultipleSegments_PreservesSlashesInUri(), GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray(), GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray(), FalAiImageServiceTests, BuildService(), FalAiImageService() (+12 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.22
Nodes (18): AiServiceHelperTests.cs, AiServiceHelperTests.cs, ParseChatCompletionResponseAsync_WhenStatusIs429_ReturnsFalseAndEmpty(), ParseChatCompletionResponseAsync_WhenNonSuccess_LogsProviderNameAndStatusCode(), ParseChatCompletionResponseAsync_WhenResponseBodyIsEmpty_ReturnsFalseAndEmpty(), ParseChatCompletionResponseAsync_WhenStatusIs429_LogsInformation(), ParseChatCompletionResponseAsync_WhenEmptyChoices_LogsWarningWithProviderName(), ParseChatCompletionResponseAsync_WhenContentIsWhitespaceOnly_ReturnsTrueAndEmpty() (+10 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.27
Nodes (14): DeepSeekService.cs, DeepSeekService.cs, BuildImagePromptPayload(), GenerateImageAsync(), DeepSeekService(), BuildSummaryPayload(), while(), XPoster.Services (+6 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, RSSFeed_PublishDate_DefaultsToMinValue(), Post_CanHold_ImageBytes(), Post_Firm_ContainsExpectedHashtags(), RSSFeed_CanBeCreated_WithAllProperties(), Choice_CanBeCreated_WithMessage(), OpenAIResponse_CanBeCreated_WithChoices() (+6 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_MissingModelId_Fails(), Validate_ModelIdWithAllowedSpecialChars_Succeeds(), Validate_ModelIdWithUnsafeCharacters_Fails(), Validate_ValidOptions_Succeeds(), FalAiOptionsValidatorTests, XPoster.Tests.Models (+5 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.29
Nodes (13): InSenderMissingBranchTests.cs, InSenderMissingBranchTests.cs, SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse(), XPoster.Tests.SenderPlugins, InSenderMissingBranchTests, InSender(), BuildSender(), SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn() (+5 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, Validate_MissingSummaryPlaceholder_Fails(), Validate_MissingMaxCharsPlaceholder_ErrorNamesProperty(), Validate_MissingMaxCharsPlaceholder_Fails(), Validate_MissingSummaryPlaceholder_ErrorNamesProperty(), Validate_MissingTextPlaceholder_Fails(), ValidOptions() (+5 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.32
Nodes (12): XSenderMissingBranchTests.cs, XSenderMissingBranchTests.cs, BuildSender(), XPoster.Tests.SenderPlugins, XSenderMissingBranchTests, XSender(), SendAsync_ValidTextPost_CatchesTwitterException_ReturnsFalse(), MessageMaxLenght_Returns250() (+4 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.32
Nodes (12): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationThrowsException(), XPoster.Tests.Implementation, OrchestrateAsync_Should_CreateMessageWithImage_WhenFeedsAreFound(), OrchestrateAsync_Should_ReturnNull_When_NoFeedsFound(), OrchestrateAsync_Should_ReturnNull_When_SummaryGenerationFails(), OrchestrateAsync_Should_ReturnNull_When_SenderIsNull() (+4 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.18
Nodes (11): HybridAiServiceTests.cs, ChatCompletionJson(), BuildHybrid(), XPoster.Tests.Services, Constructor_NullDeepSeekService_ThrowsArgumentNullException(), GetImagePromptAsync_DelegatesToDeepSeek_ReturnsPrompt(), GetSummaryAsync_DelegatesToDeepSeek_ReturnsContent(), DeepSeekService() (+3 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.18
Nodes (11): AzureFoundryService.cs, GenerateImageAsync(), BuildSummaryPayload(), AzureFoundryService(), catch(), XPoster.Services, GetImageGenerationEndpoint(), GetImagePromptAsync() (+3 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.38
Nodes (10): XSenderTests.cs, XSenderTests.cs, XSender_ImplementsISender(), Constructor_InitializesCorrectly(), Constructor_WithMissingAccessToken_ThrowsOrHandlesGracefully(), XPoster.Tests.SenderPlugins, SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), Constructor_WithNullLogger_ThrowsArgumentNullException() (+2 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.38
Nodes (10): InSenderTests.cs, InSenderTests.cs, SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), XPoster.Tests.SenderPlugins, Constructor_WithNullLogger_ThrowsArgumentNullException(), catch(), Constructor_InitializesCorrectly(), Constructor_WithMissingAccessToken_ThrowsOrHandlesGracefully() (+2 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, SendIt_IsAlwaysFalse(), XPoster.Tests.Implementation, SendIt_Set_ThrowsNotImplementedException(), OrchestrateAsync_ReturnsNull(), Name_IsNoOrchestrator(), NoOrchestratorTests() (+2 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.42
Nodes (9): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WithValidTextOnlyPost_CatchesNetworkException_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), InSenderSendAsyncTests(), SendAsync_WithMissingOwner_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse() (+1 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.42
Nodes (9): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully(), GenerateAsync_Should_ReturnNull_When_DateIsBeforeGenesis(), GenerateAsync_Should_HandleNegativeOrZeroCryptoValue(), GenerateAsync_Should_CreateCorrectMessage_WithActualValue(), GenerateAsync_Should_CalculateCorrectPowerLawValue_ForFixedDate(), XPoster.Tests.Implementation (+1 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), DeepSeekOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), DeepSeekOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), DeepSeekOptionsTests, XPoster.Tests.Models (+1 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse(), XPoster.Tests.SenderPlugins, XSenderSendAsyncTests(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse() (+1 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.22
Nodes (9): IgSenderTests.cs, SendAsync_WithNoImage_ReturnsFalse(), SendAsync_WithEmptyImageArray_ReturnsFalse(), SendAsync_WithImage_CatchesNotImplementedException_ReturnsFalse(), Constructor_WithMissingAccessToken_ThrowsInvalidOperationException(), Constructor_WithValidEnvVars_Succeeds(), Constructor_WithMissingAccountId_ThrowsInvalidOperationException(), XPoster.Tests.SenderPlugins (+1 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.22
Nodes (9): OpenAiService.cs, XPoster.Services, while(), catch(), GetSummaryAsync(), GetPromptForImage(), GetImagePromptAsync(), GetSummary() (+1 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.42
Nodes (9): RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests, RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_RecordEquality_SameValues_AreEqual(), RSSFeed_DefaultPublishDateIsMinValue(), RSSFeed_CanSetPublishDate(), RSSFeed_RecordEquality_DifferentValues_AreNotEqual() (+1 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, GetCryptoValue_ReturnsParsedValue_WhenNumericString(), GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), MakeService(), XPoster.Tests.Services, GetCryptoValue_ReturnsZero_AndLogsError_OnException(), CryptoServiceTests (+1 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, ValidOptions(), XPoster.Tests.Models, Validate_MissingRequiredProperties_Fails(), Validate_MissingPlaceholders_Fails(), DeepSeekOptionsValidatorTests, Validate_AccumulatesAllFailures_WhenMultipleRulesViolated() (+1 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, ValidOptions(), XPoster.Tests.Models, Validate_ValidOptions_Succeeds(), Validate_MissingRequiredProperties_Fails(), AzureFoundryOptionsValidatorTests, Validate_MissingPlaceholders_Fails()

### Community 29 - "Entity (Community 29)"
Cohesion: 0.25
Nodes (8): InSender.cs, catch(), generatePayLoad(), ResolveAuthorUrn(), using(), SendAsync(), XPoster.SenderPlugins, Exception()

### Community 28 - "Entity (Community 28)"
Cohesion: 0.46
Nodes (8): FeedServiceTests.cs, FeedServiceTests.cs, GetFeedsAsync_FiltersByKeyword_AndDate(), GetFeedsAsync_ReturnsEmpty_WhenInvalidFeed(), XPoster.Tests.Services, GetFeedsAsync_ReturnsFeedsFromCache_IfPresent(), GetFeedsAsync_SetsCache_WhenFeedsFetched(), FeedServiceTests()

### Community 31 - "Entity (Community 31)"
Cohesion: 0.46
Nodes (8): AiServiceFactoryTests.cs, AiServiceFactoryTests.cs, GetByProvider_Should_ReturnAzureFoundryService_When_ProviderIsMappedAndResolvable(), AiServiceFactoryTests(), GetByProvider_Should_ThrowInvalidOperationException_When_MappedServiceCannotBeResolved(), XPoster.Tests.Implementation, GetByProvider_Should_ReturnService_When_ProviderIsMappedAndResolvable(), GetByProvider_Should_ThrowArgumentException_When_ProviderIsNotMapped()

### Community 30 - "Entity (Community 30)"
Cohesion: 0.46
Nodes (8): PostMissingBranchTests.cs, PostMissingBranchTests.cs, Post_DefaultImageIsNull(), Post_CanSetAndGetAllProperties(), Post_EmptyContent_IsAllowed(), XPoster.Tests.Models, PostMissingBranchTests, Firm_IsNotNullOrEmpty()

### Community 27 - "Entity (Community 27)"
Cohesion: 0.46
Nodes (8): OpenAIResponse.cs, OpenAIResponse.cs, XPoster.Models, OpenAIResponse, Message, OpenAIImageResponse, Choice, ImageData

### Community 26 - "Entity (Community 26)"
Cohesion: 0.46
Nodes (8): AiServiceFactory.cs, AiServiceFactory.cs, AiServiceFactory(), if(), InvalidOperationException(), XPoster.Implementation, ArgumentException(), GetByProvider()

### Community 35 - "Entity (Community 35)"
Cohesion: 0.29
Nodes (7): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_Content_IsEmpty(), PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), XPoster.Tests.Abstraction, PostAsync_ReturnsTrue_When_AllConditionsMet(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace()

### Community 34 - "Entity (Community 34)"
Cohesion: 0.52
Nodes (7): XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests.cs, Run_Should_LogError_When_OrchestrateAsync_ReturnsNull(), XPoster.Tests, Run_Should_Rethrow_When_Factory_Throws(), Run_Should_LogError_When_PostAsync_ReturnsFalse(), XFunctionMissingBranchTests()

### Community 36 - "Entity (Community 36)"
Cohesion: 0.52
Nodes (7): HybridAiService.cs, HybridAiService.cs, GetSummaryAsync(), GenerateImageAsync(), GetImagePromptAsync(), HybridAiService(), XPoster.Services

### Community 33 - "Entity (Community 33)"
Cohesion: 0.52
Nodes (7): IAiService.cs, IAiService.cs, IAiService, GetImagePromptAsync(), GenerateImageAsync(), GetSummaryAsync(), XPoster.Abstraction

### Community 38 - "Entity (Community 38)"
Cohesion: 0.60
Nodes (6): AiServiceHelper.cs, AiServiceHelper.cs, XPoster.Services, return(), catch(), if()

### Community 39 - "Entity (Community 39)"
Cohesion: 0.33
Nodes (6): OrchestratorFactory.cs, return(), ResolveAiProvider(), foreach(), Resolve(), XPoster.Implementation

### Community 40 - "Entity (Community 40)"
Cohesion: 0.33
Nodes (6): BaseOrchestratorTests.cs, BaseOrchestratorTests(), TestOrchestrator(), PostAsync_ReturnsFalse_When_Sender_IsNull(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull()

### Community 37 - "Entity (Community 37)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, if(), foreach(), Validate(), XPoster.Models

### Community 44 - "Entity (Community 44)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, GetCurrentTime_ReturnsLocalTime(), TimeProviderTests, XPoster.Tests.Services, GetCurrentTime_ReturnsCurrentDateTime()

### Community 42 - "Entity (Community 42)"
Cohesion: 0.33
Nodes (6): HybridAiServiceTests.cs, BuildDeepSeekService(), GenerateImageAsync_DelegatesToFalAi_NotToDeepSeek(), HybridAiService(), BuildFalService(), Constructor_NullFalAiService_ThrowsArgumentNullException()

### Community 41 - "Entity (Community 41)"
Cohesion: 0.60
Nodes (6): XFunctionTests.cs, XFunctionTests.cs, Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), XFunctionTests(), Run_Should_DoNothing_When_GeneratorIsDisabled(), XPoster.Tests

### Community 43 - "Entity (Community 43)"
Cohesion: 0.33
Nodes (6): OrchestratorFactoryTests.cs, XPoster.Tests.Implementation, Generate_Should_ReturnCorrectOrchestratorType_BasedOnHour(), Generate_Should_CreateFeedOrchestratorWithInSender_At6AM(), Resolve_Should_CreateNoOrchestrator_AtUnscheduledHours(), Generate_Should_CreateFeedOrchestratorWithXSender_At8AM()

### Community 49 - "Entity (Community 49)"
Cohesion: 0.40
Nodes (5): IgSender.cs, SendAsync(), catch(), UploadImageToPublicUrl(), XPoster.SenderPlugins

### Community 47 - "Entity (Community 47)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, if(), XPoster.Implementation, PowerLawOrchestrator()

### Community 48 - "Entity (Community 48)"
Cohesion: 0.40
Nodes (5): FeedService.cs, catch(), XPoster.Services, Exception(), GetFeedsAsync()

### Community 46 - "Entity (Community 46)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, PostAsync(), IOrchestrator, XPoster.Abstraction

### Community 45 - "Entity (Community 45)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, ICryptoService, XPoster.Abstraction, GetCryptoValue()

### Community 51 - "Entity (Community 51)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, XPoster.Abstraction, Resolve(), IOrchestratorFactory

### Community 50 - "Entity (Community 50)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, XPoster.Abstraction, GetFeedsAsync(), IFeedService

### Community 57 - "Entity (Community 57)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, GetCurrentTime(), XPoster.Services, TimeProvider

### Community 55 - "Entity (Community 55)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, XPoster.Abstraction, ITimeProvider, GetCurrentTime()

### Community 56 - "Entity (Community 56)"
Cohesion: 0.70
Nodes (5): IAiServiceFactory.cs, IAiServiceFactory.cs, IAiServiceFactory, XPoster.Abstraction, GetByProvider()

### Community 54 - "Entity (Community 54)"
Cohesion: 0.40
Nodes (5): FeedOrchestrator.cs, GenerateMessage(), catch(), ReplaceEveryFirstOccurenceOf(), XPoster.Implementation

### Community 52 - "Entity (Community 52)"
Cohesion: 0.40
Nodes (5): OrchestratorFactory.cs, if(), OrchestratorFactory(), ScheduledOrchestrationProfile(), CreateOrchestratorInstance()

### Community 53 - "Entity (Community 53)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, ISender, SendAsync(), XPoster.Abstraction

### Community 67 - "Entity (Community 67)"
Cohesion: 0.50
Nodes (4): XSender.cs, SendAsync(), XPoster.SenderPlugins, catch()

### Community 71 - "Entity (Community 71)"
Cohesion: 0.50
Nodes (4): OrchestratorFactoryTests.cs, OrchestratorFactoryTests(), Resolve_Should_RequestOpenAiProvider_ForScheduledFeedSlot(), SetupMocksForOrchestratorFactory()

### Community 68 - "Entity (Community 68)"
Cohesion: 0.50
Nodes (4): IgSenderTests.cs, ClearEnvVars(), SetValidEnvVars(), IgSenderTests()

### Community 69 - "Entity (Community 69)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, PostAsync(), BaseOrchestrator(), XPoster.Abstraction

### Community 70 - "Entity (Community 70)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, catch(), XPoster.Services, GetCryptoValue()

### Community 62 - "Entity (Community 62)"
Cohesion: 0.50
Nodes (4): XFunction.cs, Run(), XPoster, catch()

### Community 58 - "Entity (Community 58)"
Cohesion: 0.50
Nodes (4): OpenAiService.cs, if(), var(), OpenAiService()

### Community 61 - "Entity (Community 61)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, XPoster.Models, Post

### Community 59 - "Entity (Community 59)"
Cohesion: 0.50
Nodes (4): AzureFoundryService.cs, BuildImagePromptPayload(), if(), var()

### Community 60 - "Entity (Community 60)"
Cohesion: 0.50
Nodes (4): FeedOrchestrator.cs, foreach(), if(), FeedOrchestrator()

### Community 66 - "Entity (Community 66)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, XPoster.Abstraction, ScheduledOrchestrationProfile()

### Community 65 - "Entity (Community 65)"
Cohesion: 0.50
Nodes (4): FalAiImageService.cs, XPoster.Services, FalAiImageService(), GenerateImageAsync()

### Community 63 - "Entity (Community 63)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, XPoster.Implementation, NoOrchestrator()

### Community 64 - "Entity (Community 64)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, XPoster.Models, RSSFeed

### Community 72 - "Entity (Community 72)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, XPoster.Models, Validate()

### Community 81 - "Entity (Community 81)"
Cohesion: 0.67
Nodes (3): XFunction.cs, XFunction(), if()

### Community 82 - "Entity (Community 82)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, XPoster.Models, AzureFoundryOptions.cs

### Community 83 - "Entity (Community 83)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, XPoster.Models, FalAiOptions.cs

### Community 85 - "Entity (Community 85)"
Cohesion: 0.67
Nodes (3): XSender.cs, if(), XSender()

### Community 84 - "Entity (Community 84)"
Cohesion: 1.00
Nodes (3): XPoster.Models, OpenAiOptions.cs, OpenAiOptions.cs

### Community 87 - "Entity (Community 87)"
Cohesion: 1.00
Nodes (3): Program.cs, Program.cs, if()

### Community 86 - "Entity (Community 86)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, CryptoService(), if()

### Community 88 - "Entity (Community 88)"
Cohesion: 1.00
Nodes (3): Enums.cs, XPoster.Abstraction, Enums.cs

### Community 73 - "Entity (Community 73)"
Cohesion: 0.67
Nodes (3): InSender.cs, if(), InSender()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, XPoster.Models, Validate()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.67
Nodes (3): IgSender.cs, IgSender(), if()

### Community 75 - "Entity (Community 75)"
Cohesion: 1.00
Nodes (3): XPoster.Models, DeepSeekOptions.cs, DeepSeekOptions.cs

### Community 76 - "Entity (Community 76)"
Cohesion: 0.67
Nodes (3): FeedService.cs, FeedService(), if()

### Community 79 - "Entity (Community 79)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, AiProvider.cs, XPoster.Abstraction

### Community 78 - "Entity (Community 78)"
Cohesion: 0.67
Nodes (3): FalAiImageService.cs, catch(), if()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, XPoster.Models, Validate()

### Community 92 - "Entity (Community 92)"
Cohesion: 1.00
Nodes (2): BaseOrchestrator.cs, if()

### Community 91 - "Entity (Community 91)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

### Community 90 - "Entity (Community 90)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

### Community 89 - "Entity (Community 89)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._


# Graph Report - XPoster  (2026-06-14)

## Summary
- 625 nodes · 1034 edges · 92 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Models` - 2 edges
2. `XPoster.Models` - 2 edges
3. `XPoster.Abstraction` - 2 edges
4. `XPoster.Models` - 2 edges
5. `XPoster.Services` - 2 edges
6. `XPoster` - 2 edges
7. `XPoster.SenderPlugins` - 2 edges
8. `IAiService` - 2 edges
9. `XPoster.Abstraction` - 2 edges
10. `XPoster.Abstraction` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.13
Nodes (30): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GetSummaryAsync_WhenTextAlreadyShort_ReturnsTextUnchanged(), GetSummaryAsync_WhenSummaryAlwaysTooLong_StopsAfterThreeAttempts(), GenerateImageAsync_WhenB64JsonIsNull_ReturnsEmptyArray(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmpty(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmpty(), GenerateImageAsync_WhenApiReturnsTooManyRequests_ReturnsEmptyArray() (+22 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.15
Nodes (27): AzureFoundryServiceTests.cs, AzureFoundryServiceTests.cs, GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GenerateImageAsync_WhenResponseBodyIsMalformedJson_ReturnsEmptyByteArray(), GetImagePromptAsync_WhenApiReturnsValidResponse_ReturnsPrompt(), GenerateImageAsync_WhenPromptIsWhitespace_ReturnsEmptyByteArrayWithoutCallingApi(), GenerateImageAsync_WhenPromptIsEmpty_ReturnsEmptyByteArrayWithoutCallingApi(), GenerateImageAsync_WhenFallbackUrlIsFromDifferentOrigin_LogsWarning() (+19 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.19
Nodes (21): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), DeepSeekServiceTests, DeepSeekService(), ChatCompletionJson() (+13 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.19
Nodes (20): FalAiImageServiceTests.cs, FalAiImageServiceTests.cs, GenerateImageAsync_EmptyUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray(), FalImageJson(), GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray(), GenerateImageAsync_ReturnsNonSuccess_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithUnsafeChars_PercentEncodesInRequestUri() (+12 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, Choice_CanBeCreated_WithMessage(), RSSFeed_CanBeCreated_WithAllProperties(), Post_CanHold_ImageBytes(), Post_CanBeCreated_WithRequiredContent(), Post_Firm_ContainsExpectedHashtags(), OpenAIResponse_CanBeCreated_WithChoices() (+6 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, XPoster.Tests.Models, Validate_MissingTextPlaceholder_ErrorNamesProperty(), Validate_MissingTextPlaceholder_Fails(), ValidOptions(), Validate_MissingSummaryPlaceholder_Fails(), Validate_MissingMaxCharsPlaceholder_Fails() (+5 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.29
Nodes (13): InSenderMissingBranchTests.cs, InSenderMissingBranchTests.cs, SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse(), XPoster.Tests.SenderPlugins, InSender(), MessageMaxLenght_Returns800(), InSenderMissingBranchTests, SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn() (+5 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_ModelIdWithUnsafeCharacters_Fails(), Validate_WhitespaceModelId_Fails(), Validate_WhitespaceApiKey_Fails(), Validate_ValidOptions_Succeeds(), Validate_MissingApiKey_Fails(), FalAiOptionsValidatorTests (+5 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.32
Nodes (12): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, OrchestrateAsync_Should_ReturnNull_When_SenderIsNull(), OrchestrateAsync_Should_ReturnNull_When_SummaryGenerationFails(), OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationReturnsNull(), OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationThrowsException(), OrchestrateAsync_Should_ApplyHashtagsCorrectly(), OrchestrateAsync_Should_CreateMessageWithImage_WhenFeedsAreFound() (+4 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.32
Nodes (12): XSenderMissingBranchTests.cs, XSenderMissingBranchTests.cs, SendAsync_NullPost_ReturnsFalse(), BuildSender(), MessageMaxLenght_Returns250(), SendAsync_EmptyContent_ReturnsFalse(), XSender(), SendAsync_ValidTextPost_CatchesTwitterException_ReturnsFalse() (+4 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.18
Nodes (11): AzureFoundryService.cs, XPoster.Services, BuildImagePromptPayload(), AzureFoundryService(), while(), GetChatCompletionsEndpoint(), GetImageGenerationEndpoint(), GetImagePromptAsync() (+3 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.18
Nodes (11): HybridAiServiceTests.cs, HybridAiServiceTests, MakeHandlerMock(), XPoster.Tests.Services, GetImagePromptAsync_DelegatesToDeepSeek_ReturnsPrompt(), Constructor_NullDeepSeekService_ThrowsArgumentNullException(), FalAiImageService(), DeepSeekService() (+3 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, NoOrchestratorTests(), Name_IsNoOrchestrator(), OrchestrateAsync_ReturnsNull(), ProduceImage_Set_ThrowsNotImplementedException(), SendIt_Set_ThrowsNotImplementedException(), SendIt_IsAlwaysFalse() (+2 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.38
Nodes (10): InSenderTests.cs, InSenderTests.cs, Constructor_InitializesCorrectly(), Constructor_WithMissingAccessToken_ThrowsOrHandlesGracefully(), catch(), InSender_ImplementsISender(), InSenderTests(), XPoster.Tests.SenderPlugins (+2 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.38
Nodes (10): XSenderTests.cs, XSenderTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), Constructor_WithNullLogger_ThrowsArgumentNullException(), catch(), Constructor_InitializesCorrectly(), Constructor_WithMissingAccessToken_ThrowsOrHandlesGracefully() (+2 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.22
Nodes (9): DeepSeekService.cs, GetImagePromptAsync(), GetChatCompletionsEndpoint(), BuildSummaryPayload(), GenerateImageAsync(), NotSupportedException(), XPoster.Services, while() (+1 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.42
Nodes (9): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, GenerateAsync_Should_ReturnNull_When_DateIsBeforeGenesis(), PowerLawOrchestratorTests(), XPoster.Tests.Implementation, GenerateAsync_Should_CreateCorrectMessage_WithActualValue(), GenerateAsync_Should_CalculateCorrectPowerLawValue_ForFixedDate(), GenerateAsync_Should_HandleNegativeOrZeroCryptoValue() (+1 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.22
Nodes (9): IgSenderTests.cs, SendAsync_WithNoImage_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithOversizedCaption_StillExecutes(), Constructor_WithValidEnvVars_Succeeds(), Constructor_WithMissingAccessToken_ThrowsInvalidOperationException(), Constructor_WithMissingAccountId_ThrowsInvalidOperationException(), SendAsync_WithImage_CatchesNotImplementedException_ReturnsFalse() (+1 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.42
Nodes (9): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, InSenderSendAsyncTests(), XPoster.Tests.SenderPlugins, SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithMissingOwner_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithValidTextOnlyPost_CatchesNetworkException_ReturnsFalse() (+1 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, CryptoServiceTests, CryptoService(), GetCryptoValue_ReturnsParsedValue_WhenNumericString(), GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), GetCryptoValue_ReturnsZero_AndLogsError_OnException(), MakeService() (+1 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), DeepSeekOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), DeepSeekOptionsTests (+1 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.42
Nodes (9): RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests.cs, XPoster.Tests.Models, RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeed_DefaultPublishDateIsMinValue(), RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_CanSetPublishDate(), RSSFeedMissingBranchTests (+1 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, ValidOptions(), DeepSeekOptionsValidatorTests, Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), Validate_MissingPlaceholders_Fails(), Validate_MissingRequiredProperties_Fails(), Validate_ValidOptions_Succeeds() (+1 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithNullPost_ReturnsFalse(), XSenderSendAsyncTests(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse() (+1 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.46
Nodes (8): FeedServiceTests.cs, FeedServiceTests.cs, GetFeedsAsync_SetsCache_WhenFeedsFetched(), GetFeedsAsync_ReturnsFeedsFromCache_IfPresent(), FeedServiceTests(), GetFeedsAsync_FiltersByKeyword_AndDate(), GetFeedsAsync_ReturnsEmpty_WhenInvalidFeed(), XPoster.Tests.Services

### Community 29 - "Entity (Community 29)"
Cohesion: 0.46
Nodes (8): OpenAIResponse.cs, OpenAIResponse.cs, OpenAIResponse, XPoster.Models, ImageData, Choice, OpenAIImageResponse, Message

### Community 28 - "Entity (Community 28)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, Validate_ValidOptions_Succeeds(), ValidOptions(), XPoster.Tests.Models, Validate_MissingPlaceholders_Fails(), AzureFoundryOptionsValidatorTests, Validate_MissingRequiredProperties_Fails()

### Community 27 - "Entity (Community 27)"
Cohesion: 0.46
Nodes (8): AiServiceFactoryTests.cs, AiServiceFactoryTests.cs, GetByProvider_Should_ThrowArgumentException_When_ProviderIsNotMapped(), GetByProvider_Should_ThrowInvalidOperationException_When_MappedServiceCannotBeResolved(), XPoster.Tests.Implementation, GetByProvider_Should_ReturnAzureFoundryService_When_ProviderIsMappedAndResolvable(), AiServiceFactoryTests(), GetByProvider_Should_ReturnService_When_ProviderIsMappedAndResolvable()

### Community 26 - "Entity (Community 26)"
Cohesion: 0.25
Nodes (8): InSender.cs, generatePayLoad(), ResolveAuthorUrn(), XPoster.SenderPlugins, SendAsync(), using(), Exception(), catch()

### Community 31 - "Entity (Community 31)"
Cohesion: 0.46
Nodes (8): PostMissingBranchTests.cs, PostMissingBranchTests.cs, Post_EmptyContent_IsAllowed(), Post_DefaultImageIsNull(), Firm_IsNotNullOrEmpty(), Post_CanSetAndGetAllProperties(), XPoster.Tests.Models, PostMissingBranchTests

### Community 25 - "Entity (Community 25)"
Cohesion: 0.46
Nodes (8): AiServiceFactory.cs, AiServiceFactory.cs, ArgumentException(), AiServiceFactory(), XPoster.Implementation, GetByProvider(), InvalidOperationException(), if()

### Community 24 - "Entity (Community 24)"
Cohesion: 0.25
Nodes (8): OpenAiService.cs, GenerateImageAsync(), GetPromptForImage(), GetImagePromptAsync(), while(), XPoster.Services, GetSummary(), GetSummaryAsync()

### Community 35 - "Entity (Community 35)"
Cohesion: 0.52
Nodes (7): IAiService.cs, IAiService.cs, IAiService, XPoster.Abstraction, GetImagePromptAsync(), GenerateImageAsync(), GetSummaryAsync()

### Community 33 - "Entity (Community 33)"
Cohesion: 0.52
Nodes (7): XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests.cs, Run_Should_Rethrow_When_Factory_Throws(), XPoster.Tests, Run_Should_LogError_When_OrchestrateAsync_ReturnsNull(), Run_Should_LogError_When_PostAsync_ReturnsFalse(), XFunctionMissingBranchTests()

### Community 32 - "Entity (Community 32)"
Cohesion: 0.52
Nodes (7): HybridAiService.cs, HybridAiService.cs, XPoster.Services, GenerateImageAsync(), GetImagePromptAsync(), GetSummaryAsync(), HybridAiService()

### Community 34 - "Entity (Community 34)"
Cohesion: 0.29
Nodes (7): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_Content_IsEmpty(), PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), XPoster.Tests.Abstraction, PostAsync_ReturnsTrue_When_AllConditionsMet(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace()

### Community 37 - "Entity (Community 37)"
Cohesion: 0.60
Nodes (6): XFunctionTests.cs, XFunctionTests.cs, Run_Should_DoNothing_When_GeneratorIsDisabled(), XFunctionTests(), XPoster.Tests, Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled()

### Community 36 - "Entity (Community 36)"
Cohesion: 0.33
Nodes (6): HybridAiServiceTests.cs, GenerateImageAsync_DelegatesToFalAi_NotToDeepSeek(), BuildFalService(), BuildDeepSeekService(), Constructor_NullFalAiService_ThrowsArgumentNullException(), HybridAiService()

### Community 38 - "Entity (Community 38)"
Cohesion: 0.33
Nodes (6): OrchestratorFactory.cs, return(), Resolve(), foreach(), ResolveAiProvider(), XPoster.Implementation

### Community 42 - "Entity (Community 42)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, GetCurrentTime_ReturnsLocalTime(), XPoster.Tests.Services, TimeProviderTests, GetCurrentTime_ReturnsCurrentDateTime()

### Community 40 - "Entity (Community 40)"
Cohesion: 0.33
Nodes (6): BaseOrchestratorTests.cs, TestOrchestrator(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), BaseOrchestratorTests(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), PostAsync_ReturnsFalse_When_Sender_IsNull()

### Community 41 - "Entity (Community 41)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, foreach(), if(), XPoster.Models, Validate()

### Community 39 - "Entity (Community 39)"
Cohesion: 0.33
Nodes (6): OrchestratorFactoryTests.cs, XPoster.Tests.Implementation, Generate_Should_CreateFeedOrchestratorWithXSender_At8AM(), Resolve_Should_CreateNoOrchestrator_AtUnscheduledHours(), Generate_Should_CreateFeedOrchestratorWithInSender_At6AM(), Generate_Should_ReturnCorrectOrchestratorType_BasedOnHour()

### Community 49 - "Entity (Community 49)"
Cohesion: 0.70
Nodes (5): IAiServiceFactory.cs, IAiServiceFactory.cs, IAiServiceFactory, XPoster.Abstraction, GetByProvider()

### Community 47 - "Entity (Community 47)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, GetCryptoValue(), ICryptoService, XPoster.Abstraction

### Community 48 - "Entity (Community 48)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, XPoster.Abstraction, GetCurrentTime(), ITimeProvider

### Community 54 - "Entity (Community 54)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, TimeProvider, XPoster.Services, GetCurrentTime()

### Community 55 - "Entity (Community 55)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, XPoster.Abstraction, IOrchestrator, PostAsync()

### Community 52 - "Entity (Community 52)"
Cohesion: 0.40
Nodes (5): OrchestratorFactory.cs, CreateOrchestratorInstance(), if(), OrchestratorFactory(), ScheduledOrchestrationProfile()

### Community 53 - "Entity (Community 53)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, SendAsync(), ISender, XPoster.Abstraction

### Community 46 - "Entity (Community 46)"
Cohesion: 0.40
Nodes (5): IgSender.cs, XPoster.SenderPlugins, UploadImageToPublicUrl(), catch(), SendAsync()

### Community 44 - "Entity (Community 44)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, XPoster.Implementation, PowerLawOrchestrator(), if()

### Community 45 - "Entity (Community 45)"
Cohesion: 0.40
Nodes (5): FeedService.cs, GetFeedsAsync(), Exception(), catch(), XPoster.Services

### Community 43 - "Entity (Community 43)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, Resolve(), IOrchestratorFactory, XPoster.Abstraction

### Community 51 - "Entity (Community 51)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, XPoster.Abstraction, IFeedService, GetFeedsAsync()

### Community 50 - "Entity (Community 50)"
Cohesion: 0.40
Nodes (5): FeedOrchestrator.cs, ReplaceEveryFirstOccurenceOf(), GenerateMessage(), catch(), XPoster.Implementation

### Community 66 - "Entity (Community 66)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, GetCryptoValue(), XPoster.Services, catch()

### Community 67 - "Entity (Community 67)"
Cohesion: 0.50
Nodes (4): XFunction.cs, XPoster, Run(), catch()

### Community 68 - "Entity (Community 68)"
Cohesion: 0.50
Nodes (4): XSender.cs, XPoster.SenderPlugins, SendAsync(), catch()

### Community 69 - "Entity (Community 69)"
Cohesion: 0.50
Nodes (4): FeedOrchestrator.cs, FeedOrchestrator(), if(), foreach()

### Community 57 - "Entity (Community 57)"
Cohesion: 0.50
Nodes (4): OpenAiService.cs, if(), OpenAiService(), catch()

### Community 56 - "Entity (Community 56)"
Cohesion: 0.50
Nodes (4): FalAiImageService.cs, GenerateImageAsync(), XPoster.Services, FalAiImageService()

### Community 65 - "Entity (Community 65)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, BaseOrchestrator(), XPoster.Abstraction, PostAsync()

### Community 61 - "Entity (Community 61)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, NoOrchestrator(), XPoster.Implementation

### Community 64 - "Entity (Community 64)"
Cohesion: 0.50
Nodes (4): DeepSeekService.cs, if(), BuildImagePromptPayload(), DeepSeekService()

### Community 62 - "Entity (Community 62)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, RSSFeed, XPoster.Models

### Community 63 - "Entity (Community 63)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, XPoster.Models, Post

### Community 60 - "Entity (Community 60)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile(), XPoster.Abstraction

### Community 59 - "Entity (Community 59)"
Cohesion: 0.50
Nodes (4): OrchestratorFactoryTests.cs, Resolve_Should_RequestOpenAiProvider_ForScheduledFeedSlot(), SetupMocksForOrchestratorFactory(), OrchestratorFactoryTests()

### Community 58 - "Entity (Community 58)"
Cohesion: 0.50
Nodes (4): IgSenderTests.cs, SetValidEnvVars(), IgSenderTests(), ClearEnvVars()

### Community 80 - "Entity (Community 80)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, XPoster.Models, DeepSeekOptions.cs

### Community 81 - "Entity (Community 81)"
Cohesion: 0.67
Nodes (3): FalAiImageService.cs, catch(), if()

### Community 82 - "Entity (Community 82)"
Cohesion: 1.00
Nodes (3): OpenAiOptions.cs, OpenAiOptions.cs, XPoster.Models

### Community 84 - "Entity (Community 84)"
Cohesion: 0.67
Nodes (3): AzureFoundryService.cs, catch(), if()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, XPoster.Models, Validate()

### Community 86 - "Entity (Community 86)"
Cohesion: 0.67
Nodes (3): InSender.cs, if(), InSender()

### Community 85 - "Entity (Community 85)"
Cohesion: 0.67
Nodes (3): XSender.cs, if(), XSender()

### Community 87 - "Entity (Community 87)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, XPoster.Abstraction, AiProvider.cs

### Community 71 - "Entity (Community 71)"
Cohesion: 1.00
Nodes (3): XPoster.Models, AzureFoundryOptions.cs, AzureFoundryOptions.cs

### Community 70 - "Entity (Community 70)"
Cohesion: 0.67
Nodes (3): FeedService.cs, FeedService(), if()

### Community 72 - "Entity (Community 72)"
Cohesion: 1.00
Nodes (3): Program.cs, Program.cs, if()

### Community 79 - "Entity (Community 79)"
Cohesion: 1.00
Nodes (3): Enums.cs, XPoster.Abstraction, Enums.cs

### Community 73 - "Entity (Community 73)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, Validate(), XPoster.Models

### Community 74 - "Entity (Community 74)"
Cohesion: 1.00
Nodes (3): XPoster.Models, FalAiOptions.cs, FalAiOptions.cs

### Community 75 - "Entity (Community 75)"
Cohesion: 0.67
Nodes (3): XFunction.cs, if(), XFunction()

### Community 78 - "Entity (Community 78)"
Cohesion: 0.67
Nodes (3): IgSender.cs, IgSender(), if()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, Validate(), XPoster.Models

### Community 76 - "Entity (Community 76)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, if(), CryptoService()

### Community 91 - "Entity (Community 91)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

### Community 90 - "Entity (Community 90)"
Cohesion: 1.00
Nodes (2): BaseOrchestrator.cs, if()

### Community 89 - "Entity (Community 89)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

### Community 88 - "Entity (Community 88)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._


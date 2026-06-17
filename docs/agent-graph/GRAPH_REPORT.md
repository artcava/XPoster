# Graph Report - XPoster  (2026-06-17)

## Summary
- 855 nodes · 1428 edges · 117 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Models` - 2 edges
2. `XPoster.Models` - 2 edges
3. `XPoster.Models` - 2 edges
4. `XPoster.Models` - 2 edges
5. `XPoster.Models` - 2 edges
6. `XPoster.Abstraction` - 2 edges
7. `XPoster.Tests.Services` - 2 edges
8. `LocalOverrideTimeProviderTests` - 2 edges
9. `XPoster.Tests.Implementation` - 2 edges
10. `AzureFoundryOptionsValidatorTests` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.13
Nodes (30): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GenerateImageAsync_WhenApiReturnsError_ReturnsEmptyArray(), GenerateImageAsync_WhenApiReturns200_ReturnsDecodedBytes(), GetImagePromptAsync_WhenApiReturnsTooManyRequests_ReturnsEmpty(), GetImagePromptAsync_WhenApiReturnsTooManyRequests_LogsInformation(), GetImagePromptAsync_WhenApiReturnsError_ReturnsEmpty(), GenerateImageAsync_WhenPromptIsEmpty_ReturnsEmptyArrayWithoutCallingApi() (+22 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.16
Nodes (24): IgSenderTests.cs, IgSenderTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WithWhitespaceContent_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WhenInstagramApiReturnsNonSuccess_ReturnsFalse(), SendAsync_WhenInstagramApiReturns429_ReturnsFalse(), SendAsync_WithoutImage_DoesNotQueryKv() (+16 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.19
Nodes (21): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), DeepSeekService(), ChatCompletionJson() (+13 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.19
Nodes (20): DryRunSenderTests.cs, DryRunSenderTests.cs, SendAsync_WhenKeyVaultProbeSucceeds_ProbesXApiKey(), SendAsync_WhenKeyVaultProbeThrows_LogsError(), SendAsync_WhenKeyVaultProbeSucceeds_ReturnsTrue(), BuildSender(), XPoster.Tests.SenderPlugins, SendAsync_WithNullPost_ReturnsFalse() (+12 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.19
Nodes (20): FalAiImageServiceTests.cs, FalAiImageServiceTests.cs, FalAiImageService(), FalAiImageServiceTests, FalImageJson(), GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray(), GenerateImageAsync_EmptyUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_MalformedJson_ReturnsEmptyArray() (+12 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.22
Nodes (18): AiServiceHelperTests.cs, AiServiceHelperTests.cs, AiServiceHelperTests, ParseChatCompletionResponseAsync_WhenContentIsWhitespaceOnly_ReturnsTrueAndEmpty(), ParseChatCompletionResponseAsync_WhenNonSuccess_LogsProviderNameAndStatusCode(), ParseChatCompletionResponseAsync_WhenEmptyChoices_LogsWarningWithProviderName(), var(), XPoster.Tests.Services (+10 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.12
Nodes (17): AzureFoundryServiceTests.cs, GenerateImageAsync_WhenResponseBodyIsMalformedJson_ReturnsEmptyByteArray(), GenerateImageAsync_WhenFallbackUrlIsFromDifferentOrigin_LogsWarning(), GenerateImageAsync_WhenPromptIsEmpty_ReturnsEmptyByteArrayWithoutCallingApi(), GenerateImageAsync_WhenPromptIsWhitespace_ReturnsEmptyByteArrayWithoutCallingApi(), XPoster.Tests.Services, GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString() (+9 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.24
Nodes (16): KeyVaultServiceTests.cs, KeyVaultServiceTests.cs, XPoster.Tests.Services, XSender_SendAsync_RequestsAllFourXCredentials(), IgSender_SendAsync_WithImage_RequestsBothIgSecrets(), GetSecretAsync_ReturnsExpectedValue(), GetSecretAsync_ThrowsWhenSecretNotFound(), HttpFactory() (+8 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.13
Nodes (15): AzureFoundryServiceTests.cs, GenerateImageAsync_WhenApiReturnsValidResponse_ReturnsByteArray(), ChatCompletionJson(), GenerateImageAsync_PostsToFoundryImagesGenerationsEndpoint(), GenerateImageAsync_WhenApiReturnsTooManyRequests_ReturnsEmptyByteArray(), AzureFoundryService(), GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsTrimmedContent(), HttpResponseMessage() (+7 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, RSSFeed_PublishDate_DefaultsToMinValue(), XPoster.Tests.Models, Post_CanHold_ImageBytes(), ModelsTests, OpenAIResponse_CanBeCreated_WithChoices(), Post_CanBeCreated_WithRequiredContent() (+6 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.27
Nodes (14): InSenderMissingBranchTests.cs, InSenderMissingBranchTests.cs, InSenderMissingBranchTests(), BuildKv(), if(), BuildSender(), SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn(), SendAsync_NullPost_ReturnsFalse() (+6 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.27
Nodes (14): DeepSeekService.cs, DeepSeekService.cs, BuildImagePromptPayload(), GetImagePromptAsync(), DeepSeekService(), GenerateImageAsync(), GetChatCompletionsEndpoint(), while() (+6 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, XPoster.Tests.Services, LocalOverrideTimeProviderTests, LocalOverrideTimeProvider(), GetCurrentTime_WhenForceHourIsOutOfRange_WrapsViaDateTimeOverflow(), GetCurrentTime_WhenForceHourIsValid_ReturnsForcedHour(), GetCurrentTime_WhenForceHourIsValid_ReturnsUtcKind() (+5 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, XPoster.Tests.Models, Validate_ValidOptions_Succeeds(), Validate_WhitespaceModelId_Fails(), Validate_WhitespaceApiKey_Fails(), ValidOptions(), Validate_MissingModelId_Fails() (+5 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.29
Nodes (13): InSenderTests.cs, InSenderTests.cs, InSenderTests(), SendAsync_CalledTwice_QueriesKvAccessTokenOnEachCall(), SendAsync_WhenLinkedInOrgIdPresent_UsesOrgIdAndSkipsOwnerCode(), XPoster.Tests.SenderPlugins, SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), InSender_ImplementsISender() (+5 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests, Validate_MissingTextPlaceholder_ErrorNamesProperty(), XPoster.Tests.Models, Validate_MissingTextPlaceholder_Fails(), ValidOptions(), Validate_MissingSummaryPlaceholder_ErrorNamesProperty() (+5 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.32
Nodes (12): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, IgSenderResilienceTests, IgSender(), BuildSender(), new(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), SendAsync_WhenImageUploadNotImplemented_ReturnsFalseAndLogsError() (+4 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.32
Nodes (12): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, OrchestrateAsync_Should_ReturnNull_When_SummaryGenerationFails(), OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationThrowsException(), XPoster.Tests.Implementation, OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationReturnsNull(), OrchestrateAsync_Should_ReturnNull_When_AiServiceIsNull(), OrchestrateAsync_Should_CreateMessageWithImage_WhenFeedsAreFound() (+4 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.18
Nodes (11): AzureFoundryService.cs, XPoster.Services, AzureFoundryService(), GetSummaryAsync(), BuildSummaryPayload(), catch(), GetImagePromptAsync(), GetChatCompletionsEndpoint() (+3 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.18
Nodes (11): HybridAiServiceTests.cs, Constructor_NullDeepSeekService_ThrowsArgumentNullException(), ChatCompletionJson(), BuildHybrid(), FalAiImageService(), XPoster.Tests.Services, HybridAiServiceTests, MakeHandlerMock() (+3 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.35
Nodes (11): XSenderTests.cs, XSenderTests.cs, XPoster.Tests.SenderPlugins, XSender_ImplementsISender(), XSenderTests(), Constructor_WithNullLogger_ThrowsArgumentNullException(), BuildKeyVaultMock(), Constructor_InitializesCorrectly() (+3 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue(), InSender(), BuildSender(), InSenderResilienceTests, SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), SendAsync_WhenLinkedInReturns200_ReturnsTrue() (+3 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.35
Nodes (11): XSenderMissingBranchTests.cs, XSenderMissingBranchTests.cs, XPoster.Tests.SenderPlugins, SendAsync_EmptyContent_ReturnsFalse(), SendAsync_NullPost_ReturnsFalse(), SendAsync_PostWithImage_CatchesTwitterException_ReturnsFalse(), SendAsync_ValidTextPost_CatchesTwitterException_ReturnsFalse(), SendAsync_WhitespaceContent_ReturnsFalse() (+3 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.20
Nodes (10): OrchestratorFactoryTests.cs, Resolve_Should_ResolveDryRunSender_WhenProfileUsesDryRunSend(), Resolve_Should_NotRequestAiProvider_WhenProfileHasNoAiProvider(), DefaultSlotProfileProvider_Should_NotContainDryRunProfile(), OrchestratorFactory(), Resolve_Should_ResolveXSender_WhenProfileUsesXSummaryFeed(), Resolve_Should_ReturnCorrectOrchestratorType_ForGivenSenderProfile(), XPoster.Tests.Implementation (+2 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, Name_IsNoOrchestrator(), ProduceImage_IsAlwaysFalse(), SendIt_Set_ThrowsNotImplementedException(), SendIt_IsAlwaysFalse(), XPoster.Tests.Implementation, ProduceImage_Set_ThrowsNotImplementedException() (+2 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.22
Nodes (9): OpenAiService.cs, while(), GetSummaryAsync(), catch(), GenerateImageAsync(), GetImagePromptAsync(), GetPromptForImage(), GetSummary() (+1 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse() (+1 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.42
Nodes (9): RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests.cs, RSSFeed_CanSetPublishDate(), RSSFeed_CanCreateWithRequiredProperties(), RSSFeedMissingBranchTests, RSSFeed_DefaultPublishDateIsMinValue(), RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeed_RecordEquality_SameValues_AreEqual() (+1 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, BuildProviderWithHandler(), XPoster.Tests.Integration, HttpResponseMessage(), params(), var(), BuildSequenceHandler() (+1 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.42
Nodes (9): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests, AzureFoundryOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), AzureFoundryOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), AzureFoundryOptions_Defaults_AreCorrect(), AzureFoundryOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), AzureFoundryOptions_DoesNotExpose_ApiVersionProperty() (+1 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.42
Nodes (9): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, XPoster.Tests.Implementation, PowerLawOrchestratorTests(), GenerateAsync_Should_HandleNegativeOrZeroCryptoValue(), GenerateAsync_Should_ReturnNull_When_DateIsBeforeGenesis(), GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully(), GenerateAsync_Should_CalculateCorrectPowerLawValue_ForFixedDate() (+1 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, XPoster.Tests.Models, DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), DeepSeekOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), DeepSeekOptionsTests (+1 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests, Validate_MissingRequiredProperties_Fails(), Validate_ValidOptions_Succeeds(), ValidOptions(), Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), Validate_MissingPlaceholders_Fails() (+1 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, MakeService(), GetCryptoValue_ReturnsZero_AndLogsError_OnException(), GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), CryptoService(), GetCryptoValue_ReturnsParsedValue_WhenNumericString(), CryptoServiceTests (+1 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.46
Nodes (8): AiServiceFactoryTests.cs, AiServiceFactoryTests.cs, AiServiceFactoryTests(), GetByProvider_Should_ReturnService_When_ProviderIsMappedAndResolvable(), GetByProvider_Should_ReturnAzureFoundryService_When_ProviderIsMappedAndResolvable(), XPoster.Tests.Implementation, GetByProvider_Should_ThrowArgumentException_When_ProviderIsNotMapped(), GetByProvider_Should_ThrowInvalidOperationException_When_MappedServiceCannotBeResolved()

### Community 42 - "Entity (Community 42)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, Validate_MissingPlaceholders_Fails(), AzureFoundryOptionsValidatorTests, XPoster.Tests.Models, Validate_ValidOptions_Succeeds(), ValidOptions(), Validate_MissingRequiredProperties_Fails()

### Community 38 - "Entity (Community 38)"
Cohesion: 0.46
Nodes (8): OpenAIResponse.cs, OpenAIResponse.cs, Message, OpenAIResponse, OpenAIImageResponse, XPoster.Models, Choice, ImageData

### Community 39 - "Entity (Community 39)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, InSenderSendAsyncTests(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse()

### Community 37 - "Entity (Community 37)"
Cohesion: 0.46
Nodes (8): AiServiceFactory.cs, AiServiceFactory.cs, ArgumentException(), if(), XPoster.Implementation, GetByProvider(), InvalidOperationException(), AiServiceFactory()

### Community 40 - "Entity (Community 40)"
Cohesion: 0.46
Nodes (8): PostMissingBranchTests.cs, PostMissingBranchTests.cs, Firm_IsNotNullOrEmpty(), Post_EmptyContent_IsAllowed(), PostMissingBranchTests, Post_DefaultImageIsNull(), Post_CanSetAndGetAllProperties(), XPoster.Tests.Models

### Community 35 - "Entity (Community 35)"
Cohesion: 0.25
Nodes (8): InSender.cs, XPoster.SenderPlugins, Exception(), using(), ResolveAuthorUrnAsync(), SendAsync(), generatePayLoad(), InvalidOperationException()

### Community 34 - "Entity (Community 34)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, CaptureLogger(), XPoster.Tests.Integration, CreateLogger(), CaptureLoggerProvider(), Dispose(), IsEnabled()

### Community 36 - "Entity (Community 36)"
Cohesion: 0.46
Nodes (8): FeedServiceTests.cs, FeedServiceTests.cs, FeedServiceTests(), XPoster.Tests.Services, GetFeedsAsync_SetsCache_WhenFeedsFetched(), GetFeedsAsync_ReturnsEmpty_WhenInvalidFeed(), GetFeedsAsync_FiltersByKeyword_AndDate(), GetFeedsAsync_ReturnsFeedsFromCache_IfPresent()

### Community 43 - "Entity (Community 43)"
Cohesion: 0.52
Nodes (7): HybridAiService.cs, HybridAiService.cs, HybridAiService(), GetSummaryAsync(), GetImagePromptAsync(), GenerateImageAsync(), XPoster.Services

### Community 45 - "Entity (Community 45)"
Cohesion: 0.52
Nodes (7): DryRunSender.cs, DryRunSender.cs, DryRunSender(), catch(), SendAsync(), XPoster.SenderPlugins, if()

### Community 44 - "Entity (Community 44)"
Cohesion: 0.52
Nodes (7): IAiService.cs, IAiService.cs, IAiService, XPoster.Abstraction, GenerateImageAsync(), GetImagePromptAsync(), GetSummaryAsync()

### Community 48 - "Entity (Community 48)"
Cohesion: 0.52
Nodes (7): XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests.cs, XPoster.Tests, XFunctionMissingBranchTests(), Run_Should_Rethrow_When_Factory_Throws(), Run_Should_LogError_When_OrchestrateAsync_ReturnsNull(), Run_Should_LogError_When_PostAsync_ReturnsFalse()

### Community 46 - "Entity (Community 46)"
Cohesion: 0.29
Nodes (7): OrchestratorFactoryTests.cs, SetupMocksForOrchestratorFactory(), DryRunSlotProfileProvider_Should_AppendDryRunProfile_ToInnerProviderProfiles(), Resolve_Should_RequestConfiguredAiProvider_WhenProfileSpecifiesOne(), OrchestratorFactoryTests(), CreateFactoryWithProfiles(), CreateFactory()

### Community 47 - "Entity (Community 47)"
Cohesion: 0.29
Nodes (7): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), XPoster.Tests.Abstraction, PostAsync_ReturnsTrue_When_AllConditionsMet(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsFalse_When_Content_IsEmpty()

### Community 50 - "Entity (Community 50)"
Cohesion: 0.33
Nodes (6): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_Sender_IsNull(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), BaseOrchestratorTests(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), TestOrchestrator()

### Community 49 - "Entity (Community 49)"
Cohesion: 0.33
Nodes (6): OrchestratorFactory.cs, return(), XPoster.Implementation, ResolveAiProvider(), foreach(), Resolve()

### Community 59 - "Entity (Community 59)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, foreach(), Validate(), XPoster.Models, if()

### Community 57 - "Entity (Community 57)"
Cohesion: 0.60
Nodes (6): HttpClientExtensions.cs, HttpClientExtensions.cs, AddHttpClients(), AddResilientHttpClient(), IsTransientHttpFailure(), XPoster.Extensions

### Community 58 - "Entity (Community 58)"
Cohesion: 0.60
Nodes (6): IKeyVaultService.cs, IKeyVaultService.cs, SetSecretAsync(), GetSecretAsync(), IKeyVaultService, XPoster.Abstraction

### Community 61 - "Entity (Community 61)"
Cohesion: 0.60
Nodes (6): AiServiceHelper.cs, AiServiceHelper.cs, return(), if(), catch(), XPoster.Services

### Community 60 - "Entity (Community 60)"
Cohesion: 0.60
Nodes (6): KeyVaultService.cs, KeyVaultService.cs, XPoster.Services, GetSecretAsync(), KeyVaultService(), SetSecretAsync()

### Community 52 - "Entity (Community 52)"
Cohesion: 0.60
Nodes (6): XFunctionTests.cs, XFunctionTests.cs, XPoster.Tests, XFunctionTests(), Run_Should_DoNothing_When_GeneratorIsDisabled(), Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled()

### Community 51 - "Entity (Community 51)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, Polly_AiClient_AttemptTimeout_CancelsSlowRequest(), XPoster.Tests.Integration, StringContent(), Polly_AiClient_RetriesOn429_AndEventuallySucceeds()

### Community 54 - "Entity (Community 54)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, XPoster.Tests.Services, TimeProviderTests, GetCurrentTime_ReturnsCurrentDateTime(), GetCurrentTime_ReturnsUtcTime()

### Community 53 - "Entity (Community 53)"
Cohesion: 0.33
Nodes (6): HybridAiServiceTests.cs, BuildDeepSeekService(), BuildFalService(), GenerateImageAsync_DelegatesToFalAi_NotToDeepSeek(), Constructor_NullFalAiService_ThrowsArgumentNullException(), HybridAiService()

### Community 55 - "Entity (Community 55)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, for(), XPoster.Tests.Integration, Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures()

### Community 56 - "Entity (Community 56)"
Cohesion: 0.60
Nodes (6): DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider.cs, XPoster.Implementation, ScheduledOrchestrationProfile(), DryRunSlotProfileProvider(), GetProfiles()

### Community 70 - "Entity (Community 70)"
Cohesion: 0.40
Nodes (5): FeedService.cs, Exception(), catch(), XPoster.Services, GetFeedsAsync()

### Community 73 - "Entity (Community 73)"
Cohesion: 0.40
Nodes (5): IgSender.cs, XPoster.SenderPlugins, catch(), UploadImageToPublicUrl(), SendAsync()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.70
Nodes (5): IAiServiceFactory.cs, IAiServiceFactory.cs, XPoster.Abstraction, IAiServiceFactory, GetByProvider()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, GetCurrentTime(), XPoster.Services, LocalOverrideTimeProvider()

### Community 69 - "Entity (Community 69)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, XPoster.Services, GetCurrentTime(), TimeProvider

### Community 67 - "Entity (Community 67)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, XPoster.Tests.Integration, Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), catch()

### Community 68 - "Entity (Community 68)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, ITimeProvider, XPoster.Abstraction, GetCurrentTime()

### Community 75 - "Entity (Community 75)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, XPoster.Implementation, PowerLawOrchestrator(), if()

### Community 71 - "Entity (Community 71)"
Cohesion: 0.40
Nodes (5): FeedOrchestrator.cs, catch(), ReplaceEveryFirstOccurenceOf(), GenerateMessage(), XPoster.Implementation

### Community 72 - "Entity (Community 72)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, GetCryptoValue(), XPoster.Abstraction, ICryptoService

### Community 64 - "Entity (Community 64)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, IFeedService, XPoster.Abstraction, GetFeedsAsync()

### Community 66 - "Entity (Community 66)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, XPoster.Abstraction, ISender, SendAsync()

### Community 65 - "Entity (Community 65)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, XPoster.Abstraction, IOrchestrator, PostAsync()

### Community 62 - "Entity (Community 62)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, IOrchestratorFactory, XPoster.Abstraction, Resolve()

### Community 63 - "Entity (Community 63)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, XPoster.Abstraction, ISlotProfileProvider, GetProfiles()

### Community 91 - "Entity (Community 91)"
Cohesion: 0.50
Nodes (4): AzureFoundryService.cs, var(), BuildImagePromptPayload(), if()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, BaseOrchestrator(), XPoster.Abstraction, PostAsync()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.50
Nodes (4): InSender.cs, if(), catch(), InSender()

### Community 94 - "Entity (Community 94)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, catch(), StringContent(), Polly_LinkedIn_OnRetry_LogEntryIsEmitted()

### Community 81 - "Entity (Community 81)"
Cohesion: 0.50
Nodes (4): OpenAiService.cs, if(), var(), OpenAiService()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, GetCryptoValue(), XPoster.Services, catch()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile(), XPoster.Abstraction

### Community 78 - "Entity (Community 78)"
Cohesion: 0.50
Nodes (4): FeedOrchestrator.cs, FeedOrchestrator(), foreach(), if()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.50
Nodes (4): FalAiImageService.cs, XPoster.Services, FalAiImageService(), GenerateImageAsync()

### Community 86 - "Entity (Community 86)"
Cohesion: 0.83
Nodes (4): Program.cs, Program.cs, if(), DryRunSlotProfileProvider()

### Community 85 - "Entity (Community 85)"
Cohesion: 0.50
Nodes (4): XFunction.cs, Run(), XPoster, catch()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.50
Nodes (4): OrchestratorFactory.cs, CreateOrchestratorInstance(), OrchestratorFactory(), if()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.50
Nodes (4): XSender.cs, XPoster.SenderPlugins, catch(), SendAsync()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, XPoster.Implementation, NoOrchestrator()

### Community 90 - "Entity (Community 90)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, StringContent(), Polly_Instagram_AttemptTimeout_CancelsSlowRequest(), for()

### Community 87 - "Entity (Community 87)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, RSSFeed, XPoster.Models

### Community 89 - "Entity (Community 89)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, Post, XPoster.Models

### Community 88 - "Entity (Community 88)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, var(), XPoster.Tests.Helpers, BuildSequenceHandler()

### Community 105 - "Entity (Community 105)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, Validate(), XPoster.Models

### Community 106 - "Entity (Community 106)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, FalAiOptions.cs, XPoster.Models

### Community 107 - "Entity (Community 107)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, Validate(), XPoster.Models

### Community 109 - "Entity (Community 109)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, AzureFoundryOptions.cs, XPoster.Models

### Community 108 - "Entity (Community 108)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, XPoster.Models, Validate()

### Community 111 - "Entity (Community 111)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, XPoster.Abstraction, AiProvider.cs

### Community 110 - "Entity (Community 110)"
Cohesion: 0.67
Nodes (3): FeedService.cs, FeedService(), if()

### Community 97 - "Entity (Community 97)"
Cohesion: 1.00
Nodes (3): OpenAiOptions.cs, OpenAiOptions.cs, XPoster.Models

### Community 95 - "Entity (Community 95)"
Cohesion: 1.00
Nodes (3): Enums.cs, XPoster.Abstraction, Enums.cs

### Community 96 - "Entity (Community 96)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, DeepSeekOptions.cs, XPoster.Models

### Community 104 - "Entity (Community 104)"
Cohesion: 0.67
Nodes (3): FalAiImageService.cs, if(), catch()

### Community 102 - "Entity (Community 102)"
Cohesion: 0.67
Nodes (3): IgSender.cs, if(), IgSender()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.67
Nodes (3): XSender.cs, XSender(), if()

### Community 103 - "Entity (Community 103)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, if(), CryptoService()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.67
Nodes (3): XFunction.cs, if(), XFunction()

### Community 100 - "Entity (Community 100)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, BuildFactory(), params()

### Community 99 - "Entity (Community 99)"
Cohesion: 0.67
Nodes (3): DefaultSlotProfileProvider.cs, GetProfiles(), XPoster.Implementation

### Community 116 - "Entity (Community 116)"
Cohesion: 1.00
Nodes (2): DefaultSlotProfileProvider.cs, ScheduledOrchestrationProfile()

### Community 115 - "Entity (Community 115)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

### Community 114 - "Entity (Community 114)"
Cohesion: 1.00
Nodes (2): BaseOrchestrator.cs, if()

### Community 113 - "Entity (Community 113)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

### Community 112 - "Entity (Community 112)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._


# Graph Report - XPoster  (2026-06-19)

## Summary
- 1096 nodes · 1853 edges · 140 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Orchestrators` - 2 edges
2. `XPoster.Tests` - 2 edges
3. `IgSenderResilienceTests` - 2 edges
4. `XPoster.Contracts` - 2 edges
5. `ITimeProvider` - 2 edges
6. `XPoster.Tests.Integration` - 2 edges
7. `XPoster.Services` - 2 edges
8. `TimeProvider` - 2 edges
9. `XPoster.Services` - 2 edges
10. `RSSFeedMissingBranchTests` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, MakeHttpClient(), HttpClient(), ParseImageResponseAsync_AzureFoundry_UrlFallback_WrongOrigin_LogsWarning(), ParseImageResponseAsync_AzureFoundry_UrlFallback_DownloadFails_ReturnsEmptyArray(), ParseChatCompletionResponseAsync_WhenContentIsWhitespaceOnly_ReturnsTrueAndEmpty(), ParseChatCompletionResponseAsync_WhenChoicesIsNull_ReturnsFalseAndEmpty() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.12
Nodes (34): OpenAiServiceTests.cs, OpenAiServiceTests.cs, OpenAiService(), GetSummaryAsync_WhenTextAlreadyShort_ReturnsTextUnchanged(), MakeHandlerMock(), MakeHandler(), GenerateImageAsync_WhenApiReturnsTooManyRequests_ReturnsEmptyArray(), OpenAiServiceTests (+26 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.07
Nodes (30): AiServiceHelperImageTests.cs, AiServiceHelperImageTests, Parse_FalAi_DownloadThrows_LogsError(), Parse_AzureFoundry_UrlFallback_ReturnsBytes(), Parse_AzureFoundry_UrlFallback_WrongOrigin_LogsWarning(), Parse_AzureFoundry_ValidB64_ReturnsBytes(), Parse_MalformedJson_ReturnsEmpty(), Parse_FalAi_MissingUrlProperty_ReturnsEmpty() (+22 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, AddAzureFoundryOptions_RegistersValidator(), AddAzureFoundryOptions_BindsOptionsFromCorrectSection(), AddFalAiOptions_BindsOptionsFromCorrectSection(), AddDeepSeekOptions_BindsOptionsFromCorrectSection(), AddDeepSeekOptions_RegistersValidator(), FalAiOptionsExtensionsTests (+21 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.15
Nodes (26): PerplexityServiceTests.cs, PerplexityServiceTests.cs, PerplexityService(), GetSummaryAsync_WhenTextWithinLimit_DoesNotCallApi(), MakeHandlerMock(), MakeSequentialHandlerMock(), GenerateImageAsync_AlwaysReturnsEmptyByteArray(), foreach() (+18 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.16
Nodes (24): IgSenderTests.cs, IgSenderTests.cs, SendAsync_WhenImageUploadThrowsNotImplemented_ReturnsFalseAndLogsError(), MessageMaxLenght_Returns2200(), new(), SendAsync_WhenImageUploadThrowsHttpRequestException_ReturnsFalseAndLogsError(), SendAsync_WithImage_ReadsIgAccountIdFromKv(), SendAsync_WhenInstagramApiReturnsNonSuccess_ReturnsFalse() (+16 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.19
Nodes (21): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsContent(), GetSummaryAsync_WhenTextWithinLimit_DoesNotCallApi(), MakeHandlerMock(), GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString() (+13 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.19
Nodes (20): DryRunSenderTests.cs, DryRunSenderTests.cs, Constructor_WithNullKeyVaultService_ThrowsArgumentNullException(), BuildSender(), SendAsync_WhenKeyVaultProbeSucceeds_LogsPostContent(), SendAsync_WhenKeyVaultProbeSucceeds_ReturnsTrue(), SendAsync_WhenKeyVaultProbeThrows_LogsError(), SendAsync_WhenKeyVaultProbeSucceeds_ProbesXApiKey() (+12 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.11
Nodes (19): AzureFoundryServiceTests.cs, GenerateImageAsync_WhenFallbackUrlIsFromDifferentOrigin_LogsWarning(), GenerateImageAsync_WhenApiReturnsTooManyRequests_LogsWarning(), GenerateImageAsync_WhenB64JsonAbsentAndUrlPresent_DownloadsFromUrl(), GenerateImageAsync_WhenDataArrayIsEmpty_ReturnsEmptyByteArray(), GenerateImageAsync_WhenApiReturnsNonSuccess_ReturnsEmptyByteArray(), AzureFoundryServiceTests, GenerateImageAsync_RequestBodyContainsModelField() (+11 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.12
Nodes (17): AzureFoundryServiceTests.cs, ChatCompletionJson(), GenerateImageAsync_PostsToFoundryImagesGenerationsEndpoint(), GenerateImageAsync_WhenApiReturnsTooManyRequests_ReturnsEmptyByteArray(), GenerateImageAsync_WhenB64JsonIsNull_ReturnsEmptyByteArray(), GenerateImageAsync_WhenApiReturnsValidResponse_ReturnsByteArray(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString() (+9 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.24
Nodes (16): KeyVaultServiceTests.cs, KeyVaultServiceTests.cs, XPoster.Tests.Services, InSenderKv(), StubHttpMessageHandler(), KeyVaultServiceTests, KeyVaultService_MissingKeyVaultUri_ThrowsInvalidOperationException(), XSender_SendAsync_RequestsAllFourXCredentials() (+8 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.27
Nodes (14): InSenderMissingBranchTests.cs, InSenderMissingBranchTests.cs, BuildKv(), SendAsync_NullPost_ReturnsFalse(), BuildSender(), MessageMaxLenght_Returns800(), if(), InSenderMissingBranchTests() (+6 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.27
Nodes (14): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, Validate_WithValidOptions_ReturnsSuccess(), ValidOptions(), XPoster.Tests.Models, Validate_WithMultipleInvalidFields_ReturnsAllFailures(), Validate_WhenImagePromptSystemTemplateHasNoPlaceholder_ReturnsSuccess(), Validate_WhenSummaryUserPromptMissingText_ReturnsFailed() (+6 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.27
Nodes (14): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, XPoster.Tests.Orchestrators, OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationThrowsException(), OrchestrateAsync_Should_ReturnNull_When_AiServiceIsNull(), OrchestrateAsync_Should_ReturnNull_When_SummaryGenerationFails(), OrchestrateAsync_Should_ReturnNull_When_NoFeedsFound(), OrchestrateAsync_Should_ReturnNull_When_SenderIsNull() (+6 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, XPoster.Tests.Models, ModelsTests, ImageData_CanBeCreated_WithUrl(), Message_CanBeCreated_WithContent(), Choice_CanBeCreated_WithMessage(), RSSFeed_PublishDate_DefaultsToMinValue() (+6 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, Validate_DefaultOptions_Succeeds(), OpenAiOptionsValidatorTests, Validate_AllPlaceholdersMissing_ReportsThreeFailures(), XPoster.Tests.Models, Validate_MissingMaxCharsPlaceholder_Fails(), Validate_MissingSummaryPlaceholder_ErrorNamesProperty() (+5 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, GetCurrentTime_WhenForceHourIsValid_ReturnsForcedHour(), LocalOverrideTimeProvider(), XPoster.Tests.Services, LocalOverrideTimeProviderTests, GetCurrentTime_WhenForceHourIsValid_ReturnsUtcKind(), GetCurrentTime_WhenForceHourIsEmpty_FallsBackToUtcHour() (+5 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.29
Nodes (13): OpenAiService.cs, OpenAiService.cs, OpenAiService(), while(), var(), XPoster.Services, catch(), GetPromptForImage() (+5 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests, Validate_WhitespaceModelId_Fails(), ValidOptions(), XPoster.Tests.Models, Validate_WhitespaceApiKey_Fails(), Validate_MissingApiKey_Fails() (+5 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.29
Nodes (13): InSenderTests.cs, InSenderTests.cs, Constructor_InitializesCorrectly(), BuildKeyVaultMock(), BuildKeyVaultMockWithOrg(), XPoster.Tests.SenderPlugins, InSenderTests(), Constructor_WithNullLogger_ThrowsArgumentNullException() (+5 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.32
Nodes (12): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, SendAsync_WhenNoImage_ReturnsFalseWithoutCallingApi(), IgSenderResilienceTests, SendAsync_WhenImageUploadNotImplemented_ReturnsFalseAndLogsError(), PostWithImage(), PostWithoutImage(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse() (+4 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, GenerateImageAsync_Returns429_LogsWarning(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_ReturnsEmptyArray(), XPoster.Tests.Services, GenerateImageAsync_WhitespacePrompt_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithUnsafeChars_PercentEncodesInRequestUri(), BuildService(), GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray() (+4 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.18
Nodes (11): FalAiImageServiceTests.cs, FalAiImageService(), GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray(), GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray(), GenerateImageAsync_ValidResponse_ReturnsImageBytes(), GenerateImageAsync_ModelIdWithMultipleSegments_PreservesSlashesInUri(), GenerateImageAsync_Returns429_ReturnsEmptyArray() (+3 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.35
Nodes (11): ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProviderTests.cs, GetFeedUrls_Should_ReturnEmptyList_When_UrlsPropertyIsNull(), XPoster.Tests.Orchestrators, GetFeedUrls_Should_ReturnUrlsInOrder_When_MultipleUrlsConfigured(), GetFeedUrls_Should_ReturnReadOnlyList(), GetFeedUrls_Should_ReturnConfiguredUrls_When_OptionsContainsUrls(), Constructor_Should_Throw_When_OptionsIsNull() (+3 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), SendAsync_WhenLinkedInReturns200_ReturnsTrue(), SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue(), ValidPost(), SendAsync_WhenLinkedInReturns503_ReturnsFalseAndLogsError(), XPoster.Tests.SenderPlugins (+3 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.35
Nodes (11): XSenderTests.cs, XSenderTests.cs, XSender_ImplementsISender(), BuildKeyVaultMock(), Constructor_InitializesCorrectly(), XPoster.Tests.SenderPlugins, Constructor_WithNullLogger_ThrowsArgumentNullException(), Constructor_WithNullKeyVaultService_ThrowsArgumentNullException() (+3 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.35
Nodes (11): FeedOrchestratorFeedUrlProviderTests.cs, FeedOrchestratorFeedUrlProviderTests.cs, CreateOrchestrator(), XPoster.Tests.Orchestrators, new(), OrchestrateAsync_Should_AggregateFeeds_From_All_Urls(), OrchestrateAsync_Should_ReturnNull_And_DisableSendIt_When_ProviderReturnsEmptyList(), OrchestrateAsync_Should_CallGetFeedsAsync_With_Correct_Urls() (+3 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.18
Nodes (11): HybridAiServiceTests.cs, GetImagePromptAsync_DelegatesToDeepSeek_ReturnsPrompt(), FalAiImageService(), BuildHybrid(), ChatCompletionJson(), Constructor_NullDeepSeekService_ThrowsArgumentNullException(), DeepSeekService(), GetSummaryAsync_DelegatesToDeepSeek_ReturnsContent() (+3 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.35
Nodes (11): XSenderMissingBranchTests.cs, XSenderMissingBranchTests.cs, SendAsync_EmptyContent_ReturnsFalse(), MessageMaxLenght_Returns250(), SendAsync_NullPost_ReturnsFalse(), SendAsync_PostWithImage_CatchesTwitterException_ReturnsFalse(), BuildSender(), XPoster.Tests.SenderPlugins (+3 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, ProduceImage_IsAlwaysFalse(), NoOrchestratorTests(), Name_IsNoOrchestrator(), OrchestrateAsync_ReturnsNull(), SendIt_Set_ThrowsNotImplementedException(), XPoster.Tests.Orchestrators (+2 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.20
Nodes (10): OrchestratorFactoryTests.cs, Resolve_Should_ReturnNoOrchestrator_WhenNoProfileMatchesCurrentHour(), XPoster.Tests.Orchestrators, Resolve_Should_ReturnCorrectOrchestratorType_ForGivenSenderProfile(), Resolve_Should_ResolveXSender_WhenProfileUsesXSummaryFeed(), DefaultSlotProfileProvider_Should_NotContainDryRunProfile(), OrchestratorFactory(), Resolve_Should_NotRequestAiProvider_WhenProfileHasNoAiProvider() (+2 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.42
Nodes (9): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, GenerateAsync_Should_HandleNegativeOrZeroCryptoValue(), GenerateAsync_Should_CreateCorrectMessage_WithActualValue(), GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully(), GenerateAsync_Should_CalculateCorrectPowerLawValue_ForFixedDate(), PowerLawOrchestratorTests(), GenerateAsync_Should_ReturnNull_When_DateIsBeforeGenesis() (+1 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.42
Nodes (9): RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests, XPoster.Tests.Models, RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeed_DefaultPublishDateIsMinValue(), RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_CanSetPublishDate() (+1 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.42
Nodes (9): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, AzureFoundryOptions_Defaults_AreCorrect(), XPoster.Tests.Models, AzureFoundryOptionsTests, AzureFoundryOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), AzureFoundryOptions_DoesNotExpose_ApiVersionProperty(), AzureFoundryOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder() (+1 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), DeepSeekOptionsValidatorTests, Validate_MissingPlaceholders_Fails(), Validate_MissingRequiredProperties_Fails(), ValidOptions(), Validate_ValidOptions_Succeeds() (+1 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, GetCryptoValue_ReturnsZero_AndLogsError_OnException(), CryptoServiceTests, GetCryptoValue_ReturnsParsedValue_WhenNumericString(), CryptoService(), MakeService(), XPoster.Tests.Services (+1 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, XSenderSendAsyncTests(), SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse() (+1 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, var(), XPoster.Tests.Integration, HttpResponseMessage(), BuildProviderWithHandler(), BuildDelayedHandler(), BuildSequenceHandler() (+1 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptionsTests, XPoster.Tests.Models, DeepSeekOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptions_DoesNotExpose_ApiVersionProperty() (+1 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), XPoster.Tests.SenderPlugins, InSenderSendAsyncTests(), SendAsync_WithEmptyContent_ReturnsFalse()

### Community 41 - "Entity (Community 41)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, Validate_MissingPlaceholders_Fails(), AzureFoundryOptionsValidatorTests, ValidOptions(), Validate_ValidOptions_Succeeds(), Validate_MissingRequiredProperties_Fails(), XPoster.Tests.Models

### Community 45 - "Entity (Community 45)"
Cohesion: 0.25
Nodes (8): PerplexityService.cs, while(), nameof(), GetImagePromptAsync(), GetSummaryAsync(), GenerateImageAsync(), if(), XPoster.Services

### Community 44 - "Entity (Community 44)"
Cohesion: 0.46
Nodes (8): AiServiceFactory.cs, AiServiceFactory.cs, XPoster.Orchestrators, InvalidOperationException(), if(), ArgumentException(), AiServiceFactory(), GetByProvider()

### Community 39 - "Entity (Community 39)"
Cohesion: 0.25
Nodes (8): AzureFoundryService.cs, BuildSummaryPayload(), GenerateImageAsync(), GetImagePromptAsync(), GetChatCompletionsEndpoint(), XPoster.Services, GetSummaryAsync(), AzureFoundryService()

### Community 43 - "Entity (Community 43)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, CaptureLogger(), CreateLogger(), Dispose(), XPoster.Tests.Integration, IsEnabled(), CaptureLoggerProvider()

### Community 47 - "Entity (Community 47)"
Cohesion: 0.46
Nodes (8): OpenAIResponse.cs, OpenAIResponse.cs, Message, OpenAIImageResponse, XPoster.Models, OpenAIResponse, Choice, ImageData

### Community 48 - "Entity (Community 48)"
Cohesion: 0.46
Nodes (8): AiServiceFactoryTests.cs, AiServiceFactoryTests.cs, GetByProvider_Should_ThrowInvalidOperationException_When_MappedServiceCannotBeResolved(), XPoster.Tests.Orchestrators, GetByProvider_Should_ThrowArgumentException_When_ProviderIsNotMapped(), GetByProvider_Should_ReturnAzureFoundryService_When_ProviderIsMappedAndResolvable(), AiServiceFactoryTests(), GetByProvider_Should_ReturnService_When_ProviderIsMappedAndResolvable()

### Community 42 - "Entity (Community 42)"
Cohesion: 0.25
Nodes (8): InSender.cs, using(), InvalidOperationException(), generatePayLoad(), XPoster.SenderPlugins, SendAsync(), Exception(), ResolveAuthorUrnAsync()

### Community 49 - "Entity (Community 49)"
Cohesion: 0.46
Nodes (8): FeedServiceTests.cs, FeedServiceTests.cs, XPoster.Tests.Services, GetFeedsAsync_ReturnsFeedsFromCache_IfPresent(), GetFeedsAsync_SetsCache_WhenFeedsFetched(), GetFeedsAsync_ReturnsEmpty_WhenInvalidFeed(), FeedServiceTests(), GetFeedsAsync_FiltersByKeyword_AndDate()

### Community 46 - "Entity (Community 46)"
Cohesion: 0.46
Nodes (8): PostMissingBranchTests.cs, PostMissingBranchTests.cs, XPoster.Tests.Models, Post_CanSetAndGetAllProperties(), Post_EmptyContent_IsAllowed(), Post_DefaultImageIsNull(), Firm_IsNotNullOrEmpty(), PostMissingBranchTests

### Community 50 - "Entity (Community 50)"
Cohesion: 0.52
Nodes (7): HybridAiService.cs, HybridAiService.cs, GetSummaryAsync(), HybridAiService(), XPoster.Services, GenerateImageAsync(), GetImagePromptAsync()

### Community 59 - "Entity (Community 59)"
Cohesion: 0.29
Nodes (7): AzureFoundryService.cs, while(), GetImageGenerationEndpoint(), catch(), BuildImagePromptPayload(), var(), if()

### Community 60 - "Entity (Community 60)"
Cohesion: 0.52
Nodes (7): DryRunSender.cs, DryRunSender.cs, SendAsync(), DryRunSender(), catch(), XPoster.SenderPlugins, if()

### Community 53 - "Entity (Community 53)"
Cohesion: 0.29
Nodes (7): DeepSeekService.cs, BuildSummaryPayload(), if(), while(), XPoster.Services, GenerateImageAsync(), GetSummaryAsync()

### Community 52 - "Entity (Community 52)"
Cohesion: 0.52
Nodes (7): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, GetLabel_DescriptionDiffersFromEnumName(), XPoster.Tests.Contracts, GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(), GetLabel_UnknownProvider_ReturnsFallbackToString(), AiProviderExtensionsTests

### Community 57 - "Entity (Community 57)"
Cohesion: 0.52
Nodes (7): IAiService.cs, IAiService.cs, GetSummaryAsync(), GetImagePromptAsync(), GenerateImageAsync(), XPoster.Contracts, IAiService

### Community 56 - "Entity (Community 56)"
Cohesion: 0.29
Nodes (7): OrchestratorFactoryTests.cs, OrchestratorFactoryTests(), SetupMocksForOrchestratorFactory(), Resolve_Should_RequestConfiguredAiProvider_WhenProfileSpecifiesOne(), CreateFactory(), DryRunSlotProfileProvider_Should_AppendDryRunProfile_ToInnerProviderProfiles(), CreateFactoryWithProfiles()

### Community 58 - "Entity (Community 58)"
Cohesion: 0.29
Nodes (7): AiServiceHelper.cs, ExtractAzureFoundryBytesAsync(), XPoster.Services, ExtractFalAiBytesAsync(), ExtractOpenAiBytes(), LogAndReturnEmpty(), ParseImageResponseAsync()

### Community 55 - "Entity (Community 55)"
Cohesion: 0.52
Nodes (7): XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests(), Run_Should_Rethrow_When_Factory_Throws(), Run_Should_LogError_When_OrchestrateAsync_ReturnsNull(), Run_Should_LogError_When_PostAsync_ReturnsFalse(), XPoster.Tests

### Community 54 - "Entity (Community 54)"
Cohesion: 0.29
Nodes (7): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_Content_IsEmpty(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), XPoster.Tests.Contracts, PostAsync_ReturnsTrue_When_AllConditionsMet(), PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent()

### Community 51 - "Entity (Community 51)"
Cohesion: 0.52
Nodes (7): FalAiImageService.cs, FalAiImageService.cs, catch(), XPoster.Services, if(), FalAiImageService(), GenerateImageAsync()

### Community 71 - "Entity (Community 71)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, XPoster.Tests.Services, GetCurrentTime_ReturnsUtcTime(), TimeProviderTests, GetCurrentTime_ReturnsCurrentDateTime()

### Community 69 - "Entity (Community 69)"
Cohesion: 0.60
Nodes (6): DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider.cs, GetProfiles(), XPoster.Orchestrators, ScheduledOrchestrationProfile(), DryRunSlotProfileProvider()

### Community 70 - "Entity (Community 70)"
Cohesion: 0.60
Nodes (6): XFunctionTests.cs, XFunctionTests.cs, Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), XPoster.Tests, XFunctionTests(), Run_Should_DoNothing_When_GeneratorIsDisabled()

### Community 68 - "Entity (Community 68)"
Cohesion: 0.33
Nodes (6): DeepSeekService.cs, var(), GetChatCompletionsEndpoint(), DeepSeekService(), BuildImagePromptPayload(), GetImagePromptAsync()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.60
Nodes (6): KeyVaultService.cs, KeyVaultService.cs, KeyVaultService(), SetSecretAsync(), XPoster.Services, GetSecretAsync()

### Community 73 - "Entity (Community 73)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, XPoster.Tests.Integration, Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), for(), Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds()

### Community 75 - "Entity (Community 75)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, Validate(), if(), XPoster.Models, foreach()

### Community 72 - "Entity (Community 72)"
Cohesion: 0.33
Nodes (6): BaseOrchestratorTests.cs, BaseOrchestratorTests(), PostAsync_ReturnsFalse_When_Sender_IsNull(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), TestOrchestrator(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull()

### Community 66 - "Entity (Community 66)"
Cohesion: 0.33
Nodes (6): HybridAiServiceTests.cs, BuildDeepSeekService(), Constructor_NullFalAiService_ThrowsArgumentNullException(), GenerateImageAsync_DelegatesToFalAi_NotToDeepSeek(), HybridAiService(), BuildFalService()

### Community 64 - "Entity (Community 64)"
Cohesion: 0.33
Nodes (6): PerplexityService.cs, BuildImagePromptPayload(), BuildSummaryPayload(), GetChatCompletionsEndpoint(), PerplexityService(), var()

### Community 65 - "Entity (Community 65)"
Cohesion: 0.60
Nodes (6): HttpClientExtensions.cs, HttpClientExtensions.cs, AddResilientHttpClient(), IsTransientHttpFailure(), XPoster.Extensions, AddHttpClients()

### Community 61 - "Entity (Community 61)"
Cohesion: 0.33
Nodes (6): OrchestratorFactory.cs, return(), Resolve(), ResolveAiProvider(), foreach(), XPoster.Orchestrators

### Community 67 - "Entity (Community 67)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, var(), JsonResponse(), HttpClient(), MakeDownloadClient(), MakeNoOpClient()

### Community 63 - "Entity (Community 63)"
Cohesion: 0.60
Nodes (6): IKeyVaultService.cs, IKeyVaultService.cs, XPoster.Contracts, SetSecretAsync(), GetSecretAsync(), IKeyVaultService

### Community 62 - "Entity (Community 62)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, XPoster.Tests.Integration, StringContent(), Polly_AiClient_RetriesOn429_AndEventuallySucceeds(), Polly_AiClient_AttemptTimeout_CancelsSlowRequest()

### Community 85 - "Entity (Community 85)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, XPoster.Contracts, ITimeProvider, GetCurrentTime()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, catch(), Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), XPoster.Tests.Integration

### Community 83 - "Entity (Community 83)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, GetCurrentTime(), XPoster.Services, TimeProvider

### Community 84 - "Entity (Community 84)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, GetCurrentTime(), XPoster.Services, LocalOverrideTimeProvider()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.70
Nodes (5): ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider.cs, XPoster.Orchestrators, GetFeedUrls(), ConfigurationFeedUrlProvider()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, XPoster.Orchestrators, if(), PowerLawOrchestrator()

### Community 90 - "Entity (Community 90)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, XPoster.Contracts, IOrchestrator, PostAsync()

### Community 91 - "Entity (Community 91)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, IFeedService, GetFeedsAsync(), XPoster.Contracts

### Community 92 - "Entity (Community 92)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, XPoster.Contracts, SendAsync(), ISender

### Community 86 - "Entity (Community 86)"
Cohesion: 0.70
Nodes (5): IFeedUrlProvider.cs, IFeedUrlProvider.cs, IFeedUrlProvider, XPoster.Contracts, GetFeedUrls()

### Community 89 - "Entity (Community 89)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, XPoster.Contracts, GetCryptoValue(), ICryptoService

### Community 88 - "Entity (Community 88)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, ISlotProfileProvider, XPoster.Contracts, GetProfiles()

### Community 87 - "Entity (Community 87)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, Resolve(), IOrchestratorFactory, XPoster.Contracts

### Community 81 - "Entity (Community 81)"
Cohesion: 0.70
Nodes (5): IAiServiceFactory.cs, IAiServiceFactory.cs, IAiServiceFactory, GetByProvider(), XPoster.Contracts

### Community 78 - "Entity (Community 78)"
Cohesion: 0.40
Nodes (5): FeedOrchestrator.cs, catch(), GenerateMessage(), ReplaceEveryFirstOccurenceOf(), XPoster.Orchestrators

### Community 80 - "Entity (Community 80)"
Cohesion: 0.40
Nodes (5): FeedService.cs, XPoster.Services, Exception(), GetFeedsAsync(), catch()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.40
Nodes (5): IgSender.cs, SendAsync(), UploadImageToPublicUrl(), XPoster.SenderPlugins, catch()

### Community 111 - "Entity (Community 111)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, var(), XPoster.Tests.Helpers, BuildSequenceHandler()

### Community 112 - "Entity (Community 112)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, Polly_Instagram_AttemptTimeout_CancelsSlowRequest(), for(), StringContent()

### Community 114 - "Entity (Community 114)"
Cohesion: 0.83
Nodes (4): PerplexityOptionsExtensions.cs, PerplexityOptionsExtensions.cs, XPoster.Models, AddPerplexityOptions()

### Community 113 - "Entity (Community 113)"
Cohesion: 0.50
Nodes (4): XFunction.cs, XPoster, Run(), catch()

### Community 103 - "Entity (Community 103)"
Cohesion: 0.50
Nodes (4): OrchestratorFactory.cs, if(), CreateOrchestratorInstance(), OrchestratorFactory()

### Community 96 - "Entity (Community 96)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, XPoster.Models, Post

### Community 98 - "Entity (Community 98)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, XPoster.Models, RSSFeed

### Community 99 - "Entity (Community 99)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, catch(), XPoster.Services, GetCryptoValue()

### Community 100 - "Entity (Community 100)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, XPoster.Abstraction, ScheduledOrchestrationProfile()

### Community 97 - "Entity (Community 97)"
Cohesion: 0.83
Nodes (4): FalAiOptionsExtensions.cs, FalAiOptionsExtensions.cs, AddFalAiOptions(), XPoster.Models

### Community 101 - "Entity (Community 101)"
Cohesion: 0.83
Nodes (4): AzureFoundryOptionsExtensions.cs, AzureFoundryOptionsExtensions.cs, XPoster.Models, AddAzureFoundryOptions()

### Community 102 - "Entity (Community 102)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, XPoster.Orchestrators, NoOrchestrator()

### Community 95 - "Entity (Community 95)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, if(), return(), catch()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.50
Nodes (4): FeedOrchestrator.cs, FeedOrchestrator(), if(), foreach()

### Community 94 - "Entity (Community 94)"
Cohesion: 0.50
Nodes (4): XSender.cs, SendAsync(), catch(), XPoster.SenderPlugins

### Community 104 - "Entity (Community 104)"
Cohesion: 0.83
Nodes (4): DeepSeekOptionsExtensions.cs, DeepSeekOptionsExtensions.cs, AddDeepSeekOptions(), XPoster.Models

### Community 105 - "Entity (Community 105)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, XPoster.Abstraction, BaseOrchestrator(), PostAsync()

### Community 107 - "Entity (Community 107)"
Cohesion: 0.83
Nodes (4): Program.cs, Program.cs, DryRunSlotProfileProvider(), if()

### Community 106 - "Entity (Community 106)"
Cohesion: 0.83
Nodes (4): OpenAiOptionsExtensions.cs, OpenAiOptionsExtensions.cs, AddOpenAiOptions(), XPoster.Models

### Community 108 - "Entity (Community 108)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), catch(), StringContent()

### Community 109 - "Entity (Community 109)"
Cohesion: 0.50
Nodes (4): InSender.cs, catch(), InSender(), if()

### Community 110 - "Entity (Community 110)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, XPoster.Contracts, GetLabel()

### Community 121 - "Entity (Community 121)"
Cohesion: 0.67
Nodes (3): PerplexityOptionsValidator.cs, Validate(), XPoster.Models

### Community 120 - "Entity (Community 120)"
Cohesion: 0.67
Nodes (3): DefaultSlotProfileProvider.cs, XPoster.Orchestrators, GetProfiles()

### Community 116 - "Entity (Community 116)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, Validate(), XPoster.Models

### Community 115 - "Entity (Community 115)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, XPoster.Models, FalAiOptions.cs

### Community 119 - "Entity (Community 119)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, params(), BuildFactory()

### Community 118 - "Entity (Community 118)"
Cohesion: 1.00
Nodes (3): PerplexityOptions.cs, XPoster.Models, PerplexityOptions.cs

### Community 117 - "Entity (Community 117)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, AzureFoundryOptions.cs, XPoster.Models

### Community 122 - "Entity (Community 122)"
Cohesion: 0.67
Nodes (3): XSender.cs, if(), XSender()

### Community 131 - "Entity (Community 131)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, XPoster.Models, Validate()

### Community 133 - "Entity (Community 133)"
Cohesion: 1.00
Nodes (3): XPoster.Models, FeedOptions.cs, FeedOptions.cs

### Community 132 - "Entity (Community 132)"
Cohesion: 0.67
Nodes (3): FeedService.cs, FeedService(), if()

### Community 130 - "Entity (Community 130)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, Validate(), XPoster.Models

### Community 123 - "Entity (Community 123)"
Cohesion: 0.67
Nodes (3): XFunction.cs, if(), XFunction()

### Community 124 - "Entity (Community 124)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, XPoster.Contracts, AiProvider.cs

### Community 125 - "Entity (Community 125)"
Cohesion: 1.00
Nodes (3): XPoster.Models, DeepSeekOptions.cs, DeepSeekOptions.cs

### Community 126 - "Entity (Community 126)"
Cohesion: 0.67
Nodes (3): IgSender.cs, if(), IgSender()

### Community 128 - "Entity (Community 128)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, if(), CryptoService()

### Community 129 - "Entity (Community 129)"
Cohesion: 1.00
Nodes (3): OpenAiOptions.cs, OpenAiOptions.cs, XPoster.Models

### Community 127 - "Entity (Community 127)"
Cohesion: 1.00
Nodes (3): Enums.cs, Enums.cs, XPoster.Contracts

### Community 139 - "Entity (Community 139)"
Cohesion: 1.00
Nodes (2): DefaultSlotProfileProvider.cs, ScheduledOrchestrationProfile()

### Community 135 - "Entity (Community 135)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

### Community 134 - "Entity (Community 134)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

### Community 137 - "Entity (Community 137)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

### Community 136 - "Entity (Community 136)"
Cohesion: 1.00
Nodes (2): PerplexityOptionsValidator.cs, if()

### Community 138 - "Entity (Community 138)"
Cohesion: 1.00
Nodes (2): BaseOrchestrator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._


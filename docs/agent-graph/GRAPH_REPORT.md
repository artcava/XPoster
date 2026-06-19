# Graph Report - XPoster  (2026-06-19)

## Summary
- 1047 nodes · 1773 edges · 134 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Services` - 2 edges
2. `XPoster.Tests` - 2 edges
3. `XPoster.Models` - 2 edges
4. `XPoster.SenderPlugins` - 2 edges
5. `OpenAIResponse` - 2 edges
6. `XPoster.Models` - 2 edges
7. `OpenAIImageResponse` - 2 edges
8. `PostMissingBranchTests` - 2 edges
9. `ImageData` - 2 edges
10. `Choice` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, ParseChatCompletionResponseAsync_WhenContentIsWhitespaceOnly_ReturnsTrueAndEmpty(), ParseChatCompletionResponseAsync_WhenChoicesIsNull_ReturnsFalseAndEmpty(), ParseChatCompletionResponseAsync_WhenChoicesIsEmpty_ReturnsFalseAndEmpty(), XPoster.Tests.Services, ParseImageResponseAsync_WhenStatusIsNonSuccess_ReturnsEmptyArray(), var() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.12
Nodes (34): OpenAiServiceTests.cs, OpenAiServiceTests.cs, OpenAiServiceTests, XPoster.Tests.Services, BuildService(), ChatCompletionJson(), GenerateImageAsync_WhenHttpRequestExceptionThrown_LogsError(), GenerateImageAsync_WhenDataArrayIsEmpty_ReturnsEmptyArray() (+26 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.07
Nodes (30): AiServiceHelperImageTests.cs, Parse_AzureFoundry_MissingBothB64AndUrl_ReturnsEmpty(), Parse_AzureFoundry_MissingDataProperty_ReturnsEmpty(), Parse_AzureFoundry_UrlFallback_DownloadThrows_LogsError(), AiServiceHelperImageTests, Parse_FalAi_DownloadThrows_LogsError(), Parse_AzureFoundry_UrlFallback_ReturnsBytes(), Parse_AzureFoundry_ValidB64_ReturnsBytes() (+22 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.15
Nodes (26): PerplexityServiceTests.cs, PerplexityServiceTests.cs, GetSummaryAsync_WhenTextRemainsLongAfterMaxRetries_ReturnsLastApiContent(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenFirstResponseStillTooLong_RetriesAndReturnsSecondResponse(), GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsContent(), PerplexityServiceTests, XPoster.Tests.Services (+18 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.16
Nodes (24): IgSenderTests.cs, IgSenderTests.cs, SendAsync_WhenImageUploadThrowsHttpRequestException_ReturnsFalseAndLogsError(), IgSenderTests(), MessageMaxLenght_Returns2200(), new(), Constructor_WithNullLogger_ThrowsArgumentNullException(), BuildSenderWithFactory() (+16 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.19
Nodes (21): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, GenerateImageAsync_AlwaysThrows_NotSupportedException(), GenerateImageAsync_ExceptionMessage_MentionsHybridAiService(), GetImagePromptAsync_WhenApiReturns429_ReturnsEmptyString(), GetImagePromptAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetImagePromptAsync_WhenApiReturnsValidResponse_ReturnsPrompt(), GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString() (+13 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.19
Nodes (20): DryRunSenderTests.cs, DryRunSenderTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WhenKeyVaultProbeThrows_ReturnsFalse(), SendAsync_WithNullPost_LogsWarning(), SendAsync_WithImageBytes_LogsImagePresence(), SendAsync_WhenKeyVaultProbeSucceeds_ReturnsTrue() (+12 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.11
Nodes (19): AzureFoundryServiceTests.cs, BuildService(), AzureFoundryServiceTests, GetImagePromptAsync_WhenApiReturnsValidResponse_ReturnsPrompt(), GenerateImageAsync_WhenHttpRequestExceptionOnPost_ReturnsEmptyByteArray(), GenerateImageAsync_WhenPromptIsEmpty_ReturnsEmptyByteArrayWithoutCallingApi(), GenerateImageAsync_WhenPromptIsWhitespace_ReturnsEmptyByteArrayWithoutCallingApi(), MakeHandlerMock() (+11 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.12
Nodes (17): AzureFoundryServiceTests.cs, GenerateImageAsync_WhenApiReturnsTooManyRequests_ReturnsEmptyByteArray(), ChatCompletionJson(), AzureFoundryService(), GenerateImageAsync_PostsToFoundryImagesGenerationsEndpoint(), GetSummaryAsync_RequestBodyContainsModelField(), GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString() (+9 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.24
Nodes (16): KeyVaultServiceTests.cs, KeyVaultServiceTests.cs, HttpFactory(), GetSecretAsync_ThrowsWhenSecretNotFound(), GetSecretAsync_OnRotation_ReturnsNewValueOnNextCall(), GetSecretAsync_ReturnsExpectedValue(), StubHttpMessageHandler(), XPoster.Tests.Services (+8 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.27
Nodes (14): InSenderMissingBranchTests.cs, InSenderMissingBranchTests.cs, SendAsync_NullPost_ReturnsFalse(), BuildSender(), if(), InSenderMissingBranchTests(), BuildKv(), MessageMaxLenght_Returns800() (+6 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, ImageData_CanBeCreated_WithUrl(), Choice_CanBeCreated_WithMessage(), XPoster.Tests.Models, Post_Firm_ContainsExpectedHashtags(), RSSFeed_CanBeCreated_WithAllProperties(), RSSFeed_PublishDate_DefaultsToMinValue() (+6 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.27
Nodes (14): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, XPoster.Tests.Orchestrators, OrchestrateAsync_Should_ApplyHashtagsCorrectly(), FeedOrchestratorTests(), new(), CreateOrchestrator(), OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationThrowsException() (+6 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.27
Nodes (14): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, ValidOptions(), Validate_WhenSummarySystemPromptMissingMaxChars_ReturnsFailed(), Validate_WithMultipleInvalidFields_ReturnsAllFailures(), Validate_WithValidOptions_ReturnsSuccess(), Validate_WhenSummaryUserPromptMissingText_ReturnsFailed(), Validate_WhenImagePromptSystemTemplateHasNoPlaceholder_ReturnsSuccess() (+6 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, BuildProvider(), XPoster.Tests.Services, GetCurrentTime_WhenForceHourIsValid_ReturnsUtcKind(), GetCurrentTime_WhenForceHourIsAbsent_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsEmpty_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsNonNumeric_FallsBackToUtcHour() (+5 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.29
Nodes (13): OpenAiService.cs, OpenAiService.cs, var(), while(), XPoster.Services, catch(), if(), GenerateImageAsync() (+5 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, ValidOptions(), Validate_MissingTextPlaceholder_ErrorNamesProperty(), Validate_MissingTextPlaceholder_Fails(), XPoster.Tests.Models, Validate_MissingSummaryPlaceholder_Fails(), Validate_AllPlaceholdersMissing_ReportsThreeFailures() (+5 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.29
Nodes (13): InSenderTests.cs, InSenderTests.cs, InSenderTests(), SendAsync_WhenLinkedInOrgIdPresent_UsesOrgIdAndSkipsOwnerCode(), XPoster.Tests.SenderPlugins, SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), SendAsync_CalledTwice_QueriesKvAccessTokenOnEachCall(), Constructor_WithNullLogger_ThrowsArgumentNullException() (+5 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_BothRequiredFieldsMissing_ReportsBothFailures(), Validate_ModelIdWithAllowedSpecialChars_Succeeds(), Validate_MissingApiKey_Fails(), Validate_MissingModelId_Fails(), Validate_ModelIdWithUnsafeCharacters_Fails(), Validate_ValidOptions_Succeeds() (+5 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, GenerateImageAsync_ModelIdWithUnsafeChars_PercentEncodesInRequestUri(), BuildService(), FalAiImageServiceTests, GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray(), GenerateImageAsync_EmptyUrlProperty_ReturnsEmptyArray(), FalImageJson(), GenerateImageAsync_MalformedJson_ReturnsEmptyArray() (+4 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.32
Nodes (12): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, PostWithImage(), PostWithoutImage(), SendAsync_WhenImageUploadNotImplemented_ReturnsFalseAndLogsError(), XPoster.Tests.SenderPlugins, SendAsync_WhenNoImage_ReturnsFalseWithoutCallingApi(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse() (+4 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.35
Nodes (11): FeedOrchestratorFeedUrlProviderTests.cs, FeedOrchestratorFeedUrlProviderTests.cs, XPoster.Tests.Orchestrators, OrchestrateAsync_Should_ReturnNull_And_DisableSendIt_When_ProviderReturnsEmptyList(), FeedOrchestratorFeedUrlProviderTests(), OrchestrateAsync_Should_CallGetFeedUrls_Once(), OrchestrateAsync_Should_CallGetFeedsAsync_For_Each_Url(), OrchestrateAsync_Should_CallGetFeedsAsync_With_Correct_Urls() (+3 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.35
Nodes (11): XSenderMissingBranchTests.cs, XSenderMissingBranchTests.cs, SendAsync_NullPost_ReturnsFalse(), XSenderMissingBranchTests(), SendAsync_PostWithImage_CatchesTwitterException_ReturnsFalse(), SendAsync_ValidTextPost_CatchesTwitterException_ReturnsFalse(), SendAsync_WhitespaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins (+3 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.35
Nodes (11): ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProviderTests, ConfigurationFeedUrlProvider(), Constructor_Should_Throw_When_OptionsIsNull(), GetFeedUrls_Should_ReturnConfiguredUrls_When_OptionsContainsUrls(), GetFeedUrls_Should_ReturnReadOnlyList(), XPoster.Tests.Orchestrators (+3 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.18
Nodes (11): FalAiImageServiceTests.cs, GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray(), FalAiImageService(), GenerateImageAsync_Returns429_ReturnsEmptyArray(), GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray(), GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithMultipleSegments_PreservesSlashesInUri(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_LogsError() (+3 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.35
Nodes (11): XSenderTests.cs, XSenderTests.cs, BuildKeyVaultMock(), XSenderTests(), Constructor_WithNullKeyVaultService_ThrowsArgumentNullException(), XPoster.Tests.SenderPlugins, SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), SendAsync_CalledTwice_QueriesKvOnEachCall() (+3 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.18
Nodes (11): HybridAiServiceTests.cs, DeepSeekService(), ChatCompletionJson(), BuildHybrid(), Constructor_NullDeepSeekService_ThrowsArgumentNullException(), FalAiImageService(), XPoster.Tests.Services, HybridAiServiceTests (+3 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, ValidPost(), InSender(), SendAsync_WhenLinkedInReturns503_ReturnsFalseAndLogsError(), SendAsync_WhenLinkedInReturns200_ReturnsTrue(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue() (+3 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.20
Nodes (10): OrchestratorFactoryTests.cs, Resolve_Should_ReturnCorrectOrchestratorType_ForGivenSenderProfile(), Resolve_Should_ResolveInSender_WhenProfileUsesInSummaryFeed(), DefaultSlotProfileProvider_Should_NotContainDryRunProfile(), Resolve_Should_ResolveXSender_WhenProfileUsesXSummaryFeed(), Resolve_Should_ResolveDryRunSender_WhenProfileUsesDryRunSend(), OrchestratorFactory(), Resolve_Should_NotRequestAiProvider_WhenProfileHasNoAiProvider() (+2 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, ProduceImage_Set_ThrowsNotImplementedException(), ProduceImage_IsAlwaysFalse(), Name_IsNoOrchestrator(), NoOrchestratorTests(), OrchestrateAsync_ReturnsNull(), SendIt_Set_ThrowsNotImplementedException() (+2 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, XPoster.Tests.Models, Validate_ValidOptions_Succeeds(), Validate_MissingPlaceholders_Fails(), Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), DeepSeekOptionsValidatorTests, Validate_MissingRequiredProperties_Fails() (+1 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, CryptoServiceTests, CryptoService(), GetCryptoValue_ReturnsParsedValue_WhenNumericString(), GetCryptoValue_ReturnsZero_AndLogsError_OnException(), MakeService(), GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric() (+1 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, HttpResponseMessage(), BuildSequenceHandler(), BuildDelayedHandler(), BuildProviderWithHandler(), var(), params() (+1 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.42
Nodes (9): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, AzureFoundryOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), AzureFoundryOptions_DoesNotExpose_ApiVersionProperty(), AzureFoundryOptions_Defaults_AreCorrect(), AzureFoundryOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), AzureFoundryOptionsTests, XPoster.Tests.Models (+1 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XSenderSendAsyncTests(), XPoster.Tests.SenderPlugins, SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse() (+1 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.42
Nodes (9): RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests.cs, RSSFeed_DefaultPublishDateIsMinValue(), RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_CanSetPublishDate(), RSSFeed_RecordEquality_SameValues_AreEqual(), RSSFeedMissingBranchTests, XPoster.Tests.Models (+1 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.42
Nodes (9): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, GenerateAsync_Should_ReturnNull_When_DateIsBeforeGenesis(), PowerLawOrchestratorTests(), XPoster.Tests.Orchestrators, GenerateAsync_Should_HandleNegativeOrZeroCryptoValue(), GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully(), GenerateAsync_Should_CalculateCorrectPowerLawValue_ForFixedDate() (+1 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, XPoster.Tests.Models, DeepSeekOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptionsTests (+1 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.25
Nodes (8): InSender.cs, XPoster.SenderPlugins, using(), ResolveAuthorUrnAsync(), Exception(), SendAsync(), InvalidOperationException(), generatePayLoad()

### Community 47 - "Entity (Community 47)"
Cohesion: 0.46
Nodes (8): PostMissingBranchTests.cs, PostMissingBranchTests.cs, Post_EmptyContent_IsAllowed(), PostMissingBranchTests, XPoster.Tests.Models, Firm_IsNotNullOrEmpty(), Post_DefaultImageIsNull(), Post_CanSetAndGetAllProperties()

### Community 48 - "Entity (Community 48)"
Cohesion: 0.46
Nodes (8): OpenAIResponse.cs, OpenAIResponse.cs, OpenAIResponse, XPoster.Models, OpenAIImageResponse, ImageData, Choice, Message

### Community 40 - "Entity (Community 40)"
Cohesion: 0.25
Nodes (8): AzureFoundryService.cs, GetSummaryAsync(), XPoster.Services, AzureFoundryService(), GetChatCompletionsEndpoint(), GenerateImageAsync(), BuildSummaryPayload(), GetImagePromptAsync()

### Community 43 - "Entity (Community 43)"
Cohesion: 0.46
Nodes (8): FeedServiceTests.cs, FeedServiceTests.cs, FeedServiceTests(), GetFeedsAsync_ReturnsFeedsFromCache_IfPresent(), GetFeedsAsync_SetsCache_WhenFeedsFetched(), XPoster.Tests.Services, GetFeedsAsync_FiltersByKeyword_AndDate(), GetFeedsAsync_ReturnsEmpty_WhenInvalidFeed()

### Community 42 - "Entity (Community 42)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, CaptureLoggerProvider(), IsEnabled(), CaptureLogger(), CreateLogger(), XPoster.Tests.Integration, Dispose()

### Community 44 - "Entity (Community 44)"
Cohesion: 0.25
Nodes (8): PerplexityService.cs, nameof(), GetSummaryAsync(), GenerateImageAsync(), GetImagePromptAsync(), if(), XPoster.Services, while()

### Community 39 - "Entity (Community 39)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, InSenderSendAsyncTests(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse()

### Community 38 - "Entity (Community 38)"
Cohesion: 0.46
Nodes (8): AiServiceFactory.cs, AiServiceFactory.cs, InvalidOperationException(), XPoster.Orchestrators, ArgumentException(), AiServiceFactory(), if(), GetByProvider()

### Community 46 - "Entity (Community 46)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, Validate_MissingPlaceholders_Fails(), AzureFoundryOptionsValidatorTests, XPoster.Tests.Models, Validate_MissingRequiredProperties_Fails(), Validate_ValidOptions_Succeeds(), ValidOptions()

### Community 45 - "Entity (Community 45)"
Cohesion: 0.46
Nodes (8): AiServiceFactoryTests.cs, AiServiceFactoryTests.cs, XPoster.Tests.Orchestrators, GetByProvider_Should_ThrowInvalidOperationException_When_MappedServiceCannotBeResolved(), AiServiceFactoryTests(), GetByProvider_Should_ReturnService_When_ProviderIsMappedAndResolvable(), GetByProvider_Should_ReturnAzureFoundryService_When_ProviderIsMappedAndResolvable(), GetByProvider_Should_ThrowArgumentException_When_ProviderIsNotMapped()

### Community 59 - "Entity (Community 59)"
Cohesion: 0.52
Nodes (7): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, XPoster.Tests.Contracts, GetLabel_UnknownProvider_ReturnsFallbackToString(), GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(), GetLabel_DescriptionDiffersFromEnumName(), AiProviderExtensionsTests

### Community 58 - "Entity (Community 58)"
Cohesion: 0.29
Nodes (7): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_Content_IsEmpty(), XPoster.Tests.Contracts, PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_ReturnsTrue_When_AllConditionsMet(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent()

### Community 56 - "Entity (Community 56)"
Cohesion: 0.29
Nodes (7): AzureFoundryService.cs, GetImageGenerationEndpoint(), if(), while(), var(), BuildImagePromptPayload(), catch()

### Community 54 - "Entity (Community 54)"
Cohesion: 0.29
Nodes (7): OrchestratorFactoryTests.cs, DryRunSlotProfileProvider_Should_AppendDryRunProfile_ToInnerProviderProfiles(), OrchestratorFactoryTests(), Resolve_Should_RequestConfiguredAiProvider_WhenProfileSpecifiesOne(), SetupMocksForOrchestratorFactory(), CreateFactory(), CreateFactoryWithProfiles()

### Community 55 - "Entity (Community 55)"
Cohesion: 0.52
Nodes (7): FalAiImageService.cs, FalAiImageService.cs, if(), FalAiImageService(), GenerateImageAsync(), catch(), XPoster.Services

### Community 52 - "Entity (Community 52)"
Cohesion: 0.52
Nodes (7): XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests.cs, Run_Should_LogError_When_OrchestrateAsync_ReturnsNull(), Run_Should_Rethrow_When_Factory_Throws(), XFunctionMissingBranchTests(), XPoster.Tests, Run_Should_LogError_When_PostAsync_ReturnsFalse()

### Community 50 - "Entity (Community 50)"
Cohesion: 0.52
Nodes (7): DryRunSender.cs, DryRunSender.cs, XPoster.SenderPlugins, if(), DryRunSender(), catch(), SendAsync()

### Community 51 - "Entity (Community 51)"
Cohesion: 0.52
Nodes (7): IAiService.cs, IAiService.cs, GenerateImageAsync(), XPoster.Contracts, IAiService, GetSummaryAsync(), GetImagePromptAsync()

### Community 53 - "Entity (Community 53)"
Cohesion: 0.52
Nodes (7): HybridAiService.cs, HybridAiService.cs, GenerateImageAsync(), HybridAiService(), XPoster.Services, GetImagePromptAsync(), GetSummaryAsync()

### Community 57 - "Entity (Community 57)"
Cohesion: 0.29
Nodes (7): DeepSeekService.cs, BuildSummaryPayload(), while(), if(), GenerateImageAsync(), GetSummaryAsync(), XPoster.Services

### Community 49 - "Entity (Community 49)"
Cohesion: 0.29
Nodes (7): AiServiceHelper.cs, ExtractAzureFoundryBytesAsync(), XPoster.Services, ParseImageResponseAsync(), ExtractFalAiBytesAsync(), ExtractOpenAiBytes(), LogAndReturnEmpty()

### Community 71 - "Entity (Community 71)"
Cohesion: 0.33
Nodes (6): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), BaseOrchestratorTests(), PostAsync_ReturnsFalse_When_Sender_IsNull(), TestOrchestrator()

### Community 69 - "Entity (Community 69)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, Validate(), if(), XPoster.Models, foreach()

### Community 70 - "Entity (Community 70)"
Cohesion: 0.60
Nodes (6): XFunctionTests.cs, XFunctionTests.cs, Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), Run_Should_DoNothing_When_GeneratorIsDisabled(), XPoster.Tests, XFunctionTests()

### Community 67 - "Entity (Community 67)"
Cohesion: 0.60
Nodes (6): HttpClientExtensions.cs, HttpClientExtensions.cs, AddHttpClients(), AddResilientHttpClient(), IsTransientHttpFailure(), XPoster.Extensions

### Community 68 - "Entity (Community 68)"
Cohesion: 0.33
Nodes (6): PerplexityService.cs, BuildSummaryPayload(), var(), GetChatCompletionsEndpoint(), PerplexityService(), BuildImagePromptPayload()

### Community 66 - "Entity (Community 66)"
Cohesion: 0.60
Nodes (6): KeyVaultService.cs, KeyVaultService.cs, XPoster.Services, KeyVaultService(), SetSecretAsync(), GetSecretAsync()

### Community 64 - "Entity (Community 64)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, var(), JsonResponse(), HttpClient(), MakeNoOpClient(), MakeDownloadClient()

### Community 65 - "Entity (Community 65)"
Cohesion: 0.60
Nodes (6): DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider.cs, XPoster.Orchestrators, GetProfiles(), DryRunSlotProfileProvider(), ScheduledOrchestrationProfile()

### Community 62 - "Entity (Community 62)"
Cohesion: 0.33
Nodes (6): HybridAiServiceTests.cs, BuildFalService(), HybridAiService(), GenerateImageAsync_DelegatesToFalAi_NotToDeepSeek(), Constructor_NullFalAiService_ThrowsArgumentNullException(), BuildDeepSeekService()

### Community 60 - "Entity (Community 60)"
Cohesion: 0.60
Nodes (6): IKeyVaultService.cs, IKeyVaultService.cs, GetSecretAsync(), XPoster.Contracts, SetSecretAsync(), IKeyVaultService

### Community 61 - "Entity (Community 61)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, XPoster.Tests.Services, GetCurrentTime_ReturnsCurrentDateTime(), TimeProviderTests, GetCurrentTime_ReturnsUtcTime()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.33
Nodes (6): DeepSeekService.cs, GetImagePromptAsync(), GetChatCompletionsEndpoint(), DeepSeekService(), BuildImagePromptPayload(), var()

### Community 72 - "Entity (Community 72)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), for(), XPoster.Tests.Integration

### Community 73 - "Entity (Community 73)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, Polly_AiClient_AttemptTimeout_CancelsSlowRequest(), XPoster.Tests.Integration, StringContent(), Polly_AiClient_RetriesOn429_AndEventuallySucceeds()

### Community 63 - "Entity (Community 63)"
Cohesion: 0.33
Nodes (6): OrchestratorFactory.cs, return(), foreach(), Resolve(), XPoster.Orchestrators, ResolveAiProvider()

### Community 86 - "Entity (Community 86)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, ITimeProvider, GetCurrentTime(), XPoster.Contracts

### Community 82 - "Entity (Community 82)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, XPoster.Contracts, GetProfiles(), ISlotProfileProvider

### Community 85 - "Entity (Community 85)"
Cohesion: 0.40
Nodes (5): FeedService.cs, Exception(), catch(), XPoster.Services, GetFeedsAsync()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.40
Nodes (5): FeedOrchestrator.cs, catch(), ReplaceEveryFirstOccurenceOf(), GenerateMessage(), XPoster.Orchestrators

### Community 84 - "Entity (Community 84)"
Cohesion: 0.40
Nodes (5): IgSender.cs, catch(), XPoster.SenderPlugins, UploadImageToPublicUrl(), SendAsync()

### Community 91 - "Entity (Community 91)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration, catch(), Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures()

### Community 78 - "Entity (Community 78)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, XPoster.Contracts, ISender, SendAsync()

### Community 81 - "Entity (Community 81)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, IOrchestratorFactory, XPoster.Contracts, Resolve()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, IOrchestrator, PostAsync(), XPoster.Contracts

### Community 80 - "Entity (Community 80)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, GetFeedsAsync(), IFeedService, XPoster.Contracts

### Community 75 - "Entity (Community 75)"
Cohesion: 0.70
Nodes (5): IAiServiceFactory.cs, IAiServiceFactory.cs, IAiServiceFactory, GetByProvider(), XPoster.Contracts

### Community 76 - "Entity (Community 76)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, XPoster.Contracts, ICryptoService, GetCryptoValue()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.70
Nodes (5): IFeedUrlProvider.cs, IFeedUrlProvider.cs, XPoster.Contracts, IFeedUrlProvider, GetFeedUrls()

### Community 89 - "Entity (Community 89)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, XPoster.Services, GetCurrentTime(), TimeProvider

### Community 90 - "Entity (Community 90)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, XPoster.Orchestrators, PowerLawOrchestrator(), if()

### Community 87 - "Entity (Community 87)"
Cohesion: 0.70
Nodes (5): ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider.cs, GetFeedUrls(), XPoster.Orchestrators, ConfigurationFeedUrlProvider()

### Community 88 - "Entity (Community 88)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, GetCurrentTime(), LocalOverrideTimeProvider(), XPoster.Services

### Community 97 - "Entity (Community 97)"
Cohesion: 0.83
Nodes (4): Program.cs, Program.cs, DryRunSlotProfileProvider(), if()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.50
Nodes (4): FeedOrchestrator.cs, foreach(), FeedOrchestrator(), if()

### Community 96 - "Entity (Community 96)"
Cohesion: 0.50
Nodes (4): OrchestratorFactory.cs, OrchestratorFactory(), CreateOrchestratorInstance(), if()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.50
Nodes (4): InSender.cs, catch(), InSender(), if()

### Community 94 - "Entity (Community 94)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), catch(), StringContent()

### Community 95 - "Entity (Community 95)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, XPoster.Abstraction, ScheduledOrchestrationProfile()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, catch(), if(), return()

### Community 105 - "Entity (Community 105)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, NoOrchestrator(), XPoster.Orchestrators

### Community 99 - "Entity (Community 99)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, XPoster.Services, catch(), GetCryptoValue()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, Post, XPoster.Models

### Community 100 - "Entity (Community 100)"
Cohesion: 0.50
Nodes (4): XFunction.cs, catch(), Run(), XPoster

### Community 102 - "Entity (Community 102)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, var(), BuildSequenceHandler(), XPoster.Tests.Helpers

### Community 103 - "Entity (Community 103)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, for(), StringContent(), Polly_Instagram_AttemptTimeout_CancelsSlowRequest()

### Community 104 - "Entity (Community 104)"
Cohesion: 0.50
Nodes (4): XSender.cs, SendAsync(), XPoster.SenderPlugins, catch()

### Community 106 - "Entity (Community 106)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, BaseOrchestrator(), XPoster.Abstraction, PostAsync()

### Community 108 - "Entity (Community 108)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, XPoster.Models, RSSFeed

### Community 107 - "Entity (Community 107)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, XPoster.Contracts, GetLabel()

### Community 115 - "Entity (Community 115)"
Cohesion: 0.67
Nodes (3): IgSender.cs, if(), IgSender()

### Community 114 - "Entity (Community 114)"
Cohesion: 0.67
Nodes (3): PerplexityOptionsValidator.cs, XPoster.Models, Validate()

### Community 110 - "Entity (Community 110)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, Validate(), XPoster.Models

### Community 109 - "Entity (Community 109)"
Cohesion: 1.00
Nodes (3): PerplexityOptions.cs, PerplexityOptions.cs, XPoster.Models

### Community 113 - "Entity (Community 113)"
Cohesion: 0.67
Nodes (3): XFunction.cs, XFunction(), if()

### Community 112 - "Entity (Community 112)"
Cohesion: 1.00
Nodes (3): XPoster.Models, FeedOptions.cs, FeedOptions.cs

### Community 111 - "Entity (Community 111)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, AzureFoundryOptions.cs, XPoster.Models

### Community 116 - "Entity (Community 116)"
Cohesion: 0.67
Nodes (3): XSender.cs, if(), XSender()

### Community 125 - "Entity (Community 125)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, XPoster.Models, Validate()

### Community 127 - "Entity (Community 127)"
Cohesion: 0.67
Nodes (3): FeedService.cs, FeedService(), if()

### Community 126 - "Entity (Community 126)"
Cohesion: 1.00
Nodes (3): OpenAiOptions.cs, OpenAiOptions.cs, XPoster.Models

### Community 124 - "Entity (Community 124)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, DeepSeekOptions.cs, XPoster.Models

### Community 117 - "Entity (Community 117)"
Cohesion: 1.00
Nodes (3): XPoster.Contracts, Enums.cs, Enums.cs

### Community 118 - "Entity (Community 118)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, BuildFactory(), params()

### Community 119 - "Entity (Community 119)"
Cohesion: 0.67
Nodes (3): DefaultSlotProfileProvider.cs, XPoster.Orchestrators, GetProfiles()

### Community 120 - "Entity (Community 120)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, CryptoService(), if()

### Community 122 - "Entity (Community 122)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, FalAiOptions.cs, XPoster.Models

### Community 123 - "Entity (Community 123)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, Validate(), XPoster.Models

### Community 121 - "Entity (Community 121)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, AiProvider.cs, XPoster.Contracts

### Community 133 - "Entity (Community 133)"
Cohesion: 1.00
Nodes (2): DefaultSlotProfileProvider.cs, ScheduledOrchestrationProfile()

### Community 129 - "Entity (Community 129)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

### Community 128 - "Entity (Community 128)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

### Community 131 - "Entity (Community 131)"
Cohesion: 1.00
Nodes (2): PerplexityOptionsValidator.cs, if()

### Community 130 - "Entity (Community 130)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

### Community 132 - "Entity (Community 132)"
Cohesion: 1.00
Nodes (2): BaseOrchestrator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._


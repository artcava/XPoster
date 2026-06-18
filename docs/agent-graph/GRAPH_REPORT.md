# Graph Report - XPoster  (2026-06-18)

## Summary
- 927 nodes · 1563 edges · 121 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Extensions` - 2 edges
2. `Choice` - 2 edges
3. `Message` - 2 edges
4. `ImageData` - 2 edges
5. `XPoster.Models` - 2 edges
6. `OpenAIImageResponse` - 2 edges
7. `OpenAIResponse` - 2 edges
8. `ModelsTests` - 2 edges
9. `XPoster.Tests.SenderPlugins` - 2 edges
10. `XPoster` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.12
Nodes (34): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GenerateImageAsync_WhenDataArrayIsEmpty_ReturnsEmptyArray(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmpty(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmpty(), GenerateImageAsync_WhenB64JsonIsNull_ReturnsEmptyArray(), GetSummaryAsync_WhenApiReturnsTooManyRequests_ReturnsEmpty(), GetSummaryAsync_WhenApiReturnsError_ReturnsEmpty() (+26 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.07
Nodes (30): AiServiceHelperImageTests.cs, Parse_AzureFoundry_UrlFallback_DownloadThrows_ReturnsEmpty(), Parse_AzureFoundry_MissingDataProperty_ReturnsEmpty(), Parse_AzureFoundry_UrlFallback_DownloadThrows_LogsError(), static(), Parse_UnsupportedProvider_LogsError(), return(), Parse_UnsupportedProvider_ReturnsEmpty() (+22 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.15
Nodes (27): AiServiceHelperTests.cs, AiServiceHelperTests.cs, ParseImageResponseAsync_WhenStatusIsNonSuccess_ReturnsFalseAndNull(), XPoster.Tests.Services, var(), ParseChatCompletionResponseAsync_WhenChoicesIsNull_ReturnsFalseAndEmpty(), ParseChatCompletionResponseAsync_WhenContentIsWhitespaceOnly_ReturnsTrueAndEmpty(), ParseChatCompletionResponseAsync_WhenEmptyChoices_LogsWarningWithProviderName() (+19 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.16
Nodes (24): IgSenderTests.cs, IgSenderTests.cs, SendAsync_WhenInstagramApiReturnsNonSuccess_ReturnsFalse(), SendAsync_WhenImageUploadThrowsHttpRequestException_ReturnsFalseAndLogsError(), SendAsync_WhenInstagramApiReturns429_ReturnsFalse(), SendAsync_WhenImageUploadThrowsNotImplemented_ReturnsFalseAndLogsError(), MessageMaxLenght_Returns2200(), IgSender() (+16 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.19
Nodes (21): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, GenerateImageAsync_AlwaysThrows_NotSupportedException(), DeepSeekService(), DeepSeekServiceTests, GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString() (+13 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.19
Nodes (20): DryRunSenderTests.cs, DryRunSenderTests.cs, SendAsync_WithNullPost_LogsWarning(), ValidPost(), XPoster.Tests.SenderPlugins, SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WhenKeyVaultProbeSucceeds_ReturnsTrue(), SendAsync_WithImageBytes_LogsImagePresence() (+12 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.11
Nodes (19): AzureFoundryServiceTests.cs, AzureFoundryServiceTests, BuildService(), GenerateImageAsync_RequestBodyContainsModelField(), GenerateImageAsync_WhenApiReturnsNonSuccess_ReturnsEmptyByteArray(), GetSummaryAsync_PostsToFoundryChatCompletionsEndpoint(), GenerateImageAsync_WhenPromptIsWhitespace_ReturnsEmptyByteArrayWithoutCallingApi(), GetImagePromptAsync_WhenApiReturnsValidResponse_ReturnsPrompt() (+11 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.12
Nodes (17): AzureFoundryServiceTests.cs, GenerateImageAsync_WhenApiReturnsTooManyRequests_ReturnsEmptyByteArray(), AzureFoundryService(), ChatCompletionJson(), GenerateImageAsync_PostsToFoundryImagesGenerationsEndpoint(), GenerateImageAsync_WhenResponseBodyIsMalformedJson_ReturnsEmptyByteArray(), GenerateImageAsync_WhenB64JsonIsNull_ReturnsEmptyByteArray(), GenerateImageAsync_WhenHttpRequestExceptionOnPost_LogsError() (+9 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.24
Nodes (16): KeyVaultServiceTests.cs, KeyVaultServiceTests.cs, XPoster.Tests.Services, InSenderKv(), KeyVaultServiceTests, KeyVaultService_MissingKeyVaultUri_ThrowsInvalidOperationException(), StubHttpMessageHandler(), XSender_SendAsync_RequestsAllFourXCredentials() (+8 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.27
Nodes (14): InSenderMissingBranchTests.cs, InSenderMissingBranchTests.cs, SendAsync_WhitespaceContent_ReturnsFalse(), SendAsync_NullPost_ReturnsFalse(), SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse(), SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn(), SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn(), InSenderMissingBranchTests() (+6 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, Post_CanBeCreated_WithRequiredContent(), OpenAIResponse_CanBeCreated_WithChoices(), OpenAIImageResponse_CanBeCreated_WithData(), ImageData_CanBeCreated_WithUrl(), Message_CanBeCreated_WithContent(), ModelsTests (+6 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.27
Nodes (14): DeepSeekService.cs, DeepSeekService.cs, GetChatCompletionsEndpoint(), GetImagePromptAsync(), GetSummaryAsync(), NotSupportedException(), if(), XPoster.Services (+6 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.29
Nodes (13): InSenderTests.cs, InSenderTests.cs, BuildKeyVaultMockWithOrg(), BuildKeyVaultMock(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), XPoster.Tests.SenderPlugins, SendAsync_WhenLinkedInOrgIdPresent_UsesOrgIdAndSkipsOwnerCode(), Constructor_WithNullKeyVaultService_ThrowsArgumentNullException() (+5 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.29
Nodes (13): OpenAiService.cs, OpenAiService.cs, var(), while(), XPoster.Services, OpenAiService(), GetPromptForImage(), GenerateImageAsync() (+5 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_MissingModelId_Fails(), Validate_MissingApiKey_Fails(), FalAiOptionsValidatorTests, Validate_BothRequiredFieldsMissing_ReportsBothFailures(), XPoster.Tests.Models, Validate_ModelIdWithAllowedSpecialChars_Succeeds() (+5 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProvider(), XPoster.Tests.Services, LocalOverrideTimeProviderTests, GetCurrentTime_WhenForceHourIsValid_ReturnsForcedHour(), GetCurrentTime_WhenForceHourIsAbsent_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsOutOfRange_WrapsViaDateTimeOverflow() (+5 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, ValidOptions(), Validate_MissingMaxCharsPlaceholder_Fails(), Validate_MissingTextPlaceholder_Fails(), Validate_MissingSummaryPlaceholder_Fails(), Validate_MissingSummaryPlaceholder_ErrorNamesProperty(), Validate_MissingTextPlaceholder_ErrorNamesProperty() (+5 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.32
Nodes (12): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, FeedOrchestratorTests(), OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationThrowsException(), OrchestrateAsync_Should_ReturnNull_When_AiServiceIsNull(), OrchestrateAsync_Should_ReturnNull_When_SummaryGenerationFails(), OrchestrateAsync_Should_ReturnNull_When_SenderIsNull(), OrchestrateAsync_Should_ReturnNull_When_NoFeedsFound() (+4 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.32
Nodes (12): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), SendAsync_WhenImageUploadNotImplemented_ReturnsFalseAndLogsError(), SendAsync_WhenNoImage_ReturnsFalseWithoutCallingApi(), XPoster.Tests.SenderPlugins, BuildSender(), IgSender() (+4 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, BuildService(), FalImageJson(), GenerateImageAsync_MalformedJson_ReturnsEmptyArray(), GenerateImageAsync_EmptyUrlProperty_ReturnsEmptyArray(), FalAiImageServiceTests, GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithUnsafeChars_PercentEncodesInRequestUri() (+4 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.18
Nodes (11): HybridAiServiceTests.cs, DeepSeekService(), Constructor_NullDeepSeekService_ThrowsArgumentNullException(), BuildHybrid(), ChatCompletionJson(), FalAiImageService(), GetImagePromptAsync_DelegatesToDeepSeek_ReturnsPrompt(), XPoster.Tests.Services (+3 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, ValidPost(), XPoster.Tests.SenderPlugins, SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), InSenderResilienceTests, InSender() (+3 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.35
Nodes (11): XSenderMissingBranchTests.cs, XSenderMissingBranchTests.cs, SendAsync_WhitespaceContent_ReturnsFalse(), BuildSender(), SendAsync_ValidTextPost_CatchesTwitterException_ReturnsFalse(), SendAsync_NullPost_ReturnsFalse(), SendAsync_PostWithImage_CatchesTwitterException_ReturnsFalse(), MessageMaxLenght_Returns250() (+3 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.35
Nodes (11): XSenderTests.cs, XSenderTests.cs, XSenderTests(), Constructor_WithNullKeyVaultService_ThrowsArgumentNullException(), XSender_ImplementsISender(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), XPoster.Tests.SenderPlugins, SendAsync_CalledTwice_QueriesKvOnEachCall() (+3 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.18
Nodes (11): FalAiImageServiceTests.cs, GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray(), FalAiImageService(), GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray(), GenerateImageAsync_ReturnsNonSuccess_ReturnsEmptyArray(), MakeHandlerMock(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_LogsError() (+3 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, ProduceImage_Set_ThrowsNotImplementedException(), Name_IsNoOrchestrator(), OrchestrateAsync_ReturnsNull(), NoOrchestratorTests(), ProduceImage_IsAlwaysFalse(), SendIt_IsAlwaysFalse() (+2 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.20
Nodes (10): OrchestratorFactoryTests.cs, Resolve_Should_ResolveXSender_WhenProfileUsesXSummaryFeed(), Resolve_Should_ReturnCorrectOrchestratorType_ForGivenSenderProfile(), Resolve_Should_ReturnNoOrchestrator_WhenNoProfileMatchesCurrentHour(), XPoster.Tests.Implementation, Resolve_Should_NotRequestAiProvider_WhenProfileHasNoAiProvider(), DefaultSlotProfileProvider_Should_NotContainDryRunProfile(), OrchestratorFactory() (+2 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, BuildDelayedHandler(), BuildProviderWithHandler(), BuildSequenceHandler(), XPoster.Tests.Integration, HttpResponseMessage(), var() (+1 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.42
Nodes (9): RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests.cs, RSSFeed_DefaultPublishDateIsMinValue(), RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeed_RecordEquality_SameValues_AreEqual(), RSSFeedMissingBranchTests, XPoster.Tests.Models, RSSFeed_CanCreateWithRequiredProperties() (+1 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), DeepSeekOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), XPoster.Tests.Models, DeepSeekOptionsTests (+1 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, Validate_MissingPlaceholders_Fails(), Validate_MissingRequiredProperties_Fails(), XPoster.Tests.Models, Validate_ValidOptions_Succeeds(), ValidOptions(), DeepSeekOptionsValidatorTests (+1 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.42
Nodes (9): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, GenerateAsync_Should_CreateCorrectMessage_WithActualValue(), XPoster.Tests.Implementation, PowerLawOrchestratorTests(), GenerateAsync_Should_HandleNegativeOrZeroCryptoValue(), GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully(), GenerateAsync_Should_ReturnNull_When_DateIsBeforeGenesis() (+1 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, CryptoService(), GetCryptoValue_ReturnsZero_AndLogsError_OnException(), GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), XPoster.Tests.Services, MakeService(), CryptoServiceTests (+1 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XSenderSendAsyncTests(), SendAsync_WithEmptyContent_ReturnsFalse() (+1 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.42
Nodes (9): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, AzureFoundryOptions_DoesNotExpose_ApiVersionProperty(), AzureFoundryOptions_Defaults_AreCorrect(), AzureFoundryOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), AzureFoundryOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), AzureFoundryOptionsTests, XPoster.Tests.Models (+1 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.46
Nodes (8): OpenAIResponse.cs, OpenAIResponse.cs, Choice, Message, ImageData, XPoster.Models, OpenAIImageResponse, OpenAIResponse

### Community 40 - "Entity (Community 40)"
Cohesion: 0.46
Nodes (8): FeedServiceTests.cs, FeedServiceTests.cs, GetFeedsAsync_ReturnsEmpty_WhenInvalidFeed(), GetFeedsAsync_FiltersByKeyword_AndDate(), FeedServiceTests(), GetFeedsAsync_SetsCache_WhenFeedsFetched(), XPoster.Tests.Services, GetFeedsAsync_ReturnsFeedsFromCache_IfPresent()

### Community 37 - "Entity (Community 37)"
Cohesion: 0.25
Nodes (8): AzureFoundryService.cs, GetSummaryAsync(), GetChatCompletionsEndpoint(), GenerateImageAsync(), BuildSummaryPayload(), GetImagePromptAsync(), AzureFoundryService(), XPoster.Services

### Community 36 - "Entity (Community 36)"
Cohesion: 0.25
Nodes (8): InSender.cs, SendAsync(), XPoster.SenderPlugins, using(), Exception(), InvalidOperationException(), generatePayLoad(), ResolveAuthorUrnAsync()

### Community 35 - "Entity (Community 35)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests, Validate_MissingRequiredProperties_Fails(), ValidOptions(), Validate_ValidOptions_Succeeds(), XPoster.Tests.Models, Validate_MissingPlaceholders_Fails()

### Community 41 - "Entity (Community 41)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, XPoster.Tests.Integration, CreateLogger(), IsEnabled(), Dispose(), CaptureLoggerProvider(), CaptureLogger()

### Community 44 - "Entity (Community 44)"
Cohesion: 0.46
Nodes (8): PostMissingBranchTests.cs, PostMissingBranchTests.cs, Post_EmptyContent_IsAllowed(), Post_DefaultImageIsNull(), Firm_IsNotNullOrEmpty(), Post_CanSetAndGetAllProperties(), XPoster.Tests.Models, PostMissingBranchTests

### Community 43 - "Entity (Community 43)"
Cohesion: 0.46
Nodes (8): AiServiceFactory.cs, AiServiceFactory.cs, GetByProvider(), XPoster.Implementation, InvalidOperationException(), if(), AiServiceFactory(), ArgumentException()

### Community 42 - "Entity (Community 42)"
Cohesion: 0.46
Nodes (8): AiServiceFactoryTests.cs, AiServiceFactoryTests.cs, GetByProvider_Should_ReturnAzureFoundryService_When_ProviderIsMappedAndResolvable(), GetByProvider_Should_ThrowInvalidOperationException_When_MappedServiceCannotBeResolved(), AiServiceFactoryTests(), GetByProvider_Should_ReturnService_When_ProviderIsMappedAndResolvable(), XPoster.Tests.Implementation, GetByProvider_Should_ThrowArgumentException_When_ProviderIsNotMapped()

### Community 38 - "Entity (Community 38)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), InSenderSendAsyncTests(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse()

### Community 51 - "Entity (Community 51)"
Cohesion: 0.52
Nodes (7): XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests.cs, Run_Should_LogError_When_PostAsync_ReturnsFalse(), Run_Should_LogError_When_OrchestrateAsync_ReturnsNull(), XFunctionMissingBranchTests(), XPoster.Tests, Run_Should_Rethrow_When_Factory_Throws()

### Community 49 - "Entity (Community 49)"
Cohesion: 0.29
Nodes (7): BaseOrchestratorTests.cs, PostAsync_ReturnsTrue_When_AllConditionsMet(), XPoster.Tests.Abstraction, PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace()

### Community 50 - "Entity (Community 50)"
Cohesion: 0.52
Nodes (7): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, XPoster.Tests.Abstraction, AiProviderExtensionsTests, GetLabel_DescriptionDiffersFromEnumName(), GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(), GetLabel_UnknownProvider_ReturnsFallbackToString()

### Community 53 - "Entity (Community 53)"
Cohesion: 0.29
Nodes (7): AzureFoundryService.cs, catch(), BuildImagePromptPayload(), if(), var(), while(), GetImageGenerationEndpoint()

### Community 52 - "Entity (Community 52)"
Cohesion: 0.52
Nodes (7): DryRunSender.cs, DryRunSender.cs, DryRunSender(), SendAsync(), if(), XPoster.SenderPlugins, catch()

### Community 54 - "Entity (Community 54)"
Cohesion: 0.29
Nodes (7): OrchestratorFactoryTests.cs, CreateFactoryWithProfiles(), CreateFactory(), Resolve_Should_RequestConfiguredAiProvider_WhenProfileSpecifiesOne(), SetupMocksForOrchestratorFactory(), DryRunSlotProfileProvider_Should_AppendDryRunProfile_ToInnerProviderProfiles(), OrchestratorFactoryTests()

### Community 47 - "Entity (Community 47)"
Cohesion: 0.29
Nodes (7): AiServiceHelper.cs, LogAndReturnEmpty(), XPoster.Services, ParseImageResponseAsync(), ExtractFalAiBytesAsync(), ExtractOpenAiBytes(), ExtractAzureFoundryBytesAsync()

### Community 46 - "Entity (Community 46)"
Cohesion: 0.52
Nodes (7): HybridAiService.cs, HybridAiService.cs, GetImagePromptAsync(), GetSummaryAsync(), HybridAiService(), XPoster.Services, GenerateImageAsync()

### Community 48 - "Entity (Community 48)"
Cohesion: 0.52
Nodes (7): IAiService.cs, IAiService.cs, GenerateImageAsync(), GetImagePromptAsync(), IAiService, GetSummaryAsync(), XPoster.Abstraction

### Community 45 - "Entity (Community 45)"
Cohesion: 0.52
Nodes (7): FalAiImageService.cs, FalAiImageService.cs, if(), FalAiImageService(), catch(), XPoster.Services, GenerateImageAsync()

### Community 57 - "Entity (Community 57)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, GetCurrentTime_ReturnsCurrentDateTime(), XPoster.Tests.Services, GetCurrentTime_ReturnsUtcTime(), TimeProviderTests

### Community 55 - "Entity (Community 55)"
Cohesion: 0.33
Nodes (6): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_Sender_IsNull(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), TestOrchestrator(), BaseOrchestratorTests(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull()

### Community 56 - "Entity (Community 56)"
Cohesion: 0.60
Nodes (6): HttpClientExtensions.cs, HttpClientExtensions.cs, XPoster.Extensions, IsTransientHttpFailure(), AddResilientHttpClient(), AddHttpClients()

### Community 61 - "Entity (Community 61)"
Cohesion: 0.60
Nodes (6): IKeyVaultService.cs, IKeyVaultService.cs, XPoster.Abstraction, SetSecretAsync(), GetSecretAsync(), IKeyVaultService

### Community 59 - "Entity (Community 59)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, var(), MakeNoOpClient(), MakeDownloadClient(), HttpClient(), JsonResponse()

### Community 60 - "Entity (Community 60)"
Cohesion: 0.60
Nodes (6): XFunctionTests.cs, XFunctionTests.cs, XPoster.Tests, Run_Should_DoNothing_When_GeneratorIsDisabled(), Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), XFunctionTests()

### Community 66 - "Entity (Community 66)"
Cohesion: 0.60
Nodes (6): KeyVaultService.cs, KeyVaultService.cs, SetSecretAsync(), GetSecretAsync(), KeyVaultService(), XPoster.Services

### Community 64 - "Entity (Community 64)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, XPoster.Models, foreach(), Validate(), if()

### Community 65 - "Entity (Community 65)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), for(), XPoster.Tests.Integration

### Community 67 - "Entity (Community 67)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, Polly_AiClient_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration, StringContent(), Polly_AiClient_AttemptTimeout_CancelsSlowRequest()

### Community 58 - "Entity (Community 58)"
Cohesion: 0.33
Nodes (6): OrchestratorFactory.cs, ResolveAiProvider(), Resolve(), foreach(), return(), XPoster.Implementation

### Community 62 - "Entity (Community 62)"
Cohesion: 0.60
Nodes (6): DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider(), XPoster.Implementation, ScheduledOrchestrationProfile(), GetProfiles()

### Community 63 - "Entity (Community 63)"
Cohesion: 0.33
Nodes (6): HybridAiServiceTests.cs, Constructor_NullFalAiService_ThrowsArgumentNullException(), BuildDeepSeekService(), GenerateImageAsync_DelegatesToFalAi_NotToDeepSeek(), BuildFalService(), HybridAiService()

### Community 73 - "Entity (Community 73)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, GetCurrentTime(), LocalOverrideTimeProvider(), XPoster.Services

### Community 76 - "Entity (Community 76)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, XPoster.Tests.Integration, Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), catch(), Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures()

### Community 72 - "Entity (Community 72)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, XPoster.Implementation, PowerLawOrchestrator(), if()

### Community 70 - "Entity (Community 70)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, ISlotProfileProvider, GetProfiles(), XPoster.Abstraction

### Community 74 - "Entity (Community 74)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, TimeProvider, GetCurrentTime(), XPoster.Services

### Community 71 - "Entity (Community 71)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, XPoster.Abstraction, ITimeProvider, GetCurrentTime()

### Community 75 - "Entity (Community 75)"
Cohesion: 0.40
Nodes (5): FeedService.cs, XPoster.Services, GetFeedsAsync(), Exception(), catch()

### Community 69 - "Entity (Community 69)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, XPoster.Abstraction, IOrchestratorFactory, Resolve()

### Community 68 - "Entity (Community 68)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, IFeedService, XPoster.Abstraction, GetFeedsAsync()

### Community 81 - "Entity (Community 81)"
Cohesion: 0.70
Nodes (5): IAiServiceFactory.cs, IAiServiceFactory.cs, GetByProvider(), XPoster.Abstraction, IAiServiceFactory

### Community 82 - "Entity (Community 82)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, ICryptoService, GetCryptoValue(), XPoster.Abstraction

### Community 80 - "Entity (Community 80)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, XPoster.Abstraction, SendAsync(), ISender

### Community 77 - "Entity (Community 77)"
Cohesion: 0.40
Nodes (5): IgSender.cs, catch(), SendAsync(), UploadImageToPublicUrl(), XPoster.SenderPlugins

### Community 79 - "Entity (Community 79)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, XPoster.Abstraction, IOrchestrator, PostAsync()

### Community 78 - "Entity (Community 78)"
Cohesion: 0.40
Nodes (5): FeedOrchestrator.cs, XPoster.Implementation, catch(), GenerateMessage(), ReplaceEveryFirstOccurenceOf()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, BuildSequenceHandler(), XPoster.Tests.Helpers, var()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, BaseOrchestrator(), PostAsync(), XPoster.Abstraction

### Community 97 - "Entity (Community 97)"
Cohesion: 0.50
Nodes (4): XFunction.cs, catch(), XPoster, Run()

### Community 95 - "Entity (Community 95)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, catch(), if(), return()

### Community 94 - "Entity (Community 94)"
Cohesion: 0.50
Nodes (4): XSender.cs, XPoster.SenderPlugins, SendAsync(), catch()

### Community 96 - "Entity (Community 96)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, XPoster.Services, GetCryptoValue(), catch()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.50
Nodes (4): FeedOrchestrator.cs, FeedOrchestrator(), if(), foreach()

### Community 91 - "Entity (Community 91)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, GetLabel(), XPoster.Abstraction

### Community 85 - "Entity (Community 85)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, XPoster.Models, RSSFeed

### Community 89 - "Entity (Community 89)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, NoOrchestrator(), XPoster.Implementation

### Community 90 - "Entity (Community 90)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, XPoster.Abstraction, ScheduledOrchestrationProfile()

### Community 86 - "Entity (Community 86)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, Post, XPoster.Models

### Community 87 - "Entity (Community 87)"
Cohesion: 0.50
Nodes (4): OrchestratorFactory.cs, OrchestratorFactory(), if(), CreateOrchestratorInstance()

### Community 88 - "Entity (Community 88)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), catch(), StringContent()

### Community 99 - "Entity (Community 99)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, for(), Polly_Instagram_AttemptTimeout_CancelsSlowRequest(), StringContent()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.83
Nodes (4): Program.cs, Program.cs, DryRunSlotProfileProvider(), if()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.50
Nodes (4): InSender.cs, catch(), InSender(), if()

### Community 108 - "Entity (Community 108)"
Cohesion: 0.67
Nodes (3): XFunction.cs, if(), XFunction()

### Community 109 - "Entity (Community 109)"
Cohesion: 0.67
Nodes (3): FeedService.cs, FeedService(), if()

### Community 111 - "Entity (Community 111)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, FalAiOptions.cs, XPoster.Models

### Community 110 - "Entity (Community 110)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, XPoster.Models, Validate()

### Community 113 - "Entity (Community 113)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, Validate(), XPoster.Models

### Community 112 - "Entity (Community 112)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, XPoster.Models, DeepSeekOptions.cs

### Community 114 - "Entity (Community 114)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, AzureFoundryOptions.cs, XPoster.Models

### Community 115 - "Entity (Community 115)"
Cohesion: 1.00
Nodes (3): XPoster.Abstraction, AiProvider.cs, AiProvider.cs

### Community 107 - "Entity (Community 107)"
Cohesion: 1.00
Nodes (3): Enums.cs, XPoster.Abstraction, Enums.cs

### Community 100 - "Entity (Community 100)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, BuildFactory(), params()

### Community 102 - "Entity (Community 102)"
Cohesion: 0.67
Nodes (3): XSender.cs, if(), XSender()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.67
Nodes (3): DefaultSlotProfileProvider.cs, GetProfiles(), XPoster.Implementation

### Community 103 - "Entity (Community 103)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, XPoster.Models, Validate()

### Community 104 - "Entity (Community 104)"
Cohesion: 1.00
Nodes (3): OpenAiOptions.cs, OpenAiOptions.cs, XPoster.Models

### Community 105 - "Entity (Community 105)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, if(), CryptoService()

### Community 106 - "Entity (Community 106)"
Cohesion: 0.67
Nodes (3): IgSender.cs, IgSender(), if()

### Community 120 - "Entity (Community 120)"
Cohesion: 1.00
Nodes (2): BaseOrchestrator.cs, if()

### Community 119 - "Entity (Community 119)"
Cohesion: 1.00
Nodes (2): DefaultSlotProfileProvider.cs, ScheduledOrchestrationProfile()

### Community 118 - "Entity (Community 118)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

### Community 117 - "Entity (Community 117)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

### Community 116 - "Entity (Community 116)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._


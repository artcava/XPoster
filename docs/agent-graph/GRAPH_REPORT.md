# Graph Report - XPoster  (2026-06-23)

## Summary
- 1074 nodes · 1812 edges · 137 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Models` - 2 edges
2. `XPoster.Orchestrators` - 2 edges
3. `XPoster.Abstraction` - 2 edges
4. `XPoster.SenderPlugins` - 2 edges
5. `XPoster.Tests.Helpers` - 2 edges
6. `XPoster.Tests.SenderPlugins` - 2 edges
7. `XPoster.Contracts` - 2 edges
8. `IOrchestratorFactory` - 2 edges
9. `ITextToTextProvider` - 2 edges
10. `XPoster.Contracts` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, ParseChatCompletionResponseAsync_WhenResponseBodyIsEmpty_ReturnsFalseAndEmpty(), ParseChatCompletionResponseAsync_WhenNonSuccess_LogsProviderNameAndStatusCode(), MakeResponse(), ParseChatCompletionResponseAsync_WhenStatusIs429_ReturnsFalseAndEmpty(), ParseChatCompletionResponseAsync_WhenStatusIsNonSuccess_ReturnsFalseAndEmpty(), MakeHttpClientThatThrows() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.12
Nodes (34): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GenerateImageAsync_WhenApiReturnsTooManyRequests_ReturnsEmptyArray(), GenerateImageAsync_WhenApiReturnsError_ReturnsEmptyArray(), GenerateImageAsync_WhenApiReturnsTooManyRequests_LogsWarning(), OpenAiServiceTests, XPoster.Tests.Services, GetImagePromptAsync_WhenApiReturnsTooManyRequests_ReturnsEmpty() (+26 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, Parse_Returns429_ReturnsEmpty(), Parse_OpenAi_ValidB64_ReturnsBytes(), Parse_OpenAi_MissingDataProperty_ReturnsEmpty(), Parse_Returns429_LogsWarning(), Parse_OpenAi_EmptyDataArray_ReturnsEmpty(), Parse_OpenAi_EmptyB64Value_ReturnsEmpty(), Parse_MalformedJson_ReturnsEmpty() (+24 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, AddOpenAiOptions_RegistersValidator(), AddFalAiOptions_BindsOptionsFromCorrectSection(), AddFalAiOptions_RegistersValidator(), AddOpenAiOptions_BindsOptionsFromCorrectSection(), XPoster.Tests.Models, SectionName_IsOpenAI() (+21 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.17
Nodes (23): PerplexityServiceTests.cs, PerplexityServiceTests.cs, PerplexityServiceTests, XPoster.Tests.Services, ChatCompletionJson(), BuildService(), MakeHandlerMock(), PerplexityService() (+15 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.19
Nodes (21): IgSenderTests.cs, IgSenderTests.cs, SendAsync_WithWhitespaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WhenImageUploadThrowsNotImplemented_ReturnsFalseAndLogsError(), MessageMaxLenght_Returns2200(), SendAsync_WhenImageUploadThrowsHttpRequestException_ReturnsFalseAndLogsError(), new() (+13 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.19
Nodes (20): DryRunSenderTests.cs, DryRunSenderTests.cs, BuildSender(), Constructor_WithNullLogger_ThrowsArgumentNullException(), DryRunSender_ImplementsISender(), Constructor_WithNullConfiguration_ThrowsArgumentNullException(), BuildConfig(), SendAsync_WhenProbeKeyMissing_LogsError() (+12 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.20
Nodes (19): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString(), GetImagePromptAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), DeepSeekService() (+11 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.11
Nodes (19): AzureFoundryServiceTests.cs, AzureFoundryServiceTests, GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString(), GetSummaryAsync_PostsToFoundryChatCompletionsEndpoint(), GenerateImageAsync_WhenApiReturnsNonSuccess_ReturnsEmptyByteArray(), GenerateImageAsync_WhenApiReturnsTooManyRequests_LogsWarning() (+11 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, SendAsync(), XPoster.Tests.Services, GetFeedsAsync_ReturnsFeedsFromCache_IfPresent(), GetFeedsAsync_FiltersOutItemsOutsideDateRange(), GetFeedsAsync_FiltersOutItemsWithNoKeywordMatch(), GetFeedsAsync_ReturnsEmpty_WhenHttpFails() (+10 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.12
Nodes (17): AzureFoundryServiceTests.cs, AzureFoundryService(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), GenerateImageAsync_WhenResponseBodyIsMalformedJson_ReturnsEmptyByteArray(), GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetSummaryAsync_RequestBodyContainsModelField(), GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), HttpResponseMessage() (+9 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.23
Nodes (17): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, OrchestrateAsync_Should_UseSummaryAsPrompt_When_GetImagePromptAsyncReturnsWhitespace(), OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationReturnsEmpty(), OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationThrowsException(), OrchestrateAsync_Should_UseSummaryAsPrompt_When_GetImagePromptAsyncReturnsEmpty(), OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageProviderIsNull(), OrchestrateAsync_Should_ReturnNull_When_TextProviderIsNull() (+9 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.13
Nodes (15): OrchestratorFactoryTests.cs, Resolve_Should_ResolveXSender_ForPowerLawOrchestrator(), Resolve_Should_ResolveInSender_WhenProfileUsesLinkedIn(), Resolve_Should_NotRequestTextProvider_WhenProfileHasNoTextProvider(), Resolve_Should_ResolveDryRunSender_WhenProfileUsesDryRun(), Resolve_Should_ResolveIgSender_WhenProfileUsesInstagram(), Resolve_Should_RequestImageProviderKey_WhenProfileSpecifiesImageProvider(), Resolve_Should_ResolveXSender_WhenProfileUsesX() (+7 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.27
Nodes (14): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, Validate_WhenImagePromptSystemTemplateHasNoPlaceholder_ReturnsSuccess(), Validate_WhenEndpointIsEmpty_ReturnsFailed(), Validate_WhenDeploymentNameIsEmpty_ReturnsFailed(), Validate_WhenApiKeyIsEmpty_ReturnsFailed(), PerplexityOptionsValidatorTests, Validate_WhenSummarySystemPromptMissingMaxChars_ReturnsFailed() (+6 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, OpenAIResponse_CanBeCreated_WithChoices(), ImageData_CanBeCreated_WithUrl(), Message_CanBeCreated_WithContent(), ModelsTests, OpenAIImageResponse_CanBeCreated_WithData(), XPoster.Tests.Models (+6 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_BothRequiredFieldsMissing_ReportsBothFailures(), FalAiOptionsValidatorTests, ValidOptions(), Validate_MissingModelId_Fails(), Validate_WhitespaceModelId_Fails(), Validate_ValidOptions_Succeeds() (+5 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.29
Nodes (13): OpenAiService.cs, OpenAiService.cs, OpenAiService(), var(), XPoster.Services, while(), GenerateImageAsync(), GetPromptForImage() (+5 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.29
Nodes (13): InSenderMissingBranchTests.cs, InSenderMissingBranchTests.cs, SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn(), SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn(), SendAsync_WhitespaceContent_ReturnsFalse(), SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse(), XPoster.Tests.SenderPlugins, MessageMaxLenght_Returns800() (+5 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, Validate_MissingMaxCharsPlaceholder_ErrorNamesProperty(), Validate_DefaultOptions_Succeeds(), Validate_AllPlaceholdersMissing_ReportsThreeFailures(), OpenAiOptionsValidatorTests, Validate_MissingSummaryPlaceholder_Fails(), ValidOptions() (+5 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, GetCurrentTime_WhenForceHourIsNonNumeric_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsEmpty_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsAbsent_FallsBackToUtcHour(), Constructor_AlwaysEmitsDevOverrideWarning(), BuildProvider(), GetCurrentTime_WhenForceHourIsValid_ReturnsForcedHour() (+5 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, GenerateImageAsync_WhitespacePrompt_ReturnsEmptyArray(), XPoster.Tests.Services, FalAiImageServiceTests, BuildService(), GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithUnsafeChars_PercentEncodesInRequestUri(), FalImageJson() (+4 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.32
Nodes (12): DeepSeekService.cs, DeepSeekService.cs, BuildImagePromptPayload(), DeepSeekService(), while(), GetChatCompletionsEndpoint(), GetImagePromptAsync(), if() (+4 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.32
Nodes (12): PerplexityService.cs, PerplexityService.cs, GetImagePromptAsync(), GetChatCompletionsEndpoint(), BuildSummaryPayload(), BuildImagePromptPayload(), if(), XPoster.Services (+4 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.32
Nodes (12): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WhenImageUploadNotImplemented_ReturnsFalseAndLogsError(), BuildSender(), PostWithoutImage(), PostWithImage(), IgSenderResilienceTests (+4 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.35
Nodes (11): XSenderMissingBranchTests.cs, XSenderMissingBranchTests.cs, MessageMaxLenght_Returns250(), SendAsync_EmptyContent_ReturnsFalse(), SendAsync_WhitespaceContent_ReturnsFalse(), SendAsync_NullPost_ReturnsFalse(), SendAsync_PostWithImage_CatchesTwitterException_ReturnsFalse(), SendAsync_ValidTextPost_CatchesTwitterException_ReturnsFalse() (+3 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.35
Nodes (11): ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProviderTests.cs, GetFeedUrls_Should_ReturnEmptyList_When_UrlsPropertyIsNull(), GetFeedUrls_Should_ReturnConfiguredUrls_When_OptionsContainsUrls(), XPoster.Tests.Orchestrators, GetFeedUrls_Should_ReturnEmptyList_When_UrlsListIsEmpty(), GetFeedUrls_Should_ReturnReadOnlyList(), GetFeedUrls_Should_ReturnUrlsInOrder_When_MultipleUrlsConfigured() (+3 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.35
Nodes (11): DefaultSlotProfileProviderTests.cs, DefaultSlotProfileProviderTests.cs, FeedOrchestratorSlot_Should_HaveTextProviderConfigured(), DryRunSlotProfileProvider_DryRunSlot_Should_HaveBothProvidersConfigured(), FeedOrchestratorSlot_Should_HaveImageProviderConfigured(), DefaultSlotProfileProviderTests, GetProfiles_Should_NotContainDryRunSlot(), GetProfiles_Should_ReturnFourActiveSlots() (+3 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.18
Nodes (11): OrchestratorFactoryTests.cs, Resolve_Should_ResolveLinkedInSender_ForPowerLawOrchestrator(), Resolve_Should_RequestTextProviderKey_WhenProfileSpecifiesTextProvider(), SetupMocksForOrchestratorFactory(), Resolve_Should_NotRequestImageProvider_WhenProfileHasNoImageProvider(), OrchestratorFactoryTests(), PowerLawOrchestrator_SupportedPlatforms_ContainsXAndLinkedIn(), CreateFactory() (+3 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.35
Nodes (11): FeedOrchestratorFeedUrlProviderTests.cs, FeedOrchestratorFeedUrlProviderTests.cs, XPoster.Tests.Orchestrators, FeedOrchestratorFeedUrlProviderTests(), OrchestrateAsync_Should_CallGetFeedUrls_Once(), new(), OrchestrateAsync_Should_ReturnNull_And_DisableSendIt_When_ProviderReturnsEmptyList(), OrchestrateAsync_Should_CallGetFeedsAsync_With_Correct_Urls() (+3 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, InSenderResilienceTests, InSender(), BuildSender(), SendAsync_WhenLinkedInReturns200_ReturnsTrue(), SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue(), ValidPost() (+3 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.18
Nodes (11): FalAiImageServiceTests.cs, GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray(), FalAiImageService(), GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithMultipleSegments_PreservesSlashesInUri(), MakeHandlerMock(), GenerateImageAsync_ReturnsNonSuccess_ReturnsEmptyArray(), GenerateImageAsync_Returns429_ReturnsEmptyArray() (+3 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.38
Nodes (10): XSenderTests.cs, XSenderTests.cs, Constructor_WithNullLogger_ThrowsArgumentNullException(), XSenderTests(), SendAsync_ValidPost_TriesTwitterAndReturnsFalse(), XPoster.Tests.SenderPlugins, XSender_ImplementsISender(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning() (+2 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.38
Nodes (10): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, Constructor_Should_PreserveHour_ForBoundaryValues(), Constructor_Should_AllowDifferentProvidersPerCapability_SplitProviderSlot(), Constructor_Should_SetTextProvider_And_NullImageProvider_WhenOnlyTextProviderSupplied(), ScheduledOrchestrationProfileTests, Constructor_Should_SetAllFields_WhenBothProvidersSupplied(), Constructor_Should_SetBothProvidersToNull_WhenNeitherSupplied() (+2 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, Name_IsNoOrchestrator(), SendIt_Set_ThrowsNotImplementedException(), SendIt_IsAlwaysFalse(), OrchestrateAsync_ReturnsNull(), ProduceImage_Set_ThrowsNotImplementedException(), XPoster.Tests.Orchestrators (+2 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.22
Nodes (9): InSender.cs, XPoster.SenderPlugins, SendAsync(), using(), ResolveAuthorUrn(), generatePayLoad(), Exception(), InvalidOperationException() (+1 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, params(), XPoster.Tests.Integration, var(), BuildSequenceHandler(), HttpResponseMessage(), BuildProviderWithHandler() (+1 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.42
Nodes (9): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, AzureFoundryOptions_Defaults_AreCorrect(), AzureFoundryOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), AzureFoundryOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), XPoster.Tests.Models, AzureFoundryOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), AzureFoundryOptions_DoesNotExpose_ApiVersionProperty() (+1 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, XPoster.Tests.Services, MakeService(), CryptoServiceTests, GetCryptoValue_ReturnsZero_AndLogsError_OnException(), GetCryptoValue_ReturnsParsedValue_WhenNumericString(), CryptoService() (+1 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.42
Nodes (9): RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests.cs, RSSFeed_CanSetPublishDate(), RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeedMissingBranchTests, RSSFeed_RecordEquality_SameValues_AreEqual(), XPoster.Tests.Models (+1 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins (+1 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), DeepSeekOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), DeepSeekOptionsTests, DeepSeekOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder() (+1 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, ValidOptions(), XPoster.Tests.Models, Validate_MissingPlaceholders_Fails(), Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), DeepSeekOptionsValidatorTests, Validate_ValidOptions_Succeeds() (+1 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.42
Nodes (9): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests(), GenerateAsync_Should_CreateCorrectMessage_WithActualValue(), GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully(), GenerateAsync_Should_CalculateCorrectPowerLawValue_ForFixedDate(), GenerateAsync_Should_HandleNegativeOrZeroCryptoValue(), GenerateAsync_Should_ReturnNull_When_DateIsBeforeGenesis() (+1 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, CaptureLoggerProvider(), IsEnabled(), CreateLogger(), Dispose(), XPoster.Tests.Integration, CaptureLogger()

### Community 47 - "Entity (Community 47)"
Cohesion: 0.46
Nodes (8): OpenAIResponse.cs, OpenAIResponse.cs, OpenAIImageResponse, Choice, Message, ImageData, OpenAIResponse, XPoster.Models

### Community 46 - "Entity (Community 46)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, Validate_MissingPlaceholders_Fails(), Validate_MissingRequiredProperties_Fails(), Validate_ValidOptions_Succeeds(), ValidOptions(), XPoster.Tests.Models, AzureFoundryOptionsValidatorTests

### Community 49 - "Entity (Community 49)"
Cohesion: 0.46
Nodes (8): PostMissingBranchTests.cs, PostMissingBranchTests.cs, Post_DefaultImageIsNull(), XPoster.Tests.Models, Post_EmptyContent_IsAllowed(), PostMissingBranchTests, Post_CanSetAndGetAllProperties(), Firm_IsNotNullOrEmpty()

### Community 44 - "Entity (Community 44)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(), AiProviderExtensionsTests, GetLabel_DescriptionDiffersFromEnumName(), GetLabel_DescriptionMatchesEnumName(), XPoster.Tests.Contracts, GetLabel_UnknownProvider_ReturnsFallbackToString()

### Community 45 - "Entity (Community 45)"
Cohesion: 0.25
Nodes (8): AzureFoundryService.cs, XPoster.Services, GetChatCompletionsEndpoint(), AzureFoundryService(), BuildSummaryPayload(), GenerateImageAsync(), GetImagePromptAsync(), GetSummaryAsync()

### Community 48 - "Entity (Community 48)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, InSenderSendAsyncTests(), SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse()

### Community 52 - "Entity (Community 52)"
Cohesion: 0.29
Nodes (7): InSenderTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WithEmptyContent_ReturnsFalseAndLogsWarning(), Constructor_WithNullLogger_ThrowsArgumentNullException(), Constructor_InitializesCorrectly(), BuildCreds(), InSender_ImplementsISender()

### Community 51 - "Entity (Community 51)"
Cohesion: 0.29
Nodes (7): AzureFoundryService.cs, catch(), GetImageGenerationEndpoint(), if(), while(), var(), BuildImagePromptPayload()

### Community 56 - "Entity (Community 56)"
Cohesion: 0.52
Nodes (7): DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider.cs, XPoster.Orchestrators, typeof(), DryRunSlotProfileProvider(), ScheduledOrchestrationProfile(), GetProfiles()

### Community 55 - "Entity (Community 55)"
Cohesion: 0.29
Nodes (7): AiServiceHelper.cs, ExtractAzureFoundryBytesAsync(), ExtractFalAiBytesAsync(), ExtractOpenAiBytes(), XPoster.Services, ParseImageResponseAsync(), LogAndReturnEmpty()

### Community 54 - "Entity (Community 54)"
Cohesion: 0.52
Nodes (7): XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests(), Run_Should_Rethrow_When_Factory_Throws(), Run_Should_LogError_When_OrchestrateAsync_ReturnsNull(), Run_Should_LogError_When_PostAsync_ReturnsFalse(), XPoster.Tests

### Community 53 - "Entity (Community 53)"
Cohesion: 0.52
Nodes (7): FalAiImageService.cs, FalAiImageService.cs, catch(), FalAiImageService(), GenerateImageAsync(), if(), XPoster.Services

### Community 50 - "Entity (Community 50)"
Cohesion: 0.29
Nodes (7): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_Content_IsEmpty(), PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsTrue_When_AllConditionsMet(), XPoster.Tests.Contracts, PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_ReturnsFalse_When_SendIt_IsFalse()

### Community 67 - "Entity (Community 67)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), for(), Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration, Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures()

### Community 65 - "Entity (Community 65)"
Cohesion: 0.60
Nodes (6): ITextToTextProvider.cs, ITextToTextProvider.cs, GetImagePromptAsync(), ITextToTextProvider, XPoster.Contracts, GetSummaryAsync()

### Community 66 - "Entity (Community 66)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, StringContent(), XPoster.Tests.Integration, Polly_AiClient_RetriesOn429_AndEventuallySucceeds(), Polly_AiClient_AttemptTimeout_CancelsSlowRequest()

### Community 64 - "Entity (Community 64)"
Cohesion: 0.33
Nodes (6): InSenderTests.cs, SendAsync_ValidPost_TriesLinkedInAndReturnsFalse(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), InSenderTests(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), InSender()

### Community 59 - "Entity (Community 59)"
Cohesion: 0.60
Nodes (6): HttpClientExtensions.cs, HttpClientExtensions.cs, AddHttpClients(), IsTransientHttpFailure(), AddResilientHttpClient(), XPoster.Extensions

### Community 57 - "Entity (Community 57)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, XPoster.SenderPlugins, SendAsync(), if(), DryRunSender()

### Community 58 - "Entity (Community 58)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, if(), Validate(), foreach(), XPoster.Models

### Community 60 - "Entity (Community 60)"
Cohesion: 0.33
Nodes (6): BaseOrchestratorTests.cs, BaseOrchestratorTests(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), PostAsync_ReturnsFalse_When_Sender_IsNull(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), TestOrchestrator()

### Community 61 - "Entity (Community 61)"
Cohesion: 0.60
Nodes (6): Program.cs, Program.cs, DryRunSlotProfileProvider(), DefaultAzureCredential(), if(), Uri()

### Community 68 - "Entity (Community 68)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, GetCurrentTime_ReturnsCurrentDateTime(), GetCurrentTime_ReturnsUtcTime(), XPoster.Tests.Services, TimeProviderTests

### Community 62 - "Entity (Community 62)"
Cohesion: 0.60
Nodes (6): XFunctionTests.cs, XFunctionTests.cs, XPoster.Tests, XFunctionTests(), Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), Run_Should_DoNothing_When_GeneratorIsDisabled()

### Community 63 - "Entity (Community 63)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, MakeNoOpClient(), MakeDownloadClient(), HttpClient(), var(), JsonResponse()

### Community 86 - "Entity (Community 86)"
Cohesion: 0.40
Nodes (5): OrchestratorFactory.cs, return(), XPoster.Orchestrators, foreach(), Resolve()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, XPoster.Contracts, IOrchestrator, PostAsync()

### Community 78 - "Entity (Community 78)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, ISlotProfileProvider, XPoster.Contracts, GetProfiles()

### Community 75 - "Entity (Community 75)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, IOrchestratorFactory, XPoster.Contracts, Resolve()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, XPoster.Orchestrators, PowerLawOrchestrator(), if()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.40
Nodes (5): FeedService.cs, XPoster.Services, GetFeedsAsync(), catch(), Exception()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.40
Nodes (5): FeedOrchestrator.cs, ReplaceEveryFirstOccurenceOf(), XPoster.Orchestrators, GenerateMessage(), catch()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.70
Nodes (5): ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider.cs, GetFeedUrls(), XPoster.Orchestrators, ConfigurationFeedUrlProvider()

### Community 85 - "Entity (Community 85)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, XPoster.Contracts, ICryptoService, GetCryptoValue()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, GetCurrentTime(), TimeProvider, XPoster.Services

### Community 81 - "Entity (Community 81)"
Cohesion: 0.40
Nodes (5): IgSender.cs, XPoster.SenderPlugins, UploadImageToPublicUrl(), SendAsync(), catch()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider(), XPoster.Services, GetCurrentTime()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, ITimeProvider, XPoster.Contracts, GetCurrentTime()

### Community 71 - "Entity (Community 71)"
Cohesion: 0.70
Nodes (5): IFeedUrlProvider.cs, IFeedUrlProvider.cs, IFeedUrlProvider, GetFeedUrls(), XPoster.Contracts

### Community 73 - "Entity (Community 73)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, SendAsync(), XPoster.Contracts, ISender

### Community 72 - "Entity (Community 72)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, GenerateImageAsync(), XPoster.Contracts, ITextToImageProvider

### Community 70 - "Entity (Community 70)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, IFeedService, GetFeedsAsync(), XPoster.Contracts

### Community 69 - "Entity (Community 69)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), catch(), Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration

### Community 91 - "Entity (Community 91)"
Cohesion: 0.83
Nodes (4): PerplexityOptionsExtensions.cs, PerplexityOptionsExtensions.cs, XPoster.Models, AddPerplexityOptions()

### Community 87 - "Entity (Community 87)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, BaseOrchestrator(), XPoster.Abstraction, PostAsync()

### Community 88 - "Entity (Community 88)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, catch(), StringContent(), Polly_LinkedIn_OnRetry_LogEntryIsEmitted()

### Community 89 - "Entity (Community 89)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, var(), BuildSequenceHandler(), XPoster.Tests.Helpers

### Community 90 - "Entity (Community 90)"
Cohesion: 0.50
Nodes (4): XSender.cs, catch(), XPoster.SenderPlugins, SendAsync()

### Community 107 - "Entity (Community 107)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile(), XPoster.Abstraction

### Community 99 - "Entity (Community 99)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, catch(), XPoster.Services, GetCryptoValue()

### Community 100 - "Entity (Community 100)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, GetLabel(), XPoster.Contracts

### Community 101 - "Entity (Community 101)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, catch(), if(), return()

### Community 102 - "Entity (Community 102)"
Cohesion: 0.50
Nodes (4): FeedOrchestrator.cs, foreach(), if(), FeedOrchestrator()

### Community 103 - "Entity (Community 103)"
Cohesion: 0.83
Nodes (4): AzureFoundryOptionsExtensions.cs, AzureFoundryOptionsExtensions.cs, XPoster.Models, AddAzureFoundryOptions()

### Community 104 - "Entity (Community 104)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, AddXPosterAiProviders(), XPoster.Extensions

### Community 105 - "Entity (Community 105)"
Cohesion: 0.83
Nodes (4): FalAiOptionsExtensions.cs, FalAiOptionsExtensions.cs, XPoster.Models, AddFalAiOptions()

### Community 106 - "Entity (Community 106)"
Cohesion: 0.50
Nodes (4): XFunction.cs, Run(), XPoster, catch()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, XPoster.Models, RSSFeed

### Community 94 - "Entity (Community 94)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, NoOrchestrator(), XPoster.Orchestrators

### Community 96 - "Entity (Community 96)"
Cohesion: 0.83
Nodes (4): DeepSeekOptionsExtensions.cs, DeepSeekOptionsExtensions.cs, AddDeepSeekOptions(), XPoster.Models

### Community 95 - "Entity (Community 95)"
Cohesion: 0.83
Nodes (4): OpenAiOptionsExtensions.cs, OpenAiOptionsExtensions.cs, AddOpenAiOptions(), XPoster.Models

### Community 93 - "Entity (Community 93)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, StringContent(), Polly_Instagram_AttemptTimeout_CancelsSlowRequest(), for()

### Community 97 - "Entity (Community 97)"
Cohesion: 0.50
Nodes (4): OrchestratorFactory.cs, CreateOrchestratorInstance(), OrchestratorFactory(), if()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, XPoster.Models, Post

### Community 118 - "Entity (Community 118)"
Cohesion: 0.67
Nodes (3): InSender.cs, if(), InSender()

### Community 117 - "Entity (Community 117)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, XPoster.Models, Validate()

### Community 108 - "Entity (Community 108)"
Cohesion: 0.67
Nodes (3): DefaultSlotProfileProvider.cs, GetProfiles(), XPoster.Orchestrators

### Community 109 - "Entity (Community 109)"
Cohesion: 0.67
Nodes (3): PerplexityOptionsValidator.cs, XPoster.Models, Validate()

### Community 111 - "Entity (Community 111)"
Cohesion: 1.00
Nodes (3): FeedOptions.cs, FeedOptions.cs, XPoster.Models

### Community 110 - "Entity (Community 110)"
Cohesion: 1.00
Nodes (3): XPoster.Contracts, Enums.cs, Enums.cs

### Community 113 - "Entity (Community 113)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, Validate(), XPoster.Models

### Community 112 - "Entity (Community 112)"
Cohesion: 0.67
Nodes (3): XFunction.cs, if(), XFunction()

### Community 116 - "Entity (Community 116)"
Cohesion: 0.67
Nodes (3): IgSender.cs, IgSender(), if()

### Community 115 - "Entity (Community 115)"
Cohesion: 1.00
Nodes (3): XCredentials.cs, XPoster.Credentials, XCredentials.cs

### Community 114 - "Entity (Community 114)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, AzureFoundryOptions.cs, XPoster.Models

### Community 119 - "Entity (Community 119)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, XPoster.Contracts, AiProvider.cs

### Community 128 - "Entity (Community 128)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, XPoster.Models, Validate()

### Community 130 - "Entity (Community 130)"
Cohesion: 0.67
Nodes (3): XSender.cs, if(), XSender()

### Community 129 - "Entity (Community 129)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, XPoster.Models, FalAiOptions.cs

### Community 127 - "Entity (Community 127)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, IgCredentials.cs, IgCredentials.cs

### Community 120 - "Entity (Community 120)"
Cohesion: 1.00
Nodes (3): XPoster.Models, DeepSeekOptions.cs, DeepSeekOptions.cs

### Community 121 - "Entity (Community 121)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, CryptoService(), if()

### Community 122 - "Entity (Community 122)"
Cohesion: 1.00
Nodes (3): PerplexityOptions.cs, XPoster.Models, PerplexityOptions.cs

### Community 123 - "Entity (Community 123)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, BuildFactory(), params()

### Community 125 - "Entity (Community 125)"
Cohesion: 0.67
Nodes (3): FeedService.cs, if(), FeedService()

### Community 126 - "Entity (Community 126)"
Cohesion: 1.00
Nodes (3): LinkedInCredentials.cs, LinkedInCredentials.cs, XPoster.Credentials

### Community 124 - "Entity (Community 124)"
Cohesion: 1.00
Nodes (3): OpenAiOptions.cs, XPoster.Models, OpenAiOptions.cs

### Community 136 - "Entity (Community 136)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

### Community 132 - "Entity (Community 132)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

### Community 131 - "Entity (Community 131)"
Cohesion: 1.00
Nodes (2): DefaultSlotProfileProvider.cs, ScheduledOrchestrationProfile()

### Community 134 - "Entity (Community 134)"
Cohesion: 1.00
Nodes (2): PerplexityOptionsValidator.cs, if()

### Community 133 - "Entity (Community 133)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

### Community 135 - "Entity (Community 135)"
Cohesion: 1.00
Nodes (2): BaseOrchestrator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._


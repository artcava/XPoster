# Graph Report - XPoster  (2026-06-26)

## Summary
- 1133 nodes · 1918 edges · 138 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Tests.Integration` - 2 edges
2. `XPoster.Tests.SenderPlugins` - 2 edges
3. `XPoster.Tests.Models` - 2 edges
4. `XPoster.Tests.Orchestrators` - 2 edges
5. `RSSFeedMissingBranchTests` - 2 edges
6. `XPoster.Tests.SenderPlugins` - 2 edges
7. `AzureFoundryServiceTests` - 2 edges
8. `XPoster.Orchestrators` - 2 edges
9. `XPoster.Models` - 2 edges
10. `XPoster.Tests.Services` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, MakeHttpClient(), OpenAiB64Json(), ParseChatCompletionResponseAsync_WhenChoicesIsEmpty_ReturnsFalseAndEmpty(), HttpClient(), var(), ParseImageResponseAsync_WhenStatusIsNonSuccess_ReturnsEmptyArray() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.12
Nodes (34): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GenerateImageAsync_WhenDataArrayIsEmpty_ReturnsEmptyArray(), GenerateImageAsync_WhenApiReturnsTooManyRequests_ReturnsEmptyArray(), GenerateImageAsync_WhenB64JsonIsNull_ReturnsEmptyArray(), GetSummaryAsync_WhenApiReturnsError_ReturnsEmpty(), GetSummaryAsync_WhenApiReturns200_ReturnsTrimmedContent(), MakeHandlerMock() (+26 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, Parse_AzureFoundry_UrlFallback_DownloadThrows_LogsError(), Parse_AzureFoundry_MissingBothB64AndUrl_ReturnsEmpty(), Parse_AzureFoundry_MissingDataProperty_ReturnsEmpty(), new(), AiServiceHelperImageTests, Parse_OpenAi_EmptyDataArray_ReturnsEmpty(), Parse_NonSuccessStatus_ReturnsEmpty() (+24 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.12
Nodes (32): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, CreateMultiSenderOrchestrator(), OrchestrateAsync_DerivesImagePromptFromRawBaseSummary_BeforeHashtags(), OrchestrateAsync_ReSummarisesViaAI_WhenBaseSummaryExceedsSecondaryLimit(), OrchestrateAsync_GeneratesBaseSummaryAtPrimaryMaxLength(), OrchestrateAsync_Should_ApplyHashtagsCorrectly(), OrchestrateAsync_Should_CallTagReplacementProvider_ExactlyOnce_WhenOrchestrationSucceeds() (+24 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.13
Nodes (30): OrchestratorFactoryTests.cs, OrchestratorFactoryTests.cs, OrchestratorFactoryTests(), PowerLawProfile(), Resolve_Should_NotRequestImageProvider_WhenProfileHasNoImageProvider(), PowerLawOrchestrator_SupportedPlatforms_ContainsXAndLinkedIn(), Resolve_Should_ResolveIgSender_WhenProfileUsesInstagram(), Resolve_Should_ResolveLinkedInSender_ForPowerLawOrchestrator() (+22 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, AddOpenAiOptions_BindsOptionsFromCorrectSection(), AddDeepSeekOptions_RegistersValidator(), AddFalAiOptions_BindsOptionsFromCorrectSection(), AddFalAiOptions_RegistersValidator(), AddAzureFoundryOptions_RegistersValidator(), AddAzureFoundryOptions_BindsOptionsFromCorrectSection() (+21 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.17
Nodes (23): PerplexityServiceTests.cs, PerplexityServiceTests.cs, PerplexityServiceTests, XPoster.Tests.Services, MakeSequentialHandlerMock(), GetSummaryAsync_WhenTextRemainsLongAfterMaxRetries_ReturnsLastApiContent(), MakeHandlerMock(), GetSummaryAsync_WhenTextWithinLimit_DoesNotCallApi() (+15 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.19
Nodes (21): IgSenderTests.cs, IgSenderTests.cs, SendAsync_WhenInstagramApiReturnsNonSuccess_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithImage_TriesUploadAndReturnsFalse(), SendAsync_WithNoImage_ReturnsFalse(), Constructor_WithNullLogger_ThrowsArgumentNullException(), BuildSenderWithFactory() (+13 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.19
Nodes (20): DryRunSenderTests.cs, DryRunSenderTests.cs, SendAsync_WhenProbeKeyPresent_LogsPostContent(), new(), SendAsync_WhenProbeKeyMissing_ReturnsFalse(), SendAsync_DoesNotCallAnyOutboundSocialApi(), SendAsync_WhenProbeKeyMissing_LogsError(), ValidPost() (+12 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.11
Nodes (19): AzureFoundryServiceTests.cs, GenerateImageAsync_WhenApiReturnsNonSuccess_ReturnsEmptyByteArray(), GenerateImageAsync_RequestBodyContainsModelField(), AzureFoundryServiceTests, BuildService(), GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString(), GenerateImageAsync_WhenPromptIsWhitespace_ReturnsEmptyByteArrayWithoutCallingApi(), GetSummaryAsync_PostsToFoundryChatCompletionsEndpoint() (+11 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.20
Nodes (19): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, XPoster.Tests.Services, MakeHandlerMock(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsContent(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenTextWithinLimit_DoesNotCallApi() (+11 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, foreach(), FakeHttpMessageHandler(), BuildService(), FeedServiceTests, FeedService(), XPoster.Tests.Services (+10 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.12
Nodes (17): AzureFoundryServiceTests.cs, GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GenerateImageAsync_WhenApiReturnsValidResponse_ReturnsByteArray(), GenerateImageAsync_WhenB64JsonIsNull_ReturnsEmptyByteArray(), GenerateImageAsync_WhenResponseBodyIsMalformedJson_ReturnsEmptyByteArray(), GenerateImageAsync_WhenPromptIsEmpty_LogsWarning(), GenerateImageAsync_WhenHttpRequestExceptionOnPost_LogsError(), GenerateImageAsync_WhenApiReturnsTooManyRequests_ReturnsEmptyByteArray() (+9 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.26
Nodes (15): DefaultSlotProfileProviderTests.cs, DefaultSlotProfileProviderTests.cs, GetProfiles_Should_NotContainDryRunSlot(), XPoster.Tests.Orchestrators, PowerLawSlot_Should_HaveNullTextAndImageProvider(), PowerLawSlot_Should_ContainLinkedInAndX(), GetProfiles_Should_ReturnTwoActiveSlots(), GetProfiles_Should_HaveUniqueHours() (+7 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.27
Nodes (14): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests, Validate_WhenImagePromptUserTemplateMissingSummary_ReturnsFailed(), Validate_WhenDeploymentNameIsEmpty_ReturnsFailed(), Validate_WhenImagePromptSystemTemplateHasNoPlaceholder_ReturnsSuccess(), Validate_WhenEndpointIsEmpty_ReturnsFailed(), Validate_WhenApiKeyIsEmpty_ReturnsFailed() (+6 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, Post_CanHold_ImageBytes(), Post_Firm_ContainsExpectedHashtags(), RSSFeed_CanBeCreated_WithAllProperties(), RSSFeed_PublishDate_DefaultsToMinValue(), XPoster.Tests.Models, Choice_CanBeCreated_WithMessage() (+6 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_ModelIdWithUnsafeCharacters_Fails(), Validate_WhitespaceApiKey_Fails(), Validate_ValidOptions_Succeeds(), Validate_WhitespaceModelId_Fails(), ValidOptions(), XPoster.Tests.Models (+5 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, XPoster.Tests.Services, GetCurrentTime_WhenForceHourIsValid_ReturnsUtcKind(), Constructor_AlwaysEmitsDevOverrideWarning(), GetCurrentTime_WhenForceHourIsValid_ReturnsForcedHour(), GetCurrentTime_WhenForceHourIsNonNumeric_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsOutOfRange_WrapsViaDateTimeOverflow() (+5 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.29
Nodes (13): OpenAiService.cs, OpenAiService.cs, while(), XPoster.Services, OpenAiService(), if(), catch(), GetPromptForImage() (+5 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.29
Nodes (13): InSenderMissingBranchTests.cs, InSenderMissingBranchTests.cs, InSenderMissingBranchTests(), BuildCreds(), BuildSender(), XPoster.Tests.SenderPlugins, SendAsync_NullPost_ReturnsFalse(), SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse() (+5 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, Validate_MissingSummaryPlaceholder_Fails(), Validate_MissingTextPlaceholder_ErrorNamesProperty(), ValidOptions(), Validate_MissingTextPlaceholder_Fails(), XPoster.Tests.Models, Validate_MissingMaxCharsPlaceholder_Fails() (+5 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.32
Nodes (12): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, Constructor_Should_PreserveHour_ForBoundaryValues(), Constructor_Should_SetTextProvider_And_NullImageProvider_WhenOnlyTextProviderSupplied(), Constructor_Should_SetBothProvidersToNull_WhenNeitherSupplied(), Constructor_Should_PreserveOrderOfSenderPlatforms(), ScheduledOrchestrationProfileTests, Constructor_Should_SetAllFields_WhenBothProvidersSupplied() (+4 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.32
Nodes (12): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, PostWithImage(), XPoster.Tests.SenderPlugins, PostWithoutImage(), SendAsync_WhenNoImage_ReturnsFalseWithoutCallingApi(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), SendAsync_WhenImageUploadNotImplemented_ReturnsFalseAndLogsError() (+4 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.32
Nodes (12): PerplexityService.cs, PerplexityService.cs, GetSummaryAsync(), GetChatCompletionsEndpoint(), GetImagePromptAsync(), BuildSummaryPayload(), BuildImagePromptPayload(), var() (+4 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.32
Nodes (12): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, XPoster.Tests.Orchestrators, PowerLawOrchestratorTests(), GenerateAsync_Should_CalculateCorrectPowerLawValue_ForFixedDate(), GenerateAsync_Should_CreateCorrectMessage_WithActualValue(), OrchestrateAsync_BroadcastsSamePost_ToAllSenders(), GenerateAsync_Should_HandleNegativeOrZeroCryptoValue() (+4 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, GenerateImageAsync_EmptyUrlProperty_ReturnsEmptyArray(), FalAiImageServiceTests, BuildService(), FalImageJson(), GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithUnsafeChars_PercentEncodesInRequestUri(), GenerateImageAsync_WhitespacePrompt_ReturnsEmptyArray() (+4 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.32
Nodes (12): ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests.cs, GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsPropertyIsNull(), XPoster.Tests.Orchestrators, GetReplacements_Should_ReturnReadOnlyDictionary(), GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsIsEmpty(), ConfigurationTagReplacementProvider(), GetReplacements_Should_ReturnConfiguredReplacements_When_OptionsContainsEntries() (+4 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.32
Nodes (12): DeepSeekService.cs, DeepSeekService.cs, XPoster.Services, DeepSeekService(), while(), GetChatCompletionsEndpoint(), GetImagePromptAsync(), GetSummaryAsync() (+4 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.35
Nodes (11): XSenderMissingBranchTests.cs, XSenderMissingBranchTests.cs, SendAsync_ValidTextPost_CatchesTwitterException_ReturnsFalse(), SendAsync_PostWithImage_CatchesTwitterException_ReturnsFalse(), SendAsync_EmptyContent_ReturnsFalse(), SendAsync_NullPost_ReturnsFalse(), MessageMaxLenght_Returns250(), BuildSender() (+3 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.35
Nodes (11): ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProviderTests.cs, GetFeedUrls_Should_ReturnUrlsInOrder_When_MultipleUrlsConfigured(), XPoster.Tests.Orchestrators, GetFeedUrls_Should_ReturnEmptyList_When_UrlsPropertyIsNull(), Constructor_Should_Throw_When_OptionsIsNull(), GetFeedUrls_Should_ReturnEmptyList_When_UrlsListIsEmpty(), ConfigurationFeedUrlProvider() (+3 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.18
Nodes (11): FalAiImageServiceTests.cs, GenerateImageAsync_Returns429_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithMultipleSegments_PreservesSlashesInUri(), GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray(), GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray(), FalAiImageService(), GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_LogsError() (+3 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, ValidPost(), XPoster.Tests.SenderPlugins, SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue(), SendAsync_WhenLinkedInReturns200_ReturnsTrue(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), InSenderResilienceTests (+3 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, SendIt_Set_ThrowsNotImplementedException(), OrchestrateAsync_ReturnsEmptyList(), Name_IsNoOrchestrator(), Build(), NoOrchestratorTests, SendIt_IsAlwaysFalse() (+2 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.38
Nodes (10): XSenderTests.cs, XSenderTests.cs, XPoster.Tests.SenderPlugins, Constructor_WithNullLogger_ThrowsArgumentNullException(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), SendAsync_ValidPost_TriesTwitterAndReturnsFalse(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), Constructor_InitializesCorrectly() (+2 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.42
Nodes (9): RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests.cs, RSSFeed_CanSetPublishDate(), RSSFeed_DefaultPublishDateIsMinValue(), RSSFeed_RecordEquality_SameValues_AreEqual(), XPoster.Tests.Models, RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeedMissingBranchTests (+1 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, BuildProviderWithHandler(), BuildSequenceHandler(), BuildDelayedHandler(), params(), XPoster.Tests.Integration, var() (+1 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.42
Nodes (9): FeedOrchestrator.cs, FeedOrchestrator.cs, catch(), ApplyTagReplacements(), AcquireFeedContentAsync(), foreach(), if(), XPoster.Orchestrators (+1 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, CryptoServiceTests, XPoster.Tests.Services, MakeService(), GetCryptoValue_ReturnsParsedValue_WhenNumericString(), GetCryptoValue_ReturnsZero_AndLogsError_OnException(), GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric() (+1 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.22
Nodes (9): InSender.cs, generatePayLoad(), InvalidOperationException(), using(), SendAsync(), ResolveAuthorUrn(), XPoster.SenderPlugins, catch() (+1 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, XSenderSendAsyncTests(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse() (+1 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptionsTests, XPoster.Tests.Models, DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), DeepSeekOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder() (+1 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, XPoster.Tests.Models, Validate_MissingRequiredProperties_Fails(), DeepSeekOptionsValidatorTests, Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), Validate_MissingPlaceholders_Fails(), Validate_ValidOptions_Succeeds() (+1 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.42
Nodes (9): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, XPoster.Tests.Models, AzureFoundryOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), AzureFoundryOptions_Defaults_AreCorrect(), AzureFoundryOptions_DoesNotExpose_ApiVersionProperty(), AzureFoundryOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), AzureFoundryOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder() (+1 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.22
Nodes (9): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_ReturnsTrue_When_AllConditionsMet(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_ReturnsFalse_WhenOneSenderFails(), PostAsync_ReturnsFalse_WhenSenderListIsEmpty(), XPoster.Tests.Contracts, PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent() (+1 more)

### Community 46 - "Entity (Community 46)"
Cohesion: 0.46
Nodes (8): OpenAIResponse.cs, OpenAIResponse.cs, ImageData, Message, OpenAIImageResponse, OpenAIResponse, XPoster.Models, Choice

### Community 44 - "Entity (Community 44)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, XPoster.Tests.Integration, IsEnabled(), Dispose(), CaptureLoggerProvider(), CaptureLogger(), CreateLogger()

### Community 45 - "Entity (Community 45)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, InSenderSendAsyncTests(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), XPoster.Tests.SenderPlugins

### Community 51 - "Entity (Community 51)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, Validate_MissingPlaceholders_Fails(), XPoster.Tests.Models, ValidOptions(), Validate_ValidOptions_Succeeds(), Validate_MissingRequiredProperties_Fails(), AzureFoundryOptionsValidatorTests

### Community 49 - "Entity (Community 49)"
Cohesion: 0.25
Nodes (8): AzureFoundryService.cs, GetSummaryAsync(), XPoster.Services, GetChatCompletionsEndpoint(), AzureFoundryService(), GenerateImageAsync(), BuildSummaryPayload(), GetImagePromptAsync()

### Community 50 - "Entity (Community 50)"
Cohesion: 0.25
Nodes (8): BaseOrchestratorTests.cs, PostAsync_DispatchesEachPostToAlignedSender(), BaseOrchestratorTests(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), PostAsync_ReturnsFalse_WhenSenderPlatformNotInDictionary(), TestOrchestrator(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), PostAsync_ReturnsFalse_When_Content_IsEmpty()

### Community 48 - "Entity (Community 48)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, AiProviderExtensionsTests, XPoster.Tests.Contracts, GetLabel_DescriptionDiffersFromEnumName(), GetLabel_DescriptionMatchesEnumName(), GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(), GetLabel_UnknownProvider_ReturnsFallbackToString()

### Community 47 - "Entity (Community 47)"
Cohesion: 0.46
Nodes (8): PostMissingBranchTests.cs, PostMissingBranchTests.cs, PostMissingBranchTests, Post_EmptyContent_IsAllowed(), Post_CanSetAndGetAllProperties(), Firm_IsNotNullOrEmpty(), Post_DefaultImageIsNull(), XPoster.Tests.Models

### Community 57 - "Entity (Community 57)"
Cohesion: 0.52
Nodes (7): XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests.cs, Run_Should_Rethrow_When_Factory_Throws(), XPoster.Tests, XFunctionMissingBranchTests(), Run_Should_LogError_When_OrchestrateAsync_ReturnsEmptyDictionary(), Run_Should_LogError_When_PostAsync_ReturnsFalse()

### Community 55 - "Entity (Community 55)"
Cohesion: 0.29
Nodes (7): InSenderTests.cs, Constructor_InitializesCorrectly(), SendAsync_WithEmptyContent_ReturnsFalseAndLogsWarning(), InSender_ImplementsISender(), Constructor_WithNullLogger_ThrowsArgumentNullException(), XPoster.Tests.SenderPlugins, BuildCreds()

### Community 56 - "Entity (Community 56)"
Cohesion: 0.52
Nodes (7): FalAiImageService.cs, FalAiImageService.cs, catch(), GenerateImageAsync(), if(), XPoster.Services, FalAiImageService()

### Community 54 - "Entity (Community 54)"
Cohesion: 0.29
Nodes (7): FeedOrchestratorFeedUrlProviderTests.cs, XPoster.Tests.Orchestrators, OrchestrateAsync_Should_CallGetFeedsAsync_With_Correct_Urls(), OrchestrateAsync_Should_ReturnEmpty_And_DisableSendIt_When_ProviderReturnsEmptyList(), OrchestrateAsync_Should_CallGetFeedUrls_Once(), new(), OrchestrateAsync_Should_CallGetFeedsAsync_For_Each_Url()

### Community 53 - "Entity (Community 53)"
Cohesion: 0.52
Nodes (7): XFunction.cs, XFunction.cs, catch(), if(), XPoster, XFunction(), Run()

### Community 52 - "Entity (Community 52)"
Cohesion: 0.29
Nodes (7): AiServiceHelper.cs, ExtractOpenAiBytes(), ExtractAzureFoundryBytesAsync(), XPoster.Services, LogAndReturnEmpty(), ExtractFalAiBytesAsync(), ParseImageResponseAsync()

### Community 59 - "Entity (Community 59)"
Cohesion: 0.29
Nodes (7): AzureFoundryService.cs, while(), if(), GetImageGenerationEndpoint(), catch(), BuildImagePromptPayload(), var()

### Community 60 - "Entity (Community 60)"
Cohesion: 0.52
Nodes (7): DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider.cs, GetProfiles(), DryRunSlotProfileProvider(), ScheduledOrchestrationProfile(), typeof(), XPoster.Orchestrators

### Community 58 - "Entity (Community 58)"
Cohesion: 0.52
Nodes (7): XFunctionTests.cs, XFunctionTests.cs, XPoster.Tests, Run_Should_DoNothing_When_GeneratorIsDisabled(), XFunctionTests(), Run_Should_LogWarning_AndNotRethrow_When_CancelledGracefully(), Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled()

### Community 69 - "Entity (Community 69)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, GetCurrentTime_ReturnsCurrentDateTime(), GetCurrentTime_ReturnsUtcTime(), XPoster.Tests.Services, TimeProviderTests

### Community 70 - "Entity (Community 70)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, XPoster.SenderPlugins, SendAsync(), DryRunSender(), if()

### Community 62 - "Entity (Community 62)"
Cohesion: 0.60
Nodes (6): ITextToTextProvider.cs, ITextToTextProvider.cs, GetImagePromptAsync(), ITextToTextProvider, XPoster.Contracts, GetSummaryAsync()

### Community 61 - "Entity (Community 61)"
Cohesion: 0.60
Nodes (6): Program.cs, Program.cs, DefaultAzureCredential(), Uri(), DryRunSlotProfileProvider(), if()

### Community 68 - "Entity (Community 68)"
Cohesion: 0.33
Nodes (6): InSenderTests.cs, SendAsync_ValidPost_TriesLinkedInAndReturnsFalse(), InSenderTests(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), InSender(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning()

### Community 65 - "Entity (Community 65)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, var(), MakeDownloadClient(), JsonResponse(), HttpClient(), MakeNoOpClient()

### Community 66 - "Entity (Community 66)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, Polly_AiClient_RetriesOn429_AndEventuallySucceeds(), Polly_AiClient_AttemptTimeout_CancelsSlowRequest(), XPoster.Tests.Integration, StringContent()

### Community 67 - "Entity (Community 67)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, Validate(), XPoster.Models, if(), foreach()

### Community 63 - "Entity (Community 63)"
Cohesion: 0.60
Nodes (6): HttpClientExtensions.cs, HttpClientExtensions.cs, IsTransientHttpFailure(), AddResilientHttpClient(), XPoster.Extensions, AddHttpClients()

### Community 64 - "Entity (Community 64)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, XPoster.Tests.Integration, Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), for()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, catch(), Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration, Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures()

### Community 72 - "Entity (Community 72)"
Cohesion: 0.70
Nodes (5): ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider.cs, GetFeedUrls(), XPoster.Orchestrators, ConfigurationFeedUrlProvider()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.70
Nodes (5): DefaultSlotProfileProvider.cs, DefaultSlotProfileProvider.cs, ScheduledOrchestrationProfile(), XPoster.Orchestrators, GetProfiles()

### Community 75 - "Entity (Community 75)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, XPoster.Orchestrators, PowerLawOrchestrator(), if()

### Community 73 - "Entity (Community 73)"
Cohesion: 0.40
Nodes (5): FeedService.cs, GetFeedsAsync(), catch(), Exception(), XPoster.Services

### Community 71 - "Entity (Community 71)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, XPoster.Contracts, SendAsync(), ISender

### Community 80 - "Entity (Community 80)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, XPoster.Contracts, PostAsync(), IOrchestrator

### Community 77 - "Entity (Community 77)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, IOrchestratorFactory, Resolve(), XPoster.Contracts

### Community 78 - "Entity (Community 78)"
Cohesion: 0.70
Nodes (5): IFeedUrlProvider.cs, IFeedUrlProvider.cs, XPoster.Contracts, IFeedUrlProvider, GetFeedUrls()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, IFeedService, XPoster.Contracts, GetFeedsAsync()

### Community 87 - "Entity (Community 87)"
Cohesion: 0.70
Nodes (5): ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider(), XPoster.Orchestrators, GetReplacements()

### Community 90 - "Entity (Community 90)"
Cohesion: 0.40
Nodes (5): IgSender.cs, XPoster.SenderPlugins, SendAsync(), catch(), UploadImageToPublicUrl()

### Community 88 - "Entity (Community 88)"
Cohesion: 0.40
Nodes (5): OrchestratorFactory.cs, return(), XPoster.Orchestrators, Resolve(), foreach()

### Community 89 - "Entity (Community 89)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, GetCryptoValue(), ICryptoService, XPoster.Contracts

### Community 86 - "Entity (Community 86)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider(), GetCurrentTime(), XPoster.Services

### Community 81 - "Entity (Community 81)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, ISlotProfileProvider, XPoster.Contracts, GetProfiles()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.70
Nodes (5): ITagReplacementProvider.cs, ITagReplacementProvider.cs, XPoster.Contracts, ITagReplacementProvider, GetReplacements()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, ITextToImageProvider, GenerateImageAsync(), XPoster.Contracts

### Community 84 - "Entity (Community 84)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, GetCurrentTime(), XPoster.Contracts, ITimeProvider

### Community 85 - "Entity (Community 85)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, XPoster.Services, TimeProvider, GetCurrentTime()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, XPoster.Extensions, AddXPosterAiProviders()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.83
Nodes (4): AzureFoundryOptionsExtensions.cs, AzureFoundryOptionsExtensions.cs, AddAzureFoundryOptions(), XPoster.Models

### Community 94 - "Entity (Community 94)"
Cohesion: 0.83
Nodes (4): DeepSeekOptionsExtensions.cs, DeepSeekOptionsExtensions.cs, AddDeepSeekOptions(), XPoster.Models

### Community 95 - "Entity (Community 95)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, NoOrchestrator(), XPoster.Orchestrators

### Community 96 - "Entity (Community 96)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, if(), return(), catch()

### Community 97 - "Entity (Community 97)"
Cohesion: 0.83
Nodes (4): FalAiOptionsExtensions.cs, FalAiOptionsExtensions.cs, XPoster.Models, AddFalAiOptions()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, Post, XPoster.Models

### Community 99 - "Entity (Community 99)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, XPoster.Contracts, GetLabel()

### Community 100 - "Entity (Community 100)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, RSSFeed, XPoster.Models

### Community 109 - "Entity (Community 109)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, Polly_Instagram_AttemptTimeout_CancelsSlowRequest(), StringContent(), for()

### Community 110 - "Entity (Community 110)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile(), XPoster.Abstraction

### Community 108 - "Entity (Community 108)"
Cohesion: 0.50
Nodes (4): XSender.cs, SendAsync(), XPoster.SenderPlugins, catch()

### Community 106 - "Entity (Community 106)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, catch(), GetCryptoValue(), XPoster.Services

### Community 107 - "Entity (Community 107)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, var(), BuildSequenceHandler(), XPoster.Tests.Helpers

### Community 102 - "Entity (Community 102)"
Cohesion: 0.83
Nodes (4): OpenAiOptionsExtensions.cs, OpenAiOptionsExtensions.cs, XPoster.Models, AddOpenAiOptions()

### Community 105 - "Entity (Community 105)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, PostAsync(), XPoster.Abstraction, BaseOrchestrator()

### Community 104 - "Entity (Community 104)"
Cohesion: 0.50
Nodes (4): OrchestratorFactory.cs, OrchestratorFactory(), CreateOrchestratorInstance(), if()

### Community 103 - "Entity (Community 103)"
Cohesion: 0.50
Nodes (4): FeedOrchestratorFeedUrlProviderTests.cs, FeedOrchestratorFeedUrlProviderTests(), OrchestrateAsync_Should_AggregateFeeds_From_All_Urls(), CreateOrchestrator()

### Community 91 - "Entity (Community 91)"
Cohesion: 0.83
Nodes (4): PerplexityOptionsExtensions.cs, PerplexityOptionsExtensions.cs, AddPerplexityOptions(), XPoster.Models

### Community 92 - "Entity (Community 92)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, catch(), Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), StringContent()

### Community 119 - "Entity (Community 119)"
Cohesion: 1.00
Nodes (3): Enums.cs, XPoster.Contracts, Enums.cs

### Community 112 - "Entity (Community 112)"
Cohesion: 1.00
Nodes (3): XPoster.Models, PerplexityOptions.cs, PerplexityOptions.cs

### Community 111 - "Entity (Community 111)"
Cohesion: 1.00
Nodes (3): XPoster.Models, TagReplacementOptions.cs, TagReplacementOptions.cs

### Community 114 - "Entity (Community 114)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, Validate(), XPoster.Models

### Community 113 - "Entity (Community 113)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, XPoster.Models, AzureFoundryOptions.cs

### Community 118 - "Entity (Community 118)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, XPoster.Models, DeepSeekOptions.cs

### Community 117 - "Entity (Community 117)"
Cohesion: 0.67
Nodes (3): InSender.cs, InSender(), if()

### Community 115 - "Entity (Community 115)"
Cohesion: 1.00
Nodes (3): FeedOptions.cs, FeedOptions.cs, XPoster.Models

### Community 116 - "Entity (Community 116)"
Cohesion: 1.00
Nodes (3): LinkedInCredentials.cs, XPoster.Credentials, LinkedInCredentials.cs

### Community 120 - "Entity (Community 120)"
Cohesion: 0.67
Nodes (3): PerplexityOptionsValidator.cs, XPoster.Models, Validate()

### Community 133 - "Entity (Community 133)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, XPoster.Models, Validate()

### Community 132 - "Entity (Community 132)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, XPoster.Models, Validate()

### Community 130 - "Entity (Community 130)"
Cohesion: 0.67
Nodes (3): FeedService.cs, FeedService(), if()

### Community 121 - "Entity (Community 121)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, BuildFactory(), params()

### Community 129 - "Entity (Community 129)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, XPoster.Models, FalAiOptions.cs

### Community 131 - "Entity (Community 131)"
Cohesion: 1.00
Nodes (3): XPoster.Models, OpenAiOptions.cs, OpenAiOptions.cs

### Community 122 - "Entity (Community 122)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, XPoster.Contracts, AiProvider.cs

### Community 123 - "Entity (Community 123)"
Cohesion: 0.67
Nodes (3): IgSender.cs, if(), IgSender()

### Community 124 - "Entity (Community 124)"
Cohesion: 0.67
Nodes (3): BaseOrchestrator.cs, DispatchAsync(), if()

### Community 125 - "Entity (Community 125)"
Cohesion: 0.67
Nodes (3): XSender.cs, if(), XSender()

### Community 127 - "Entity (Community 127)"
Cohesion: 1.00
Nodes (3): XCredentials.cs, XPoster.Credentials, XCredentials.cs

### Community 128 - "Entity (Community 128)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, if(), CryptoService()

### Community 126 - "Entity (Community 126)"
Cohesion: 1.00
Nodes (3): IgCredentials.cs, XPoster.Credentials, IgCredentials.cs

### Community 137 - "Entity (Community 137)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

### Community 135 - "Entity (Community 135)"
Cohesion: 1.00
Nodes (2): PerplexityOptionsValidator.cs, if()

### Community 134 - "Entity (Community 134)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

### Community 136 - "Entity (Community 136)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._


# Graph Report - XPoster  (2026-06-27)

## Summary
- 1133 nodes · 1918 edges · 138 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Tests.SenderPlugins` - 2 edges
2. `XPoster.Tests.SenderPlugins` - 2 edges
3. `XPoster.Tests.Services` - 2 edges
4. `XPoster.Tests.Orchestrators` - 2 edges
5. `IgSenderResilienceTests` - 2 edges
6. `XPoster.Tests.Services` - 2 edges
7. `XPoster.Orchestrators` - 2 edges
8. `XPoster.Models` - 2 edges
9. `XPoster.Services` - 2 edges
10. `XPoster.Contracts` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, ParseChatCompletionResponseAsync_WhenNonSuccess_LogsProviderNameAndStatusCode(), ParseChatCompletionResponseAsync_WhenContentIsWhitespaceOnly_ReturnsTrueAndEmpty(), ParseChatCompletionResponseAsync_WhenEmptyChoices_LogsWarningWithProviderName(), ParseChatCompletionResponseAsync_WhenStatusIs429_ReturnsFalseAndEmpty(), ParseChatCompletionResponseAsync_WhenResponseBodyIsEmpty_ReturnsFalseAndEmpty(), ParseChatCompletionResponseAsync_WhenStatusIs429_LogsInformation() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.12
Nodes (34): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GenerateImageAsync_WhenPromptIsEmpty_LogsWarning(), GenerateImageAsync_WhenHttpRequestExceptionThrown_ReturnsEmptyArray(), GenerateImageAsync_WhenHttpRequestExceptionThrown_LogsError(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmpty(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmpty(), OpenAiService() (+26 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, XPoster.Tests.Services, Parse_AzureFoundry_UrlFallback_WrongOrigin_LogsWarning(), Parse_AzureFoundry_UrlFallback_NullAllowedOrigin_SkipsOriginCheckAndDownloads(), Parse_AzureFoundry_UrlFallback_ReturnsBytes(), Parse_OpenAi_EmptyDataArray_ReturnsEmpty(), Parse_NonSuccessStatus_ReturnsEmpty(), Parse_OpenAi_EmptyB64Value_ReturnsEmpty() (+24 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.12
Nodes (32): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, new(), CreateOrchestrator(), FeedOrchestratorTests(), OrchestrateAsync_Should_ReturnNull_When_FeedUrlProviderReturnsEmptyList(), OrchestrateAsync_Should_ReturnNull_When_SenderIsNull(), OrchestrateAsync_Should_ReturnNull_When_NoFeedsFound() (+24 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.13
Nodes (30): OrchestratorFactoryTests.cs, OrchestratorFactoryTests.cs, FeedOrchestrator_SupportedPlatforms_ContainsAllExpectedPlatforms(), FeedProfile(), new(), Resolve_Should_NotRequestImageProvider_WhenProfileHasNoImageProvider(), OrchestratorFactoryTests(), PowerLawOrchestrator_SupportedPlatforms_ContainsXAndLinkedIn() (+22 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, PerplexityOptionsExtensionsTests, register(), SectionName_IsAzureFoundry(), SectionName_IsDeepSeek(), BuildProvider(), AddPerplexityOptions_RegistersValidator() (+21 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.17
Nodes (23): PerplexityServiceTests.cs, PerplexityServiceTests.cs, GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenFirstResponseStillTooLong_RetriesAndReturnsSecondResponse(), PerplexityServiceTests, XPoster.Tests.Services (+15 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.19
Nodes (21): IgSenderTests.cs, IgSenderTests.cs, SendAsync_WhenImageUploadThrowsNotImplemented_ReturnsFalseAndLogsError(), MessageMaxLenght_Returns2200(), SendAsync_WhenImageUploadThrowsHttpRequestException_ReturnsFalseAndLogsError(), new(), Constructor_WithNullLogger_ThrowsArgumentNullException(), BuildSenderWithFactory() (+13 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.19
Nodes (20): DryRunSenderTests.cs, DryRunSenderTests.cs, BuildSender(), Constructor_WithNullLogger_ThrowsArgumentNullException(), DryRunSender_ImplementsISender(), Constructor_WithNullConfiguration_ThrowsArgumentNullException(), ValidPost(), SendAsync_WhenProbeKeyPresent_ReturnsTrue() (+12 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.20
Nodes (19): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString(), GetImagePromptAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetImagePromptAsync_WhenApiReturnsValidResponse_ReturnsPrompt(), GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetImagePromptAsync_WhenApiReturns429_ReturnsEmptyString() (+11 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.11
Nodes (19): AzureFoundryServiceTests.cs, XPoster.Tests.Services, GenerateImageAsync_WhenHttpRequestExceptionOnPost_ReturnsEmptyByteArray(), GenerateImageAsync_WhenB64JsonAbsentAndUrlPresent_DownloadsFromUrl(), GenerateImageAsync_WhenApiReturnsTooManyRequests_LogsWarning(), GenerateImageAsync_WhenFallbackUrlIsFromDifferentOrigin_LogsWarning(), GenerateImageAsync_WhenDataArrayIsEmpty_ReturnsEmptyByteArray(), GenerateImageAsync_WhenPromptIsWhitespace_ReturnsEmptyByteArrayWithoutCallingApi() (+11 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, XPoster.Tests.Services, BuildRssXml(), BuildFactory(), SendAsync(), GetFeedsAsync_FiltersOutItemsWithNoKeywordMatch(), GetFeedsAsync_ReturnsFeedsFromCache_IfPresent() (+10 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.12
Nodes (17): AzureFoundryServiceTests.cs, GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GenerateImageAsync_WhenApiReturnsValidResponse_ReturnsByteArray(), GenerateImageAsync_WhenB64JsonIsNull_ReturnsEmptyByteArray(), GenerateImageAsync_WhenResponseBodyIsMalformedJson_ReturnsEmptyByteArray(), GenerateImageAsync_WhenPromptIsEmpty_LogsWarning(), GenerateImageAsync_WhenHttpRequestExceptionOnPost_LogsError(), GenerateImageAsync_WhenApiReturnsTooManyRequests_ReturnsEmptyByteArray() (+9 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.26
Nodes (15): DefaultSlotProfileProviderTests.cs, DefaultSlotProfileProviderTests.cs, GetProfiles_Should_NotContainDryRunSlot(), GetProfiles_Should_ReturnTwoActiveSlots(), PowerLawSlot_Should_ContainLinkedInAndX(), PowerLawSlot_Should_HaveNullTextAndImageProvider(), XPoster.Tests.Orchestrators, DefaultSlotProfileProviderTests (+7 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, Post_CanBeCreated_WithRequiredContent(), XPoster.Tests.Models, RSSFeed_PublishDate_DefaultsToMinValue(), RSSFeed_CanBeCreated_WithAllProperties(), Post_Firm_ContainsExpectedHashtags(), Post_CanHold_ImageBytes() (+6 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.27
Nodes (14): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, Validate_WhenImagePromptSystemTemplateHasNoPlaceholder_ReturnsSuccess(), PerplexityOptionsValidatorTests, Validate_WhenEndpointIsEmpty_ReturnsFailed(), Validate_WhenDeploymentNameIsEmpty_ReturnsFailed(), Validate_WhenApiKeyIsEmpty_ReturnsFailed(), Validate_WhenSummarySystemPromptMissingMaxChars_ReturnsFailed() (+6 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, Validate_DefaultOptions_Succeeds(), Validate_MissingTextPlaceholder_Fails(), Validate_MissingMaxCharsPlaceholder_ErrorNamesProperty(), Validate_MissingMaxCharsPlaceholder_Fails(), Validate_MissingSummaryPlaceholder_Fails(), Validate_MissingSummaryPlaceholder_ErrorNamesProperty() (+5 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.29
Nodes (13): InSenderMissingBranchTests.cs, InSenderMissingBranchTests.cs, InSenderMissingBranchTests(), BuildSender(), BuildCreds(), SendAsync_NullPost_ReturnsFalse(), SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn(), SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse() (+5 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, GetCurrentTime_WhenForceHourIsOutOfRange_WrapsViaDateTimeOverflow(), GetCurrentTime_WhenForceHourIsNonNumeric_FallsBackToUtcHour(), BuildProvider(), Constructor_AlwaysEmitsDevOverrideWarning(), GetCurrentTime_WhenForceHourIsAbsent_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsEmpty_FallsBackToUtcHour() (+5 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_ModelIdWithUnsafeCharacters_Fails(), ValidOptions(), Validate_WhitespaceModelId_Fails(), Validate_WhitespaceApiKey_Fails(), XPoster.Tests.Models, Validate_ValidOptions_Succeeds() (+5 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.29
Nodes (13): OpenAiService.cs, OpenAiService.cs, OpenAiService(), if(), catch(), GetPromptForImage(), GetSummaryAsync(), GenerateImageAsync() (+5 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.32
Nodes (12): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, IgSenderResilienceTests, BuildSender(), IgSender(), PostWithImage(), SendAsync_WhenImageUploadNotImplemented_ReturnsFalseAndLogsError(), PostWithoutImage() (+4 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, GenerateImageAsync_WhitespacePrompt_ReturnsEmptyArray(), XPoster.Tests.Services, GenerateImageAsync_ModelIdWithUnsafeChars_PercentEncodesInRequestUri(), BuildService(), GenerateImageAsync_MalformedJson_ReturnsEmptyArray(), GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray(), FalAiImageServiceTests (+4 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.32
Nodes (12): DeepSeekService.cs, DeepSeekService.cs, XPoster.Services, DeepSeekService(), GetChatCompletionsEndpoint(), while(), GetSummaryAsync(), GetImagePromptAsync() (+4 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.32
Nodes (12): ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests.cs, GetReplacements_Should_PreserveAllEntries_When_MultipleReplacementsConfigured(), XPoster.Tests.Orchestrators, GetReplacements_Should_ReturnReadOnlyDictionary(), GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsIsEmpty(), GetReplacements_Should_ReturnConfiguredReplacements_When_OptionsContainsEntries(), GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsPropertyIsNull() (+4 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.32
Nodes (12): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, XPoster.Tests.Orchestrators, OrchestrateAsync_BroadcastsSamePost_ToAllSenders(), CreateOrchestrator(), GenerateAsync_Should_CalculateCorrectPowerLawValue_ForFixedDate(), new(), GenerateAsync_Should_HandleNegativeOrZeroCryptoValue() (+4 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.32
Nodes (12): PerplexityService.cs, PerplexityService.cs, var(), while(), XPoster.Services, if(), GetSummaryAsync(), BuildSummaryPayload() (+4 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.32
Nodes (12): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, Constructor_Should_PreserveHour_ForBoundaryValues(), Constructor_Should_SetTextProvider_And_NullImageProvider_WhenOnlyTextProviderSupplied(), Constructor_Should_SetBothProvidersToNull_WhenNeitherSupplied(), Constructor_Should_PreserveOrderOfSenderPlatforms(), ScheduledOrchestrationProfileTests, Constructor_Should_SetAllFields_WhenBothProvidersSupplied() (+4 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.35
Nodes (11): ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProviderTests.cs, GetFeedUrls_Should_ReturnEmptyList_When_UrlsPropertyIsNull(), GetFeedUrls_Should_ReturnEmptyList_When_UrlsListIsEmpty(), ConfigurationFeedUrlProviderTests, Constructor_Should_Throw_When_OptionsIsNull(), ConfigurationFeedUrlProvider(), GetFeedUrls_Should_ReturnConfiguredUrls_When_OptionsContainsUrls() (+3 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.35
Nodes (11): XSenderMissingBranchTests.cs, XSenderMissingBranchTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WhitespaceContent_ReturnsFalse(), XSenderMissingBranchTests, SendAsync_ValidTextPost_CatchesTwitterException_ReturnsFalse(), SendAsync_NullPost_ReturnsFalse(), MessageMaxLenght_Returns250() (+3 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, SendAsync_WhenLinkedInReturns200_ReturnsTrue(), InSender(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), InSenderResilienceTests, BuildSender(), ValidPost() (+3 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.18
Nodes (11): FalAiImageServiceTests.cs, GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_LogsError(), MakeHandlerMock(), GenerateImageAsync_ReturnsNonSuccess_ReturnsEmptyArray(), FalAiImageService(), GenerateImageAsync_Returns429_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithMultipleSegments_PreservesSlashesInUri(), GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray() (+3 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.38
Nodes (10): XSenderTests.cs, XSenderTests.cs, XSender_ImplementsISender(), XPoster.Tests.SenderPlugins, SendAsync_ValidPost_TriesTwitterAndReturnsFalse(), Constructor_InitializesCorrectly(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), Constructor_WithNullLogger_ThrowsArgumentNullException() (+2 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, SupportedPlatforms_IsEmpty(), XPoster.Tests.Orchestrators, SendIt_IsAlwaysFalse(), Name_IsNoOrchestrator(), OrchestrateAsync_ReturnsEmptyList(), NoOrchestratorTests (+2 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, MakeService(), XPoster.Tests.Services, GetCryptoValue_ReturnsParsedValue_WhenNumericString(), CryptoServiceTests, CryptoService(), GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric() (+1 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse() (+1 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.42
Nodes (9): FeedOrchestrator.cs, FeedOrchestrator.cs, ApplyTagReplacements(), XPoster.Orchestrators, if(), catch(), FeedOrchestrator(), foreach() (+1 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.42
Nodes (9): RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests.cs, XPoster.Tests.Models, RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_RecordEquality_SameValues_AreEqual(), RSSFeedMissingBranchTests, RSSFeed_CanSetPublishDate(), RSSFeed_RecordEquality_DifferentValues_AreNotEqual() (+1 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.22
Nodes (9): InSender.cs, Exception(), generatePayLoad(), XPoster.SenderPlugins, InvalidOperationException(), ResolveAuthorUrn(), SendAsync(), using() (+1 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, Validate_MissingRequiredProperties_Fails(), Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), DeepSeekOptionsValidatorTests, Validate_MissingPlaceholders_Fails(), Validate_ValidOptions_Succeeds(), ValidOptions() (+1 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, BuildProviderWithHandler(), var(), XPoster.Tests.Integration, HttpResponseMessage(), params(), BuildSequenceHandler() (+1 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.42
Nodes (9): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests, AzureFoundryOptions_Defaults_AreCorrect(), AzureFoundryOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), AzureFoundryOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), AzureFoundryOptions_DoesNotExpose_ApiVersionProperty(), AzureFoundryOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder() (+1 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.22
Nodes (9): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_ReturnsTrue_When_AllConditionsMet(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_ReturnsFalse_WhenOneSenderFails(), PostAsync_ReturnsFalse_WhenSenderListIsEmpty(), XPoster.Tests.Contracts, PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent() (+1 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, XPoster.Tests.Models, DeepSeekOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), DeepSeekOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder() (+1 more)

### Community 47 - "Entity (Community 47)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, XPoster.Tests.Models, ValidOptions(), Validate_MissingRequiredProperties_Fails(), Validate_MissingPlaceholders_Fails(), AzureFoundryOptionsValidatorTests, Validate_ValidOptions_Succeeds()

### Community 46 - "Entity (Community 46)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, GetLabel_DescriptionMatchesEnumName(), GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(), GetLabel_UnknownProvider_ReturnsFallbackToString(), XPoster.Tests.Contracts, AiProviderExtensionsTests, GetLabel_DescriptionDiffersFromEnumName()

### Community 49 - "Entity (Community 49)"
Cohesion: 0.46
Nodes (8): OpenAIResponse.cs, OpenAIResponse.cs, Message, ImageData, Choice, OpenAIImageResponse, OpenAIResponse, XPoster.Models

### Community 48 - "Entity (Community 48)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, CaptureLogger(), CaptureLoggerProvider(), IsEnabled(), Dispose(), CreateLogger(), XPoster.Tests.Integration

### Community 51 - "Entity (Community 51)"
Cohesion: 0.46
Nodes (8): PostMissingBranchTests.cs, PostMissingBranchTests.cs, Firm_IsNotNullOrEmpty(), Post_CanSetAndGetAllProperties(), Post_DefaultImageIsNull(), XPoster.Tests.Models, PostMissingBranchTests, Post_EmptyContent_IsAllowed()

### Community 50 - "Entity (Community 50)"
Cohesion: 0.25
Nodes (8): BaseOrchestratorTests.cs, PostAsync_DispatchesEachPostToAlignedSender(), BaseOrchestratorTests(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), PostAsync_ReturnsFalse_WhenSenderPlatformNotInDictionary(), TestOrchestrator(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), PostAsync_ReturnsFalse_When_Content_IsEmpty()

### Community 44 - "Entity (Community 44)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), InSenderSendAsyncTests(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse()

### Community 45 - "Entity (Community 45)"
Cohesion: 0.25
Nodes (8): AzureFoundryService.cs, XPoster.Services, GetImagePromptAsync(), GetSummaryAsync(), AzureFoundryService(), BuildSummaryPayload(), GenerateImageAsync(), GetChatCompletionsEndpoint()

### Community 59 - "Entity (Community 59)"
Cohesion: 0.29
Nodes (7): AzureFoundryService.cs, if(), GetImageGenerationEndpoint(), catch(), BuildImagePromptPayload(), while(), var()

### Community 57 - "Entity (Community 57)"
Cohesion: 0.29
Nodes (7): AiServiceHelper.cs, ParseImageResponseAsync(), XPoster.Services, ExtractOpenAiBytes(), LogAndReturnEmpty(), ExtractFalAiBytesAsync(), ExtractAzureFoundryBytesAsync()

### Community 58 - "Entity (Community 58)"
Cohesion: 0.52
Nodes (7): XFunctionTests.cs, XFunctionTests.cs, XPoster.Tests, Run_Should_DoNothing_When_GeneratorIsDisabled(), XFunctionTests(), Run_Should_LogWarning_AndNotRethrow_When_CancelledGracefully(), Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled()

### Community 60 - "Entity (Community 60)"
Cohesion: 0.52
Nodes (7): FalAiImageService.cs, FalAiImageService.cs, FalAiImageService(), catch(), GenerateImageAsync(), if(), XPoster.Services

### Community 52 - "Entity (Community 52)"
Cohesion: 0.52
Nodes (7): XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests.cs, XPoster.Tests, XFunctionMissingBranchTests(), Run_Should_LogError_When_OrchestrateAsync_ReturnsEmptyDictionary(), Run_Should_Rethrow_When_Factory_Throws(), Run_Should_LogError_When_PostAsync_ReturnsFalse()

### Community 55 - "Entity (Community 55)"
Cohesion: 0.52
Nodes (7): XFunction.cs, XFunction.cs, catch(), XFunction(), Run(), if(), XPoster

### Community 56 - "Entity (Community 56)"
Cohesion: 0.52
Nodes (7): DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider(), ScheduledOrchestrationProfile(), typeof(), XPoster.Orchestrators, GetProfiles()

### Community 54 - "Entity (Community 54)"
Cohesion: 0.29
Nodes (7): FeedOrchestratorFeedUrlProviderTests.cs, OrchestrateAsync_Should_CallGetFeedsAsync_With_Correct_Urls(), new(), XPoster.Tests.Orchestrators, OrchestrateAsync_Should_CallGetFeedUrls_Once(), OrchestrateAsync_Should_CallGetFeedsAsync_For_Each_Url(), OrchestrateAsync_Should_ReturnEmpty_And_DisableSendIt_When_ProviderReturnsEmptyList()

### Community 53 - "Entity (Community 53)"
Cohesion: 0.29
Nodes (7): InSenderTests.cs, BuildCreds(), XPoster.Tests.SenderPlugins, SendAsync_WithEmptyContent_ReturnsFalseAndLogsWarning(), InSender_ImplementsISender(), Constructor_WithNullLogger_ThrowsArgumentNullException(), Constructor_InitializesCorrectly()

### Community 68 - "Entity (Community 68)"
Cohesion: 0.33
Nodes (6): InSenderTests.cs, SendAsync_ValidPost_TriesLinkedInAndReturnsFalse(), InSenderTests(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), InSender(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning()

### Community 65 - "Entity (Community 65)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, XPoster.Tests.Services, GetCurrentTime_ReturnsUtcTime(), GetCurrentTime_ReturnsCurrentDateTime(), TimeProviderTests

### Community 66 - "Entity (Community 66)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, Polly_AiClient_RetriesOn429_AndEventuallySucceeds(), Polly_AiClient_AttemptTimeout_CancelsSlowRequest(), XPoster.Tests.Integration, StringContent()

### Community 67 - "Entity (Community 67)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, MakeDownloadClient(), var(), MakeNoOpClient(), JsonResponse(), HttpClient()

### Community 62 - "Entity (Community 62)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, XPoster.SenderPlugins, if(), DryRunSender(), SendAsync()

### Community 63 - "Entity (Community 63)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, for(), Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), XPoster.Tests.Integration, Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest()

### Community 64 - "Entity (Community 64)"
Cohesion: 0.60
Nodes (6): Program.cs, Program.cs, Uri(), DryRunSlotProfileProvider(), if(), DefaultAzureCredential()

### Community 61 - "Entity (Community 61)"
Cohesion: 0.60
Nodes (6): ITextToTextProvider.cs, ITextToTextProvider.cs, GetImagePromptAsync(), XPoster.Contracts, GetSummaryAsync(), ITextToTextProvider

### Community 69 - "Entity (Community 69)"
Cohesion: 0.60
Nodes (6): HttpClientExtensions.cs, HttpClientExtensions.cs, AddHttpClients(), AddResilientHttpClient(), XPoster.Extensions, IsTransientHttpFailure()

### Community 70 - "Entity (Community 70)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, XPoster.Models, Validate(), foreach(), if()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.40
Nodes (5): OrchestratorFactory.cs, foreach(), return(), XPoster.Orchestrators, Resolve()

### Community 72 - "Entity (Community 72)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, GetCryptoValue(), XPoster.Contracts, ICryptoService

### Community 74 - "Entity (Community 74)"
Cohesion: 0.70
Nodes (5): ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider.cs, GetReplacements(), XPoster.Orchestrators, ConfigurationTagReplacementProvider()

### Community 75 - "Entity (Community 75)"
Cohesion: 0.70
Nodes (5): IFeedUrlProvider.cs, IFeedUrlProvider.cs, XPoster.Contracts, IFeedUrlProvider, GetFeedUrls()

### Community 73 - "Entity (Community 73)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, GetFeedsAsync(), IFeedService, XPoster.Contracts

### Community 80 - "Entity (Community 80)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, XPoster.Services, LocalOverrideTimeProvider(), GetCurrentTime()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.70
Nodes (5): DefaultSlotProfileProvider.cs, DefaultSlotProfileProvider.cs, ScheduledOrchestrationProfile(), GetProfiles(), XPoster.Orchestrators

### Community 78 - "Entity (Community 78)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, XPoster.Tests.Integration, Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), catch()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, Resolve(), XPoster.Contracts, IOrchestratorFactory

### Community 87 - "Entity (Community 87)"
Cohesion: 0.70
Nodes (5): ITagReplacementProvider.cs, ITagReplacementProvider.cs, XPoster.Contracts, ITagReplacementProvider, GetReplacements()

### Community 90 - "Entity (Community 90)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, XPoster.Services, GetCurrentTime(), TimeProvider

### Community 88 - "Entity (Community 88)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, ISlotProfileProvider, XPoster.Contracts, GetProfiles()

### Community 89 - "Entity (Community 89)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, IOrchestrator, PostAsync(), XPoster.Contracts

### Community 86 - "Entity (Community 86)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, ITextToImageProvider, GenerateImageAsync(), XPoster.Contracts

### Community 81 - "Entity (Community 81)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, SendAsync(), XPoster.Contracts, ISender

### Community 82 - "Entity (Community 82)"
Cohesion: 0.40
Nodes (5): FeedService.cs, XPoster.Services, GetFeedsAsync(), Exception(), catch()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, PowerLawOrchestrator(), if(), XPoster.Orchestrators

### Community 84 - "Entity (Community 84)"
Cohesion: 0.70
Nodes (5): ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider.cs, GetFeedUrls(), ConfigurationFeedUrlProvider(), XPoster.Orchestrators

### Community 85 - "Entity (Community 85)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, XPoster.Contracts, ITimeProvider, GetCurrentTime()

### Community 71 - "Entity (Community 71)"
Cohesion: 0.40
Nodes (5): IgSender.cs, XPoster.SenderPlugins, UploadImageToPublicUrl(), SendAsync(), catch()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, XPoster.Orchestrators, NoOrchestrator()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, BuildSequenceHandler(), XPoster.Tests.Helpers, var()

### Community 94 - "Entity (Community 94)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, AddXPosterAiProviders(), XPoster.Extensions

### Community 95 - "Entity (Community 95)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, catch(), GetCryptoValue(), XPoster.Services

### Community 96 - "Entity (Community 96)"
Cohesion: 0.83
Nodes (4): DeepSeekOptionsExtensions.cs, DeepSeekOptionsExtensions.cs, XPoster.Models, AddDeepSeekOptions()

### Community 97 - "Entity (Community 97)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, XPoster.Contracts, GetLabel()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.50
Nodes (4): FeedOrchestratorFeedUrlProviderTests.cs, CreateOrchestrator(), FeedOrchestratorFeedUrlProviderTests(), OrchestrateAsync_Should_AggregateFeeds_From_All_Urls()

### Community 99 - "Entity (Community 99)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, RSSFeed, XPoster.Models

### Community 100 - "Entity (Community 100)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, Polly_Instagram_AttemptTimeout_CancelsSlowRequest(), StringContent(), for()

### Community 91 - "Entity (Community 91)"
Cohesion: 0.50
Nodes (4): XSender.cs, SendAsync(), catch(), XPoster.SenderPlugins

### Community 92 - "Entity (Community 92)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, catch(), if(), return()

### Community 109 - "Entity (Community 109)"
Cohesion: 0.50
Nodes (4): OrchestratorFactory.cs, if(), OrchestratorFactory(), CreateOrchestratorInstance()

### Community 110 - "Entity (Community 110)"
Cohesion: 0.83
Nodes (4): AzureFoundryOptionsExtensions.cs, AzureFoundryOptionsExtensions.cs, XPoster.Models, AddAzureFoundryOptions()

### Community 108 - "Entity (Community 108)"
Cohesion: 0.83
Nodes (4): OpenAiOptionsExtensions.cs, OpenAiOptionsExtensions.cs, AddOpenAiOptions(), XPoster.Models

### Community 106 - "Entity (Community 106)"
Cohesion: 0.83
Nodes (4): FalAiOptionsExtensions.cs, FalAiOptionsExtensions.cs, AddFalAiOptions(), XPoster.Models

### Community 107 - "Entity (Community 107)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile(), XPoster.Abstraction

### Community 102 - "Entity (Community 102)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, XPoster.Models, Post

### Community 105 - "Entity (Community 105)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, PostAsync(), XPoster.Abstraction, BaseOrchestrator()

### Community 104 - "Entity (Community 104)"
Cohesion: 0.83
Nodes (4): PerplexityOptionsExtensions.cs, PerplexityOptionsExtensions.cs, XPoster.Models, AddPerplexityOptions()

### Community 103 - "Entity (Community 103)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), StringContent(), catch()

### Community 119 - "Entity (Community 119)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, if(), CryptoService()

### Community 112 - "Entity (Community 112)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, AzureFoundryOptions.cs, XPoster.Models

### Community 111 - "Entity (Community 111)"
Cohesion: 1.00
Nodes (3): XPoster.Models, OpenAiOptions.cs, OpenAiOptions.cs

### Community 114 - "Entity (Community 114)"
Cohesion: 0.67
Nodes (3): PerplexityOptionsValidator.cs, XPoster.Models, Validate()

### Community 113 - "Entity (Community 113)"
Cohesion: 1.00
Nodes (3): Enums.cs, XPoster.Contracts, Enums.cs

### Community 118 - "Entity (Community 118)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, XPoster.Models, DeepSeekOptions.cs

### Community 117 - "Entity (Community 117)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, LinkedInCredentials.cs, LinkedInCredentials.cs

### Community 115 - "Entity (Community 115)"
Cohesion: 1.00
Nodes (3): TagReplacementOptions.cs, XPoster.Models, TagReplacementOptions.cs

### Community 116 - "Entity (Community 116)"
Cohesion: 0.67
Nodes (3): FeedService.cs, FeedService(), if()

### Community 120 - "Entity (Community 120)"
Cohesion: 0.67
Nodes (3): BaseOrchestrator.cs, if(), DispatchAsync()

### Community 133 - "Entity (Community 133)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, XPoster.Models, Validate()

### Community 132 - "Entity (Community 132)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, Validate(), XPoster.Models

### Community 130 - "Entity (Community 130)"
Cohesion: 0.67
Nodes (3): IgSender.cs, if(), IgSender()

### Community 121 - "Entity (Community 121)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, XPoster.Models, FalAiOptions.cs

### Community 129 - "Entity (Community 129)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, params(), BuildFactory()

### Community 131 - "Entity (Community 131)"
Cohesion: 0.67
Nodes (3): XSender.cs, XSender(), if()

### Community 122 - "Entity (Community 122)"
Cohesion: 0.67
Nodes (3): InSender.cs, if(), InSender()

### Community 123 - "Entity (Community 123)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, XPoster.Contracts, AiProvider.cs

### Community 124 - "Entity (Community 124)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, Validate(), XPoster.Models

### Community 125 - "Entity (Community 125)"
Cohesion: 1.00
Nodes (3): FeedOptions.cs, XPoster.Models, FeedOptions.cs

### Community 127 - "Entity (Community 127)"
Cohesion: 1.00
Nodes (3): IgCredentials.cs, XPoster.Credentials, IgCredentials.cs

### Community 128 - "Entity (Community 128)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, XCredentials.cs, XCredentials.cs

### Community 126 - "Entity (Community 126)"
Cohesion: 1.00
Nodes (3): PerplexityOptions.cs, XPoster.Models, PerplexityOptions.cs

### Community 137 - "Entity (Community 137)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

### Community 135 - "Entity (Community 135)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

### Community 134 - "Entity (Community 134)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

### Community 136 - "Entity (Community 136)"
Cohesion: 1.00
Nodes (2): PerplexityOptionsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._


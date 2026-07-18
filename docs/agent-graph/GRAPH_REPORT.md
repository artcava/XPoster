# Graph Report - XPoster  (2026-07-18)

## Summary
- 1604 nodes · 2722 edges · 193 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Tests.Extensions` - 2 edges
2. `AiProviderServiceCollectionExtensionsTests` - 2 edges
3. `XPoster.Services` - 2 edges
4. `XPoster.Services` - 2 edges
5. `XPoster.Orchestrators` - 2 edges
6. `XPoster.SenderPlugins` - 2 edges
7. `Post` - 2 edges
8. `XPoster.Models` - 2 edges
9. `XPoster.Models` - 2 edges
10. `XPoster.Contracts` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, MakeResponse(), MakeHttpClientThatThrows(), AiServiceHelperTests, AzureFoundryUrlJson(), AzureFoundryB64Json(), MakeHttpClient() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.09
Nodes (43): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, OrchestrateAsync_SkipsAICall_WhenBaseSummaryFitsSecondaryLimit(), OrchestrateAsync_Should_UseSummaryAsPrompt_When_ImagePromptDerivationReturnsWhitespace(), OrchestrateAsync_Should_UseSummaryAsPrompt_When_ImagePromptDerivationReturnsEmpty(), OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageProviderIsNull(), OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationThrowsException(), OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationReturnsEmpty() (+35 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.10
Nodes (41): AzureFoundryServiceTests.cs, AzureFoundryServiceTests.cs, if(), GenerateTextAsync_WhenUsedAsImagePromptDerivationStep_ReturnsContent(), HttpResponseMessage(), GenerateTextAsync_WhenUsedAsImagePromptDerivationStep_AndChoicesEmpty_ReturnsEmptyString(), GenerateTextAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GenerateTextAsync_WhenChoicesIsNull_ReturnsEmptyString() (+33 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.11
Nodes (36): OpenAiServiceTests.cs, OpenAiServiceTests.cs, OpenAiServiceTests, XPoster.Tests.Services, new(), HttpResponseMessage(), MakeHandler(), MakeHandlerMock() (+28 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, Parse_AzureFoundry_UrlFallback_DownloadThrows_LogsError(), new(), Parse_AzureFoundry_MissingDataProperty_ReturnsEmpty(), Parse_AzureFoundry_MissingBothB64AndUrl_ReturnsEmpty(), AiServiceHelperImageTests, Parse_FalAi_DownloadThrows_LogsError(), Parse_AzureFoundry_UrlFallback_WrongOrigin_ReturnsEmpty() (+24 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.13
Nodes (30): OrchestratorFactoryTests.cs, OrchestratorFactoryTests.cs, typeof(), XPoster.Tests.Orchestrators, Resolve_Should_ResolveInSender_WhenProfileUsesLinkedIn(), Resolve_Should_ResolveAllSenders_ForMultiPlatformProfile(), Resolve_Should_ResolveDryRunSender_WhenProfileUsesDryRun(), Resolve_Should_ResolveIgSender_WhenProfileUsesInstagram() (+22 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, AzureFoundryOptionsExtensionsTests, AddOpenAiOptions_RegistersValidator(), AddPerplexityOptions_RegistersValidator(), AddPerplexityOptions_BindsOptionsFromCorrectSection(), register(), OpenAiOptionsExtensionsTests (+21 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.14
Nodes (28): PerplexityServiceTests.cs, PerplexityServiceTests.cs, BuildImagePromptRequest(), XPoster.Tests.Services, new(), PerplexityService(), PerplexityServiceTests, MakeHandlerMock() (+20 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.15
Nodes (26): FbSenderTests.cs, FbSenderTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WhenHttpClientThrows_ReturnsFalse(), SendAsync_WithCaptionExceedingMaxLength_TruncatesAndPublishes(), SendAsync_WhenPhotoEndpointReturns503_ReturnsFalseAndDeletesBlob(), NormalizeImage_WithValidPng_ReturnsOriginalBytes(), FbSenderTests() (+18 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.16
Nodes (25): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, GenerateTextAsync_WhenChoicesIsNull_ReturnsEmptyString(), GenerateTextAsync_WhenCancellationRequested_ThrowsOperationCanceledException(), GenerateTextAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GenerateTextAsync_WhenChoicesIsNull_ForImagePromptRole_ReturnsEmptyString(), GenerateTextAsync_WhenApiReturnsBadGateway_ReturnsEmptyString(), GenerateTextAsync_AppliesCustomInputTextLabel_InUserTemplate() (+17 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.19
Nodes (21): XSenderTests.cs, XSenderTests.cs, Constructor_InitializesCorrectly(), BuildSender(), SendAsync_PostWithImage_CatchesTwitterException_ReturnsFalse(), SendAsync_ValidPost_TriesTwitterAndReturnsFalse(), SendAsync_ValidTextPost_CatchesTwitterException_ReturnsFalse(), SendAsync_WhenTwitterContextThrows_ReturnsFalse() (+13 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.20
Nodes (19): FeedPromptOptionsTests.cs, FeedPromptOptionsTests.cs, FeedPromptOptions_ValueEquality_DifferentStepCount_AreNotEqual(), FeedPromptOptions_Steps_AreSetCorrectly(), FeedPromptOptions_IsImmutable_AfterConstruction(), FeedPromptOptions_Steps_PreservesOrder(), FeedPromptOptions_Steps_CanBeASingleStep(), FeedPromptOptions_ValueEquality_SameSteps_AreEqual() (+11 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, GetFeedsAsync_FiltersOutItemsWithNoKeywordMatch(), FeedServiceTests, GetFeedsAsync_FiltersOutItemsOutsideDateRange(), foreach(), GetFeedsAsync_FetchesAndCachesFeeds_WhenCacheMissAndHttpSucceeds(), FeedService() (+10 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.22
Nodes (18): IgSenderImageFlowTests.cs, IgSenderImageFlowTests.cs, SendAsync_WhenJsonResponseMissingIdProperty_ReturnsFalse(), NormalizeImage_WithValidPng_ReturnsJpegBytes(), SendAsync_WhenBlobUploadSucceeds_CreatesMediaContainerWithCorrectSasUrl(), return(), SendAsync_WhenJsonResponseIdIsEmpty_ReturnsFalse(), IgSender() (+10 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.23
Nodes (17): PromptRequestTests.cs, PromptRequestTests.cs, ImagePromptRequest_ImageProperties_AreSetCorrectly(), ImagePromptRequest_BaseProperties_AreAccessible(), XPoster.Tests.Models, PromptRequest_Temperature_AcceptsZeroAndOne(), PromptRequestTests, PromptRequest_ValueEquality_SameValues_AreEqual() (+9 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.23
Nodes (17): MetaPublishingServiceTests.cs, MetaPublishingServiceTests.cs, GetContainerStatusAsync_WhenResponseBodyIsEmpty_ThrowsJsonException(), PublishContainerAsync_WhenCancelled_ThrowsTaskCanceledException(), GetContainerStatusAsync_WithEmptyCreationId_ThrowsArgumentException(), MetaPublishingService(), GetContainerStatusAsync_WhenStatusInNestedField_ReturnsCode(), PublishContainerAsync_WhenOk_ReturnsPublishId() (+9 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.23
Nodes (17): PromptStepOptionsTests.cs, PromptStepOptionsTests.cs, PromptStepOptions_NonImageSteps_ImageProperties_AreNull(), PromptStepOptions_AllRoles_CanBeConstructed(), PromptStepOptions_IsImmutable_AfterConstruction(), PromptStepOptions_ImageGenerationStep_ImageProperties_AreIndependent(), PromptStepOptions_ValueEquality_SameValues_AreEqual(), PromptStepOptions_WithExpression_PreservesUnchangedProperties() (+9 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.24
Nodes (16): InMemoryContainerStateStoreTests.cs, InMemoryContainerStateStoreTests.cs, SaveAsync_WithNullCreationId_ThrowsArgumentNullException(), GetPendingAsync_WhenStoreIsEmpty_ReturnsEmptyList(), SaveAsync_WithEmptyOrWhitespaceCreationId_ThrowsArgumentException(), SaveAsync_WithEmptyOrWhitespaceBlobName_ThrowsArgumentException(), SaveAsync_WithNullBlobName_ThrowsArgumentNullException(), InMemoryContainerStateStoreTests (+8 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.26
Nodes (15): DefaultSlotProfileProviderTests.cs, DefaultSlotProfileProviderTests.cs, PowerLawSlot_Should_ContainLinkedInAndX(), FeedOrchestratorSlot_Should_HaveDistinctTextAndImageProviders(), GetProfiles_Should_ReturnWellFormedProfiles(), GetProfiles_Should_HaveUniqueHours(), GetProfiles_Should_NotContainDryRunSlot(), FeedOrchestratorSlot_Should_HaveImageProviderConfigured() (+7 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.26
Nodes (15): PromptRoleTests.cs, PromptRoleTests.cs, PromptRole_ParseFromString_ReturnsCorrectMember(), PromptRole_HasExactlyThreeMembers(), PromptRole_BackingValue_IsStable(), PromptRole_ParseFromStringIgnoreCase_ReturnsCorrectMember(), PromptRole_DefinedMember_IsDefined(), PromptRole_ParseInvalidName_Throws() (+7 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.26
Nodes (15): BlobStorageServiceTests.cs, BlobStorageServiceTests.cs, DeleteAsync_WhenBlobDoesNotExist_LogsDebugAndDoesNotThrow(), BlobStorageService(), BlobStorageServiceTests, Constructor_WhenContainerNameIsEmpty_UsesDefaultName(), CreateSut(), XPoster.Tests.Services (+7 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.26
Nodes (15): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, IgSenderResilienceTests, IgSender(), BuildSender(), XPoster.Tests.SenderPlugins, SendAsync_WhenImageUploadNotImplemented_ReturnsFalseAndLogsError(), PostWithoutImage() (+7 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.26
Nodes (15): MaskUrlTelemetryProcessorTests.cs, MaskUrlTelemetryProcessorTests.cs, Initialize_WhenDependencyTypeIsNotHttp_DoesNotModifyData(), Initialize_WhenDataIsNull_DoesThrow(), Initialize_WhenDataIsEmpty_DoesNotThrow(), Initialize_WhenAccessTokenAlreadyMasked_DoesNotDoubleEncode(), MaskUrlTelemetryProcessorTests, Initialize_WhenFacebookUrlHasAccessToken_TokenIsMasked() (+7 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.13
Nodes (15): DryRunSenderTests.cs, SendAsync_WhenProbeKeyMissing_ReturnsFalse(), ConfigurationBuilder(), new(), DryRunSender_ImplementsISender(), Constructor_WithNullConfiguration_ThrowsArgumentNullException(), SendAsync_WhenKeyMissing_ReturnsFalse(), DryRunSender() (+7 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.26
Nodes (15): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, Constructor_Should_SetBothProvidersToNull_WhenNeitherSupplied(), Constructor_Should_PreserveOrderOfSenderPlatforms(), Constructor_Should_PreserveHour_ForBoundaryValues(), Constructor_Should_SetAllFields_WhenBothProvidersSupplied(), Constructor_Should_AllowDifferentProvidersPerCapability_SplitProviderSlot(), OrchestratorContextKey_Should_BeNull_WhenNotProvided() (+7 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.27
Nodes (14): XPosterContainerPollingFunction.cs, XPosterContainerPollingFunction.cs, catch(), XPoster, XPosterContainerPollingFunction(), switch(), HandleFinishedAsync(), Run() (+6 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, Post_Firm_ContainsExpectedHashtags(), XPoster.Tests.Models, RSSFeed_PublishDate_DefaultsToMinValue(), RSSFeed_CanBeCreated_WithAllProperties(), OpenAIImageResponse_CanBeCreated_WithData(), AIResponse_CanBeCreated_WithChoices() (+6 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, GetCurrentTime_WhenForceHourIsValid_ReturnsForcedHour(), BuildProvider(), GetCurrentTime_WhenForceHourIsOutOfRange_WrapsViaDateTimeOverflow(), GetCurrentTime_WhenForceHourIsEmpty_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsNonNumeric_FallsBackToUtcHour(), Constructor_AlwaysEmitsDevOverrideWarning() (+5 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.29
Nodes (13): AzureFoundryService.cs, AzureFoundryService.cs, GetChatCompletionsEndpoint(), GetImageGenerationEndpoint(), if(), while(), GenerateTextAsync(), XPoster.Services (+5 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_ImageModelNameWithUnsafeCharacters_Fails(), Validate_BothRequiredFieldsMissing_ReportsBothFailures(), Validate_ImageModelNameWithAllowedSpecialChars_Succeeds(), FalAiOptionsValidatorTests, Validate_ValidOptions_Succeeds(), Validate_WhitespaceModelId_Fails() (+5 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.15
Nodes (13): FalAiImageServiceTests.cs, FalAiImageServiceTests, BuildService(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_ReturnsEmptyArray(), GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray(), GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithUnsafeChars_PercentEncodesInRequestUri(), GenerateImageAsync_ReturnsNonSuccess_ReturnsEmptyArray() (+5 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.15
Nodes (13): InSenderTests.cs, SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), SendAsync_WithImage_WhenRegisterUploadFails_ReturnsFalse(), SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn(), XPoster.Tests.SenderPlugins, SendAsync_TextOnly_WhenPostCreationFails_ReturnsFalse(), Constructor_WithNullLogger_ThrowsArgumentNullException() (+5 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.32
Nodes (12): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, GenerateAsync_Should_ReturnNull_When_DateIsBeforeGenesis(), PowerLawOrchestratorTests(), new(), OrchestrateAsync_BroadcastsSamePost_ToAllSenders(), XPoster.Tests.Orchestrators, GenerateAsync_Should_CreateCorrectMessage_WithActualValue() (+4 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, FalAiImageService(), GenerateImageAsync_EmptyUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_MalformedJson_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithMultipleSegments_PreservesSlashesInUri(), GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray(), GenerateImageAsync_WhitespacePrompt_ReturnsEmptyArray(), MakeHandlerMock() (+4 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.32
Nodes (12): ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests.cs, GetReplacements_Should_ReturnReadOnlyDictionary(), XPoster.Tests.Providers, GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsIsEmpty(), ConfigurationTagReplacementProvider(), Constructor_Should_Throw_When_OptionsIsNull(), foreach() (+4 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.17
Nodes (12): DryRunSenderTests.cs, SendAsync_WithNullPost_LogsWarning(), MessageMaxLength_ReturnsIntMaxValue(), SendAsync_WhenKeyWhitespace_ReturnsFalse(), Platform_ReturnsDryRun(), SendAsync_DoesNotCallAnyOutboundSocialApi(), SendAsync_WithNullContent_StillReturnsTrueWhenKeyPresent(), SendAsync_WhenProbeKeyMissing_LogsError() (+4 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.17
Nodes (12): InSenderTests.cs, SendAsync_TextOnly_WithOrgId_UsesOrganizationUrn(), InSenderTests(), Platform_ReturnsLinkedIn(), Constructor_InitializesCorrectly(), MessageMaxLength_Returns2800(), InSender(), SendAsync_WhenNeitherOrgIdNorOwnerCodeSet_ReturnsFalse() (+4 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.17
Nodes (12): XPosterContainerPollingFunctionTests.cs, XPoster.Tests, XPosterContainerPollingFunctionTests, RunAsync_WhenStatusIsUnknown_LogsWarningAndSkips(), RunAsync_WhenStatusIsInProgress_SkipsContainer(), CreateSut(), RunAsync_WhenBlobDeleteFails_LogsError(), RunAsync_WhenNoPendingContainers_DoesNothing() (+4 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, InSender(), BuildSender(), SendAsync_WhenLinkedInReturns200_ReturnsTrue(), SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue(), SendAsync_WhenLinkedInReturns503_ReturnsFalseAndLogsError(), ValidPost() (+3 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.35
Nodes (11): AiProviderServiceCollectionExtensionsTests.cs, AiProviderServiceCollectionExtensionsTests.cs, AddXPosterAiProviders_RegistersPerplexity_AsTextOnly(), AddXPosterAiProviders_ReturnsSameServiceCollection(), XPoster.Tests.Extensions, AiProviderServiceCollectionExtensionsTests, AddXPosterAiProviders_RegistersOpenAi_AsTextAndImageProvider(), AddXPosterAiProviders_RegistersExpectedNumberOfKeyedServices() (+3 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.35
Nodes (11): ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProviderTests.cs, GetFeedUrls_Should_ReturnEmptyList_When_UrlsListIsEmpty(), Constructor_Should_Throw_When_OptionsIsNull(), GetFeedUrls_Should_ReturnConfiguredUrls_When_OptionsContainsUrls(), GetFeedUrls_Should_ReturnReadOnlyList(), XPoster.Tests.Providers, GetFeedUrls_Should_ReturnEmptyList_When_UrlsPropertyIsNull() (+3 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.18
Nodes (11): IgSenderTests.cs, Constructor_InitializesCorrectly(), BuildSender(), BuildCreds(), Constructor_WithNullContainerStateStore_ThrowsArgumentNullException(), Platform_ReturnsInstagram(), XPoster.Tests.SenderPlugins, Constructor_WithNullHttpClientFactory_ThrowsArgumentNullException() (+3 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.38
Nodes (10): MetaPublishingService.cs, MetaPublishingService.cs, catch(), GetContainerStatusAsync(), MetaPublishingService(), HttpRequestException(), XPoster.Services, if() (+2 more)

### Community 44 - "Entity (Community 44)"
Cohesion: 0.38
Nodes (10): IgSenderSendAsyncTests.cs, IgSenderSendAsyncTests.cs, BuildSender(), IgSender(), SendAsync_WithCaptionExceedingMaxLength_TruncatesCaption(), IgSenderSendAsyncTests, SendAsync_WithEmptyImageArray_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse() (+2 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.38
Nodes (10): XSenderResilienceTests.cs, XSenderResilienceTests.cs, SendAsync_WhenContentIsBlank_ReturnsFalseAndLogsWarning(), XSender(), SendAsync_WhenMediaTweetFails_ReturnsFalseAndLogsError(), SendAsync_WhenTextTweetFails_ReturnsFalseAndLogsError(), XPoster.Tests.SenderPlugins, XSenderResilienceTests (+2 more)

### Community 48 - "Entity (Community 48)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, XPoster.Tests.Orchestrators, SupportedPlatforms_IsEmpty(), SendIt_Set_ThrowsNotImplementedException(), NoOrchestratorTests, SendIt_IsAlwaysFalse(), OrchestrateAsync_ReturnsEmptyList() (+2 more)

### Community 49 - "Entity (Community 49)"
Cohesion: 0.38
Nodes (10): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, ValidOptions(), Validate_WhenEndpointIsEmpty_ReturnsFailed(), PerplexityOptionsValidatorTests, Validate_WhenApiKeyIsEmpty_ReturnsFailed(), Validate_WithValidOptions_ReturnsSuccess(), Validate_WhenTextModelNameIsEmpty_ReturnsFailed() (+2 more)

### Community 46 - "Entity (Community 46)"
Cohesion: 0.38
Nodes (10): XFunctionTests.cs, XFunctionTests.cs, Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), Run_Should_DoNothing_When_GeneratorIsDisabled(), Run_Should_LogWarning_AndNotRethrow_When_CancelledGracefully(), Run_Should_Rethrow_When_Factory_Throws(), XPoster.Tests, XFunctionTests() (+2 more)

### Community 45 - "Entity (Community 45)"
Cohesion: 0.38
Nodes (10): FbSenderSendAsyncTests.cs, FbSenderSendAsyncTests.cs, SendAsync_WithCaptionLongerThanMax_StillPublishes_ReturnsTrue(), SendAsync_WithEmptyImage_PublishesTextOnly_ReturnsTrue(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), SendAsync_WithNullImage_PublishesTextOnly_ReturnsTrue(), XPoster.Tests.SenderPlugins, BuildCreds() (+2 more)

### Community 47 - "Entity (Community 47)"
Cohesion: 0.38
Nodes (10): FbSender.cs, FbSender.cs, SendAsync(), XPoster.SenderPlugins, PublishTextOnlyAsync(), PublishPhotoAsync(), if(), HandleResponseAsync() (+2 more)

### Community 53 - "Entity (Community 53)"
Cohesion: 0.42
Nodes (9): HttpClientExtensionsTests.cs, HttpClientExtensionsTests.cs, XPoster.Tests.Extensions, foreach(), AddHttpClients_CanCreateAllExpectedNamedClients(), AddHttpClients_RegistersExpectedNamedClients(), AddHttpClients_RegistersIHttpClientFactory(), AddHttpClients_ReturnsSameServiceCollection() (+1 more)

### Community 52 - "Entity (Community 52)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, var(), XPoster.Tests.Integration, BuildSequenceHandler(), BuildProviderWithHandler(), BuildDelayedHandler(), params() (+1 more)

### Community 51 - "Entity (Community 51)"
Cohesion: 0.22
Nodes (9): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_WhenOneSenderFails(), PostAsync_ReturnsFalse_WhenSenderListIsEmpty(), PostAsync_SkipsNullPost_ReturnsFalse(), PostAsync_ReturnsTrue_When_AllConditionsMet(), XPoster.Tests.Orchestrators, PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace() (+1 more)

### Community 55 - "Entity (Community 55)"
Cohesion: 0.22
Nodes (9): FbSenderImageFlowTests.cs, FbSenderImageFlowTests, BuildFactory(), BuildCreds(), HttpRequestException(), InvalidImageBytes(), SendAsync_WhenPhotoPublishThrows_FallsBackToTextOnly(), XPoster.Tests.SenderPlugins (+1 more)

### Community 54 - "Entity (Community 54)"
Cohesion: 0.42
Nodes (9): FeedOrchestrator.cs, FeedOrchestrator.cs, if(), AcquireFeedContentAsync(), FeedOrchestrator(), XPoster.Orchestrators, BuildPromptRequest(), foreach() (+1 more)

### Community 60 - "Entity (Community 60)"
Cohesion: 0.42
Nodes (9): RSSFeedTests.cs, RSSFeedTests.cs, XPoster.Tests.Models, RSSFeedTests, RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeed_DefaultPublishDateIsMinValue(), RSSFeed_CanSetPublishDate(), RSSFeed_CanCreateWithRequiredProperties() (+1 more)

### Community 59 - "Entity (Community 59)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, XSenderSendAsyncTests(), SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse() (+1 more)

### Community 61 - "Entity (Community 61)"
Cohesion: 0.22
Nodes (9): XPosterContainerPollingFunctionTests.cs, PendingContainer(), RunAsync_WhenUpdateStatusThrows_PropagatesException(), RunAsync_WhenStatusIsFinished_PublishesAndCleansUp(), RunAsync_WhenCancelled_StopsGracefully(), RunAsync_WhenPublishFails_MarksFailedAndCleansUp(), RunAsync_WhenBlobDeleteFails_StillUpdatesStatus(), RunAsync_WhenStatusIsExpired_MarksFailedAndCleansUp() (+1 more)

### Community 56 - "Entity (Community 56)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), GetCryptoValue_ReturnsZero_AndLogsError_OnException(), GetCryptoValue_ReturnsParsedValue_WhenNumericString(), CryptoServiceTests, CryptoService(), XPoster.Tests.Services (+1 more)

### Community 58 - "Entity (Community 58)"
Cohesion: 0.22
Nodes (9): FbSenderResilienceTests.cs, FbSenderResilienceTests, HttpResponseMessage(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), SendAsync_WhenTextPublishReturns200WithEmptyId_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WhenTextPublishReturns200WithoutId_ReturnsFalse(), SendAsync_WhenTextPublishReturns200WithId_ReturnsTrue() (+1 more)

### Community 50 - "Entity (Community 50)"
Cohesion: 0.22
Nodes (9): InSender.cs, catch(), Exception(), InvalidOperationException(), XPoster.SenderPlugins, using(), ResolveAuthorUrn(), generatePayLoad() (+1 more)

### Community 57 - "Entity (Community 57)"
Cohesion: 0.42
Nodes (9): FacebookResiliencePipelineTests.cs, FacebookResiliencePipelineTests.cs, Polly_Facebook_RetriesOn429_AndEventuallySucceeds(), Polly_Facebook_AttemptTimeout_CancelsSlowRequest(), for(), XPoster.Tests.Integration, Polly_Facebook_OnRetry_LogEntryIsEmitted(), catch() (+1 more)

### Community 71 - "Entity (Community 71)"
Cohesion: 0.25
Nodes (8): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_Content_IsEmpty(), PostAsync_DispatchesEachPostToAlignedSender(), BaseOrchestratorTests(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), TestOrchestrator(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), PostAsync_ReturnsFalse_WhenSenderPlatformNotInDictionary()

### Community 69 - "Entity (Community 69)"
Cohesion: 0.25
Nodes (8): FeedOrchestratorFeedUrlProviderTests.cs, OrchestrateAsync_TwoSlots_Should_UseDifferentFeedUrls_Independently(), OrchestrateAsync_Should_CallGetFeedsAsync_With_Correct_Urls(), OrchestrateAsync_Should_PassSenderMessageMaxLength_As_MaxOutputLength_In_SummaryRequest(), OrchestrateAsync_Should_ReturnEmpty_And_DisableSendIt_When_ContextHasNoFeedUrls(), OrchestrateAsync_Should_CallGetFeedsAsync_For_Each_Url(), OrchestrateAsync_Should_AggregateFeeds_From_All_Urls(), XPoster.Tests.Providers

### Community 70 - "Entity (Community 70)"
Cohesion: 0.46
Nodes (8): BlobStorageService.cs, BlobStorageService.cs, BlobStorageService(), BlobUploadResult(), UploadAsync(), XPoster.Services, DeleteAsync(), if()

### Community 68 - "Entity (Community 68)"
Cohesion: 0.25
Nodes (8): OpenAiService.cs, BuildChatPayload(), XPoster.Services, GenerateTextAsync(), var(), while(), catch(), GenerateImageAsync()

### Community 64 - "Entity (Community 64)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, CaptureLogger(), CreateLogger(), XPoster.Tests.Integration, IsEnabled(), Dispose(), CaptureLoggerProvider()

### Community 62 - "Entity (Community 62)"
Cohesion: 0.46
Nodes (8): AIResponse.cs, AIResponse.cs, XPoster.Models, OpenAIImageResponse, Message, ImageData, Choice, AIResponse

### Community 63 - "Entity (Community 63)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, AiProviderExtensionsTests, GetLabel_DescriptionMatchesEnumName(), GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(), GetLabel_DescriptionDiffersFromEnumName(), XPoster.Tests.Contracts, GetLabel_UnknownProvider_ReturnsFallbackToString()

### Community 66 - "Entity (Community 66)"
Cohesion: 0.46
Nodes (8): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), Validate_MissingRequiredProperties_Fails(), XPoster.Tests.Models, Validate_ValidOptions_Succeeds(), ValidOptions(), DeepSeekOptionsValidatorTests

### Community 67 - "Entity (Community 67)"
Cohesion: 0.46
Nodes (8): FalAiImageService.cs, FalAiImageService.cs, XPoster.Services, GetImageGenerationEndpoint(), FalAiImageService(), catch(), if(), GenerateImageAsync()

### Community 72 - "Entity (Community 72)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, InSenderSendAsyncTests(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithEmptyContent_ReturnsFalse()

### Community 65 - "Entity (Community 65)"
Cohesion: 0.46
Nodes (8): PostTests.cs, PostTests.cs, XPoster.Tests.Models, Firm_IsNotNullOrEmpty(), PostTests, Post_EmptyContent_IsAllowed(), Post_CanSetAndGetAllProperties(), Post_DefaultImageIsNull()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.52
Nodes (7): InMemoryContainerStateStore.cs, InMemoryContainerStateStore.cs, XPoster.Services, GetPendingAsync(), UpdateStatusAsync(), SaveAsync(), InMemoryContainerStateStore

### Community 78 - "Entity (Community 78)"
Cohesion: 0.29
Nodes (7): CredentialsStartupValidator.cs, catch(), InvalidOperationException(), CredentialsStartupValidator(), Validate(), XPoster.Credentials, if()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.52
Nodes (7): XFunction.cs, XFunction.cs, XPoster, Run(), catch(), XFunction(), if()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.52
Nodes (7): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, Validate_ValidOptions_Succeeds(), Validate_MissingRequiredProperties_Fails(), ValidOptions(), AzureFoundryOptionsValidatorTests, XPoster.Tests.Models

### Community 75 - "Entity (Community 75)"
Cohesion: 0.52
Nodes (7): TagReplacementService.cs, TagReplacementService.cs, if(), foreach(), Apply(), XPoster.Services, TagReplacementService()

### Community 73 - "Entity (Community 73)"
Cohesion: 0.29
Nodes (7): AiServiceHelper.cs, XPoster.Services, ParseImageResponseAsync(), LogAndReturnEmpty(), ExtractFalAiBytesAsync(), ExtractAzureFoundryBytesAsync(), ExtractOpenAiBytes()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.52
Nodes (7): Program.cs, Program.cs, Uri(), if(), DefaultAzureCredential(), DryRunSlotProfileProvider(), BlobServiceClient()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.29
Nodes (7): FbSenderImageFlowTests.cs, CreateValidJpegBytes(), if(), SendAsync_WhenDeleteFails_AfterSuccessfulPhotoPublish_ReturnsTrue(), SendAsync_WhenUploadThrows_FallsBackToTextOnly(), SendAsync_WithSupportedImage_UploadsPublishesPhotoAndDeletesBlob(), HttpResponseMessage()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.52
Nodes (7): IgSender.cs, IgSender.cs, IgSender(), catch(), if(), SendAsync(), XPoster.SenderPlugins

### Community 81 - "Entity (Community 81)"
Cohesion: 0.52
Nodes (7): IContainerStateStore.cs, IContainerStateStore.cs, UpdateStatusAsync(), IContainerStateStore, GetPendingAsync(), SaveAsync(), XPoster.Contracts

### Community 96 - "Entity (Community 96)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, SendAsync(), if(), DryRunSender(), XPoster.SenderPlugins

### Community 93 - "Entity (Community 93)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, XPoster.Tests.Integration, Polly_AiClient_RetriesOn429_AndEventuallySucceeds(), StringContent(), Polly_AiClient_AttemptTimeout_CancelsSlowRequest()

### Community 95 - "Entity (Community 95)"
Cohesion: 0.60
Nodes (6): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptions_Defaults_AreCorrect(), XPoster.Tests.Models, DeepSeekOptionsTests, DeepSeekOptions_DoesNotExpose_ApiVersionProperty()

### Community 94 - "Entity (Community 94)"
Cohesion: 0.60
Nodes (6): InstagramCredentialsValidator.cs, InstagramCredentialsValidator.cs, Validate(), XPoster.Credentials, InstagramCredentialsValidator, if()

### Community 99 - "Entity (Community 99)"
Cohesion: 0.33
Nodes (6): FeedOrchestratorFeedUrlProviderTests.cs, SetupHappyPathProviders(), FeedOrchestratorFeedUrlProviderTests(), BuildContext(), CreateOrchestrator(), new()

### Community 97 - "Entity (Community 97)"
Cohesion: 0.60
Nodes (6): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, AzureFoundryOptions_Defaults_AreCorrect(), AzureFoundryOptions_DoesNotExpose_ApiVersionProperty(), AzureFoundryOptionsTests, XPoster.Tests.Models

### Community 98 - "Entity (Community 98)"
Cohesion: 0.33
Nodes (6): DeepSeekService.cs, var(), GenerateTextAsync(), if(), while(), XPoster.Services

### Community 100 - "Entity (Community 100)"
Cohesion: 0.60
Nodes (6): FacebookCredentialsValidator.cs, FacebookCredentialsValidator.cs, if(), FacebookCredentialsValidator, XPoster.Credentials, Validate()

### Community 87 - "Entity (Community 87)"
Cohesion: 0.33
Nodes (6): OrchestratorFactory.cs, typeof(), return(), foreach(), Resolve(), XPoster.Orchestrators

### Community 85 - "Entity (Community 85)"
Cohesion: 0.33
Nodes (6): IgSenderTests.cs, Constructor_WithNullBlobStorageService_ThrowsArgumentNullException(), IgSenderTests(), IgSender_ImplementsISender(), IgSender(), Constructor_WithNullCredentials_ThrowsArgumentNullException()

### Community 86 - "Entity (Community 86)"
Cohesion: 0.33
Nodes (6): PerplexityService.cs, if(), while(), XPoster.Services, var(), GenerateTextAsync()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, XPoster.Tests.Providers, GetCurrentTime_ReturnsCurrentDateTime(), GetCurrentTime_ReturnsUtcTime(), TimeProviderTests

### Community 83 - "Entity (Community 83)"
Cohesion: 0.60
Nodes (6): IMetaPublishingService.cs, IMetaPublishingService.cs, PublishContainerAsync(), XPoster.Contracts, GetContainerStatusAsync(), IMetaPublishingService

### Community 91 - "Entity (Community 91)"
Cohesion: 0.60
Nodes (6): IBlobStorageService.cs, IBlobStorageService.cs, IBlobStorageService, DeleteAsync(), UploadAsync(), XPoster.Contracts

### Community 92 - "Entity (Community 92)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, MakeNoOpClient(), MakeDownloadClient(), var(), JsonResponse(), HttpClient()

### Community 90 - "Entity (Community 90)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), for(), Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), XPoster.Tests.Integration, Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds()

### Community 88 - "Entity (Community 88)"
Cohesion: 0.60
Nodes (6): DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider(), GetProfiles(), ScheduledOrchestrationProfile(), XPoster.Providers

### Community 89 - "Entity (Community 89)"
Cohesion: 0.60
Nodes (6): TagReplacementServiceTests.cs, TagReplacementServiceTests.cs, Apply_Does_Not_Replace_Words_Already_Prefixed_With_Hashtag(), XPoster.Tests.Services, Apply_Returns_Input_Unchanged_When_Text_Is_Empty_Or_Whitespace(), Apply_Replaces_Only_First_Occurrence_For_Each_Word()

### Community 108 - "Entity (Community 108)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, XPoster.Contracts, ISlotProfileProvider, GetProfiles()

### Community 104 - "Entity (Community 104)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, XPoster.Contracts, GetFeedsAsync(), IFeedService

### Community 105 - "Entity (Community 105)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, ICryptoService, XPoster.Contracts, GetCryptoValue()

### Community 106 - "Entity (Community 106)"
Cohesion: 0.70
Nodes (5): DefaultSlotProfileProvider.cs, DefaultSlotProfileProvider.cs, ScheduledOrchestrationProfile(), GetProfiles(), XPoster.Providers

### Community 107 - "Entity (Community 107)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, IOrchestrator, PostAsync(), XPoster.Contracts

### Community 119 - "Entity (Community 119)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, if(), XPoster.Orchestrators, PowerLawOrchestrator()

### Community 114 - "Entity (Community 114)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, GetCurrentTime(), LocalOverrideTimeProvider(), XPoster.Providers

### Community 115 - "Entity (Community 115)"
Cohesion: 0.70
Nodes (5): PromptRequest.cs, PromptRequest.cs, PromptRequest, XPoster.Models, ImagePromptRequest

### Community 118 - "Entity (Community 118)"
Cohesion: 0.70
Nodes (5): IFeedUrlProvider.cs, IFeedUrlProvider.cs, GetFeedUrls(), IFeedUrlProvider, XPoster.Contracts

### Community 117 - "Entity (Community 117)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, XPoster.Contracts, ITimeProvider, GetCurrentTime()

### Community 116 - "Entity (Community 116)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, XPoster.Contracts, ITextToImageProvider, GenerateImageAsync()

### Community 103 - "Entity (Community 103)"
Cohesion: 0.70
Nodes (5): MaskUrlTelemetryProcessor.cs, MaskUrlTelemetryProcessor.cs, MaskUrlTelemetryProcessor(), if(), Process()

### Community 102 - "Entity (Community 102)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, ISender, XPoster.Contracts, SendAsync()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, catch(), Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), XPoster.Tests.Integration, Polly_Instagram_RetriesOn429_AndEventuallySucceeds()

### Community 125 - "Entity (Community 125)"
Cohesion: 0.70
Nodes (5): LinkedInCredentialsValidator.cs, LinkedInCredentialsValidator.cs, Validate(), XPoster.Credentials, if()

### Community 121 - "Entity (Community 121)"
Cohesion: 0.70
Nodes (5): ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider.cs, GetFeedUrls(), XPoster.Providers, ConfigurationFeedUrlProvider()

### Community 123 - "Entity (Community 123)"
Cohesion: 0.70
Nodes (5): ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider.cs, XPoster.Providers, GetReplacements(), ConfigurationTagReplacementProvider()

### Community 122 - "Entity (Community 122)"
Cohesion: 0.40
Nodes (5): OrchestratorFactory.cs, CreateOrchestratorInstance(), OrchestratorFactory(), if(), InvalidOperationException()

### Community 120 - "Entity (Community 120)"
Cohesion: 0.40
Nodes (5): FeedService.cs, Exception(), XPoster.Services, GetFeedsAsync(), catch()

### Community 124 - "Entity (Community 124)"
Cohesion: 0.70
Nodes (5): ICredentialsStartupValidator.cs, ICredentialsStartupValidator.cs, XPoster.Contracts, Validate(), ICredentialsStartupValidator

### Community 109 - "Entity (Community 109)"
Cohesion: 0.70
Nodes (5): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests, ValidOptions(), XPoster.Tests.Models

### Community 111 - "Entity (Community 111)"
Cohesion: 0.40
Nodes (5): OpenAiService.cs, OpenAiService(), if(), GetChatCompletionsEndpoint(), GetImageGenerationEndpoint()

### Community 113 - "Entity (Community 113)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, GetCurrentTime(), TimeProvider, XPoster.Providers

### Community 112 - "Entity (Community 112)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, Resolve(), XPoster.Contracts, IOrchestratorFactory

### Community 110 - "Entity (Community 110)"
Cohesion: 0.70
Nodes (5): ITagReplacementProvider.cs, ITagReplacementProvider.cs, ITagReplacementProvider, XPoster.Contracts, GetReplacements()

### Community 126 - "Entity (Community 126)"
Cohesion: 0.70
Nodes (5): ImageTestData.cs, ImageTestData.cs, CreateValidJpeg(), CreateValidPng(), XPoster.Tests.Helpers

### Community 127 - "Entity (Community 127)"
Cohesion: 0.70
Nodes (5): ITextToTextProvider.cs, ITextToTextProvider.cs, GenerateTextAsync(), ITextToTextProvider, XPoster.Contracts

### Community 128 - "Entity (Community 128)"
Cohesion: 0.70
Nodes (5): ITagReplacementService.cs, ITagReplacementService.cs, Apply(), ITagReplacementService, XPoster.Contracts

### Community 148 - "Entity (Community 148)"
Cohesion: 0.50
Nodes (4): CredentialsStartupValidator.cs, ValidateOptions(), foreach(), resolve()

### Community 140 - "Entity (Community 140)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, GetCryptoValue(), XPoster.Services, catch()

### Community 141 - "Entity (Community 141)"
Cohesion: 0.50
Nodes (4): PerplexityService.cs, GetChatCompletionsEndpoint(), BuildChatPayload(), PerplexityService()

### Community 147 - "Entity (Community 147)"
Cohesion: 0.83
Nodes (4): FalAiOptionsExtensions.cs, FalAiOptionsExtensions.cs, AddFalAiOptions(), XPoster.Models

### Community 143 - "Entity (Community 143)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, XPoster.Orchestrators, NoOrchestrator()

### Community 142 - "Entity (Community 142)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, catch(), if(), return()

### Community 144 - "Entity (Community 144)"
Cohesion: 0.50
Nodes (4): DeepSeekService.cs, BuildChatPayload(), GetChatCompletionsEndpoint(), DeepSeekService()

### Community 145 - "Entity (Community 145)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, Post, XPoster.Models

### Community 146 - "Entity (Community 146)"
Cohesion: 0.50
Nodes (4): XSender.cs, SendAsync(), XPoster.SenderPlugins, catch()

### Community 132 - "Entity (Community 132)"
Cohesion: 0.83
Nodes (4): FeedOrchestratorContext.cs, FeedOrchestratorContext.cs, XPoster.Models, FeedOrchestratorContext

### Community 133 - "Entity (Community 133)"
Cohesion: 0.50
Nodes (4): HttpClientExtensions.cs, XPoster.Extensions, AddHttpClients(), AddResilientHttpClient()

### Community 139 - "Entity (Community 139)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, StringContent(), catch(), Polly_LinkedIn_OnRetry_LogEntryIsEmitted()

### Community 134 - "Entity (Community 134)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, BaseOrchestrator(), PostAsync(), XPoster.Orchestrators

### Community 135 - "Entity (Community 135)"
Cohesion: 0.83
Nodes (4): PerplexityOptionsExtensions.cs, PerplexityOptionsExtensions.cs, AddPerplexityOptions(), XPoster.Models

### Community 136 - "Entity (Community 136)"
Cohesion: 0.83
Nodes (4): PendingContainer.cs, PendingContainer.cs, XPoster.Models, PendingContainer()

### Community 137 - "Entity (Community 137)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile(), XPoster.Models

### Community 138 - "Entity (Community 138)"
Cohesion: 0.50
Nodes (4): FalAiOptionsValidator.cs, Validate(), foreach(), XPoster.Models

### Community 149 - "Entity (Community 149)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, RSSFeed, XPoster.Models

### Community 151 - "Entity (Community 151)"
Cohesion: 0.83
Nodes (4): BlobUploadResult.cs, BlobUploadResult.cs, XPoster.Models, BlobUploadResult()

### Community 153 - "Entity (Community 153)"
Cohesion: 0.83
Nodes (4): CredentialsExtensions.cs, CredentialsExtensions.cs, AddCredentials(), XPoster.Credentials

### Community 150 - "Entity (Community 150)"
Cohesion: 0.83
Nodes (4): DeepSeekOptionsExtensions.cs, DeepSeekOptionsExtensions.cs, AddDeepSeekOptions(), XPoster.Models

### Community 152 - "Entity (Community 152)"
Cohesion: 0.83
Nodes (4): AzureFoundryOptionsExtensions.cs, AzureFoundryOptionsExtensions.cs, XPoster.Models, AddAzureFoundryOptions()

### Community 156 - "Entity (Community 156)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, StringContent(), for(), Polly_Instagram_AttemptTimeout_CancelsSlowRequest()

### Community 155 - "Entity (Community 155)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, BuildSequenceHandler(), var(), XPoster.Tests.Helpers

### Community 154 - "Entity (Community 154)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, GetLabel(), XPoster.Contracts

### Community 131 - "Entity (Community 131)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, AddXPosterAiProviders(), XPoster.Extensions

### Community 129 - "Entity (Community 129)"
Cohesion: 0.83
Nodes (4): OpenAiOptionsExtensions.cs, OpenAiOptionsExtensions.cs, AddOpenAiOptions(), XPoster.Models

### Community 130 - "Entity (Community 130)"
Cohesion: 0.83
Nodes (4): FeedPromptOptions.cs, FeedPromptOptions.cs, GetStep(), XPoster.Models

### Community 160 - "Entity (Community 160)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, params(), BuildFactory()

### Community 159 - "Entity (Community 159)"
Cohesion: 1.00
Nodes (3): PromptRole.cs, XPoster.Models, PromptRole.cs

### Community 158 - "Entity (Community 158)"
Cohesion: 1.00
Nodes (3): SenderPlatform.cs, SenderPlatform.cs, XPoster.Contracts

### Community 157 - "Entity (Community 157)"
Cohesion: 1.00
Nodes (3): FacebookCredentials.cs, XPoster.Credentials, FacebookCredentials.cs

### Community 175 - "Entity (Community 175)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, XPoster.Models, AzureFoundryOptions.cs

### Community 184 - "Entity (Community 184)"
Cohesion: 1.00
Nodes (3): PromptStepOptions.cs, XPoster.Models, PromptStepOptions.cs

### Community 186 - "Entity (Community 186)"
Cohesion: 0.67
Nodes (3): BaseOrchestrator.cs, DispatchAsync(), if()

### Community 185 - "Entity (Community 185)"
Cohesion: 1.00
Nodes (3): TagReplacementOptions.cs, TagReplacementOptions.cs, XPoster.Models

### Community 183 - "Entity (Community 183)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, AiProvider.cs, XPoster.Contracts

### Community 176 - "Entity (Community 176)"
Cohesion: 0.67
Nodes (3): InSender.cs, if(), InSender()

### Community 177 - "Entity (Community 177)"
Cohesion: 0.67
Nodes (3): HttpClientExtensions.cs, if(), IsTransientHttpFailure()

### Community 178 - "Entity (Community 178)"
Cohesion: 1.00
Nodes (3): XPoster.Models, FeedOptions.cs, FeedOptions.cs

### Community 179 - "Entity (Community 179)"
Cohesion: 1.00
Nodes (3): OpenAiOptions.cs, OpenAiOptions.cs, XPoster.Models

### Community 181 - "Entity (Community 181)"
Cohesion: 0.67
Nodes (3): XSender.cs, XSender(), if()

### Community 182 - "Entity (Community 182)"
Cohesion: 0.67
Nodes (3): PerplexityOptionsValidator.cs, Validate(), XPoster.Models

### Community 180 - "Entity (Community 180)"
Cohesion: 1.00
Nodes (3): PerplexityOptions.cs, XPoster.Models, PerplexityOptions.cs

### Community 174 - "Entity (Community 174)"
Cohesion: 1.00
Nodes (3): XPoster.Contracts, ContainerStatus.cs, ContainerStatus.cs

### Community 172 - "Entity (Community 172)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, XCredentials.cs, XCredentials.cs

### Community 161 - "Entity (Community 161)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, Validate(), XPoster.Models

### Community 171 - "Entity (Community 171)"
Cohesion: 1.00
Nodes (3): BlobStorageOptions.cs, XPoster.Models, BlobStorageOptions.cs

### Community 173 - "Entity (Community 173)"
Cohesion: 1.00
Nodes (3): LinkedInCredentials.cs, LinkedInCredentials.cs, XPoster.Credentials

### Community 168 - "Entity (Community 168)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, XPoster.Models, FalAiOptions.cs

### Community 170 - "Entity (Community 170)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, DeepSeekOptions.cs, XPoster.Models

### Community 169 - "Entity (Community 169)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, Validate(), XPoster.Models

### Community 163 - "Entity (Community 163)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, if(), CryptoService()

### Community 162 - "Entity (Community 162)"
Cohesion: 0.67
Nodes (3): XCredentialsValidator.cs, XPoster.Credentials, Validate()

### Community 166 - "Entity (Community 166)"
Cohesion: 0.67
Nodes (3): FeedService.cs, FeedService(), if()

### Community 165 - "Entity (Community 165)"
Cohesion: 0.67
Nodes (3): FbSenderResilienceTests.cs, BuildFactory(), BuildCreds()

### Community 164 - "Entity (Community 164)"
Cohesion: 1.00
Nodes (3): InstagramCredentials.cs, XPoster.Credentials, InstagramCredentials.cs

### Community 167 - "Entity (Community 167)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, XPoster.Models, Validate()

### Community 192 - "Entity (Community 192)"
Cohesion: 1.00
Nodes (2): FalAiOptionsValidator.cs, if()

### Community 188 - "Entity (Community 188)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

### Community 187 - "Entity (Community 187)"
Cohesion: 1.00
Nodes (2): PerplexityOptionsValidator.cs, if()

### Community 190 - "Entity (Community 190)"
Cohesion: 1.00
Nodes (2): XCredentialsValidator.cs, if()

### Community 189 - "Entity (Community 189)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

### Community 191 - "Entity (Community 191)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._


# Graph Report - XPoster  (2026-07-30)

## Summary
- 1684 nodes · 2867 edges · 195 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Tests.Helpers` - 2 edges
2. `XPoster.Services` - 2 edges
3. `XPoster.Models` - 2 edges
4. `RSSFeed` - 2 edges
5. `XPoster.Orchestrators` - 2 edges
6. `XPoster.Credentials` - 2 edges
7. `XPoster.Models` - 2 edges
8. `XPoster.Models` - 2 edges
9. `XPoster.Orchestrators` - 2 edges
10. `XPoster.Extensions` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, ParseImageResponseAsync_OpenAi_EmptyDataArray_ReturnsEmptyArray(), ParseImageResponseAsync_FalAi_ValidUrl_ReturnsDownloadedBytes(), ParseImageResponseAsync_OpenAi_EmptyB64JsonValue_ReturnsEmptyArray(), AiServiceHelperTests, ParseChatCompletionResponseAsync_WhenContentIsWhitespaceOnly_ReturnsTrueAndEmpty(), ParseChatCompletionResponseAsync_WhenEmptyChoices_LogsWarningWithProviderName() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.09
Nodes (43): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, XPoster.Tests.Orchestrators, OrchestrateAsync_Should_PassNullMaxTokenBudget_ToPromptRequest(), OrchestrateAsync_Should_PassNullInputTextLabel_ToPromptRequest(), OrchestrateAsync_Should_CreateMessageWithImage_WhenFeedsAreFound(), OrchestrateAsync_Should_ReturnNull_When_TextProviderIsNull(), OrchestrateAsync_Should_ReturnNull_When_SummaryGenerationFails() (+35 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.10
Nodes (41): AzureFoundryServiceTests.cs, AzureFoundryServiceTests.cs, GenerateTextAsync_WhenUsedAsImagePromptDerivationStep_AndChoicesEmpty_ReturnsEmptyString(), GenerateTextAsync_WhenApiReturnsValidResponse_ReturnsContent(), GenerateTextAsync_WhenChoicesIsNull_ReturnsEmptyString(), GenerateTextAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), AzureFoundryService(), if() (+33 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.11
Nodes (36): OpenAiServiceTests.cs, OpenAiServiceTests.cs, BuildPromptRequest(), BuildImagePromptRequest(), GenerateTextAsync_ReplacesInputTextLabelInUserPromptTemplate(), GenerateImageAsync_WhenPromptIsWhitespace_ReturnsEmptyArrayWithoutCallingApi(), GenerateImageAsync_WhenResponseBodyIsMalformedJson_ReturnsEmptyArray(), GenerateImageAsync_WhenDataArrayIsEmpty_ReturnsEmptyArray() (+28 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, Parse_Returns429_ReturnsEmpty(), Parse_OpenAi_MissingDataProperty_ReturnsEmpty(), Parse_Returns429_LogsWarning(), Parse_OpenAi_ValidB64_ReturnsBytes(), Parse_AzureFoundry_MissingBothB64AndUrl_ReturnsEmpty(), Parse_AzureFoundry_MissingDataProperty_ReturnsEmpty(), Parse_AzureFoundry_UrlFallback_DownloadThrows_LogsError() (+24 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, OpenAiOptionsExtensionsTests, ConfigurationBuilder(), new(), DeepSeekOptionsExtensionsTests, FalAiOptionsExtensionsTests, SectionName_IsDeepSeek() (+21 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.14
Nodes (28): PerplexityServiceTests.cs, PerplexityServiceTests.cs, GenerateTextAsync_WhenMaxOutputLengthIsNull_CallsApiOnce(), GenerateTextAsync_WhenChoicesIsNull_ReturnsEmptyString(), GenerateTextAsync_WhenInputTextLabelIsNull_FallsBackToDefaultLabel(), GenerateTextAsync_WhenFirstResponseStillTooLong_RetriesAndReturnsSecondResponse(), GenerateTextAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GenerateTextAsync_UsesCustomInputTextLabel_InUserPromptSubstitution() (+20 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.15
Nodes (26): FbSenderTests.cs, FbSenderTests.cs, BuildCreds(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), BuildSender(), Constructor_InitializesCorrectly(), Constructor_WithNullBlobStorage_ThrowsArgumentNullException(), SendAsync_WithCaptionExceedingMaxLength_TruncatesAndPublishes() (+18 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.16
Nodes (25): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, GenerateTextAsync_WhenChoicesIsNull_ForImagePromptRole_ReturnsEmptyString(), GenerateTextAsync_WhenChoicesIsNull_ReturnsEmptyString(), GenerateTextAsync_WhenNoMaxOutputLength_DoesNotRetryRegardlessOfLength(), GenerateTextAsync_WhenResponseFitsWithinMaxOutputLength_ReturnsSingleCallResult(), ChatCompletionJson(), GenerateTextAsync_AppliesCustomInputTextLabel_InUserTemplate() (+17 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.09
Nodes (22): OrchestratorFactoryTests.cs, PowerLawProfile(), DefaultSlotProfileProvider_Should_NotContainDryRunProfile(), FeedProfile(), PowerLawOrchestrator_SupportedPlatforms_ContainsXAndLinkedIn(), Resolve_Should_ResolveInSender_WhenProfileUsesLinkedIn(), Resolve_Should_ResolveFbSender_WhenProfileUsesFacebook(), Resolve_Should_ResolveIgSender_WhenProfileUsesInstagram() (+14 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.19
Nodes (21): XSenderTests.cs, XSenderTests.cs, SendAsync_PostWithImage_CatchesTwitterException_ReturnsFalse(), SendAsync_ValidPost_TriesTwitterAndReturnsFalse(), SendAsync_ValidTextPost_CatchesTwitterException_ReturnsFalse(), SendAsync_WhenTwitterContextThrows_ReturnsFalse(), XSender_ImplementsISender(), SendAsync_WithBlankContent_ReturnsFalseAndLogsWarning() (+13 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.20
Nodes (19): FeedPromptOptionsTests.cs, FeedPromptOptionsTests.cs, FeedPromptOptions_ValueEquality_DifferentStepCount_AreNotEqual(), FeedPromptOptions_IsImmutable_AfterConstruction(), FeedPromptOptions_Steps_PreservesOrder(), FeedPromptOptions_Steps_AreSetCorrectly(), FeedPromptOptions_Steps_CanBeASingleStep(), MakeStep() (+11 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.22
Nodes (18): IgSenderImageFlowTests.cs, IgSenderImageFlowTests.cs, NormalizeImage_WithValidPng_ReturnsJpegBytes(), return(), SendAsync_WhenBlobUploadSucceeds_CreatesMediaContainerWithCorrectSasUrl(), SendAsync_WhenJsonResponseMissingIdProperty_ReturnsFalse(), SendAsync_WhenJsonResponseIdIsEmpty_ReturnsFalse(), NormalizeImage_WithValidJpeg_ReturnsSameBytes() (+10 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.22
Nodes (18): AiServiceHelperChatPayloadTests.cs, AiServiceHelperChatPayloadTests.cs, BuildChatPayload_SystemMessage_NoPlaceholder_IsUnchanged(), BuildChatPayload_InterpolatesMaxCharsInSystemMessage(), BuildChatPayload_SubstitutesCustomLabelInUserMessage(), BuildChatPayload_MessagesContainsTwoEntries(), BuildChatPayload_SecondMessageRoleIsUser(), BuildChatPayload_ForwardsTemperature() (+10 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, SendAsync(), GetFeedsAsync_ReturnsEmpty_WhenFeedIsInvalidXml(), GetFeedsAsync_ReturnsFeedsFromCache_IfPresent(), new(), GetFeedsAsync_ReturnsEmpty_WhenHttpFails(), FakeHttpMessageHandler() (+10 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.22
Nodes (18): AiProviderOptionsAbstractionTests.cs, AiProviderOptionsAbstractionTests.cs, DeepSeekOptions_ImplementsIAiProviderOptions(), AzureFoundryOptions_ModelCatalog_ExposesTextAndImage(), AzureFoundryOptions_ImplementsIAiProviderOptions(), AiProviderOptionsAbstractionTests, PerplexityOptions_ModelCatalog_ExposesTextOnly(), OpenAiOptions_ApiKeyAndEndpoint_AccessibleThroughAbstraction() (+10 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.23
Nodes (17): MetaPublishingServiceTests.cs, MetaPublishingServiceTests.cs, XPoster.Tests.Services, PublishContainerAsync_WhenIdIsNull_ReturnsEmptyString(), PublishContainerAsync_WhenRateLimited_Throws(), PublishContainerAsync_WhenResponseBodyIsNull_ThrowsJsonException(), PublishContainerAsync_WithWhitespaceCreationId_ThrowsArgumentException(), PublishContainerAsync_WhenOk_ReturnsPublishId() (+9 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.23
Nodes (17): PromptStepOptionsTests.cs, PromptStepOptionsTests.cs, PromptStepOptions_NonImageSteps_ImageProperties_AreNull(), PromptStepOptions_ImageGenerationStep_ImageProperties_AreIndependent(), PromptStepOptions_AllRoles_CanBeConstructed(), PromptStepOptions_IsImmutable_AfterConstruction(), PromptStepOptions_ValueEquality_DifferentRole_AreNotEqual(), PromptStepOptions_OptionalProperties_DefaultToNull() (+9 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.23
Nodes (17): PromptRequestTests.cs, PromptRequestTests.cs, ImagePromptRequest_ImageProperties_DefaultToNull(), ImagePromptRequest_ValueEquality_SameValues_AreEqual(), ImagePromptRequest_IsImmutable_AfterConstruction(), ImagePromptRequest_InheritsFrom_PromptRequest(), PromptRequest_IsImmutable_AfterConstruction(), PromptRequest_OptionalProperties_AreSetCorrectly() (+9 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.24
Nodes (16): InMemoryContainerStateStoreTests.cs, InMemoryContainerStateStoreTests.cs, UpdateStatusAsync_WithEmptyOrWhitespaceCreationId_ThrowsArgumentException(), SaveAsync_WithNullCreationId_ThrowsArgumentNullException(), UpdateStatusAsync_WhenEntryDoesNotExist_AddsNonPendingEntryWithEmptyBlobName(), UpdateStatusAsync_CanMoveEntryBackToPending(), UpdateStatusAsync_WhenEntryExists_UpdatesStatusAndRemovesItFromPending(), SaveAsync_WithValidInputs_StoresPendingEntry() (+8 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.26
Nodes (15): PromptRoleTests.cs, PromptRoleTests.cs, PromptRole_HasExactlyThreeMembers(), PromptRole_DefinedMember_IsDefined(), PromptRole_BackingValue_IsStable(), PromptRole_UsedAsDictionaryKey_LookupSucceeds(), PromptRoleTests, XPoster.Tests.Models (+7 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.26
Nodes (15): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WhenNoImage_ReturnsFalseWithoutCallingApi(), SendAsync_WhenImageUploadNotImplemented_ReturnsFalseAndLogsError(), PostWithImage(), SendAsync_WhenHttpClientThrows_ReturnsFalse(), PostWithoutImage() (+7 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.26
Nodes (15): DefaultSlotProfileProviderTests.cs, DefaultSlotProfileProviderTests.cs, FeedOrchestratorSlot_Should_HaveTextProviderConfigured(), DefaultSlotProfileProviderTests, FeedOrchestratorSlot_Should_HaveDistinctTextAndImageProviders(), FeedOrchestratorSlot_Should_HaveAtLeastOneSender(), FeedOrchestratorSlot_Should_ContainLinkedInAndX(), FeedOrchestratorSlot_Should_HaveImageProviderConfigured() (+7 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.26
Nodes (15): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, XPoster.Tests.Models, Constructor_Should_SetTextProvider_And_NullImageProvider_WhenOnlyTextProviderSupplied(), typeof(), OrchestratorContextKey_Should_BeSet_WhenProvided(), OrchestratorContextKey_Should_BeNull_WhenNotProvided(), TwoSlotsWithSameOrchestratorType_Should_CarryIndependentContextKeys() (+7 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.26
Nodes (15): MaskUrlTelemetryProcessorTests.cs, MaskUrlTelemetryProcessorTests.cs, Initialize_WhenFacebookUrlHasAccessToken_TokenIsMasked(), MaskUrlTelemetryProcessorTests, Initialize_WhenFacebookUrlHasNoAccessToken_DataUnchanged(), Initialize_WhenFacebookUrlHasOnlyAccessToken_TokenIsMasked(), Initialize_WhenTelemetryIsNotDependency_DoesNothing(), Initialize_WhenHttpDependencyNotFacebook_DoesNotModifyData() (+7 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.26
Nodes (15): BlobStorageServiceTests.cs, BlobStorageServiceTests.cs, XPoster.Tests.Services, DeleteAsync_WhenBlobExists_DeletesSuccessfully(), UploadAsync_WhenContainerDoesNotExist_CreatesItAndUploads(), UploadAsync_WhenBlobClientSucceeds_ReturnsSasUri(), DeleteAsync_WithNullBlobName_ThrowsArgumentException(), UploadAsync_WhenStorageThrows_PropagatesException() (+7 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.26
Nodes (15): AddAiProviderOptionsTests.cs, AddAiProviderOptionsTests.cs, BuildAllProvidersConfig(), ConfigurationBuilder(), XPoster.Tests.Extensions, AddAiProviderOptions_BindsAzureFoundryOptions_FromCorrectSection(), AddAiProviderOptions_ReturnsSameServiceCollection(), AddAiProviderOptions_BindsFalAiOptions_FromCorrectSection() (+7 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.13
Nodes (15): DryRunSenderTests.cs, SendAsync_WhenProbeKeyMissing_ReturnsFalse(), ConfigurationBuilder(), Constructor_WithNullConfiguration_ThrowsArgumentNullException(), SendAsync_WhenKeyMissing_ReturnsFalse(), DryRunSender_ImplementsISender(), new(), DryRunSender() (+7 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, Post_CanHold_ImageBytes(), RSSFeed_CanBeCreated_WithAllProperties(), Post_Firm_ContainsExpectedHashtags(), RSSFeed_PublishDate_DefaultsToMinValue(), XPoster.Tests.Models, Message_CanBeCreated_WithContent() (+6 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.27
Nodes (14): XPosterContainerPollingFunction.cs, XPosterContainerPollingFunction.cs, foreach(), catch(), XPoster, HandleTerminalFailureAsync(), ProcessContainerAsync(), if() (+6 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_ImageModelNameWithAllowedSpecialChars_Succeeds(), FalAiOptionsValidatorTests, Validate_BothRequiredFieldsMissing_ReportsBothFailures(), Validate_MissingApiKey_Fails(), Validate_ValidOptions_Succeeds(), Validate_MissingModelId_Fails() (+5 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProvider(), GetCurrentTime_WhenForceHourIsValid_ReturnsUtcKind(), LocalOverrideTimeProviderTests, XPoster.Tests.Providers, GetCurrentTime_WhenForceHourIsValid_ReturnsForcedHour(), BuildProvider() (+5 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.29
Nodes (13): AiModelCatalogTests.cs, AiModelCatalogTests.cs, TryGet_ReturnsTrueAndPopulatesModelName_WhenSupported(), Constructor_NullDictionary_Throws(), Empty_SupportsNoModelClass(), TryGet_ReturnsFalseAndNullModelName_WhenNotSupported(), Supports_ReturnsFalseForMissingModelClass(), Supports_ReturnsTrueForRegisteredModelClass() (+5 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.15
Nodes (13): InSenderTests.cs, SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn(), XPoster.Tests.SenderPlugins, SendAsync_WithImage_WhenRegisterUploadFails_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), SendAsync_TextOnly_WithPersonCode_UsesPersonUrn(), BuildCreds(), BuildSender() (+5 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.15
Nodes (13): FalAiImageServiceTests.cs, FalAiImageServiceTests, FalImageJson(), BuildService(), GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray(), GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray(), XPoster.Tests.Services, GenerateImageAsync_ModelIdWithUnsafeChars_PercentEncodesInRequestUri() (+5 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.32
Nodes (12): AzureFoundryService.cs, AzureFoundryService.cs, while(), GenerateImageAsync(), AzureFoundryService(), var(), catch(), GetChatCompletionsEndpoint() (+4 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, GenerateImageAsync_RequestUsesImageQuantityFromRequest(), GenerateImageAsync_MalformedJson_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithMultipleSegments_PreservesSlashesInUri(), GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray(), FalAiImageService(), GenerateImageAsync_EmptyUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_Returns429_LogsWarning() (+4 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.17
Nodes (12): InSenderTests.cs, SendAsync_WithEmptyContent_ReturnsFalseAndLogsWarning(), SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse(), SendAsync_ValidPost_TriesLinkedInAndReturnsFalse(), MessageMaxLength_Returns2800(), SendAsync_TextOnly_WithOrgId_UsesOrganizationUrn(), InSender(), Constructor_InitializesCorrectly() (+4 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.17
Nodes (12): XPosterContainerPollingFunctionTests.cs, XPosterContainerPollingFunctionTests, RunAsync_WhenCancelledDuringForEach_StopsGracefully(), XPoster.Tests, RunAsync_WhenMultiplePendingContainers_ProcessesAll(), RunAsync_WhenNoPendingContainers_DoesNothing(), RunAsync_WhenStatusIsUnknown_LogsWarningAndSkips(), RunAsync_WhenUnexpectedExceptionThrown_LogsErrorAndRethrows() (+4 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.32
Nodes (12): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully(), GenerateAsync_Should_HandleNegativeOrZeroCryptoValue(), XPoster.Tests.Orchestrators, new(), PowerLawOrchestratorTests(), OrchestrateAsync_BroadcastsSamePost_ToAllSenders() (+4 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.32
Nodes (12): ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests.cs, GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsPropertyIsNull(), ConfigurationTagReplacementProvider(), GetReplacements_Should_ReturnConfiguredReplacements_When_OptionsContainsEntries(), GetReplacements_Should_PreserveAllEntries_When_MultipleReplacementsConfigured(), Constructor_Should_Throw_When_OptionsIsNull(), ConfigurationTagReplacementProviderTests (+4 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.17
Nodes (12): DryRunSenderTests.cs, Platform_ReturnsDryRun(), BuildSender(), Constructor_WithNullLogger_ThrowsArgumentNullException(), DryRunSenderTests(), MessageMaxLength_ReturnsIntMaxValue(), SendAsync_WhenKeyWhitespace_ReturnsFalse(), SendAsync_WhenProbeKeyMissing_LogsError() (+4 more)

### Community 46 - "Entity (Community 46)"
Cohesion: 0.18
Nodes (11): OrchestratorFactoryTests.cs, new(), OrchestratorFactoryTests(), NoOrchestrator_SupportedPlatforms_IsEmpty(), Resolve_Should_NotRequestTextProvider_WhenProfileHasNoTextProvider(), SetupMocksForOrchestratorFactory(), Resolve_Should_RequestImageProviderKey_WhenProfileSpecifiesImageProvider(), typeof() (+3 more)

### Community 45 - "Entity (Community 45)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), SendAsync_WhenLinkedInReturns200_ReturnsTrue(), ValidPost(), SendAsync_WhenLinkedInReturns503_ReturnsFalseAndLogsError(), XPoster.Tests.SenderPlugins, SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue() (+3 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.35
Nodes (11): ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProviderTests.cs, Constructor_Should_Throw_When_OptionsIsNull(), ConfigurationFeedUrlProviderTests, ConfigurationFeedUrlProvider(), GetFeedUrls_Should_ReturnEmptyList_When_UrlsPropertyIsNull(), GetFeedUrls_Should_ReturnReadOnlyList(), GetFeedUrls_Should_ReturnUrlsInOrder_When_MultipleUrlsConfigured() (+3 more)

### Community 44 - "Entity (Community 44)"
Cohesion: 0.35
Nodes (11): AiProviderServiceCollectionExtensionsTests.cs, AiProviderServiceCollectionExtensionsTests.cs, AddXPosterAiProviders_RegistersFalAi_AsImageOnly(), AddXPosterAiProviders_RegistersOpenAi_AsTextAndImageProvider(), AddXPosterAiProviders_ReturnsSameServiceCollection(), AddXPosterAiProviders_RegistersPerplexity_AsTextOnly(), XPoster.Tests.Extensions, AiProviderServiceCollectionExtensionsTests (+3 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.18
Nodes (11): IgSenderTests.cs, new(), XPoster.Tests.SenderPlugins, Constructor_WithNullContainerStateStore_ThrowsArgumentNullException(), Constructor_WithNullHttpClientFactory_ThrowsArgumentNullException(), Constructor_WithNullLogger_ThrowsArgumentNullException(), MessageMaxLength_Returns2200(), Platform_ReturnsInstagram() (+3 more)

### Community 47 - "Entity (Community 47)"
Cohesion: 0.38
Nodes (10): FbSender.cs, FbSender.cs, catch(), FbSender(), PublishPhotoAsync(), PublishTextOnlyAsync(), XPoster.SenderPlugins, SendAsync() (+2 more)

### Community 54 - "Entity (Community 54)"
Cohesion: 0.38
Nodes (10): IgSenderSendAsyncTests.cs, IgSenderSendAsyncTests.cs, SendAsync_WithEmptyImageArray_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithCaptionExceedingMaxLength_TruncatesCaption(), SendAsync_WithNoImage_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), IgSender() (+2 more)

### Community 48 - "Entity (Community 48)"
Cohesion: 0.38
Nodes (10): MetaPublishingService.cs, MetaPublishingService.cs, GetContainerStatusAsync(), catch(), GetApiVersion(), if(), HttpRequestException(), MetaPublishingService() (+2 more)

### Community 53 - "Entity (Community 53)"
Cohesion: 0.38
Nodes (10): XFunctionTests.cs, XFunctionTests.cs, Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), Run_Should_LogError_When_OrchestrateAsync_ReturnsEmptyDictionary(), Run_Should_LogWarning_AndNotRethrow_When_CancelledGracefully(), Run_Should_LogError_When_PostAsync_ReturnsFalse(), Run_Should_Rethrow_When_Factory_Throws(), XPoster.Tests (+2 more)

### Community 50 - "Entity (Community 50)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, SupportedPlatforms_IsEmpty(), OrchestrateAsync_ReturnsEmptyList(), SendIt_Set_ThrowsNotImplementedException(), SendIt_IsAlwaysFalse(), Name_IsNoOrchestrator(), NoOrchestratorTests (+2 more)

### Community 49 - "Entity (Community 49)"
Cohesion: 0.38
Nodes (10): FbSenderSendAsyncTests.cs, FbSenderSendAsyncTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), SendAsync_WithNullImage_PublishesTextOnly_ReturnsTrue(), SendAsync_WithEmptyImage_PublishesTextOnly_ReturnsTrue(), FbSenderSendAsyncTests, BuildFactory() (+2 more)

### Community 52 - "Entity (Community 52)"
Cohesion: 0.38
Nodes (10): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests, Validate_WithValidOptions_ReturnsSuccess(), Validate_WhenTextModelNameIsEmpty_ReturnsFailed(), Validate_WithMultipleInvalidFields_ReturnsAllFailures(), Validate_WhenEndpointIsEmpty_ReturnsFailed(), Validate_WhenApiKeyIsEmpty_ReturnsFailed() (+2 more)

### Community 51 - "Entity (Community 51)"
Cohesion: 0.38
Nodes (10): XSenderResilienceTests.cs, XSenderResilienceTests.cs, XSenderResilienceTests, SendAsync_WhenTextTweetFails_ReturnsFalseAndLogsError(), SendAsync_WhenPostIsNull_ReturnsFalseAndLogsWarning(), BuildSender(), SendAsync_WhenContentIsBlank_ReturnsFalseAndLogsWarning(), XPoster.Tests.SenderPlugins (+2 more)

### Community 55 - "Entity (Community 55)"
Cohesion: 0.42
Nodes (9): HttpClientExtensionsTests.cs, HttpClientExtensionsTests.cs, foreach(), AddHttpClients_RegistersExpectedNamedClients(), AddHttpClients_ReturnsSameServiceCollection(), AddHttpClients_RegistersIHttpClientFactory(), AddHttpClients_CanCreateAllExpectedNamedClients(), XPoster.Tests.Extensions (+1 more)

### Community 59 - "Entity (Community 59)"
Cohesion: 0.42
Nodes (9): FacebookResiliencePipelineTests.cs, FacebookResiliencePipelineTests.cs, XPoster.Tests.Integration, Polly_Facebook_RetriesOn429_AndEventuallySucceeds(), Polly_Facebook_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_Facebook_AttemptTimeout_CancelsSlowRequest(), for(), catch() (+1 more)

### Community 58 - "Entity (Community 58)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, XSenderSendAsyncTests(), SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse() (+1 more)

### Community 57 - "Entity (Community 57)"
Cohesion: 0.22
Nodes (9): InSender.cs, Exception(), generatePayLoad(), SendAsync(), XPoster.SenderPlugins, ResolveAuthorUrn(), using(), InvalidOperationException() (+1 more)

### Community 61 - "Entity (Community 61)"
Cohesion: 0.22
Nodes (9): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_WhenSenderListIsEmpty(), PostAsync_ReturnsTrue_When_AllConditionsMet(), XPoster.Tests.Orchestrators, PostAsync_SkipsNullPost_ReturnsFalse(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_ReturnsFalse_WhenOneSenderFails(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace() (+1 more)

### Community 62 - "Entity (Community 62)"
Cohesion: 0.22
Nodes (9): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenStatusIsExpired_MarksFailedAndCleansUp(), RunAsync_WhenPublishFails_MarksFailedAndCleansUp(), RunAsync_WhenCancelled_StopsGracefully(), RunAsync_WhenBlobDeleteFails_StillUpdatesStatus(), PendingContainer(), CreateTimerInfo(), RunAsync_WhenStatusIsFinished_PublishesAndCleansUp() (+1 more)

### Community 56 - "Entity (Community 56)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, var(), BuildProviderWithHandler(), BuildSequenceHandler(), HttpResponseMessage(), BuildDelayedHandler(), params() (+1 more)

### Community 67 - "Entity (Community 67)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, CryptoServiceTests, CryptoService(), GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), XPoster.Tests.Services, MakeService(), GetCryptoValue_ReturnsParsedValue_WhenNumericString() (+1 more)

### Community 66 - "Entity (Community 66)"
Cohesion: 0.42
Nodes (9): FeedOrchestrator.cs, FeedOrchestrator.cs, catch(), foreach(), if(), FeedOrchestrator(), BuildPromptRequest(), XPoster.Orchestrators (+1 more)

### Community 65 - "Entity (Community 65)"
Cohesion: 0.22
Nodes (9): FbSenderImageFlowTests.cs, SendAsync_WhenPhotoPublishThrows_FallsBackToTextOnly(), BuildFactory(), SendAsync_WhenImageNormalizationFails_FallsBackToTextOnly(), InvalidImageBytes(), FbSenderImageFlowTests, BuildCreds(), HttpRequestException() (+1 more)

### Community 60 - "Entity (Community 60)"
Cohesion: 0.42
Nodes (9): AiModelCatalog.cs, AiModelCatalog.cs, AiModelCatalog(), Supports(), InvalidOperationException(), XPoster.Models, if(), GetRequired() (+1 more)

### Community 64 - "Entity (Community 64)"
Cohesion: 0.22
Nodes (9): FbSenderResilienceTests.cs, SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WhenTextPublishReturns200WithoutId_ReturnsFalse(), SendAsync_WhenTextPublishReturns200WithId_ReturnsTrue(), SendAsync_WhenTextPublishReturns200WithEmptyId_ReturnsFalse(), SendAsync_WhenFacebookReturns503_ReturnsFalseAndLogsError(), HttpResponseMessage() (+1 more)

### Community 63 - "Entity (Community 63)"
Cohesion: 0.42
Nodes (9): RSSFeedTests.cs, RSSFeedTests.cs, RSSFeedTests, XPoster.Tests.Models, RSSFeed_CanSetPublishDate(), RSSFeed_DefaultPublishDateIsMinValue(), RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_RecordEquality_SameValues_AreEqual() (+1 more)

### Community 69 - "Entity (Community 69)"
Cohesion: 0.46
Nodes (8): AIResponse.cs, AIResponse.cs, ImageData, Message, OpenAIImageResponse, XPoster.Models, AIResponse, Choice

### Community 71 - "Entity (Community 71)"
Cohesion: 0.46
Nodes (8): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), ValidOptions(), Validate_ValidOptions_Succeeds(), Validate_MissingRequiredProperties_Fails(), XPoster.Tests.Models, DeepSeekOptionsValidatorTests

### Community 70 - "Entity (Community 70)"
Cohesion: 0.46
Nodes (8): PostTests.cs, PostTests.cs, XPoster.Tests.Models, Post_EmptyContent_IsAllowed(), Post_CanSetAndGetAllProperties(), Firm_IsNotNullOrEmpty(), PostTests, Post_DefaultImageIsNull()

### Community 72 - "Entity (Community 72)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, XPoster.Tests.Integration, CaptureLogger(), CaptureLoggerProvider(), Dispose(), CreateLogger(), IsEnabled()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.46
Nodes (8): BlobStorageService.cs, BlobStorageService.cs, UploadAsync(), BlobStorageService(), if(), DeleteAsync(), BlobUploadResult(), XPoster.Services

### Community 73 - "Entity (Community 73)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, GetLabel_DescriptionMatchesEnumName(), XPoster.Tests.Contracts, AiProviderExtensionsTests, GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(), GetLabel_UnknownProvider_ReturnsFallbackToString(), GetLabel_DescriptionDiffersFromEnumName()

### Community 78 - "Entity (Community 78)"
Cohesion: 0.25
Nodes (8): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), PostAsync_ReturnsFalse_WhenSenderPlatformNotInDictionary(), TestOrchestrator(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), PostAsync_DispatchesEachPostToAlignedSender(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), BaseOrchestratorTests()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, SendAsync_WithNullPost_ReturnsFalse(), InSenderSendAsyncTests(), SendAsync_WithEmptyContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse()

### Community 75 - "Entity (Community 75)"
Cohesion: 0.25
Nodes (8): AiServiceHelper.cs, BuildChatPayload(), ExtractAzureFoundryBytesAsync(), ExtractFalAiBytesAsync(), ParseImageResponseAsync(), XPoster.Services, ExtractOpenAiBytes(), LogAndReturnEmpty()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.25
Nodes (8): FeedOrchestratorFeedUrlProviderTests.cs, OrchestrateAsync_Should_CallGetFeedsAsync_With_Correct_Urls(), OrchestrateAsync_Should_CallGetFeedsAsync_For_Each_Url(), OrchestrateAsync_Should_PassSenderMessageMaxLength_As_MaxOutputLength_In_SummaryRequest(), OrchestrateAsync_Should_AggregateFeeds_From_All_Urls(), XPoster.Tests.Providers, OrchestrateAsync_Should_ReturnEmpty_And_DisableSendIt_When_ContextHasNoFeedUrls(), OrchestrateAsync_TwoSlots_Should_UseDifferentFeedUrls_Independently()

### Community 68 - "Entity (Community 68)"
Cohesion: 0.46
Nodes (8): FalAiImageService.cs, FalAiImageService.cs, FalAiImageService(), catch(), if(), XPoster.Services, GetImageGenerationEndpoint(), GenerateImageAsync()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.52
Nodes (7): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, Validate_ValidOptions_Succeeds(), AzureFoundryOptionsValidatorTests, Validate_MissingRequiredProperties_Fails(), XPoster.Tests.Models, ValidOptions()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.52
Nodes (7): XFunction.cs, XFunction.cs, XPoster, XFunction(), Run(), catch(), if()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.52
Nodes (7): TagReplacementService.cs, TagReplacementService.cs, XPoster.Services, foreach(), Apply(), if(), TagReplacementService()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.29
Nodes (7): CredentialsStartupValidator.cs, Validate(), CredentialsStartupValidator(), InvalidOperationException(), if(), catch(), XPoster.Credentials

### Community 83 - "Entity (Community 83)"
Cohesion: 0.52
Nodes (7): IContainerStateStore.cs, IContainerStateStore.cs, UpdateStatusAsync(), XPoster.Contracts, GetPendingAsync(), IContainerStateStore, SaveAsync()

### Community 87 - "Entity (Community 87)"
Cohesion: 0.52
Nodes (7): Program.cs, Program.cs, BlobServiceClient(), DryRunSlotProfileProvider(), if(), Uri(), DefaultAzureCredential()

### Community 85 - "Entity (Community 85)"
Cohesion: 0.29
Nodes (7): OrchestratorFactory.cs, catch(), foreach(), XPoster.Orchestrators, Resolve(), return(), typeof()

### Community 86 - "Entity (Community 86)"
Cohesion: 0.29
Nodes (7): OpenAiService.cs, catch(), GenerateImageAsync(), while(), XPoster.Services, var(), GenerateTextAsync()

### Community 81 - "Entity (Community 81)"
Cohesion: 0.29
Nodes (7): FbSenderImageFlowTests.cs, SendAsync_WithSupportedImage_UploadsPublishesPhotoAndDeletesBlob(), SendAsync_WhenUploadThrows_FallsBackToTextOnly(), CreateValidJpegBytes(), if(), SendAsync_WhenDeleteFails_AfterSuccessfulPhotoPublish_ReturnsTrue(), HttpResponseMessage()

### Community 89 - "Entity (Community 89)"
Cohesion: 0.52
Nodes (7): InMemoryContainerStateStore.cs, InMemoryContainerStateStore.cs, UpdateStatusAsync(), GetPendingAsync(), InMemoryContainerStateStore, SaveAsync(), XPoster.Services

### Community 88 - "Entity (Community 88)"
Cohesion: 0.52
Nodes (7): IgSender.cs, IgSender.cs, SendAsync(), XPoster.SenderPlugins, catch(), if(), IgSender()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.33
Nodes (6): FeedOrchestratorFeedUrlProviderTests.cs, new(), FeedOrchestratorFeedUrlProviderTests(), BuildContext(), CreateOrchestrator(), SetupHappyPathProviders()

### Community 96 - "Entity (Community 96)"
Cohesion: 0.60
Nodes (6): IMetaPublishingService.cs, IMetaPublishingService.cs, PublishContainerAsync(), GetContainerStatusAsync(), IMetaPublishingService, XPoster.Contracts

### Community 97 - "Entity (Community 97)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, var(), MakeNoOpClient(), HttpClient(), MakeDownloadClient(), JsonResponse()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.60
Nodes (6): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests, AzureFoundryOptions_DoesNotExpose_ApiVersionProperty(), AzureFoundryOptions_Defaults_AreCorrect(), XPoster.Tests.Models

### Community 90 - "Entity (Community 90)"
Cohesion: 0.33
Nodes (6): IgSenderTests.cs, IgSender_ImplementsISender(), IgSender(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), IgSenderTests(), Constructor_WithNullBlobStorageService_ThrowsArgumentNullException()

### Community 91 - "Entity (Community 91)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, XPoster.Tests.Providers, GetCurrentTime_ReturnsUtcTime(), TimeProviderTests, GetCurrentTime_ReturnsCurrentDateTime()

### Community 95 - "Entity (Community 95)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, SendAsync(), if(), DryRunSender(), XPoster.SenderPlugins

### Community 94 - "Entity (Community 94)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, Polly_AiClient_AttemptTimeout_CancelsSlowRequest(), XPoster.Tests.Integration, StringContent(), Polly_AiClient_RetriesOn429_AndEventuallySucceeds()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration, Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), for(), Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest()

### Community 104 - "Entity (Community 104)"
Cohesion: 0.60
Nodes (6): DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider.cs, XPoster.Providers, ScheduledOrchestrationProfile(), GetProfiles(), DryRunSlotProfileProvider()

### Community 102 - "Entity (Community 102)"
Cohesion: 0.60
Nodes (6): PerplexityOptionsValidator.cs, PerplexityOptionsValidator.cs, Validate(), nameof(), XPoster.Models, if()

### Community 103 - "Entity (Community 103)"
Cohesion: 0.60
Nodes (6): AzureFoundryOptionsValidator.cs, AzureFoundryOptionsValidator.cs, XPoster.Models, Validate(), nameof(), if()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.60
Nodes (6): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, XPoster.Tests.Models, DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptionsTests, DeepSeekOptions_Defaults_AreCorrect()

### Community 99 - "Entity (Community 99)"
Cohesion: 0.60
Nodes (6): TagReplacementServiceTests.cs, TagReplacementServiceTests.cs, Apply_Replaces_Only_First_Occurrence_For_Each_Word(), Apply_Does_Not_Replace_Words_Already_Prefixed_With_Hashtag(), Apply_Returns_Input_Unchanged_When_Text_Is_Empty_Or_Whitespace(), XPoster.Tests.Services

### Community 100 - "Entity (Community 100)"
Cohesion: 0.60
Nodes (6): IBlobStorageService.cs, IBlobStorageService.cs, UploadAsync(), IBlobStorageService, XPoster.Contracts, DeleteAsync()

### Community 107 - "Entity (Community 107)"
Cohesion: 0.60
Nodes (6): FacebookCredentialsValidator.cs, FacebookCredentialsValidator.cs, Validate(), FacebookCredentialsValidator, if(), XPoster.Credentials

### Community 105 - "Entity (Community 105)"
Cohesion: 0.60
Nodes (6): OpenAiOptionsValidator.cs, OpenAiOptionsValidator.cs, if(), XPoster.Models, nameof(), Validate()

### Community 106 - "Entity (Community 106)"
Cohesion: 0.60
Nodes (6): DeepSeekOptionsValidator.cs, DeepSeekOptionsValidator.cs, nameof(), if(), Validate(), XPoster.Models

### Community 108 - "Entity (Community 108)"
Cohesion: 0.60
Nodes (6): InstagramCredentialsValidator.cs, InstagramCredentialsValidator.cs, if(), Validate(), XPoster.Credentials, InstagramCredentialsValidator

### Community 126 - "Entity (Community 126)"
Cohesion: 0.70
Nodes (5): PromptRequest.cs, PromptRequest.cs, ImagePromptRequest, PromptRequest, XPoster.Models

### Community 121 - "Entity (Community 121)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, TimeProvider, XPoster.Providers, GetCurrentTime()

### Community 124 - "Entity (Community 124)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider(), XPoster.Providers, GetCurrentTime()

### Community 125 - "Entity (Community 125)"
Cohesion: 0.70
Nodes (5): ITagReplacementProvider.cs, ITagReplacementProvider.cs, XPoster.Contracts, ITagReplacementProvider, GetReplacements()

### Community 123 - "Entity (Community 123)"
Cohesion: 0.70
Nodes (5): ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider(), XPoster.Providers, GetReplacements()

### Community 122 - "Entity (Community 122)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, if(), XPoster.Orchestrators, PowerLawOrchestrator()

### Community 131 - "Entity (Community 131)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, XPoster.Contracts, GenerateImageAsync(), ITextToImageProvider

### Community 127 - "Entity (Community 127)"
Cohesion: 0.70
Nodes (5): AiProviderValidationHelper.cs, AiProviderValidationHelper.cs, XPoster.Models, ValidateConnectivity(), if()

### Community 130 - "Entity (Community 130)"
Cohesion: 0.70
Nodes (5): LinkedInCredentialsValidator.cs, LinkedInCredentialsValidator.cs, XPoster.Credentials, Validate(), if()

### Community 128 - "Entity (Community 128)"
Cohesion: 0.70
Nodes (5): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, XPoster.Tests.Models, ValidOptions(), OpenAiOptionsValidatorTests

### Community 129 - "Entity (Community 129)"
Cohesion: 0.70
Nodes (5): MaskUrlTelemetryProcessor.cs, MaskUrlTelemetryProcessor.cs, if(), Process(), MaskUrlTelemetryProcessor()

### Community 116 - "Entity (Community 116)"
Cohesion: 0.70
Nodes (5): ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider.cs, XPoster.Providers, GetFeedUrls(), ConfigurationFeedUrlProvider()

### Community 120 - "Entity (Community 120)"
Cohesion: 0.40
Nodes (5): PerplexityService.cs, if(), var(), XPoster.Services, GenerateTextAsync()

### Community 117 - "Entity (Community 117)"
Cohesion: 0.40
Nodes (5): DeepSeekService.cs, if(), GenerateTextAsync(), var(), XPoster.Services

### Community 119 - "Entity (Community 119)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, XPoster.Contracts, ISender, SendAsync()

### Community 118 - "Entity (Community 118)"
Cohesion: 0.40
Nodes (5): FeedService.cs, catch(), Exception(), GetFeedsAsync(), XPoster.Services

### Community 138 - "Entity (Community 138)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, GetFeedsAsync(), IFeedService, XPoster.Contracts

### Community 139 - "Entity (Community 139)"
Cohesion: 0.70
Nodes (5): ImageTestData.cs, ImageTestData.cs, CreateValidJpeg(), CreateValidPng(), XPoster.Tests.Helpers

### Community 140 - "Entity (Community 140)"
Cohesion: 0.70
Nodes (5): ITagReplacementService.cs, ITagReplacementService.cs, Apply(), ITagReplacementService, XPoster.Contracts

### Community 137 - "Entity (Community 137)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, Resolve(), IOrchestratorFactory, XPoster.Contracts

### Community 132 - "Entity (Community 132)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, ITimeProvider, XPoster.Contracts, GetCurrentTime()

### Community 133 - "Entity (Community 133)"
Cohesion: 0.40
Nodes (5): OrchestratorFactory.cs, OrchestratorFactory(), InvalidOperationException(), if(), CreateOrchestratorInstance()

### Community 134 - "Entity (Community 134)"
Cohesion: 0.40
Nodes (5): OpenAiService.cs, if(), GetImageGenerationEndpoint(), OpenAiService(), GetChatCompletionsEndpoint()

### Community 135 - "Entity (Community 135)"
Cohesion: 0.70
Nodes (5): IAiProviderOptions.cs, IAiProviderOptions.cs, IAiProviderOptions, XPoster.Contracts, IAiProviderSection

### Community 136 - "Entity (Community 136)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, XPoster.Contracts, ISlotProfileProvider, GetProfiles()

### Community 111 - "Entity (Community 111)"
Cohesion: 0.70
Nodes (5): IFeedUrlProvider.cs, IFeedUrlProvider.cs, IFeedUrlProvider, GetFeedUrls(), XPoster.Contracts

### Community 110 - "Entity (Community 110)"
Cohesion: 0.70
Nodes (5): ICredentialsStartupValidator.cs, ICredentialsStartupValidator.cs, ICredentialsStartupValidator, XPoster.Contracts, Validate()

### Community 109 - "Entity (Community 109)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, catch(), Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), XPoster.Tests.Integration, Polly_Instagram_RetriesOn429_AndEventuallySucceeds()

### Community 112 - "Entity (Community 112)"
Cohesion: 0.70
Nodes (5): DefaultSlotProfileProvider.cs, DefaultSlotProfileProvider.cs, ScheduledOrchestrationProfile(), GetProfiles(), XPoster.Providers

### Community 115 - "Entity (Community 115)"
Cohesion: 0.70
Nodes (5): ITextToTextProvider.cs, ITextToTextProvider.cs, ITextToTextProvider, XPoster.Contracts, GenerateTextAsync()

### Community 113 - "Entity (Community 113)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, IOrchestrator, XPoster.Contracts, PostAsync()

### Community 114 - "Entity (Community 114)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, GetCryptoValue(), ICryptoService, XPoster.Contracts

### Community 153 - "Entity (Community 153)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, XPoster.Tests.Helpers, BuildSequenceHandler(), var()

### Community 145 - "Entity (Community 145)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, GetCryptoValue(), XPoster.Services, catch()

### Community 146 - "Entity (Community 146)"
Cohesion: 0.50
Nodes (4): PerplexityService.cs, PerplexityService(), GetChatCompletionsEndpoint(), while()

### Community 152 - "Entity (Community 152)"
Cohesion: 0.50
Nodes (4): CredentialsStartupValidator.cs, ValidateOptions(), foreach(), resolve()

### Community 148 - "Entity (Community 148)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, XPoster.Models, RSSFeed

### Community 147 - "Entity (Community 147)"
Cohesion: 0.50
Nodes (4): DeepSeekService.cs, DeepSeekService(), GetChatCompletionsEndpoint(), while()

### Community 149 - "Entity (Community 149)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, XPoster.Orchestrators, NoOrchestrator()

### Community 150 - "Entity (Community 150)"
Cohesion: 0.83
Nodes (4): PendingContainer.cs, PendingContainer.cs, PendingContainer(), XPoster.Models

### Community 151 - "Entity (Community 151)"
Cohesion: 0.83
Nodes (4): CredentialsExtensions.cs, CredentialsExtensions.cs, XPoster.Credentials, AddCredentials()

### Community 164 - "Entity (Community 164)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, catch(), return(), if()

### Community 154 - "Entity (Community 154)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, Polly_Instagram_AttemptTimeout_CancelsSlowRequest(), StringContent(), for()

### Community 163 - "Entity (Community 163)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, BaseOrchestrator(), PostAsync(), XPoster.Orchestrators

### Community 162 - "Entity (Community 162)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, XPoster.Models, ScheduledOrchestrationProfile()

### Community 156 - "Entity (Community 156)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, StringContent(), Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), catch()

### Community 158 - "Entity (Community 158)"
Cohesion: 0.83
Nodes (4): FeedPromptOptions.cs, FeedPromptOptions.cs, GetStep(), XPoster.Models

### Community 155 - "Entity (Community 155)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, GetLabel(), XPoster.Contracts

### Community 157 - "Entity (Community 157)"
Cohesion: 0.50
Nodes (4): HttpClientExtensions.cs, XPoster.Extensions, AddResilientHttpClient(), AddHttpClients()

### Community 161 - "Entity (Community 161)"
Cohesion: 0.83
Nodes (4): FeedOrchestratorContext.cs, FeedOrchestratorContext.cs, FeedOrchestratorContext, XPoster.Models

### Community 160 - "Entity (Community 160)"
Cohesion: 0.83
Nodes (4): AiProviderOptionsCompositionExtensions.cs, AiProviderOptionsCompositionExtensions.cs, AddAiProviderOptions(), XPoster.Extensions

### Community 159 - "Entity (Community 159)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, Post, XPoster.Models

### Community 144 - "Entity (Community 144)"
Cohesion: 0.50
Nodes (4): FalAiOptionsValidator.cs, Validate(), XPoster.Models, foreach()

### Community 141 - "Entity (Community 141)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, AddXPosterAiProviders(), XPoster.Extensions

### Community 142 - "Entity (Community 142)"
Cohesion: 0.83
Nodes (4): SenderPluginsServiceCollectionExtensions.cs, SenderPluginsServiceCollectionExtensions.cs, AddXPosterSenderPlugins(), XPoster.Extensions

### Community 143 - "Entity (Community 143)"
Cohesion: 0.83
Nodes (4): BlobUploadResult.cs, BlobUploadResult.cs, BlobUploadResult(), XPoster.Models

### Community 165 - "Entity (Community 165)"
Cohesion: 0.50
Nodes (4): XSender.cs, catch(), SendAsync(), XPoster.SenderPlugins

### Community 178 - "Entity (Community 178)"
Cohesion: 1.00
Nodes (3): TagReplacementOptions.cs, XPoster.Models, TagReplacementOptions.cs

### Community 176 - "Entity (Community 176)"
Cohesion: 0.67
Nodes (3): XSender.cs, if(), XSender()

### Community 175 - "Entity (Community 175)"
Cohesion: 0.67
Nodes (3): FeedService.cs, FeedService(), if()

### Community 177 - "Entity (Community 177)"
Cohesion: 0.67
Nodes (3): BaseOrchestrator.cs, if(), DispatchAsync()

### Community 174 - "Entity (Community 174)"
Cohesion: 0.67
Nodes (3): FalAiOptionsValidator.cs, nameof(), if()

### Community 171 - "Entity (Community 171)"
Cohesion: 0.67
Nodes (3): FbSenderResilienceTests.cs, BuildFactory(), BuildCreds()

### Community 173 - "Entity (Community 173)"
Cohesion: 1.00
Nodes (3): ContainerStatus.cs, XPoster.Contracts, ContainerStatus.cs

### Community 166 - "Entity (Community 166)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, LinkedInCredentials.cs, LinkedInCredentials.cs

### Community 172 - "Entity (Community 172)"
Cohesion: 1.00
Nodes (3): XPoster.Contracts, SenderPlatform.cs, SenderPlatform.cs

### Community 170 - "Entity (Community 170)"
Cohesion: 1.00
Nodes (3): PerplexityOptions.cs, PerplexityOptions.cs, XPoster.Models

### Community 169 - "Entity (Community 169)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, BuildFactory(), params()

### Community 167 - "Entity (Community 167)"
Cohesion: 1.00
Nodes (3): XPoster.Models, OpenAiOptions.cs, OpenAiOptions.cs

### Community 168 - "Entity (Community 168)"
Cohesion: 0.67
Nodes (3): HttpClientExtensions.cs, IsTransientHttpFailure(), if()

### Community 191 - "Entity (Community 191)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, CryptoService(), if()

### Community 193 - "Entity (Community 193)"
Cohesion: 1.00
Nodes (3): AiModelClass.cs, AiModelClass.cs, XPoster.Contracts

### Community 192 - "Entity (Community 192)"
Cohesion: 1.00
Nodes (3): BlobStorageOptions.cs, XPoster.Models, BlobStorageOptions.cs

### Community 190 - "Entity (Community 190)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, AiProvider.cs, XPoster.Contracts

### Community 188 - "Entity (Community 188)"
Cohesion: 1.00
Nodes (3): InstagramCredentials.cs, InstagramCredentials.cs, XPoster.Credentials

### Community 179 - "Entity (Community 179)"
Cohesion: 1.00
Nodes (3): PromptStepOptions.cs, PromptStepOptions.cs, XPoster.Models

### Community 187 - "Entity (Community 187)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, XCredentials.cs, XCredentials.cs

### Community 189 - "Entity (Community 189)"
Cohesion: 0.67
Nodes (3): XCredentialsValidator.cs, XPoster.Credentials, Validate()

### Community 180 - "Entity (Community 180)"
Cohesion: 1.00
Nodes (3): PromptRole.cs, PromptRole.cs, XPoster.Models

### Community 181 - "Entity (Community 181)"
Cohesion: 1.00
Nodes (3): FeedOptions.cs, XPoster.Models, FeedOptions.cs

### Community 182 - "Entity (Community 182)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, XPoster.Models, FalAiOptions.cs

### Community 183 - "Entity (Community 183)"
Cohesion: 0.67
Nodes (3): InSender.cs, if(), InSender()

### Community 185 - "Entity (Community 185)"
Cohesion: 1.00
Nodes (3): XPoster.Models, AzureFoundryOptions.cs, AzureFoundryOptions.cs

### Community 186 - "Entity (Community 186)"
Cohesion: 1.00
Nodes (3): FacebookCredentials.cs, FacebookCredentials.cs, XPoster.Credentials

### Community 184 - "Entity (Community 184)"
Cohesion: 1.00
Nodes (3): XPoster.Models, DeepSeekOptions.cs, DeepSeekOptions.cs

### Community 194 - "Entity (Community 194)"
Cohesion: 1.00
Nodes (2): XCredentialsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._


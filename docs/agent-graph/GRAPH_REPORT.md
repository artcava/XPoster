# Graph Report - XPoster  (2026-07-30)

## Summary
- 1684 nodes · 2867 edges · 195 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Tests.Models` - 2 edges
2. `FbSenderResilienceTests` - 2 edges
3. `XPoster.Tests.Services` - 2 edges
4. `XPoster.SenderPlugins` - 2 edges
5. `XPoster.Services` - 2 edges
6. `XPoster.Tests.Models` - 2 edges
7. `DeepSeekOptionsValidatorTests` - 2 edges
8. `XPoster.Tests.SenderPlugins` - 2 edges
9. `XPoster.Orchestrators` - 2 edges
10. `XPoster.Tests.SenderPlugins` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, XPoster.Tests.Services, ParseImageResponseAsync_WhenStatusIsNonSuccess_ReturnsEmptyArray(), ParseImageResponseAsync_WhenStatusIsNonSuccess_LogsError(), ParseImageResponseAsync_WhenStatusIs429_LogsWarning(), ParseImageResponseAsync_WhenMalformedJson_ReturnsEmptyArray(), ParseImageResponseAsync_WhenMalformedJson_LogsError() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.09
Nodes (43): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, OrchestrateAsync_DerivesImagePromptFromRawBaseSummary_BeforeHashtags(), OrchestrateAsync_AppliesHashtagsIndependently_PerSender(), new(), OrchestrateAsync_UsesFeedUrls_FromInjectedContext(), OrchestrateAsync_ThirdSender_ReusesUpdatedPreviousSummary_WhenItFitsThirdLimit(), OrchestrateAsync_TwoSlots_ReceiveIndependentFeedUrlsAndPrompts() (+35 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.10
Nodes (41): AzureFoundryServiceTests.cs, AzureFoundryServiceTests.cs, GenerateImageAsync_RequestBodyContainsModelFromOptions(), ChatCompletionJson(), GenerateImageAsync_PostsToFoundryImagesGenerationsEndpoint(), HttpResponseMessage(), GenerateTextAsync_WhenUsedAsImagePromptDerivationStep_AndChoicesNull_ReturnsEmptyString(), GenerateTextAsync_WhenUsedAsImagePromptDerivationStep_ReturnsContent() (+33 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.11
Nodes (36): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GenerateTextAsync_WhenResponseAlwaysExceedsMaxOutputLength_StopsAfterThreeAttempts(), GenerateTextAsync_WhenNoMaxOutputLength_DoesNotRetry(), GenerateTextAsync_WhenOutputFitsWithinMaxOutputLength_ReturnsSingleCallResult(), GenerateTextAsync_WhenChoicesIsNull_ReturnsEmpty(), GenerateImageAsync_WhenPromptIsEmpty_LogsWarning(), GenerateImageAsync_WhenHttpRequestExceptionThrown_LogsError() (+28 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, Parse_AzureFoundry_UrlFallback_WrongOrigin_LogsWarning(), Parse_AzureFoundry_UrlFallback_DownloadThrows_ReturnsEmpty(), Parse_AzureFoundry_UrlFallback_ReturnsBytes(), Parse_AzureFoundry_UrlFallback_NullAllowedOrigin_SkipsOriginCheckAndDownloads(), Parse_Returns429_ReturnsEmpty(), Parse_OpenAi_MissingDataProperty_ReturnsEmpty(), Parse_Returns429_LogsWarning() (+24 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, BuildProvider(), AddPerplexityOptions_RegistersValidator(), AzureFoundryOptionsExtensionsTests, BuildConfig(), AddOpenAiOptions_BindsOptionsFromCorrectSection(), AddDeepSeekOptions_RegistersValidator() (+21 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.14
Nodes (28): PerplexityServiceTests.cs, PerplexityServiceTests.cs, GenerateTextAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GenerateTextAsync_ImagePromptRole_WhenChoicesIsNull_ReturnsEmptyString(), GenerateTextAsync_UsesCustomInputTextLabel_InUserPromptSubstitution(), GenerateTextAsync_WhenApiReturns429_ReturnsEmptyString(), BuildSummaryRequest(), BuildService() (+20 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.15
Nodes (26): FbSenderTests.cs, FbSenderTests.cs, Constructor_WithNullCredentials_ThrowsArgumentNullException(), BuildSender(), Constructor_InitializesCorrectly(), Constructor_WithNullBlobStorage_ThrowsArgumentNullException(), Platform_ReturnsFacebook(), NormalizeImage_WithInvalidBytes_ReturnsNull() (+18 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.16
Nodes (25): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, SummaryRequest(), XPoster.Tests.Services, HttpResponseMessage(), ImagePromptDerivationRequest(), MakeHandlerMock(), new() (+17 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.09
Nodes (22): OrchestratorFactoryTests.cs, XPoster.Tests.Orchestrators, Resolve_Should_ResolveXSender_ForPowerLawOrchestrator(), Resolve_Should_ReturnCorrectOrchestratorType_ForGivenSenderProfile(), Resolve_Should_ReturnNoOrchestrator_WhenNoProfileMatchesCurrentHour(), Resolve_Should_ResolveXSender_WhenProfileUsesX(), Resolve_Should_ResolveDryRunSender_WhenProfileUsesDryRun(), Resolve_Should_RequestDifferentKeys_WhenTextAndImageProvidersAreDifferent() (+14 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.19
Nodes (21): XSenderTests.cs, XSenderTests.cs, SendAsync_EmptyContent_ReturnsFalse(), Constructor_WithNullLogger_ThrowsArgumentNullException(), MessageMaxLength_Returns250(), Platform_ReturnsX(), XSenderTests(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning() (+13 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.20
Nodes (19): FeedPromptOptionsTests.cs, FeedPromptOptionsTests.cs, GetStep_EmptySteps_ThrowsInvalidOperationException(), FeedPromptOptions_ValueEquality_SameSteps_AreEqual(), FeedPromptOptions_WithExpression_PreservesStepsReference(), GetStep_DuplicateRole_ThrowsInvalidOperationException(), FeedPromptOptionsTests, XPoster.Tests.Models (+11 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.22
Nodes (18): IgSenderImageFlowTests.cs, IgSenderImageFlowTests.cs, SendAsync_WhenJsonResponseMissingIdProperty_ReturnsFalse(), NormalizeImage_WithValidPng_ReturnsJpegBytes(), SendAsync_WhenBlobUploadSucceeds_CreatesMediaContainerWithCorrectSasUrl(), SendAsync_WhenJsonResponseIdIsEmpty_ReturnsFalse(), return(), NormalizeImage_WithInvalidBytes_ReturnsNull() (+10 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.22
Nodes (18): AiProviderOptionsAbstractionTests.cs, AiProviderOptionsAbstractionTests.cs, XPoster.Tests.Models, OpenAiOptions_ImplementsIAiProviderOptions(), OpenAiOptions_ModelCatalog_ExposesTextAndImage(), PerplexityOptions_ImplementsIAiProviderOptions(), PerplexityOptions_ModelCatalog_ExposesTextOnly(), AzureFoundryOptions_ModelCatalog_ExposesTextAndImage() (+10 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, GetFeedsAsync_FiltersOutItemsWithNoKeywordMatch(), FeedService(), foreach(), GetFeedsAsync_FetchesAndCachesFeeds_WhenCacheMissAndHttpSucceeds(), GetFeedsAsync_FiltersOutItemsOutsideDateRange(), FeedServiceTests (+10 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.22
Nodes (18): AiServiceHelperChatPayloadTests.cs, AiServiceHelperChatPayloadTests.cs, AiServiceHelperChatPayloadTests, BuildChatPayload_ForwardsMaxTokenBudget(), BuildChatPayload_FirstMessageRoleIsSystem(), BuildChatPayload_SystemMessage_NoPlaceholder_IsUnchanged(), BuildChatPayload_InterpolatesMaxCharsInSystemMessage(), BuildChatPayload_SecondMessageRoleIsUser() (+10 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.23
Nodes (17): PromptStepOptionsTests.cs, PromptStepOptionsTests.cs, PromptStepOptions_ValueEquality_DifferentRole_AreNotEqual(), PromptStepOptions_OptionalProperties_DefaultToNull(), PromptStepOptions_RequiredProperties_AreSetCorrectly(), PromptStepOptions_ValueEquality_DifferentOptionals_AreNotEqual(), PromptStepOptions_SummaryStep_MaxOutputLength_IsNullByConvention(), PromptStepOptions_Temperature_AcceptsZeroAndOne() (+9 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.23
Nodes (17): MetaPublishingServiceTests.cs, MetaPublishingServiceTests.cs, CreateSut(), XPoster.Tests.Services, PublishContainerAsync_WhenIdIsNull_ReturnsEmptyString(), PublishContainerAsync_WhenOk_ReturnsPublishId(), PublishContainerAsync_WhenRateLimited_Throws(), PublishContainerAsync_WhenResponseBodyIsNull_ThrowsJsonException() (+9 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.23
Nodes (17): PromptRequestTests.cs, PromptRequestTests.cs, PromptRequest_OptionalProperties_DefaultToNull(), ImagePromptRequest_IsImmutable_AfterConstruction(), ImagePromptRequest_ValueEquality_SameValues_AreEqual(), PromptRequest_IsImmutable_AfterConstruction(), PromptRequest_OptionalProperties_AreSetCorrectly(), ImagePromptRequest_ImageProperties_AreSetCorrectly() (+9 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.24
Nodes (16): InMemoryContainerStateStoreTests.cs, InMemoryContainerStateStoreTests.cs, SaveAsync_WithNullBlobName_ThrowsArgumentNullException(), SaveAsync_WithEmptyOrWhitespaceCreationId_ThrowsArgumentException(), SaveAsync_WithEmptyOrWhitespaceBlobName_ThrowsArgumentException(), GetPendingAsync_ReturnsOnlyPendingEntries(), InMemoryContainerStateStoreTests, GetPendingAsync_WhenStoreIsEmpty_ReturnsEmptyList() (+8 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.26
Nodes (15): BlobStorageServiceTests.cs, BlobStorageServiceTests.cs, DeleteAsync_WithNullBlobName_ThrowsArgumentException(), XPoster.Tests.Services, UploadAsync_WhenContainerDoesNotExist_CreatesItAndUploads(), UploadAsync_WhenStorageThrows_PropagatesException(), UploadAsync_SasUriExpiry_IsApproximately30Minutes(), UploadAsync_WhenBlobClientSucceeds_ReturnsSasUri() (+7 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.26
Nodes (15): AddAiProviderOptionsTests.cs, AddAiProviderOptionsTests.cs, AddAiProviderOptions_ReturnsSameServiceCollection(), AddAiProviderOptions_BindsFalAiOptions_FromCorrectSection(), AddAiProviderOptions_RegistersAllFiveOptionTypes(), AddAiProviderOptions_DoesNotDuplicateValidatorRegistrations_WhenCalledOnce(), AddAiProviderOptions_BindsPerplexityOptions_FromCorrectSection(), AddAiProviderOptions_RegistersAllFiveValidators() (+7 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.13
Nodes (15): DryRunSenderTests.cs, XPoster.Tests.SenderPlugins, DryRunSender(), BuildConfig(), Constructor_WithNullConfiguration_ThrowsArgumentNullException(), ConfigurationBuilder(), DryRunSender_ImplementsISender(), SendAsync_WithNullPost_ReturnsFalse() (+7 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.26
Nodes (15): DefaultSlotProfileProviderTests.cs, DefaultSlotProfileProviderTests.cs, FeedOrchestratorSlot_Should_ContainLinkedInAndX(), DryRunSlotProfileProvider_DryRunSlot_Should_HaveBothProvidersConfigured(), FeedOrchestratorSlot_Should_HaveAtLeastOneSender(), DefaultSlotProfileProviderTests, PowerLawSlot_Should_ContainLinkedInAndX(), FeedOrchestratorSlot_Should_HaveDistinctTextAndImageProviders() (+7 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.26
Nodes (15): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, XPoster.Tests.SenderPlugins, Uri(), PostWithoutImage(), SendAsync_WhenHttpClientThrows_ReturnsFalse(), SendAsync_WhenNoImage_ReturnsFalseWithoutCallingApi(), SendAsync_WhenBlobUploadCancelled_ReturnsFalseAndLogsError() (+7 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.26
Nodes (15): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, OrchestratorContextKey_Should_BeSet_WhenProvided(), ScheduledOrchestrationProfileTests, XPoster.Tests.Models, typeof(), TwoSlotsWithSameOrchestratorType_Should_CarryIndependentContextKeys(), Constructor_Should_SetTextProvider_And_NullImageProvider_WhenOnlyTextProviderSupplied() (+7 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.26
Nodes (15): PromptRoleTests.cs, PromptRoleTests.cs, XPoster.Tests.Models, PromptRole_UndefinedValueNotPresentInMap_ThrowsKeyNotFound(), PromptRole_ParseFromStringIgnoreCase_ReturnsCorrectMember(), PromptRole_TryParse_InvalidName_ReturnsFalse(), PromptRole_ToString_ReturnsName(), PromptRole_TryParse_ValidName_ReturnsTrue() (+7 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.26
Nodes (15): MaskUrlTelemetryProcessorTests.cs, MaskUrlTelemetryProcessorTests.cs, Initialize_WhenDependencyTypeIsNotHttp_DoesNotModifyData(), Initialize_WhenAccessTokenAlreadyMasked_DoesNotDoubleEncode(), Initialize_WhenDataIsNull_DoesThrow(), Initialize_WhenDataIsEmpty_DoesNotThrow(), MaskUrlTelemetryProcessorTests, Initialize_WhenFacebookUrlHasAccessToken_TokenIsMasked() (+7 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, Post_CanBeCreated_WithRequiredContent(), Post_CanHold_ImageBytes(), RSSFeed_PublishDate_DefaultsToMinValue(), XPoster.Tests.Models, Post_Firm_ContainsExpectedHashtags(), RSSFeed_CanBeCreated_WithAllProperties() (+6 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.27
Nodes (14): XPosterContainerPollingFunction.cs, XPosterContainerPollingFunction.cs, catch(), XPoster, HandleTerminalFailureAsync(), switch(), if(), TryDeleteBlobAsync() (+6 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, GetCurrentTime_WhenForceHourIsAbsent_FallsBackToUtcHour(), BuildProvider(), Constructor_AlwaysEmitsDevOverrideWarning(), GetCurrentTime_WhenForceHourIsNonNumeric_FallsBackToUtcHour(), LocalOverrideTimeProviderTests, GetCurrentTime_WhenForceHourIsValid_ReturnsUtcKind() (+5 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.15
Nodes (13): FalAiImageServiceTests.cs, GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_ReturnsEmptyArray(), XPoster.Tests.Services, GenerateImageAsync_ValidResponse_ReturnsImageBytes(), GenerateImageAsync_ReturnsNonSuccess_ReturnsEmptyArray(), FalAiImageServiceTests, GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray(), FalImageJson() (+5 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests, ValidOptions(), Validate_ImageModelNameWithAllowedSpecialChars_Succeeds(), Validate_ImageModelNameWithUnsafeCharacters_Fails(), Validate_MissingModelId_Fails(), Validate_ValidOptions_Succeeds() (+5 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.29
Nodes (13): AiModelCatalogTests.cs, AiModelCatalogTests.cs, GetRequired_ReturnsModelName_WhenSupported(), TryGet_ReturnsTrueAndPopulatesModelName_WhenSupported(), Supports_ReturnsTrueForRegisteredModelClass(), XPoster.Tests.Models, Supports_ReturnsFalseForMissingModelClass(), GetRequired_Throws_WhenNotSupported() (+5 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.15
Nodes (13): InSenderTests.cs, SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn(), XPoster.Tests.SenderPlugins, SendAsync_WithImage_WhenRegisterUploadFails_ReturnsFalse(), SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), SendAsync_TextOnly_WithPersonCode_UsesPersonUrn(), BuildCreds() (+5 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.32
Nodes (12): AzureFoundryService.cs, AzureFoundryService.cs, GetImageGenerationEndpoint(), GenerateImageAsync(), GetChatCompletionsEndpoint(), GenerateTextAsync(), AzureFoundryService(), catch() (+4 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.17
Nodes (12): DryRunSenderTests.cs, SendAsync_WithNullContent_StillReturnsTrueWhenKeyPresent(), SendAsync_WithNullPost_LogsWarning(), SendAsync_WhenKeyWhitespace_ReturnsFalse(), MessageMaxLength_ReturnsIntMaxValue(), SendAsync_DoesNotCallAnyOutboundSocialApi(), Platform_ReturnsDryRun(), BuildSender() (+4 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, MakeHandlerMock(), GenerateImageAsync_EmptyUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_LogsError(), GenerateImageAsync_MalformedJson_ReturnsEmptyArray(), GenerateImageAsync_RequestUsesImageQuantityFromRequest(), GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithMultipleSegments_PreservesSlashesInUri() (+4 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.17
Nodes (12): InSenderTests.cs, SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse(), Constructor_InitializesCorrectly(), InSenderTests(), InSender(), SendAsync_ValidPost_TriesLinkedInAndReturnsFalse(), SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse(), MessageMaxLength_Returns2800() (+4 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.17
Nodes (12): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenStatusIsError_MarksFailedAndCleansUp(), RunAsync_WhenNoPendingContainers_DoesNothing(), CreateSut(), RunAsync_WhenBlobDeleteFails_LogsError(), RunAsync_WhenMultiplePendingContainers_ProcessesAll(), RunAsync_WhenCancelledDuringForEach_StopsGracefully(), RunAsync_WhenStatusIsInProgress_SkipsContainer() (+4 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.32
Nodes (12): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, XPoster.Tests.Orchestrators, GenerateAsync_Should_CalculateCorrectPowerLawValue_ForFixedDate(), GenerateAsync_Should_CreateCorrectMessage_WithActualValue(), PowerLawOrchestratorTests(), OrchestrateAsync_BroadcastsSamePost_ToAllSenders(), GenerateAsync_Should_HandleNegativeOrZeroCryptoValue() (+4 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.32
Nodes (12): ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests.cs, GetReplacements_Should_PreserveAllEntries_When_MultipleReplacementsConfigured(), GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsIsEmpty(), XPoster.Tests.Providers, GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsPropertyIsNull(), GetReplacements_Should_ReturnReadOnlyDictionary(), GetReplacements_Should_ReturnConfiguredReplacements_When_OptionsContainsEntries() (+4 more)

### Community 46 - "Entity (Community 46)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WhenLinkedInReturns200_ReturnsTrue(), SendAsync_WhenLinkedInReturns503_ReturnsFalseAndLogsError(), ValidPost(), SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue() (+3 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.18
Nodes (11): IgSenderTests.cs, Constructor_InitializesCorrectly(), BuildSender(), BuildCreds(), Constructor_WithNullHttpClientFactory_ThrowsArgumentNullException(), XPoster.Tests.SenderPlugins, new(), MessageMaxLength_Returns2200() (+3 more)

### Community 44 - "Entity (Community 44)"
Cohesion: 0.18
Nodes (11): OrchestratorFactoryTests.cs, DryRunSlotProfileProvider_Should_AppendDryRunProfile_ToInnerProviderProfiles(), CreateFactory(), NoOrchestrator_SupportedPlatforms_IsEmpty(), OrchestratorFactoryTests(), SetupMocksForOrchestratorFactory(), Resolve_Should_RequestImageProviderKey_WhenProfileSpecifiesImageProvider(), typeof() (+3 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.35
Nodes (11): ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProviderTests.cs, GetFeedUrls_Should_ReturnConfiguredUrls_When_OptionsContainsUrls(), GetFeedUrls_Should_ReturnEmptyList_When_UrlsListIsEmpty(), GetFeedUrls_Should_ReturnReadOnlyList(), GetFeedUrls_Should_ReturnEmptyList_When_UrlsPropertyIsNull(), XPoster.Tests.Providers, GetFeedUrls_Should_ReturnUrlsInOrder_When_MultipleUrlsConfigured() (+3 more)

### Community 45 - "Entity (Community 45)"
Cohesion: 0.35
Nodes (11): AiProviderServiceCollectionExtensionsTests.cs, AiProviderServiceCollectionExtensionsTests.cs, AiProviderServiceCollectionExtensionsTests, AddXPosterAiProviders_RegistersFalAi_AsImageOnly(), AddXPosterAiProviders_RegistersOpenAi_AsTextAndImageProvider(), AddXPosterAiProviders_RegistersPerplexity_AsTextOnly(), AddXPosterAiProviders_ReturnsSameServiceCollection(), XPoster.Tests.Extensions (+3 more)

### Community 54 - "Entity (Community 54)"
Cohesion: 0.38
Nodes (10): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, Validate_WithMultipleInvalidFields_ReturnsAllFailures(), Validate_WhenTextModelNameIsEmpty_ReturnsFailed(), XPoster.Tests.Models, ValidOptions(), Validate_WithValidOptions_ReturnsSuccess(), Validate_WhenEndpointIsEmpty_ReturnsFailed() (+2 more)

### Community 52 - "Entity (Community 52)"
Cohesion: 0.38
Nodes (10): XFunctionTests.cs, XFunctionTests.cs, Run_Should_DoNothing_When_GeneratorIsDisabled(), Run_Should_LogError_When_OrchestrateAsync_ReturnsEmptyDictionary(), XFunctionTests(), XPoster.Tests, Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), Run_Should_LogError_When_PostAsync_ReturnsFalse() (+2 more)

### Community 51 - "Entity (Community 51)"
Cohesion: 0.38
Nodes (10): FbSender.cs, FbSender.cs, catch(), HandleResponseAsync(), SendAsync(), PublishTextOnlyAsync(), XPoster.SenderPlugins, if() (+2 more)

### Community 50 - "Entity (Community 50)"
Cohesion: 0.38
Nodes (10): IgSenderSendAsyncTests.cs, IgSenderSendAsyncTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithCaptionExceedingMaxLength_TruncatesCaption(), SendAsync_WithNoImage_ReturnsFalse(), IgSender(), SendAsync_WithEmptyImageArray_ReturnsFalse() (+2 more)

### Community 49 - "Entity (Community 49)"
Cohesion: 0.38
Nodes (10): FbSenderSendAsyncTests.cs, FbSenderSendAsyncTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), SendAsync_WithNullImage_PublishesTextOnly_ReturnsTrue(), SendAsync_WithEmptyImage_PublishesTextOnly_ReturnsTrue(), BuildFactory(), BuildCreds() (+2 more)

### Community 47 - "Entity (Community 47)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, Name_IsNoOrchestrator(), Build(), NoOrchestratorTests, SendIt_IsAlwaysFalse(), OrchestrateAsync_ReturnsEmptyList(), SendIt_Set_ThrowsNotImplementedException() (+2 more)

### Community 53 - "Entity (Community 53)"
Cohesion: 0.38
Nodes (10): MetaPublishingService.cs, MetaPublishingService.cs, GetContainerStatusAsync(), PublishContainerAsync(), XPoster.Services, if(), MetaPublishingService(), HttpRequestException() (+2 more)

### Community 48 - "Entity (Community 48)"
Cohesion: 0.38
Nodes (10): XSenderResilienceTests.cs, XSenderResilienceTests.cs, BuildSender(), SendAsync_WhenContentIsBlank_ReturnsFalseAndLogsWarning(), SendAsync_WhenTextTweetFails_ReturnsFalseAndLogsError(), XSender(), XSenderResilienceTests, XPoster.Tests.SenderPlugins (+2 more)

### Community 55 - "Entity (Community 55)"
Cohesion: 0.22
Nodes (9): FbSenderResilienceTests.cs, SendAsync_WhenTextPublishReturns200WithId_ReturnsTrue(), HttpResponseMessage(), FbSenderResilienceTests, SendAsync_WhenTextPublishReturns200WithEmptyId_ReturnsFalse(), SendAsync_WhenFacebookReturns503_ReturnsFalseAndLogsError(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), XPoster.Tests.SenderPlugins (+1 more)

### Community 58 - "Entity (Community 58)"
Cohesion: 0.22
Nodes (9): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenStatusIsExpired_MarksFailedAndCleansUp(), RunAsync_WhenUpdateStatusThrows_PropagatesException(), RunAsync_WhenStatusIsFinished_PublishesAndCleansUp(), RunAsync_WhenBlobDeleteFails_StillUpdatesStatus(), PendingContainer(), CreateTimerInfo(), RunAsync_WhenPublishFails_MarksFailedAndCleansUp() (+1 more)

### Community 59 - "Entity (Community 59)"
Cohesion: 0.42
Nodes (9): FeedOrchestrator.cs, FeedOrchestrator.cs, XPoster.Orchestrators, if(), FeedOrchestrator(), AcquireFeedContentAsync(), foreach(), catch() (+1 more)

### Community 57 - "Entity (Community 57)"
Cohesion: 0.22
Nodes (9): BaseOrchestratorTests.cs, PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_ReturnsFalse_WhenOneSenderFails(), PostAsync_ReturnsTrue_When_AllConditionsMet(), PostAsync_ReturnsFalse_WhenSenderListIsEmpty(), XPoster.Tests.Orchestrators (+1 more)

### Community 61 - "Entity (Community 61)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, BuildSequenceHandler(), HttpResponseMessage(), var(), XPoster.Tests.Integration, params(), BuildProviderWithHandler() (+1 more)

### Community 56 - "Entity (Community 56)"
Cohesion: 0.22
Nodes (9): InSender.cs, SendAsync(), XPoster.SenderPlugins, using(), InvalidOperationException(), ResolveAuthorUrn(), generatePayLoad(), catch() (+1 more)

### Community 62 - "Entity (Community 62)"
Cohesion: 0.42
Nodes (9): FacebookResiliencePipelineTests.cs, FacebookResiliencePipelineTests.cs, Polly_Facebook_RetriesOn429_AndEventuallySucceeds(), Polly_Facebook_OnRetry_LogEntryIsEmitted(), Polly_Facebook_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_Facebook_AttemptTimeout_CancelsSlowRequest(), for(), catch() (+1 more)

### Community 60 - "Entity (Community 60)"
Cohesion: 0.22
Nodes (9): FbSenderImageFlowTests.cs, BuildFactory(), InvalidImageBytes(), SendAsync_WhenImageNormalizationFails_FallsBackToTextOnly(), FbSenderImageFlowTests, HttpRequestException(), XPoster.Tests.SenderPlugins, SendAsync_WhenPhotoPublishThrows_FallsBackToTextOnly() (+1 more)

### Community 67 - "Entity (Community 67)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse(), XSenderSendAsyncTests(), XPoster.Tests.SenderPlugins, SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse() (+1 more)

### Community 66 - "Entity (Community 66)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, GetCryptoValue_ReturnsParsedValue_WhenNumericString(), GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), MakeService(), GetCryptoValue_ReturnsZero_AndLogsError_OnException(), CryptoServiceTests, XPoster.Tests.Services (+1 more)

### Community 65 - "Entity (Community 65)"
Cohesion: 0.42
Nodes (9): AiModelCatalog.cs, AiModelCatalog.cs, TryGet(), AiModelCatalog(), Supports(), InvalidOperationException(), GetRequired(), if() (+1 more)

### Community 64 - "Entity (Community 64)"
Cohesion: 0.42
Nodes (9): RSSFeedTests.cs, RSSFeedTests.cs, RSSFeed_CanSetPublishDate(), XPoster.Tests.Models, RSSFeedTests, RSSFeed_RecordEquality_SameValues_AreEqual(), RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeed_DefaultPublishDateIsMinValue() (+1 more)

### Community 63 - "Entity (Community 63)"
Cohesion: 0.42
Nodes (9): HttpClientExtensionsTests.cs, HttpClientExtensionsTests.cs, AddHttpClients_RegistersIHttpClientFactory(), foreach(), AddHttpClients_RegistersExpectedNamedClients(), AddHttpClients_ReturnsSameServiceCollection(), AddHttpClients_CanCreateAllExpectedNamedClients(), HttpClientExtensionsTests (+1 more)

### Community 72 - "Entity (Community 72)"
Cohesion: 0.46
Nodes (8): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, ValidOptions(), Validate_MissingRequiredProperties_Fails(), XPoster.Tests.Models, Validate_ValidOptions_Succeeds(), DeepSeekOptionsValidatorTests, Validate_AccumulatesAllFailures_WhenMultipleRulesViolated()

### Community 71 - "Entity (Community 71)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, InSenderSendAsyncTests(), SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), XPoster.Tests.SenderPlugins

### Community 78 - "Entity (Community 78)"
Cohesion: 0.25
Nodes (8): FeedOrchestratorFeedUrlProviderTests.cs, XPoster.Tests.Providers, OrchestrateAsync_Should_ReturnEmpty_And_DisableSendIt_When_ContextHasNoFeedUrls(), OrchestrateAsync_Should_PassSenderMessageMaxLength_As_MaxOutputLength_In_SummaryRequest(), OrchestrateAsync_Should_CallGetFeedsAsync_For_Each_Url(), OrchestrateAsync_Should_AggregateFeeds_From_All_Urls(), OrchestrateAsync_Should_CallGetFeedsAsync_With_Correct_Urls(), OrchestrateAsync_TwoSlots_Should_UseDifferentFeedUrls_Independently()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.25
Nodes (8): AiServiceHelper.cs, LogAndReturnEmpty(), BuildChatPayload(), ExtractFalAiBytesAsync(), ExtractAzureFoundryBytesAsync(), ExtractOpenAiBytes(), XPoster.Services, ParseImageResponseAsync()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.46
Nodes (8): PostTests.cs, PostTests.cs, Firm_IsNotNullOrEmpty(), Post_DefaultImageIsNull(), Post_EmptyContent_IsAllowed(), PostTests, XPoster.Tests.Models, Post_CanSetAndGetAllProperties()

### Community 70 - "Entity (Community 70)"
Cohesion: 0.46
Nodes (8): FalAiImageService.cs, FalAiImageService.cs, GenerateImageAsync(), catch(), FalAiImageService(), XPoster.Services, if(), GetImageGenerationEndpoint()

### Community 69 - "Entity (Community 69)"
Cohesion: 0.46
Nodes (8): BlobStorageService.cs, BlobStorageService.cs, BlobUploadResult(), UploadAsync(), DeleteAsync(), XPoster.Services, if(), BlobStorageService()

### Community 68 - "Entity (Community 68)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, CaptureLoggerProvider(), CaptureLogger(), IsEnabled(), XPoster.Tests.Integration, Dispose(), CreateLogger()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, GetLabel_UnknownProvider_ReturnsFallbackToString(), GetLabel_DescriptionDiffersFromEnumName(), GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(), GetLabel_DescriptionMatchesEnumName(), AiProviderExtensionsTests, XPoster.Tests.Contracts

### Community 75 - "Entity (Community 75)"
Cohesion: 0.46
Nodes (8): AIResponse.cs, AIResponse.cs, AIResponse, Choice, OpenAIImageResponse, XPoster.Models, ImageData, Message

### Community 73 - "Entity (Community 73)"
Cohesion: 0.25
Nodes (8): BaseOrchestratorTests.cs, TestOrchestrator(), PostAsync_DispatchesEachPostToAlignedSender(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), PostAsync_ReturnsFalse_WhenSenderPlatformNotInDictionary(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), BaseOrchestratorTests()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.29
Nodes (7): FbSenderImageFlowTests.cs, SendAsync_WithSupportedImage_UploadsPublishesPhotoAndDeletesBlob(), if(), CreateValidJpegBytes(), HttpResponseMessage(), SendAsync_WhenDeleteFails_AfterSuccessfulPhotoPublish_ReturnsTrue(), SendAsync_WhenUploadThrows_FallsBackToTextOnly()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.52
Nodes (7): IgSender.cs, IgSender.cs, XPoster.SenderPlugins, IgSender(), catch(), if(), SendAsync()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.29
Nodes (7): OpenAiService.cs, while(), XPoster.Services, GenerateImageAsync(), catch(), GenerateTextAsync(), var()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.29
Nodes (7): CredentialsStartupValidator.cs, Validate(), InvalidOperationException(), CredentialsStartupValidator(), if(), catch(), XPoster.Credentials

### Community 79 - "Entity (Community 79)"
Cohesion: 0.52
Nodes (7): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, Validate_MissingRequiredProperties_Fails(), XPoster.Tests.Models, Validate_ValidOptions_Succeeds(), AzureFoundryOptionsValidatorTests, ValidOptions()

### Community 81 - "Entity (Community 81)"
Cohesion: 0.52
Nodes (7): InMemoryContainerStateStore.cs, InMemoryContainerStateStore.cs, XPoster.Services, UpdateStatusAsync(), GetPendingAsync(), InMemoryContainerStateStore, SaveAsync()

### Community 89 - "Entity (Community 89)"
Cohesion: 0.52
Nodes (7): IContainerStateStore.cs, IContainerStateStore.cs, UpdateStatusAsync(), GetPendingAsync(), IContainerStateStore, SaveAsync(), XPoster.Contracts

### Community 87 - "Entity (Community 87)"
Cohesion: 0.29
Nodes (7): OrchestratorFactory.cs, return(), typeof(), XPoster.Orchestrators, foreach(), catch(), Resolve()

### Community 88 - "Entity (Community 88)"
Cohesion: 0.52
Nodes (7): TagReplacementService.cs, TagReplacementService.cs, TagReplacementService(), XPoster.Services, Apply(), foreach(), if()

### Community 85 - "Entity (Community 85)"
Cohesion: 0.52
Nodes (7): XFunction.cs, XFunction.cs, XFunction(), Run(), if(), XPoster, catch()

### Community 86 - "Entity (Community 86)"
Cohesion: 0.52
Nodes (7): Program.cs, Program.cs, if(), DefaultAzureCredential(), Uri(), DryRunSlotProfileProvider(), BlobServiceClient()

### Community 104 - "Entity (Community 104)"
Cohesion: 0.60
Nodes (6): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests, AzureFoundryOptions_DoesNotExpose_ApiVersionProperty(), AzureFoundryOptions_Defaults_AreCorrect(), XPoster.Tests.Models

### Community 101 - "Entity (Community 101)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, XPoster.Tests.Integration, Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), for(), Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest()

### Community 103 - "Entity (Community 103)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, XPoster.Tests.Providers, TimeProviderTests, GetCurrentTime_ReturnsUtcTime(), GetCurrentTime_ReturnsCurrentDateTime()

### Community 102 - "Entity (Community 102)"
Cohesion: 0.60
Nodes (6): TagReplacementServiceTests.cs, TagReplacementServiceTests.cs, Apply_Returns_Input_Unchanged_When_Text_Is_Empty_Or_Whitespace(), XPoster.Tests.Services, Apply_Replaces_Only_First_Occurrence_For_Each_Word(), Apply_Does_Not_Replace_Words_Already_Prefixed_With_Hashtag()

### Community 107 - "Entity (Community 107)"
Cohesion: 0.60
Nodes (6): PerplexityOptionsValidator.cs, PerplexityOptionsValidator.cs, XPoster.Models, nameof(), if(), Validate()

### Community 105 - "Entity (Community 105)"
Cohesion: 0.60
Nodes (6): DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider(), GetProfiles(), ScheduledOrchestrationProfile(), XPoster.Providers

### Community 106 - "Entity (Community 106)"
Cohesion: 0.60
Nodes (6): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptionsTests, XPoster.Tests.Models

### Community 99 - "Entity (Community 99)"
Cohesion: 0.60
Nodes (6): IBlobStorageService.cs, IBlobStorageService.cs, UploadAsync(), DeleteAsync(), IBlobStorageService, XPoster.Contracts

### Community 100 - "Entity (Community 100)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, XPoster.Tests.Integration, Polly_AiClient_AttemptTimeout_CancelsSlowRequest(), StringContent(), Polly_AiClient_RetriesOn429_AndEventuallySucceeds()

### Community 95 - "Entity (Community 95)"
Cohesion: 0.60
Nodes (6): IMetaPublishingService.cs, IMetaPublishingService.cs, PublishContainerAsync(), IMetaPublishingService, GetContainerStatusAsync(), XPoster.Contracts

### Community 93 - "Entity (Community 93)"
Cohesion: 0.60
Nodes (6): AzureFoundryOptionsValidator.cs, AzureFoundryOptionsValidator.cs, XPoster.Models, Validate(), nameof(), if()

### Community 94 - "Entity (Community 94)"
Cohesion: 0.60
Nodes (6): FacebookCredentialsValidator.cs, FacebookCredentialsValidator.cs, XPoster.Credentials, Validate(), if(), FacebookCredentialsValidator

### Community 108 - "Entity (Community 108)"
Cohesion: 0.33
Nodes (6): FeedOrchestratorFeedUrlProviderTests.cs, CreateOrchestrator(), BuildContext(), new(), SetupHappyPathProviders(), FeedOrchestratorFeedUrlProviderTests()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, XPoster.SenderPlugins, if(), SendAsync(), DryRunSender()

### Community 96 - "Entity (Community 96)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, MakeDownloadClient(), JsonResponse(), MakeNoOpClient(), var(), HttpClient()

### Community 97 - "Entity (Community 97)"
Cohesion: 0.33
Nodes (6): IgSenderTests.cs, IgSender_ImplementsISender(), IgSender(), IgSenderTests(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), Constructor_WithNullBlobStorageService_ThrowsArgumentNullException()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.60
Nodes (6): OpenAiOptionsValidator.cs, OpenAiOptionsValidator.cs, nameof(), if(), XPoster.Models, Validate()

### Community 90 - "Entity (Community 90)"
Cohesion: 0.60
Nodes (6): InstagramCredentialsValidator.cs, InstagramCredentialsValidator.cs, XPoster.Credentials, if(), InstagramCredentialsValidator, Validate()

### Community 91 - "Entity (Community 91)"
Cohesion: 0.60
Nodes (6): DeepSeekOptionsValidator.cs, DeepSeekOptionsValidator.cs, if(), nameof(), XPoster.Models, Validate()

### Community 126 - "Entity (Community 126)"
Cohesion: 0.70
Nodes (5): ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider.cs, GetFeedUrls(), ConfigurationFeedUrlProvider(), XPoster.Providers

### Community 121 - "Entity (Community 121)"
Cohesion: 0.70
Nodes (5): IAiProviderOptions.cs, IAiProviderOptions.cs, IAiProviderSection, XPoster.Contracts, IAiProviderOptions

### Community 124 - "Entity (Community 124)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, Resolve(), XPoster.Contracts, IOrchestratorFactory

### Community 125 - "Entity (Community 125)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, XPoster.Contracts, ITimeProvider, GetCurrentTime()

### Community 123 - "Entity (Community 123)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, ISlotProfileProvider, GetProfiles(), XPoster.Contracts

### Community 122 - "Entity (Community 122)"
Cohesion: 0.70
Nodes (5): ICredentialsStartupValidator.cs, ICredentialsStartupValidator.cs, ICredentialsStartupValidator, XPoster.Contracts, Validate()

### Community 137 - "Entity (Community 137)"
Cohesion: 0.70
Nodes (5): DefaultSlotProfileProvider.cs, DefaultSlotProfileProvider.cs, XPoster.Providers, ScheduledOrchestrationProfile(), GetProfiles()

### Community 132 - "Entity (Community 132)"
Cohesion: 0.70
Nodes (5): ITextToTextProvider.cs, ITextToTextProvider.cs, ITextToTextProvider, XPoster.Contracts, GenerateTextAsync()

### Community 133 - "Entity (Community 133)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, XPoster.Providers, TimeProvider, GetCurrentTime()

### Community 134 - "Entity (Community 134)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider(), GetCurrentTime(), XPoster.Providers

### Community 135 - "Entity (Community 135)"
Cohesion: 0.70
Nodes (5): AiProviderValidationHelper.cs, AiProviderValidationHelper.cs, ValidateConnectivity(), if(), XPoster.Models

### Community 136 - "Entity (Community 136)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, XPoster.Contracts, SendAsync(), ISender

### Community 131 - "Entity (Community 131)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, XPoster.Contracts, IOrchestrator, PostAsync()

### Community 127 - "Entity (Community 127)"
Cohesion: 0.40
Nodes (5): OpenAiService.cs, if(), GetImageGenerationEndpoint(), GetChatCompletionsEndpoint(), OpenAiService()

### Community 130 - "Entity (Community 130)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, XPoster.Contracts, IFeedService, GetFeedsAsync()

### Community 128 - "Entity (Community 128)"
Cohesion: 0.70
Nodes (5): ImageTestData.cs, ImageTestData.cs, XPoster.Tests.Helpers, CreateValidPng(), CreateValidJpeg()

### Community 129 - "Entity (Community 129)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, GetCryptoValue(), XPoster.Contracts, ICryptoService

### Community 116 - "Entity (Community 116)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration, Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), catch()

### Community 120 - "Entity (Community 120)"
Cohesion: 0.40
Nodes (5): DeepSeekService.cs, var(), XPoster.Services, GenerateTextAsync(), if()

### Community 117 - "Entity (Community 117)"
Cohesion: 0.40
Nodes (5): FeedService.cs, Exception(), catch(), GetFeedsAsync(), XPoster.Services

### Community 119 - "Entity (Community 119)"
Cohesion: 0.40
Nodes (5): PerplexityService.cs, GenerateTextAsync(), XPoster.Services, if(), var()

### Community 118 - "Entity (Community 118)"
Cohesion: 0.70
Nodes (5): ITagReplacementProvider.cs, ITagReplacementProvider.cs, XPoster.Contracts, GetReplacements(), ITagReplacementProvider

### Community 138 - "Entity (Community 138)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, if(), PowerLawOrchestrator(), XPoster.Orchestrators

### Community 139 - "Entity (Community 139)"
Cohesion: 0.70
Nodes (5): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests, ValidOptions(), XPoster.Tests.Models

### Community 140 - "Entity (Community 140)"
Cohesion: 0.70
Nodes (5): ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider.cs, GetReplacements(), XPoster.Providers, ConfigurationTagReplacementProvider()

### Community 111 - "Entity (Community 111)"
Cohesion: 0.70
Nodes (5): LinkedInCredentialsValidator.cs, LinkedInCredentialsValidator.cs, Validate(), if(), XPoster.Credentials

### Community 110 - "Entity (Community 110)"
Cohesion: 0.70
Nodes (5): PromptRequest.cs, PromptRequest.cs, ImagePromptRequest, XPoster.Models, PromptRequest

### Community 109 - "Entity (Community 109)"
Cohesion: 0.70
Nodes (5): IFeedUrlProvider.cs, IFeedUrlProvider.cs, GetFeedUrls(), XPoster.Contracts, IFeedUrlProvider

### Community 112 - "Entity (Community 112)"
Cohesion: 0.40
Nodes (5): OrchestratorFactory.cs, if(), CreateOrchestratorInstance(), InvalidOperationException(), OrchestratorFactory()

### Community 115 - "Entity (Community 115)"
Cohesion: 0.70
Nodes (5): ITagReplacementService.cs, ITagReplacementService.cs, ITagReplacementService, XPoster.Contracts, Apply()

### Community 113 - "Entity (Community 113)"
Cohesion: 0.70
Nodes (5): MaskUrlTelemetryProcessor.cs, MaskUrlTelemetryProcessor.cs, if(), Process(), MaskUrlTelemetryProcessor()

### Community 114 - "Entity (Community 114)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, GenerateImageAsync(), ITextToImageProvider, XPoster.Contracts

### Community 153 - "Entity (Community 153)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, return(), catch(), if()

### Community 145 - "Entity (Community 145)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, catch(), Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), StringContent()

### Community 146 - "Entity (Community 146)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, XPoster.Extensions, AddXPosterAiProviders()

### Community 152 - "Entity (Community 152)"
Cohesion: 0.83
Nodes (4): FeedPromptOptions.cs, FeedPromptOptions.cs, GetStep(), XPoster.Models

### Community 148 - "Entity (Community 148)"
Cohesion: 0.83
Nodes (4): CredentialsExtensions.cs, CredentialsExtensions.cs, AddCredentials(), XPoster.Credentials

### Community 147 - "Entity (Community 147)"
Cohesion: 0.50
Nodes (4): PerplexityService.cs, GetChatCompletionsEndpoint(), PerplexityService(), while()

### Community 149 - "Entity (Community 149)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, XPoster.Models, ScheduledOrchestrationProfile()

### Community 150 - "Entity (Community 150)"
Cohesion: 0.83
Nodes (4): PendingContainer.cs, PendingContainer.cs, PendingContainer(), XPoster.Models

### Community 151 - "Entity (Community 151)"
Cohesion: 0.50
Nodes (4): DeepSeekService.cs, GetChatCompletionsEndpoint(), while(), DeepSeekService()

### Community 164 - "Entity (Community 164)"
Cohesion: 0.83
Nodes (4): AiProviderOptionsCompositionExtensions.cs, AiProviderOptionsCompositionExtensions.cs, AddAiProviderOptions(), XPoster.Extensions

### Community 154 - "Entity (Community 154)"
Cohesion: 0.83
Nodes (4): FeedOrchestratorContext.cs, FeedOrchestratorContext.cs, XPoster.Models, FeedOrchestratorContext

### Community 163 - "Entity (Community 163)"
Cohesion: 0.83
Nodes (4): SenderPluginsServiceCollectionExtensions.cs, SenderPluginsServiceCollectionExtensions.cs, XPoster.Extensions, AddXPosterSenderPlugins()

### Community 162 - "Entity (Community 162)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, XPoster.Orchestrators, NoOrchestrator()

### Community 156 - "Entity (Community 156)"
Cohesion: 0.50
Nodes (4): XSender.cs, XPoster.SenderPlugins, SendAsync(), catch()

### Community 158 - "Entity (Community 158)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, PostAsync(), BaseOrchestrator(), XPoster.Orchestrators

### Community 155 - "Entity (Community 155)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, Post, XPoster.Models

### Community 157 - "Entity (Community 157)"
Cohesion: 0.50
Nodes (4): FalAiOptionsValidator.cs, XPoster.Models, Validate(), foreach()

### Community 161 - "Entity (Community 161)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, catch(), GetCryptoValue(), XPoster.Services

### Community 160 - "Entity (Community 160)"
Cohesion: 0.83
Nodes (4): BlobUploadResult.cs, BlobUploadResult.cs, BlobUploadResult(), XPoster.Models

### Community 159 - "Entity (Community 159)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, BuildSequenceHandler(), var(), XPoster.Tests.Helpers

### Community 144 - "Entity (Community 144)"
Cohesion: 0.50
Nodes (4): CredentialsStartupValidator.cs, ValidateOptions(), foreach(), resolve()

### Community 141 - "Entity (Community 141)"
Cohesion: 0.50
Nodes (4): HttpClientExtensions.cs, AddHttpClients(), XPoster.Extensions, AddResilientHttpClient()

### Community 142 - "Entity (Community 142)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, GetLabel(), XPoster.Contracts

### Community 143 - "Entity (Community 143)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, for(), Polly_Instagram_AttemptTimeout_CancelsSlowRequest(), StringContent()

### Community 165 - "Entity (Community 165)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, RSSFeed, XPoster.Models

### Community 178 - "Entity (Community 178)"
Cohesion: 1.00
Nodes (3): XPoster.Models, PromptStepOptions.cs, PromptStepOptions.cs

### Community 191 - "Entity (Community 191)"
Cohesion: 1.00
Nodes (3): XPoster.Models, BlobStorageOptions.cs, BlobStorageOptions.cs

### Community 193 - "Entity (Community 193)"
Cohesion: 1.00
Nodes (3): FacebookCredentials.cs, FacebookCredentials.cs, XPoster.Credentials

### Community 192 - "Entity (Community 192)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, XPoster.Models, AzureFoundryOptions.cs

### Community 190 - "Entity (Community 190)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, DeepSeekOptions.cs, XPoster.Models

### Community 188 - "Entity (Community 188)"
Cohesion: 1.00
Nodes (3): AiModelClass.cs, XPoster.Contracts, AiModelClass.cs

### Community 179 - "Entity (Community 179)"
Cohesion: 1.00
Nodes (3): PromptRole.cs, PromptRole.cs, XPoster.Models

### Community 187 - "Entity (Community 187)"
Cohesion: 0.67
Nodes (3): XCredentialsValidator.cs, XPoster.Credentials, Validate()

### Community 189 - "Entity (Community 189)"
Cohesion: 0.67
Nodes (3): XSender.cs, XSender(), if()

### Community 180 - "Entity (Community 180)"
Cohesion: 1.00
Nodes (3): XCredentials.cs, XCredentials.cs, XPoster.Credentials

### Community 181 - "Entity (Community 181)"
Cohesion: 1.00
Nodes (3): ContainerStatus.cs, XPoster.Contracts, ContainerStatus.cs

### Community 182 - "Entity (Community 182)"
Cohesion: 0.67
Nodes (3): FbSenderResilienceTests.cs, BuildCreds(), BuildFactory()

### Community 183 - "Entity (Community 183)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, BuildFactory(), params()

### Community 185 - "Entity (Community 185)"
Cohesion: 0.67
Nodes (3): HttpClientExtensions.cs, if(), IsTransientHttpFailure()

### Community 186 - "Entity (Community 186)"
Cohesion: 1.00
Nodes (3): XPoster.Contracts, SenderPlatform.cs, SenderPlatform.cs

### Community 184 - "Entity (Community 184)"
Cohesion: 0.67
Nodes (3): InSender.cs, if(), InSender()

### Community 176 - "Entity (Community 176)"
Cohesion: 1.00
Nodes (3): OpenAiOptions.cs, XPoster.Models, OpenAiOptions.cs

### Community 175 - "Entity (Community 175)"
Cohesion: 1.00
Nodes (3): PerplexityOptions.cs, PerplexityOptions.cs, XPoster.Models

### Community 177 - "Entity (Community 177)"
Cohesion: 1.00
Nodes (3): FeedOptions.cs, FeedOptions.cs, XPoster.Models

### Community 174 - "Entity (Community 174)"
Cohesion: 0.67
Nodes (3): FeedService.cs, if(), FeedService()

### Community 171 - "Entity (Community 171)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, XPoster.Models, FalAiOptions.cs

### Community 173 - "Entity (Community 173)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, LinkedInCredentials.cs, LinkedInCredentials.cs

### Community 166 - "Entity (Community 166)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, InstagramCredentials.cs, InstagramCredentials.cs

### Community 172 - "Entity (Community 172)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, AiProvider.cs, XPoster.Contracts

### Community 170 - "Entity (Community 170)"
Cohesion: 1.00
Nodes (3): TagReplacementOptions.cs, TagReplacementOptions.cs, XPoster.Models

### Community 169 - "Entity (Community 169)"
Cohesion: 0.67
Nodes (3): BaseOrchestrator.cs, DispatchAsync(), if()

### Community 167 - "Entity (Community 167)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, if(), CryptoService()

### Community 168 - "Entity (Community 168)"
Cohesion: 0.67
Nodes (3): FalAiOptionsValidator.cs, nameof(), if()

### Community 194 - "Entity (Community 194)"
Cohesion: 1.00
Nodes (2): XCredentialsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._


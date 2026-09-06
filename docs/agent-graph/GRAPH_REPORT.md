# Graph Report - XPoster  (2026-09-06)

## Summary
- 1885 nodes · 3188 edges · 230 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Tests.Models` - 2 edges
2. `RSSFeedTests` - 2 edges
3. `XPoster.Tests.Integration` - 2 edges
4. `FacebookCredentialsValidator` - 2 edges
5. `XPoster.Models` - 2 edges
6. `XPoster.Contracts` - 2 edges
7. `XPoster.Credentials` - 2 edges
8. `IBlobStorageService` - 2 edges
9. `XPoster.Workflows.Nodes` - 2 edges
10. `AzureFoundryOptionsTests` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, new(), MakeResponse(), MakeHttpClientThatThrows(), ParseChatCompletionResponseAsync_WhenChoicesIsEmpty_ReturnsFalseAndEmpty(), OpenAiB64Json(), ParseChatCompletionResponseAsync_WhenEmptyChoices_LogsWarningWithProviderName() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.10
Nodes (41): AzureFoundryServiceTests.cs, AzureFoundryServiceTests.cs, GenerateTextAsync_PostsToChatCompletionsEndpoint(), GenerateImageAsync_WhenResponseBodyIsMalformedJson_ReturnsEmptyByteArray(), GenerateImageAsync_WhenInputTextIsWhitespace_ReturnsEmptyByteArrayWithoutCallingApi(), GenerateTextAsync_RequestBodyContainsTemperatureAndMaxTokensFromRequest(), GenerateTextAsync_RequestBodyContainsSystemAndUserMessagesFromRequest(), GenerateTextAsync_RequestBodyContainsModelFromOptions() (+33 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.11
Nodes (36): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GenerateTextAsync_WhenResponseAlwaysExceedsMaxOutputLength_StopsAfterThreeAttempts(), GenerateTextAsync_WhenChoicesIsNull_ReturnsEmpty(), GenerateTextAsync_WhenNoMaxOutputLength_DoesNotRetry(), GenerateTextAsync_WhenOutputFitsWithinMaxOutputLength_ReturnsSingleCallResult(), GenerateTextAsync_UsesSystemPromptTemplateFromRequest(), GenerateImageAsync_WhenResponseBodyIsMalformedJson_ReturnsEmptyArray() (+28 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, Parse_FalAi_EmptyUrl_ReturnsEmpty(), Parse_FalAi_MissingImagesProperty_ReturnsEmpty(), Parse_FalAi_MissingUrlProperty_ReturnsEmpty(), Parse_UnsupportedProvider_ReturnsEmpty(), Parse_Returns429_ReturnsEmpty(), Parse_UnsupportedProvider_LogsError(), Parse_NonSuccessStatus_ReturnsEmpty() (+24 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.12
Nodes (32): DryRunSenderTests.cs, DryRunSenderTests.cs, SendAsync_WithNullPost_LogsWarning(), SendAsync_WithNullContent_StillReturnsTrueWhenKeyPresent(), SendAsync_WithImageBytes_ReturnsTrue(), SendAsync_WithImageAttached_ReturnsTrueAndLogsImagePresent(), DryRunSenderTests(), Constructor_WithNullLogger_ThrowsArgumentNullException() (+24 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, BuildConfig(), ConfigurationBuilder(), BuildProvider(), SectionName_IsDeepSeek(), register(), SectionName_IsAzureFoundry() (+21 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.14
Nodes (28): PerplexityServiceTests.cs, PerplexityServiceTests.cs, GenerateTextAsync_WhenMaxOutputLengthIsNull_CallsApiOnce(), GenerateTextAsync_WhenInputTextLabelIsNull_FallsBackToDefaultLabel(), GenerateTextAsync_WhenFirstResponseStillTooLong_RetriesAndReturnsSecondResponse(), GenerateTextAsync_WhenChoicesIsNull_ReturnsEmptyString(), MakeSequentialHandlerMock(), GenerateTextAsync_WhenTextRemainsLongAfterMaxRetries_ReturnsLastApiContent() (+20 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.15
Nodes (26): FbSenderTests.cs, FbSenderTests.cs, SendAsync_TextOnly_WhenResponseHasNullId_ReturnsFalse(), Platform_ReturnsFacebook(), return(), SendAsync_TextOnly_WhenResponseHasEmptyId_ReturnsFalse(), NormalizeImage_WithValidJpeg_ReturnsSameBytes(), FbSenderTests() (+18 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.16
Nodes (25): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, GenerateTextAsync_WhenChoicesIsNull_ReturnsEmptyString(), GenerateTextAsync_WhenCancellationRequested_ThrowsOperationCanceledException(), GenerateTextAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GenerateTextAsync_WhenChoicesIsNull_ForImagePromptRole_ReturnsEmptyString(), MakeHandlerMock(), new() (+17 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.16
Nodes (25): NodeParameterExtractorTests.cs, NodeParameterExtractorTests.cs, GetParameter_MalformedJson_ForList_ReturnsEmptyOrNull(), GetParameter_JsonElement_ToList(), GetParameter_JsonObjectString_ToDictionary(), GetParameter_JsonElement_ToString(), GetParameter_JsonElement_ToBool(), GetParameter_DirectCast_Int() (+17 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.10
Nodes (21): WorkflowExecutionEngineTests.cs, WorkflowExecutionEngineTests, XPoster.Tests.Workflows.Engine, Execute_PowerLawChain_AcquireThenBuildThenFanOut_StoresOutputs(), foreach(), Execute_UnregisteredNodeType_ReturnsFailure(), ExecuteAsync(), return() (+13 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.19
Nodes (21): XSenderTests.cs, XSenderTests.cs, SendAsync_WhenTwitterContextThrows_ReturnsFalse(), SendAsync_PostWithImage_CatchesTwitterException_ReturnsFalse(), SendAsync_ValidTextPost_CatchesTwitterException_ReturnsFalse(), SendAsync_ValidPost_TriesTwitterAndReturnsFalse(), XSenderTests(), XPoster.Tests.SenderPlugins (+13 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.22
Nodes (18): AiProviderOptionsAbstractionTests.cs, AiProviderOptionsAbstractionTests.cs, OpenAiOptions_ModelCatalog_ExposesTextAndImage(), ModelCatalog_UnsupportedCapability_GetRequired_Throws(), OpenAiOptions_ApiKeyAndEndpoint_AccessibleThroughAbstraction(), OpenAiOptions_ImplementsIAiProviderOptions(), FalAiOptions_NumInferenceSteps_RemainsOnConcreteClass(), DeepSeekOptions_ModelCatalog_ExposesTextOnly() (+10 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.22
Nodes (18): IgSenderImageFlowTests.cs, IgSenderImageFlowTests.cs, return(), NormalizeImage_WithInvalidBytes_ReturnsNull(), NormalizeImage_WithValidPng_ReturnsJpegBytes(), NormalizeImage_WithValidJpeg_ReturnsSameBytes(), NormalizeImage_WhenCodecIsNull_ReturnsNull(), CreateMalformedPngBytes() (+10 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, FeedService(), BuildFactory(), BuildService(), BuildRssXml(), FakeHttpMessageHandler(), GetFeedsAsync_ReturnsEmpty_WhenFeedIsInvalidXml() (+10 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.22
Nodes (18): AiServiceHelperChatPayloadTests.cs, AiServiceHelperChatPayloadTests.cs, BuildRequest(), BuildChatPayload_SecondMessageRoleIsUser(), BuildChatPayload_WhenInputTextLabelIsNull_FallsBackToTextPlaceholder(), BuildChatPayload_SubstitutesCustomLabelInUserMessage(), BuildChatPayload_SystemMessage_NoPlaceholder_IsUnchanged(), BuildChatPayload_MessagesContainsTwoEntries() (+10 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.22
Nodes (18): WorkflowContextTests.cs, WorkflowContextTests.cs, XPoster.Tests.Workflows.Models, TryGetData_ReturnsFalse_OnTypeMismatch(), TryGetData_ReturnsFalse_WhenKeyMissing(), TryGetData_ReturnsTrue_WhenKeyExists(), WorkflowContextTests, GetData_ThrowsOnTypeMismatch() (+10 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.23
Nodes (17): MetaPublishingServiceTests.cs, MetaPublishingServiceTests.cs, PublishContainerAsync_WhenRateLimited_Throws(), MetaPublishingService(), PublishContainerAsync_WhenIdIsNull_ReturnsEmptyString(), GetContainerStatusAsync_WithEmptyCreationId_ThrowsArgumentException(), PublishContainerAsync_WhenCancelled_ThrowsTaskCanceledException(), PublishContainerAsync_WhenOk_ReturnsPublishId() (+9 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.23
Nodes (17): PromptRequestTests.cs, PromptRequestTests.cs, ImagePromptRequest_ValueEquality_SameValues_AreEqual(), ImagePromptRequest_ImageProperties_AreSetCorrectly(), ImagePromptRequest_ImageProperties_DefaultToNull(), ImagePromptRequest_IsImmutable_AfterConstruction(), ImagePromptRequest_InheritsFrom_PromptRequest(), ImagePromptRequest_BaseProperties_AreAccessible() (+9 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.23
Nodes (17): WorkflowServiceCollectionExtensionsTests.cs, WorkflowServiceCollectionExtensionsTests.cs, AddWorkflows_Registers_WorkflowEngine(), AddWorkflows_ConvertsParameters_ToObjectDictionary(), AddWorkflows_Registers_WorkflowDefinitions_AsKeyedSingletons(), AddWorkflows_Registers_KeyedNodes(), AddWorkflows_Registers_StepOptionsResolver(), ServiceCollection() (+9 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.24
Nodes (16): ConfigurationSlotProfileProviderTests.cs, ConfigurationSlotProfileProviderTests.cs, GetProfiles_Should_OrderSlotsByHour(), GetProfiles_Should_SkipSlot_WithNoSenders(), GetProfiles_Should_ParseSenderPlatforms(), GetProfiles_Should_SkipSlot_WhenNoValidSendersRemain(), GetProfiles_Should_ReturnEmpty_WhenNoScheduleConfigured(), GetProfiles_Should_MapEachSlotToWorkflowOrchestrator() (+8 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.12
Nodes (16): WorkflowDefinitionValidatorTests.cs, XPoster.Tests.Workflows.Engine, ValidateTerminalNodeContract_TerminalImplementsContract_ReturnsNull(), WorkflowDefinitionValidatorTests, WorkflowDefinition(), ValidateTerminalNodeContract_UnresolvableTerminalType_ReturnsNull(), MissingRef(), Linear() (+8 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.24
Nodes (16): InMemoryContainerStateStoreTests.cs, InMemoryContainerStateStoreTests.cs, SaveAsync_WithNullBlobName_ThrowsArgumentNullException(), GetPendingAsync_WhenStoreIsEmpty_ReturnsEmptyList(), InMemoryContainerStateStoreTests, SaveAsync_WithEmptyOrWhitespaceCreationId_ThrowsArgumentException(), SaveAsync_WithEmptyOrWhitespaceBlobName_ThrowsArgumentException(), SaveAsync_WithNullCreationId_ThrowsArgumentNullException() (+8 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.26
Nodes (15): BlobStorageServiceTests.cs, BlobStorageServiceTests.cs, UploadAsync_WhenStorageThrows_PropagatesException(), XPoster.Tests.Services, CreateSut(), Constructor_WhenContainerNameIsEmpty_UsesDefaultName(), BlobStorageServiceTests, BlobStorageService() (+7 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.26
Nodes (15): AddAiProviderOptionsTests.cs, AddAiProviderOptionsTests.cs, AddAiProviderOptions_ReturnsSameServiceCollection(), AddAiProviderOptions_BindsPerplexityOptions_FromCorrectSection(), AddAiProviderOptions_DoesNotDuplicateValidatorRegistrations_WhenCalledOnce(), AddAiProviderOptions_RegistersAllFiveValidators(), AddAiProviderOptions_RegistersAllFiveOptionTypes(), AddAiProviderOptionsTests (+7 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.26
Nodes (15): MaskUrlTelemetryProcessorTests.cs, MaskUrlTelemetryProcessorTests.cs, XPoster.Tests.Services, Initialize_WhenTelemetryIsNotDependency_DoesNothing(), Initialize_WhenFacebookUrlHasAccessToken_TokenIsMasked(), Initialize_WhenHttpDependencyNotFacebook_DoesNotModifyData(), Initialize_WhenFacebookUrlHasOnlyAccessToken_TokenIsMasked(), Initialize_WhenFacebookUrlHasNoQueryString_DataUnchanged() (+7 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.26
Nodes (15): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, XPoster.Tests.SenderPlugins, PostWithImage(), new(), BuildSender(), IgSenderResilienceTests, IgSender() (+7 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.14
Nodes (14): WorkflowOrchestratorTests.cs, OrchestrateAsync_ReturnsEmptyDictionary_OnFailure(), MakeDefinitionWithoutImage(), MakeDefinition(), OrchestrateAsync_ReturnsEmptyDictionary_WhenSendResultsMissing(), ProduceImage_IsTrue_WhenWorkflowHasAiImageNode(), OrchestrateAsync_ReturnsPostMap_OnSuccess(), ProduceImage_Set_ThrowsNotSupported() (+6 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.14
Nodes (14): FanOutSendNodeTests.cs, Execute_StoresSendResultsInContext(), FanOutSendNodeTests, Execute_TwoSenders_ResummarisesForSmallSenderAndKeepsVariantForWideSender(), Execute_TwoSenders_DistinctPlatforms_ReSummarisationRunsPerSender(), Input(), return(), Execute_ShortText_NoResummary() (+6 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.27
Nodes (14): XPosterContainerPollingFunction.cs, XPosterContainerPollingFunction.cs, Run(), HandleFinishedAsync(), PollPendingContainersAsync(), if(), ProcessContainerAsync(), HandleTerminalFailureAsync() (+6 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, RSSFeed_PublishDate_DefaultsToMinValue(), XPoster.Tests.Models, AIResponse_CanBeCreated_WithChoices(), Post_CanHold_ImageBytes(), ImageData_CanBeCreated_WithUrl(), Message_CanBeCreated_WithContent() (+6 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.15
Nodes (13): InSenderTests.cs, SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn(), SendAsync_TextOnly_WithPersonCode_UsesPersonUrn(), BuildCreds(), Constructor_WithNullLogger_ThrowsArgumentNullException(), SendAsync_TextOnly_WhenPostCreationFails_ReturnsFalse(), BuildSender(), InSender_ImplementsISender() (+5 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProvider(), GetCurrentTime_WhenForceHourIsAbsent_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsValid_ReturnsForcedHour(), GetCurrentTime_WhenForceHourIsOutOfRange_WrapsViaDateTimeOverflow(), GetCurrentTime_WhenForceHourIsEmpty_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsValid_ReturnsUtcKind() (+5 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.29
Nodes (13): AiModelCatalogTests.cs, AiModelCatalogTests.cs, AiModelCatalogTests, Supports_ReturnsFalseForMissingModelClass(), Constructor_ExcludesNullOrWhitespaceEntries(), Empty_SupportsNoModelClass(), GetRequired_Throws_WhenNotSupported(), GetRequired_ReturnsModelName_WhenSupported() (+5 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, XPoster.Tests.Models, Validate_MissingApiKey_Fails(), Validate_WhitespaceModelId_Fails(), ValidOptions(), Validate_WhitespaceApiKey_Fails(), Validate_ValidOptions_Succeeds() (+5 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.15
Nodes (13): FalAiImageServiceTests.cs, GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray(), BuildService(), GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray(), FalImageJson(), FalAiImageServiceTests, GenerateImageAsync_ValidResponse_ReturnsImageBytes() (+5 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.15
Nodes (13): AiImageNodeTests.cs, if(), WorkflowNodeInput(), Input(), return(), static(), XPoster.Tests.Workflows.Nodes, Execute_ReturnsSoftFailure_WhenRequiredFalse_AndImageMissing() (+5 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.32
Nodes (12): AzureFoundryService.cs, AzureFoundryService.cs, GetImageGenerationEndpoint(), catch(), GenerateImageAsync(), AzureFoundryService(), GenerateTextAsync(), GetChatCompletionsEndpoint() (+4 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.17
Nodes (12): OrchestratorFactoryTests.cs, Resolve_ForMissingContextKey_ReturnsNoOrchestrator(), foreach(), NoOrchestrator_SupportedPlatforms_IsEmpty(), Resolve_Should_ResolveKeyedSender_ForEachSupportedPlatform(), typeof(), Resolve_Should_ReturnWorkflowOrchestrator_ForAnyConfiguredSlot(), Resolve_Should_ReturnNoOrchestrator_WhenNoProfileMatchesCurrentHour() (+4 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.32
Nodes (12): ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests.cs, GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsPropertyIsNull(), GetReplacements_Should_ReturnReadOnlyDictionary(), XPoster.Tests.Providers, GetReplacements_Should_PreserveAllEntries_When_MultipleReplacementsConfigured(), foreach(), ConfigurationTagReplacementProviderTests (+4 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.32
Nodes (12): ConfigurationStepOptionsResolverTests.cs, ConfigurationStepOptionsResolverTests.cs, Resolve_Throws_OnNullOrWhitespaceStepId(), BuildConfig(), Resolve_BindsMaxOutputLength_WhenPresent(), Resolve_BindsImageProperties_WhenPresent(), foreach(), ConfigurationStepOptionsResolverTests (+4 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.17
Nodes (12): XPosterContainerPollingFunctionTests.cs, XPoster.Tests, RunAsync_WhenMultiplePendingContainers_ProcessesAll(), RunAsync_WhenUnexpectedExceptionThrown_LogsErrorAndRethrows(), RunAsync_WhenStatusIsUnknown_LogsWarningAndSkips(), RunAsync_WhenStatusIsError_MarksFailedAndCleansUp(), RunAsync_WhenNoPendingContainers_DoesNothing(), RunAsync_WhenStatusIsInProgress_SkipsContainer() (+4 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.17
Nodes (12): InSenderTests.cs, SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalseAndLogsWarning(), MessageMaxLength_Returns2800(), SendAsync_WhenNeitherOrgIdNorOwnerCodeSet_ReturnsFalse(), Platform_ReturnsLinkedIn(), SendAsync_TextOnly_WithOrgId_UsesOrganizationUrn(), SendAsync_ValidPost_TriesLinkedInAndReturnsFalse() (+4 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_LogsError(), MakeHandlerMock(), GenerateImageAsync_WhitespacePrompt_ReturnsEmptyArray(), MakeRequest(), GenerateImageAsync_RequestUsesImageQuantityFromRequest(), GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithMultipleSegments_PreservesSlashesInUri() (+4 more)

### Community 47 - "Entity (Community 47)"
Cohesion: 0.35
Nodes (11): AiProviderServiceCollectionExtensionsTests.cs, AiProviderServiceCollectionExtensionsTests.cs, XPoster.Tests.Extensions, AddXPosterAiProviders_RegistersDeepSeek_AsTextOnly(), AddXPosterAiProviders_RegistersExpectedNumberOfKeyedServices(), AddXPosterAiProviders_RegistersOpenAi_AsTextAndImageProvider(), AddXPosterAiProviders_ReturnsSameServiceCollection(), AiProviderServiceCollectionExtensionsTests (+3 more)

### Community 46 - "Entity (Community 46)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, XPoster.Tests.SenderPlugins, InSender(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), ValidPost(), SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue(), InSenderResilienceTests (+3 more)

### Community 45 - "Entity (Community 45)"
Cohesion: 0.35
Nodes (11): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, OrchestratorContextKey_Should_BeNull_WhenNotProvided(), OrchestratorContextKey_Should_BeSet_WhenProvided(), TwoSlotsWithSameOrchestratorType_Should_CarryIndependentContextKeys(), typeof(), XPoster.Tests.Models, ScheduledOrchestrationProfileTests (+3 more)

### Community 44 - "Entity (Community 44)"
Cohesion: 0.18
Nodes (11): IgSenderTests.cs, Constructor_WithNullHttpClientFactory_ThrowsArgumentNullException(), Constructor_InitializesCorrectly(), Constructor_WithNullContainerStateStore_ThrowsArgumentNullException(), BuildSender(), BuildCreds(), new(), XPoster.Tests.SenderPlugins (+3 more)

### Community 48 - "Entity (Community 48)"
Cohesion: 0.38
Nodes (10): IgSenderSendAsyncTests.cs, IgSenderSendAsyncTests.cs, SendAsync_WithNoImage_ReturnsFalse(), SendAsync_WithEmptyImageArray_ReturnsFalse(), BuildSender(), IgSender(), SendAsync_WithCaptionExceedingMaxLength_TruncatesCaption(), IgSenderSendAsyncTests (+2 more)

### Community 55 - "Entity (Community 55)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, Build(), OrchestrateAsync_ReturnsEmptyList(), Name_IsNoOrchestrator(), NoOrchestratorTests, SendIt_Set_ThrowsNotImplementedException(), XPoster.Tests.Orchestrators (+2 more)

### Community 54 - "Entity (Community 54)"
Cohesion: 0.38
Nodes (10): FbSender.cs, FbSender.cs, if(), PublishPhotoAsync(), XPoster.SenderPlugins, PublishTextOnlyAsync(), SendAsync(), catch() (+2 more)

### Community 49 - "Entity (Community 49)"
Cohesion: 0.38
Nodes (10): FbSenderSendAsyncTests.cs, FbSenderSendAsyncTests.cs, SendAsync_WithCaptionLongerThanMax_StillPublishes_ReturnsTrue(), SendAsync_WithNullImage_PublishesTextOnly_ReturnsTrue(), BuildFactory(), SendAsync_WithEmptyImage_PublishesTextOnly_ReturnsTrue(), BuildCreds(), FbSenderSendAsyncTests (+2 more)

### Community 53 - "Entity (Community 53)"
Cohesion: 0.38
Nodes (10): XSenderResilienceTests.cs, XSenderResilienceTests.cs, SendAsync_WhenContentIsBlank_ReturnsFalseAndLogsWarning(), XSender(), SendAsync_WhenTextTweetFails_ReturnsFalseAndLogsError(), SendAsync_WhenPostIsNull_ReturnsFalseAndLogsWarning(), XSenderResilienceTests, XPoster.Tests.SenderPlugins (+2 more)

### Community 52 - "Entity (Community 52)"
Cohesion: 0.38
Nodes (10): XFunctionTests.cs, XFunctionTests.cs, Run_Should_LogError_When_OrchestrateAsync_ReturnsEmptyDictionary(), Run_Should_LogError_When_PostAsync_ReturnsFalse(), XFunctionTests(), XPoster.Tests, Run_Should_LogWarning_AndNotRethrow_When_CancelledGracefully(), Run_Should_Rethrow_When_Factory_Throws() (+2 more)

### Community 51 - "Entity (Community 51)"
Cohesion: 0.38
Nodes (10): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, Validate_WhenEndpointIsEmpty_ReturnsFailed(), Validate_WhenApiKeyIsEmpty_ReturnsFailed(), PerplexityOptionsValidatorTests, Validate_WhenTextModelNameIsEmpty_ReturnsFailed(), Validate_WithValidOptions_ReturnsSuccess(), Validate_WithMultipleInvalidFields_ReturnsAllFailures() (+2 more)

### Community 50 - "Entity (Community 50)"
Cohesion: 0.38
Nodes (10): MetaPublishingService.cs, MetaPublishingService.cs, MetaPublishingService(), PublishContainerAsync(), XPoster.Services, HttpRequestException(), catch(), GetApiVersion() (+2 more)

### Community 57 - "Entity (Community 57)"
Cohesion: 0.22
Nodes (9): InSender.cs, Exception(), catch(), InvalidOperationException(), ResolveAuthorUrn(), SendAsync(), XPoster.SenderPlugins, using() (+1 more)

### Community 56 - "Entity (Community 56)"
Cohesion: 0.42
Nodes (9): RSSFeedTests.cs, RSSFeedTests.cs, RSSFeed_CanSetPublishDate(), RSSFeed_DefaultPublishDateIsMinValue(), RSSFeed_RecordEquality_SameValues_AreEqual(), XPoster.Tests.Models, RSSFeedTests, RSSFeed_RecordEquality_DifferentValues_AreNotEqual() (+1 more)

### Community 68 - "Entity (Community 68)"
Cohesion: 0.22
Nodes (9): BaseOrchestratorTests.cs, PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_ReturnsFalse_WhenSenderListIsEmpty(), PostAsync_SkipsNullPost_ReturnsFalse(), PostAsync_ReturnsFalse_WhenOneSenderFails(), PostAsync_ReturnsTrue_When_AllConditionsMet() (+1 more)

### Community 66 - "Entity (Community 66)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, XSenderSendAsyncTests(), SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), XPoster.Tests.SenderPlugins (+1 more)

### Community 67 - "Entity (Community 67)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, var(), XPoster.Tests.Integration, HttpResponseMessage(), params(), BuildDelayedHandler(), BuildSequenceHandler() (+1 more)

### Community 69 - "Entity (Community 69)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), XPoster.Tests.Services, MakeService(), CryptoService(), CryptoServiceTests, GetCryptoValue_ReturnsZero_AndLogsError_OnException() (+1 more)

### Community 64 - "Entity (Community 64)"
Cohesion: 0.42
Nodes (9): HttpClientExtensionsTests.cs, HttpClientExtensionsTests.cs, AddHttpClients_RegistersExpectedNamedClients(), foreach(), AddHttpClients_RegistersIHttpClientFactory(), HttpClientExtensionsTests, XPoster.Tests.Extensions, AddHttpClients_ReturnsSameServiceCollection() (+1 more)

### Community 63 - "Entity (Community 63)"
Cohesion: 0.42
Nodes (9): WorkflowExecutionEngine.cs, WorkflowExecutionEngine.cs, WorkflowExecutionResult(), XPoster.Workflows.Engine, ExecuteAsync(), if(), foreach(), WorkflowExecutionEngine() (+1 more)

### Community 65 - "Entity (Community 65)"
Cohesion: 0.42
Nodes (9): AcquireCryptoValueNodeTests.cs, AcquireCryptoValueNodeTests.cs, Input(), XPoster.Tests.Workflows.Nodes, WorkflowNodeInput(), Execute_ReturnsZero_WhenCryptoServiceReturnsZero(), Execute_ReturnsCryptoValue_WhenSymbolParameterProvided(), AcquireCryptoValueNodeTests() (+1 more)

### Community 61 - "Entity (Community 61)"
Cohesion: 0.22
Nodes (9): FbSenderResilienceTests.cs, SendAsync_WhenTextPublishReturns200WithoutId_ReturnsFalse(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), SendAsync_WhenTextPublishReturns200WithId_ReturnsTrue(), SendAsync_WhenTextPublishReturns200WithEmptyId_ReturnsFalse(), FbSenderResilienceTests, HttpResponseMessage(), SendAsync_WhenFacebookReturns503_ReturnsFalseAndLogsError() (+1 more)

### Community 60 - "Entity (Community 60)"
Cohesion: 0.22
Nodes (9): FbSenderImageFlowTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WhenPhotoPublishThrows_FallsBackToTextOnly(), HttpRequestException(), SendAsync_WhenImageNormalizationFails_FallsBackToTextOnly(), InvalidImageBytes(), BuildCreds(), BuildFactory() (+1 more)

### Community 59 - "Entity (Community 59)"
Cohesion: 0.22
Nodes (9): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenStatusIsFinished_PublishesAndCleansUp(), RunAsync_WhenUpdateStatusThrows_PropagatesException(), RunAsync_WhenCancelled_StopsGracefully(), CreateTimerInfo(), RunAsync_WhenBlobDeleteFails_StillUpdatesStatus(), PendingContainer(), RunAsync_WhenStatusIsExpired_MarksFailedAndCleansUp() (+1 more)

### Community 58 - "Entity (Community 58)"
Cohesion: 0.42
Nodes (9): AiModelCatalog.cs, AiModelCatalog.cs, if(), GetRequired(), AiModelCatalog(), Supports(), XPoster.Models, TryGet() (+1 more)

### Community 62 - "Entity (Community 62)"
Cohesion: 0.42
Nodes (9): FacebookResiliencePipelineTests.cs, FacebookResiliencePipelineTests.cs, catch(), Polly_Facebook_CircuitBreaker_OpensAfterConsecutiveFailures(), XPoster.Tests.Integration, Polly_Facebook_AttemptTimeout_CancelsSlowRequest(), Polly_Facebook_OnRetry_LogEntryIsEmitted(), for() (+1 more)

### Community 72 - "Entity (Community 72)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, CaptureLoggerProvider(), CaptureLogger(), Dispose(), XPoster.Tests.Integration, IsEnabled(), CreateLogger()

### Community 78 - "Entity (Community 78)"
Cohesion: 0.46
Nodes (8): WorkflowContext.cs, WorkflowContext.cs, KeyNotFoundException(), SetData(), XPoster.Workflows.Models, WorkflowContext, if(), HasData()

### Community 71 - "Entity (Community 71)"
Cohesion: 0.46
Nodes (8): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, ValidOptions(), XPoster.Tests.Models, Validate_ValidOptions_Succeeds(), DeepSeekOptionsValidatorTests, Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), Validate_MissingRequiredProperties_Fails()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.25
Nodes (8): BaseOrchestratorTests.cs, TestOrchestrator(), PostAsync_ReturnsFalse_WhenSenderPlatformNotInDictionary(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), BaseOrchestratorTests(), PostAsync_DispatchesEachPostToAlignedSender()

### Community 70 - "Entity (Community 70)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), InSenderSendAsyncTests(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.46
Nodes (8): FetchRssNode.cs, FetchRssNode.cs, XPoster.Workflows.Nodes, WorkflowNodeResult(), foreach(), FetchRssNode(), if(), ExecuteAsync()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.25
Nodes (8): OrchestratorFactoryTests.cs, CreateFactoryWithProfiles(), WorkflowOrchestrator_SupportedPlatforms_ContainsAllExpectedPlatforms(), SetupMocksForOrchestratorFactory(), OrchestratorFactoryTests(), new(), WorkflowProfile(), CreateFactory()

### Community 81 - "Entity (Community 81)"
Cohesion: 0.46
Nodes (8): BlobStorageService.cs, BlobStorageService.cs, if(), UploadAsync(), DeleteAsync(), BlobStorageService(), BlobUploadResult(), XPoster.Services

### Community 75 - "Entity (Community 75)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(), GetLabel_DescriptionMatchesEnumName(), GetLabel_UnknownProvider_ReturnsFallbackToString(), XPoster.Tests.Contracts, AiProviderExtensionsTests, GetLabel_DescriptionDiffersFromEnumName()

### Community 86 - "Entity (Community 86)"
Cohesion: 0.25
Nodes (8): BuildPowerLawPostNodeTests.cs, WorkflowNodeInput(), XPoster.Tests.Workflows.Nodes, new(), Execute_ComputesFairValueAndAppendsDelta_WhenActualPositive(), Execute_CalculatesCorrectPowerLawValue_ForFixedDate(), Execute_OmitsDelta_WhenActualValueZeroOrMissing(), CreateNode()

### Community 73 - "Entity (Community 73)"
Cohesion: 0.25
Nodes (8): AiTextNodeTests.cs, XPoster.Tests.Workflows.Nodes, WorkflowNodeInput(), Execute_Throws_WhenProviderNameIsUnknown(), Execute_ReturnsFailure_WhenProviderReturnsEmpty(), return(), static(), AiTextNodeTests

### Community 85 - "Entity (Community 85)"
Cohesion: 0.25
Nodes (8): FetchRssNodeTests.cs, Execute_ReturnsFailure_WhenNoUrlsProvided(), foreach(), return(), static(), XPoster.Tests.Workflows.Nodes, FetchRssNodeTests, Execute_ReturnsFailure_WhenNoContentRetrieved()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.46
Nodes (8): PostTests.cs, PostTests.cs, Post_DefaultImageIsNull(), XPoster.Tests.Models, Post_EmptyContent_IsAllowed(), PostTests, Firm_IsNotNullOrEmpty(), Post_CanSetAndGetAllProperties()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.46
Nodes (8): FalAiImageService.cs, FalAiImageService.cs, FalAiImageService(), catch(), XPoster.Services, if(), GetImageGenerationEndpoint(), GenerateImageAsync()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.25
Nodes (8): AiServiceHelper.cs, XPoster.Services, ExtractOpenAiBytes(), LogAndReturnEmpty(), ParseImageResponseAsync(), BuildChatPayload(), ExtractFalAiBytesAsync(), ExtractAzureFoundryBytesAsync()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.46
Nodes (8): AIResponse.cs, AIResponse.cs, OpenAIImageResponse, ImageData, Message, Choice, AIResponse, XPoster.Models

### Community 77 - "Entity (Community 77)"
Cohesion: 0.46
Nodes (8): FanOutSendNode.cs, FanOutSendNode.cs, ExecuteAsync(), if(), XPoster.Workflows.Nodes, foreach(), WorkflowNodeResult(), FanOutSendNode()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.52
Nodes (7): WorkflowServiceCollectionExtensions.cs, WorkflowServiceCollectionExtensions.cs, if(), InvalidOperationException(), XPoster.Workflows.Configuration, AddWorkflows(), foreach()

### Community 94 - "Entity (Community 94)"
Cohesion: 0.29
Nodes (7): FbSenderImageFlowTests.cs, HttpResponseMessage(), CreateValidJpegBytes(), SendAsync_WhenUploadThrows_FallsBackToTextOnly(), SendAsync_WithSupportedImage_UploadsPublishesPhotoAndDeletesBlob(), if(), SendAsync_WhenDeleteFails_AfterSuccessfulPhotoPublish_ReturnsTrue()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.29
Nodes (7): OrchestratorFactory.cs, WorkflowOrchestrator(), XPoster.Orchestrators, catch(), ResolveSenders(), Resolve(), NoOrchestrator()

### Community 90 - "Entity (Community 90)"
Cohesion: 0.52
Nodes (7): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, XPoster.Tests.Models, ValidOptions(), AzureFoundryOptionsValidatorTests, Validate_MissingRequiredProperties_Fails(), Validate_ValidOptions_Succeeds()

### Community 91 - "Entity (Community 91)"
Cohesion: 0.52
Nodes (7): IContainerStateStore.cs, IContainerStateStore.cs, IContainerStateStore, SaveAsync(), GetPendingAsync(), XPoster.Contracts, UpdateStatusAsync()

### Community 88 - "Entity (Community 88)"
Cohesion: 0.52
Nodes (7): XFunction.cs, XFunction.cs, XFunction(), XPoster, catch(), Run(), if()

### Community 89 - "Entity (Community 89)"
Cohesion: 0.29
Nodes (7): OpenAiService.cs, GenerateTextAsync(), catch(), GenerateImageAsync(), var(), while(), XPoster.Services

### Community 98 - "Entity (Community 98)"
Cohesion: 0.52
Nodes (7): InMemoryContainerStateStore.cs, InMemoryContainerStateStore.cs, SaveAsync(), GetPendingAsync(), InMemoryContainerStateStore, XPoster.Services, UpdateStatusAsync()

### Community 96 - "Entity (Community 96)"
Cohesion: 0.52
Nodes (7): AiTextNode.cs, AiTextNode.cs, XPoster.Workflows.Nodes, WorkflowNodeResult(), ExecuteAsync(), if(), AiTextNode()

### Community 97 - "Entity (Community 97)"
Cohesion: 0.52
Nodes (7): AiImageNode.cs, AiImageNode.cs, AiImageNode(), WorkflowNodeResult(), XPoster.Workflows.Nodes, ExecuteAsync(), if()

### Community 95 - "Entity (Community 95)"
Cohesion: 0.29
Nodes (7): CredentialsStartupValidator.cs, CredentialsStartupValidator(), catch(), if(), XPoster.Credentials, InvalidOperationException(), Validate()

### Community 99 - "Entity (Community 99)"
Cohesion: 0.52
Nodes (7): IgSender.cs, IgSender.cs, XPoster.SenderPlugins, catch(), IgSender(), SendAsync(), if()

### Community 87 - "Entity (Community 87)"
Cohesion: 0.52
Nodes (7): TagReplacementService.cs, TagReplacementService.cs, if(), Apply(), TagReplacementService(), foreach(), XPoster.Services

### Community 125 - "Entity (Community 125)"
Cohesion: 0.60
Nodes (6): FacebookCredentialsValidator.cs, FacebookCredentialsValidator.cs, FacebookCredentialsValidator, if(), XPoster.Credentials, Validate()

### Community 123 - "Entity (Community 123)"
Cohesion: 0.60
Nodes (6): OpenAiOptionsValidator.cs, OpenAiOptionsValidator.cs, if(), nameof(), Validate(), XPoster.Models

### Community 124 - "Entity (Community 124)"
Cohesion: 0.60
Nodes (6): IBlobStorageService.cs, IBlobStorageService.cs, DeleteAsync(), UploadAsync(), XPoster.Contracts, IBlobStorageService

### Community 109 - "Entity (Community 109)"
Cohesion: 0.60
Nodes (6): BuildPowerLawPostNode.cs, BuildPowerLawPostNode.cs, BuildPowerLawPostNode(), ExecuteAsync(), XPoster.Workflows.Nodes, if()

### Community 111 - "Entity (Community 111)"
Cohesion: 0.60
Nodes (6): AcquireCryptoValueNode.cs, AcquireCryptoValueNode.cs, AcquireCryptoValueNode(), ExecuteAsync(), XPoster.Workflows.Nodes, WorkflowNodeResult()

### Community 110 - "Entity (Community 110)"
Cohesion: 0.33
Nodes (6): FetchRssNodeTests.cs, WorkflowNodeInput(), Execute_CallsFeedServiceForMultipleUrls(), var(), Execute_ConcatenatesMultipleFeeds(), Input()

### Community 106 - "Entity (Community 106)"
Cohesion: 0.60
Nodes (6): IMetaPublishingService.cs, IMetaPublishingService.cs, IMetaPublishingService, PublishContainerAsync(), XPoster.Contracts, GetContainerStatusAsync()

### Community 103 - "Entity (Community 103)"
Cohesion: 0.60
Nodes (6): WorkflowDefinitionValidator.cs, WorkflowDefinitionValidator.cs, if(), XPoster.Workflows.Engine, HasCycle(), foreach()

### Community 105 - "Entity (Community 105)"
Cohesion: 0.60
Nodes (6): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests, AzureFoundryOptions_Defaults_AreCorrect(), AzureFoundryOptions_DoesNotExpose_ApiVersionProperty(), XPoster.Tests.Models

### Community 104 - "Entity (Community 104)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration, for(), Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures()

### Community 100 - "Entity (Community 100)"
Cohesion: 0.33
Nodes (6): BuildPowerLawPostNodeTests.cs, Input(), Execute_DateBeforeGenesis_ReturnsFailure(), if(), Execute_UsesSymbol_ForPostTag(), BuildPowerLawPostNodeTests()

### Community 119 - "Entity (Community 119)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, if(), SendAsync(), DryRunSender(), XPoster.SenderPlugins

### Community 117 - "Entity (Community 117)"
Cohesion: 0.60
Nodes (6): Program.cs, Program.cs, BlobServiceClient(), DefaultAzureCredential(), Uri(), if()

### Community 118 - "Entity (Community 118)"
Cohesion: 0.60
Nodes (6): AzureFoundryOptionsValidator.cs, AzureFoundryOptionsValidator.cs, if(), nameof(), XPoster.Models, Validate()

### Community 120 - "Entity (Community 120)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, Polly_AiClient_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration, StringContent(), Polly_AiClient_AttemptTimeout_CancelsSlowRequest()

### Community 122 - "Entity (Community 122)"
Cohesion: 0.60
Nodes (6): InstagramCredentialsValidator.cs, InstagramCredentialsValidator.cs, Validate(), XPoster.Credentials, InstagramCredentialsValidator, if()

### Community 121 - "Entity (Community 121)"
Cohesion: 0.60
Nodes (6): TagReplacementServiceTests.cs, TagReplacementServiceTests.cs, XPoster.Tests.Services, Apply_Returns_Input_Unchanged_When_Text_Is_Empty_Or_Whitespace(), Apply_Replaces_Only_First_Occurrence_For_Each_Word(), Apply_Does_Not_Replace_Words_Already_Prefixed_With_Hashtag()

### Community 126 - "Entity (Community 126)"
Cohesion: 0.33
Nodes (6): AiImageNodeTests.cs, Execute_ReturnsNullOutput_OnEmptyArray(), Execute_Throws_WhenProviderNameIsUnknown(), Execute_ReturnsSuccess_WhenRequired_AndImageProduced(), var(), Execute_PassesStepOptionsToImagePromptRequest()

### Community 127 - "Entity (Community 127)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, JsonResponse(), MakeDownloadClient(), HttpClient(), var(), MakeNoOpClient()

### Community 108 - "Entity (Community 108)"
Cohesion: 0.33
Nodes (6): OrchestratorFactory.cs, ResolveWorkflowOrchestrator(), if(), CreateEmptyNoOrchestrator(), OrchestratorFactory(), nameof()

### Community 107 - "Entity (Community 107)"
Cohesion: 0.33
Nodes (6): NodeParameterExtractor.cs, return(), XPoster.Workflows.Utilities, catch(), GetProvider(), IsJsonLike()

### Community 114 - "Entity (Community 114)"
Cohesion: 0.60
Nodes (6): DeepSeekOptionsValidator.cs, DeepSeekOptionsValidator.cs, if(), Validate(), XPoster.Models, nameof()

### Community 112 - "Entity (Community 112)"
Cohesion: 0.33
Nodes (6): IgSenderTests.cs, IgSender(), IgSender_ImplementsISender(), IgSenderTests(), Constructor_WithNullBlobStorageService_ThrowsArgumentNullException(), Constructor_WithNullCredentials_ThrowsArgumentNullException()

### Community 113 - "Entity (Community 113)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, GetCurrentTime_ReturnsUtcTime(), TimeProviderTests, XPoster.Tests.Providers, GetCurrentTime_ReturnsCurrentDateTime()

### Community 116 - "Entity (Community 116)"
Cohesion: 0.60
Nodes (6): PerplexityOptionsValidator.cs, PerplexityOptionsValidator.cs, XPoster.Models, if(), nameof(), Validate()

### Community 115 - "Entity (Community 115)"
Cohesion: 0.33
Nodes (6): AiTextNodeTests.cs, Input(), var(), Execute_PassesStepOptionsToPromptRequest(), Execute_Throws_WhenValidProviderNotRegistered(), Execute_ReturnsGeneratedText()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.60
Nodes (6): IWorkflowContext.cs, IWorkflowContext.cs, HasData(), XPoster.Workflows.Models, SetData(), IWorkflowContext

### Community 102 - "Entity (Community 102)"
Cohesion: 0.60
Nodes (6): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptions_Defaults_AreCorrect(), XPoster.Tests.Models, DeepSeekOptionsTests

### Community 160 - "Entity (Community 160)"
Cohesion: 0.70
Nodes (5): ConfigurationStepOptionsResolver.cs, ConfigurationStepOptionsResolver.cs, ConfigurationStepOptionsResolver(), Resolve(), XPoster.Workflows.Services

### Community 149 - "Entity (Community 149)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, XPoster.Contracts, ITextToImageProvider, GenerateImageAsync()

### Community 145 - "Entity (Community 145)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, catch(), XPoster.Tests.Integration, Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_Instagram_RetriesOn429_AndEventuallySucceeds()

### Community 146 - "Entity (Community 146)"
Cohesion: 0.70
Nodes (5): IWorkflowNode.cs, IWorkflowNode.cs, IWorkflowNode, XPoster.Workflows.Abstractions, ExecuteAsync()

### Community 147 - "Entity (Community 147)"
Cohesion: 0.70
Nodes (5): AiProviderValidationHelper.cs, AiProviderValidationHelper.cs, ValidateConnectivity(), if(), XPoster.Models

### Community 148 - "Entity (Community 148)"
Cohesion: 0.70
Nodes (5): ITagReplacementService.cs, ITagReplacementService.cs, Apply(), ITagReplacementService, XPoster.Contracts

### Community 155 - "Entity (Community 155)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, GetFeedsAsync(), IFeedService, XPoster.Contracts

### Community 157 - "Entity (Community 157)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, XPoster.Contracts, PostAsync(), IOrchestrator

### Community 159 - "Entity (Community 159)"
Cohesion: 0.70
Nodes (5): ICredentialsStartupValidator.cs, ICredentialsStartupValidator.cs, ICredentialsStartupValidator, Validate(), XPoster.Contracts

### Community 158 - "Entity (Community 158)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, ICryptoService, XPoster.Contracts, GetCryptoValue()

### Community 156 - "Entity (Community 156)"
Cohesion: 0.70
Nodes (5): ITextToTextProvider.cs, ITextToTextProvider.cs, ITextToTextProvider, XPoster.Contracts, GenerateTextAsync()

### Community 132 - "Entity (Community 132)"
Cohesion: 0.40
Nodes (5): PerplexityService.cs, XPoster.Services, var(), if(), GenerateTextAsync()

### Community 129 - "Entity (Community 129)"
Cohesion: 0.40
Nodes (5): FeedService.cs, XPoster.Services, Exception(), catch(), GetFeedsAsync()

### Community 130 - "Entity (Community 130)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, GetCurrentTime(), TimeProvider, XPoster.Providers

### Community 131 - "Entity (Community 131)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, XPoster.Providers, LocalOverrideTimeProvider(), GetCurrentTime()

### Community 136 - "Entity (Community 136)"
Cohesion: 0.70
Nodes (5): LinkedInCredentialsValidator.cs, LinkedInCredentialsValidator.cs, Validate(), XPoster.Credentials, if()

### Community 138 - "Entity (Community 138)"
Cohesion: 0.40
Nodes (5): DeepSeekService.cs, if(), GenerateTextAsync(), XPoster.Services, var()

### Community 137 - "Entity (Community 137)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, ISender, XPoster.Contracts, SendAsync()

### Community 140 - "Entity (Community 140)"
Cohesion: 0.70
Nodes (5): IAiProviderOptions.cs, IAiProviderOptions.cs, IAiProviderOptions, XPoster.Contracts, IAiProviderSection

### Community 139 - "Entity (Community 139)"
Cohesion: 0.70
Nodes (5): PromptRequest.cs, PromptRequest.cs, PromptRequest, XPoster.Models, ImagePromptRequest

### Community 144 - "Entity (Community 144)"
Cohesion: 0.70
Nodes (5): WorkflowDefinitionOptions.cs, WorkflowDefinitionOptions.cs, WorkflowDefinition(), ToDefinition(), XPoster.Workflows.Configuration

### Community 141 - "Entity (Community 141)"
Cohesion: 0.70
Nodes (5): IWorkflowEngine.cs, IWorkflowEngine.cs, IWorkflowEngine, XPoster.Workflows.Engine, ExecuteAsync()

### Community 143 - "Entity (Community 143)"
Cohesion: 0.70
Nodes (5): MaskUrlTelemetryProcessor.cs, MaskUrlTelemetryProcessor.cs, if(), Process(), MaskUrlTelemetryProcessor()

### Community 142 - "Entity (Community 142)"
Cohesion: 0.70
Nodes (5): IStepOptionsResolver.cs, IStepOptionsResolver.cs, IStepOptionsResolver, XPoster.Workflows.Services, Resolve()

### Community 154 - "Entity (Community 154)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, Resolve(), IOrchestratorFactory, XPoster.Contracts

### Community 150 - "Entity (Community 150)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, GetProfiles(), XPoster.Contracts, ISlotProfileProvider

### Community 151 - "Entity (Community 151)"
Cohesion: 0.70
Nodes (5): ITagReplacementProvider.cs, ITagReplacementProvider.cs, ITagReplacementProvider, GetReplacements(), XPoster.Contracts

### Community 153 - "Entity (Community 153)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, ITimeProvider, XPoster.Contracts, GetCurrentTime()

### Community 152 - "Entity (Community 152)"
Cohesion: 0.70
Nodes (5): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, ValidOptions(), XPoster.Tests.Models, OpenAiOptionsValidatorTests

### Community 128 - "Entity (Community 128)"
Cohesion: 0.70
Nodes (5): ImageTestData.cs, ImageTestData.cs, CreateValidJpeg(), CreateValidPng(), XPoster.Tests.Helpers

### Community 133 - "Entity (Community 133)"
Cohesion: 0.40
Nodes (5): OpenAiService.cs, OpenAiService(), GetChatCompletionsEndpoint(), GetImageGenerationEndpoint(), if()

### Community 135 - "Entity (Community 135)"
Cohesion: 0.70
Nodes (5): WorkflowOrchestrator.cs, WorkflowOrchestrator.cs, if(), WorkflowOrchestrator(), XPoster.Orchestrators

### Community 134 - "Entity (Community 134)"
Cohesion: 0.70
Nodes (5): ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider.cs, GetReplacements(), ConfigurationTagReplacementProvider(), XPoster.Providers

### Community 166 - "Entity (Community 166)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), catch(), StringContent()

### Community 161 - "Entity (Community 161)"
Cohesion: 0.50
Nodes (4): WorkflowExecutionEngineTests.cs, new(), var(), StubNode()

### Community 165 - "Entity (Community 165)"
Cohesion: 0.83
Nodes (4): ITerminalNode.cs, ITerminalNode.cs, ITerminalNode, XPoster.Workflows.Abstractions

### Community 162 - "Entity (Community 162)"
Cohesion: 0.50
Nodes (4): WorkflowOrchestratorTests.cs, WorkflowExecutionResult(), var(), new()

### Community 163 - "Entity (Community 163)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile(), XPoster.Models

### Community 164 - "Entity (Community 164)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, RSSFeed, XPoster.Models

### Community 173 - "Entity (Community 173)"
Cohesion: 0.50
Nodes (4): FanOutSendNodeTests.cs, var(), SetupSender(), if()

### Community 167 - "Entity (Community 167)"
Cohesion: 0.83
Nodes (4): DryRunMaxLengthSender.cs, DryRunMaxLengthSender.cs, XPoster.SenderPlugins, DryRunMaxLengthSender()

### Community 169 - "Entity (Community 169)"
Cohesion: 0.83
Nodes (4): WorkflowNodeInput.cs, WorkflowNodeInput.cs, XPoster.Workflows.Abstractions, WorkflowNodeInput()

### Community 171 - "Entity (Community 171)"
Cohesion: 0.83
Nodes (4): WorkflowDefinition.cs, WorkflowDefinition.cs, XPoster.Workflows.Engine, WorkflowDefinition()

### Community 170 - "Entity (Community 170)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, XPoster.Tests.Helpers, BuildSequenceHandler(), var()

### Community 168 - "Entity (Community 168)"
Cohesion: 0.83
Nodes (4): DryRunShortLengthSender.cs, DryRunShortLengthSender.cs, XPoster.SenderPlugins, DryRunShortLengthSender()

### Community 172 - "Entity (Community 172)"
Cohesion: 0.83
Nodes (4): WorkflowNodeResult.cs, WorkflowNodeResult.cs, XPoster.Workflows.Abstractions, WorkflowNodeResult()

### Community 182 - "Entity (Community 182)"
Cohesion: 0.83
Nodes (4): AiProviderOptionsCompositionExtensions.cs, AiProviderOptionsCompositionExtensions.cs, XPoster.Extensions, AddAiProviderOptions()

### Community 190 - "Entity (Community 190)"
Cohesion: 0.50
Nodes (4): FalAiOptionsValidator.cs, foreach(), Validate(), XPoster.Models

### Community 183 - "Entity (Community 183)"
Cohesion: 0.83
Nodes (4): PendingContainer.cs, PendingContainer.cs, XPoster.Models, PendingContainer()

### Community 189 - "Entity (Community 189)"
Cohesion: 0.50
Nodes (4): PerplexityService.cs, while(), GetChatCompletionsEndpoint(), PerplexityService()

### Community 184 - "Entity (Community 184)"
Cohesion: 0.50
Nodes (4): HttpClientExtensions.cs, AddHttpClients(), AddResilientHttpClient(), XPoster.Extensions

### Community 185 - "Entity (Community 185)"
Cohesion: 0.83
Nodes (4): MediaAttachment.cs, MediaAttachment.cs, MediaAttachment(), XPoster.Workflows.Models

### Community 186 - "Entity (Community 186)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, GetCryptoValue(), catch(), XPoster.Services

### Community 187 - "Entity (Community 187)"
Cohesion: 0.83
Nodes (4): WorkflowExecutionResult.cs, WorkflowExecutionResult.cs, WorkflowExecutionResult(), XPoster.Workflows.Engine

### Community 188 - "Entity (Community 188)"
Cohesion: 0.83
Nodes (4): WorkflowNodeDefinition.cs, WorkflowNodeDefinition.cs, WorkflowNodeDefinition(), XPoster.Workflows.Engine

### Community 191 - "Entity (Community 191)"
Cohesion: 0.50
Nodes (4): XSender.cs, SendAsync(), catch(), XPoster.SenderPlugins

### Community 197 - "Entity (Community 197)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, PostAsync(), BaseOrchestrator(), XPoster.Orchestrators

### Community 193 - "Entity (Community 193)"
Cohesion: 0.83
Nodes (4): CredentialsExtensions.cs, CredentialsExtensions.cs, AddCredentials(), XPoster.Credentials

### Community 192 - "Entity (Community 192)"
Cohesion: 0.50
Nodes (4): WorkflowDefinitionValidatorTests.cs, ExecuteAsync(), new(), Node()

### Community 194 - "Entity (Community 194)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, catch(), return(), if()

### Community 195 - "Entity (Community 195)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, Post, XPoster.Models

### Community 196 - "Entity (Community 196)"
Cohesion: 0.50
Nodes (4): ConfigurationSlotProfileProvider.cs, XPoster.Providers, ConfigurationSlotProfileProvider(), GetProfiles()

### Community 174 - "Entity (Community 174)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, XPoster.Contracts, GetLabel()

### Community 180 - "Entity (Community 180)"
Cohesion: 0.83
Nodes (4): BlobUploadResult.cs, BlobUploadResult.cs, BlobUploadResult(), XPoster.Models

### Community 181 - "Entity (Community 181)"
Cohesion: 0.50
Nodes (4): CredentialsStartupValidator.cs, ValidateOptions(), resolve(), foreach()

### Community 179 - "Entity (Community 179)"
Cohesion: 0.83
Nodes (4): SenderPluginsServiceCollectionExtensions.cs, SenderPluginsServiceCollectionExtensions.cs, XPoster.Extensions, AddXPosterSenderPlugins()

### Community 178 - "Entity (Community 178)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, StringContent(), for(), Polly_Instagram_AttemptTimeout_CancelsSlowRequest()

### Community 175 - "Entity (Community 175)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, NoOrchestrator(), XPoster.Orchestrators

### Community 176 - "Entity (Community 176)"
Cohesion: 0.50
Nodes (4): DeepSeekService.cs, while(), DeepSeekService(), GetChatCompletionsEndpoint()

### Community 177 - "Entity (Community 177)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, AddXPosterAiProviders(), XPoster.Extensions

### Community 213 - "Entity (Community 213)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, DeepSeekOptions.cs, XPoster.Models

### Community 200 - "Entity (Community 200)"
Cohesion: 0.67
Nodes (3): HttpClientExtensions.cs, if(), IsTransientHttpFailure()

### Community 212 - "Entity (Community 212)"
Cohesion: 1.00
Nodes (3): XPoster.Models, BlobStorageOptions.cs, BlobStorageOptions.cs

### Community 211 - "Entity (Community 211)"
Cohesion: 0.67
Nodes (3): NodeParameterExtractor.cs, if(), InvalidOperationException()

### Community 203 - "Entity (Community 203)"
Cohesion: 1.00
Nodes (3): TagReplacementOptions.cs, XPoster.Models, TagReplacementOptions.cs

### Community 205 - "Entity (Community 205)"
Cohesion: 0.67
Nodes (3): FbSenderResilienceTests.cs, BuildCreds(), BuildFactory()

### Community 204 - "Entity (Community 204)"
Cohesion: 0.67
Nodes (3): FeedService.cs, if(), FeedService()

### Community 201 - "Entity (Community 201)"
Cohesion: 0.67
Nodes (3): FalAiOptionsValidator.cs, if(), nameof()

### Community 202 - "Entity (Community 202)"
Cohesion: 1.00
Nodes (3): XPoster.Models, PerplexityOptions.cs, PerplexityOptions.cs

### Community 208 - "Entity (Community 208)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, XCredentials.cs, XCredentials.cs

### Community 210 - "Entity (Community 210)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, XPoster.Models, AzureFoundryOptions.cs

### Community 209 - "Entity (Community 209)"
Cohesion: 0.67
Nodes (3): XCredentialsValidator.cs, XPoster.Credentials, Validate()

### Community 207 - "Entity (Community 207)"
Cohesion: 1.00
Nodes (3): FacebookCredentials.cs, XPoster.Credentials, FacebookCredentials.cs

### Community 206 - "Entity (Community 206)"
Cohesion: 1.00
Nodes (3): SenderPlatform.cs, SenderPlatform.cs, XPoster.Contracts

### Community 199 - "Entity (Community 199)"
Cohesion: 1.00
Nodes (3): SlotScheduleOptions.cs, XPoster.Models, SlotScheduleOptions.cs

### Community 198 - "Entity (Community 198)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, XPoster.Models, FalAiOptions.cs

### Community 226 - "Entity (Community 226)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, BuildFactory(), params()

### Community 228 - "Entity (Community 228)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, AiProvider.cs, XPoster.Contracts

### Community 227 - "Entity (Community 227)"
Cohesion: 1.00
Nodes (3): PromptStepOptions.cs, PromptStepOptions.cs, XPoster.Workflows.Models

### Community 225 - "Entity (Community 225)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, LinkedInCredentials.cs, LinkedInCredentials.cs

### Community 223 - "Entity (Community 223)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, CryptoService(), if()

### Community 214 - "Entity (Community 214)"
Cohesion: 1.00
Nodes (3): OpenAiOptions.cs, OpenAiOptions.cs, XPoster.Models

### Community 222 - "Entity (Community 222)"
Cohesion: 1.00
Nodes (3): AiModelClass.cs, XPoster.Contracts, AiModelClass.cs

### Community 224 - "Entity (Community 224)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, InstagramCredentials.cs, InstagramCredentials.cs

### Community 215 - "Entity (Community 215)"
Cohesion: 0.67
Nodes (3): BaseOrchestrator.cs, DispatchAsync(), if()

### Community 216 - "Entity (Community 216)"
Cohesion: 1.00
Nodes (3): WorkflowContextKeys.cs, WorkflowContextKeys.cs, XPoster.Workflows.Models

### Community 217 - "Entity (Community 217)"
Cohesion: 1.00
Nodes (3): MediaType.cs, MediaType.cs, XPoster.Workflows.Models

### Community 218 - "Entity (Community 218)"
Cohesion: 0.67
Nodes (3): ConfigurationSlotProfileProvider.cs, foreach(), if()

### Community 220 - "Entity (Community 220)"
Cohesion: 0.67
Nodes (3): XSender.cs, if(), XSender()

### Community 221 - "Entity (Community 221)"
Cohesion: 1.00
Nodes (3): ContainerStatus.cs, ContainerStatus.cs, XPoster.Contracts

### Community 219 - "Entity (Community 219)"
Cohesion: 0.67
Nodes (3): InSender.cs, if(), InSender()

### Community 229 - "Entity (Community 229)"
Cohesion: 1.00
Nodes (2): XCredentialsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._


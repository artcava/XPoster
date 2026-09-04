# Graph Report - XPoster  (2026-09-04)

## Summary
- 1885 nodes · 3188 edges · 230 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Tests.SenderPlugins` - 2 edges
2. `XPoster.Tests` - 2 edges
3. `XPoster.Tests.Services` - 2 edges
4. `XPoster.Tests.Workflows.Services` - 2 edges
5. `ConfigurationStepOptionsResolverTests` - 2 edges
6. `DeepSeekOptionsExtensionsTests` - 2 edges
7. `XPoster.Providers` - 2 edges
8. `IOrchestrator` - 2 edges
9. `XPoster.Services` - 2 edges
10. `XPoster.Contracts` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, new(), MakeResponse(), MakeHttpClientThatThrows(), ParseChatCompletionResponseAsync_WhenNonSuccess_LogsProviderNameAndStatusCode(), ParseChatCompletionResponseAsync_WhenEmptyChoices_LogsWarningWithProviderName(), ParseChatCompletionResponseAsync_WhenContentIsWhitespaceOnly_ReturnsTrueAndEmpty() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.10
Nodes (41): AzureFoundryServiceTests.cs, AzureFoundryServiceTests.cs, GenerateImageAsync_RequestBodyContainsSizeAndQuantityFromRequest(), GenerateImageAsync_RequestBodyContainsModelFromOptions(), GenerateImageAsync_PostsToFoundryImagesGenerationsEndpoint(), GenerateImageAsync_WhenInputTextIsEmpty_ReturnsEmptyByteArrayWithoutCallingApi(), GenerateImageAsync_WhenInputTextIsEmpty_LogsWarning(), GenerateTextAsync_WhenChoicesIsNull_ReturnsEmptyString() (+33 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.11
Nodes (36): OpenAiServiceTests.cs, OpenAiServiceTests.cs, BuildPromptRequest(), BuildImagePromptRequest(), GenerateTextAsync_UsesSystemPromptTemplateFromRequest(), GenerateImageAsync_WhenPromptIsWhitespace_ReturnsEmptyArrayWithoutCallingApi(), GenerateImageAsync_WhenResponseBodyIsMalformedJson_ReturnsEmptyArray(), GenerateTextAsync_ReplacesInputTextLabelInUserPromptTemplate() (+28 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.12
Nodes (32): DryRunSenderTests.cs, DryRunSenderTests.cs, MaxSender_MessageMaxLength_IsIntMaxValue(), DryRunShortLengthSender(), MaxSender_ImplementsISender(), BuildShortSender(), BuildConfig(), BuildMaxSender() (+24 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, Parse_UnsupportedProvider_ReturnsEmpty(), Parse_Returns429_ReturnsEmpty(), Parse_UnsupportedProvider_LogsError(), Parse_Returns429_LogsWarning(), Parse_OpenAi_MissingDataProperty_ReturnsEmpty(), Parse_OpenAi_ValidB64_ReturnsBytes(), Parse_OpenAi_EmptyDataArray_ReturnsEmpty() (+24 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, DeepSeekOptionsExtensionsTests, BuildProvider(), ConfigurationBuilder(), BuildConfig(), OptionsExtensionsTests, FalAiOptionsExtensionsTests (+21 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.14
Nodes (28): PerplexityServiceTests.cs, PerplexityServiceTests.cs, ChatCompletionJson(), foreach(), GenerateTextAsync_ImagePromptRole_WhenApiReturns429_ReturnsEmptyString(), GenerateTextAsync_UsesCustomInputTextLabel_InUserPromptSubstitution(), GenerateTextAsync_WhenApiReturns429_ReturnsEmptyString(), GenerateTextAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString() (+20 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.15
Nodes (26): FbSenderTests.cs, FbSenderTests.cs, SendAsync_TextOnly_WhenResponseHasNullId_ReturnsFalse(), Platform_ReturnsFacebook(), return(), SendAsync_TextOnly_WhenResponseHasEmptyId_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WhenHttpClientThrows_ReturnsFalse() (+18 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.16
Nodes (25): NodeParameterExtractorTests.cs, NodeParameterExtractorTests.cs, NodeParameterExtractorTests, GetProvider_Throws_WhenEmptyName(), GetProvider_UsesProvidedDefault_WhenMissing(), GetProvider_Throws_WhenUnknownName(), GetParameter_ConversionFailure_ReturnsDefault(), GetParameter_ConvertChangeType_IntFromString() (+17 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.16
Nodes (25): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, DeepSeekService(), BuildService(), ChatCompletionJson(), GenerateTextAsync_WhenCancellationRequested_ThrowsOperationCanceledException(), GenerateTextAsync_WhenChoicesIsNull_ReturnsEmptyString(), GenerateTextAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString() (+17 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.10
Nodes (21): WorkflowExecutionEngineTests.cs, EmptySenders(), Diamond(), Cyclic(), _onExecute(), return(), static(), WorkflowExecutionEngineTests (+13 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.19
Nodes (21): XSenderTests.cs, XSenderTests.cs, SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), SendAsync_WhitespaceContent_ReturnsFalse(), SendAsync_WithImageAndTwitterContextThrows_ReturnsFalse(), SendAsync_WithBlankContent_ReturnsFalseAndLogsWarning(), Platform_ReturnsX(), Constructor_WithNullCredentials_ThrowsArgumentNullException() (+13 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.22
Nodes (18): AiServiceHelperChatPayloadTests.cs, AiServiceHelperChatPayloadTests.cs, BuildChatPayload_InterpolatesMaxCharsInSystemMessage(), AiServiceHelperChatPayloadTests, BuildChatPayload_ForwardsModelName(), BuildChatPayload_ForwardsMaxTokenBudget(), BuildChatPayload_FirstMessageRoleIsSystem(), BuildChatPayload_ForwardsTemperature() (+10 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, SendAsync(), GetFeedsAsync_ReturnsFeedsFromCache_IfPresent(), new(), XPoster.Tests.Services, BuildFactory(), GetFeedsAsync_ReturnsEmpty_WhenFeedIsInvalidXml() (+10 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.22
Nodes (18): IgSenderImageFlowTests.cs, IgSenderImageFlowTests.cs, return(), NormalizeImage_WithValidPng_ReturnsJpegBytes(), NormalizeImage_WhenJpegIsAlreadyValid_ReturnsOriginalBytes(), NormalizeImage_WhenPngDecodesToNull_ReturnsNull(), NormalizeImage_WithValidJpeg_ReturnsSameBytes(), NormalizeImage_WithInvalidBytes_ReturnsNull() (+10 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.22
Nodes (18): AiProviderOptionsAbstractionTests.cs, AiProviderOptionsAbstractionTests.cs, PerplexityOptions_ModelCatalog_ExposesTextOnly(), XPoster.Tests.Models, AzureFoundryOptions_ModelCatalog_ExposesTextAndImage(), AzureFoundryOptions_ImplementsIAiProviderOptions(), AiProviderOptionsAbstractionTests, PerplexityOptions_ImplementsIAiProviderOptions() (+10 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.22
Nodes (18): WorkflowContextTests.cs, WorkflowContextTests.cs, SetData_OverwritesExistingValue(), HasData_ReturnsTrue_WhenKeyExists(), lock(), SetData_AndGetData_RoundTrip(), WorkflowContextTests, TryGetData_ReturnsFalse_OnTypeMismatch() (+10 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.23
Nodes (17): PromptRequestTests.cs, PromptRequestTests.cs, PromptRequest_ValueEquality_DifferentValues_AreNotEqual(), PromptRequest_ValueEquality_SameValues_AreEqual(), XPoster.Tests.Models, PromptRequestTests, PromptRequest_Temperature_AcceptsZeroAndOne(), PromptRequest_IsImmutable_AfterConstruction() (+9 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.23
Nodes (17): MetaPublishingServiceTests.cs, MetaPublishingServiceTests.cs, GetContainerStatusAsync_WhenStatusInNestedField_ReturnsCode(), GetContainerStatusAsync_WhenCancelled_ThrowsTaskCanceledException(), GetContainerStatusAsync_WhenOk_ReturnsStatusCode(), GetContainerStatusAsync_WhenNotFound_ThrowsHttpRequestException(), GetContainerStatusAsync_WhenResponseBodyIsEmpty_ThrowsJsonException(), PublishContainerAsync_WhenResponseBodyIsNull_ThrowsJsonException() (+9 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.23
Nodes (17): WorkflowServiceCollectionExtensionsTests.cs, WorkflowServiceCollectionExtensionsTests.cs, ServiceCollection(), XPoster.Tests.Workflows.Configuration, WorkflowServiceCollectionExtensionsTests, InMemory(), AddWorkflows_WithNoTerminalNode_ThrowsInvalidOperationException(), BuildProvider() (+9 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.24
Nodes (16): ConfigurationSlotProfileProviderTests.cs, ConfigurationSlotProfileProviderTests.cs, ConfigurationBuilder(), BuildConfiguration(), GetProfiles_Should_SkipSlot_WithNoWorkflowKey(), XPoster.Tests.Providers, GetProfiles_Should_SkipUnknownSenders_ButKeepValidOnes(), new() (+8 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.12
Nodes (16): WorkflowDefinitionValidatorTests.cs, ValidateTerminalNodeContract_TerminalDoesNotImplementContract_ReturnsError(), ValidateStructural_EmptyNodes_ReturnsNull(), ValidateStructural_MultipleTerminalNodes_ReturnsError(), ValidateStructural_MissingNodeReference_ReturnsError(), ValidateStructural_ValidLinearDag_ReturnsNull(), WorkflowDefinition(), ValidateTerminalNodeContract_UnresolvableTerminalType_ReturnsNull() (+8 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.24
Nodes (16): InMemoryContainerStateStoreTests.cs, InMemoryContainerStateStoreTests.cs, SaveAsync_WithNullBlobName_ThrowsArgumentNullException(), GetPendingAsync_WhenStoreIsEmpty_ReturnsEmptyList(), InMemoryContainerStateStoreTests, SaveAsync_WithEmptyOrWhitespaceBlobName_ThrowsArgumentException(), SaveAsync_WithEmptyOrWhitespaceCreationId_ThrowsArgumentException(), UpdateStatusAsync_WithEmptyOrWhitespaceCreationId_ThrowsArgumentException() (+8 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.26
Nodes (15): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, SendAsync_WhenNoImage_ReturnsFalseWithoutCallingApi(), XPoster.Tests.SenderPlugins, Uri(), IgSenderResilienceTests, IgSender(), BuildSender() (+7 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.26
Nodes (15): AddAiProviderOptionsTests.cs, AddAiProviderOptionsTests.cs, ConfigurationBuilder(), AddAiProviderOptions_RegistersAllFiveOptionTypes(), AddAiProviderOptionsTests, AddAiProviderOptions_ReturnsSameServiceCollection(), BuildAllProvidersConfig(), AddAiProviderOptions_RegistersAllFiveValidators() (+7 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.26
Nodes (15): MaskUrlTelemetryProcessorTests.cs, MaskUrlTelemetryProcessorTests.cs, XPoster.Tests.Services, Initialize_WhenDependencyTypeIsNotHttp_DoesNotModifyData(), Initialize_WhenDataIsNull_DoesThrow(), Initialize_WhenAccessTokenAlreadyMasked_DoesNotDoubleEncode(), Initialize_WhenDataIsEmpty_DoesNotThrow(), Initialize_WhenTelemetryIsNotDependency_DoesNothing() (+7 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.26
Nodes (15): BlobStorageServiceTests.cs, BlobStorageServiceTests.cs, UploadAsync_SasUriExpiry_IsApproximately30Minutes(), DeleteAsync_WhenBlobDoesNotExist_LogsDebugAndDoesNotThrow(), DeleteAsync_WhenBlobExists_DeletesSuccessfully(), DeleteAsync_WithNullBlobName_ThrowsArgumentException(), DeleteAsync_WithEmptyBlobName_ThrowsArgumentException(), UploadAsync_WhenContainerDoesNotExist_CreatesItAndUploads() (+7 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.14
Nodes (14): WorkflowOrchestratorTests.cs, MakeDefinition(), MakeDefinitionWithoutImage(), Properties_AreConfigured(), OrchestrateAsync_ReturnsEmptyDictionary_WhenSendResultsMissing(), ProduceImage_IsFalse_WhenWorkflowHasNoAiImageNode(), OrchestrateAsync_ReturnsPostMap_OnSuccess(), ProduceImage_IsTrue_WhenWorkflowHasAiImageNode() (+6 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, AIResponse_CanBeCreated_WithChoices(), Message_CanBeCreated_WithContent(), Post_CanHold_ImageBytes(), ModelsTests, Post_CanBeCreated_WithRequiredContent(), OpenAIImageResponse_CanBeCreated_WithData() (+6 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.27
Nodes (14): XPosterContainerPollingFunction.cs, XPosterContainerPollingFunction.cs, TryDeleteBlobAsync(), XPoster, XPosterContainerPollingFunction(), Run(), HandleFinishedAsync(), PollPendingContainersAsync() (+6 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.14
Nodes (14): FanOutSendNodeTests.cs, return(), Execute_StoresSendResultsInContext(), Input(), FanOutSendNodeTests, Execute_TwoSenders_ResummarisesForSmallSenderAndKeepsVariantForWideSender(), Execute_TwoSenders_DistinctPlatforms_ReSummarisationRunsPerSender(), WorkflowNodeInput() (+6 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_WhitespaceModelId_Fails(), XPoster.Tests.Models, ValidOptions(), Validate_ValidOptions_Succeeds(), FalAiOptionsValidatorTests, Validate_BothRequiredFieldsMissing_ReportsBothFailures() (+5 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.15
Nodes (13): InSenderTests.cs, SendAsync_TextOnly_WithPersonCode_UsesPersonUrn(), XPoster.Tests.SenderPlugins, SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn(), SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn(), SendAsync_WithImage_WhenRegisterUploadFails_ReturnsFalse(), InSender_ImplementsISender() (+5 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.15
Nodes (13): FalAiImageServiceTests.cs, GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray(), BuildService(), FalAiImageServiceTests, FalImageJson(), XPoster.Tests.Services, GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_ReturnsEmptyArray() (+5 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, XPoster.Tests.Providers, BuildProvider(), GetCurrentTime_WhenForceHourIsAbsent_FallsBackToUtcHour(), LocalOverrideTimeProvider(), GetCurrentTime_WhenForceHourIsEmpty_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsOutOfRange_WrapsViaDateTimeOverflow() (+5 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.15
Nodes (13): AiImageNodeTests.cs, Input(), Execute_ReturnsFailure_WhenRequired_AndImageMissing(), Execute_Throws_WhenValidProviderNotRegistered(), if(), Execute_ReturnsNullOutput_OnSoftFailure(), Execute_ReturnsMediaAttachment_OnSuccess(), Execute_ReturnsSoftFailure_WhenRequiredFalse_AndImageMissing() (+5 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.29
Nodes (13): AiModelCatalogTests.cs, AiModelCatalogTests.cs, GetRequired_Throws_WhenNotSupported(), TryGet_ReturnsTrueAndPopulatesModelName_WhenSupported(), TryGet_ReturnsFalseAndNullModelName_WhenNotSupported(), Supports_ReturnsTrueForRegisteredModelClass(), XPoster.Tests.Models, Supports_ReturnsFalseForMissingModelClass() (+5 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.32
Nodes (12): ConfigurationStepOptionsResolverTests.cs, ConfigurationStepOptionsResolverTests.cs, if(), Resolve_Throws_OnNullOrWhitespaceStepId(), Resolve_BindsImageProperties_WhenPresent(), Resolve_BindsMaxOutputLength_WhenPresent(), Resolve_ReturnsStepOptions_WhenSectionExists(), Resolve_Throws_WhenStepMissing() (+4 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.17
Nodes (12): InSenderTests.cs, SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse(), SendAsync_WhenNeitherOrgIdNorOwnerCodeSet_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalseAndLogsWarning(), SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse(), SendAsync_TextOnly_WithOrgId_UsesOrganizationUrn(), Platform_ReturnsLinkedIn(), Constructor_InitializesCorrectly() (+4 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.32
Nodes (12): ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests.cs, foreach(), GetReplacements_Should_ReturnConfiguredReplacements_When_OptionsContainsEntries(), XPoster.Tests.Providers, GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsPropertyIsNull(), GetReplacements_Should_PreserveAllEntries_When_MultipleReplacementsConfigured(), GetReplacements_Should_ReturnReadOnlyDictionary() (+4 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.17
Nodes (12): OrchestratorFactoryTests.cs, NoOrchestrator_SupportedPlatforms_IsEmpty(), foreach(), Resolve_Should_ReturnWorkflowOrchestrator_WhenWorkflowDefinitionIsRegistered(), Resolve_ForMissingContextKey_ReturnsNoOrchestrator(), Resolve_Should_ReturnWorkflowOrchestrator_ForAnyConfiguredSlot(), Resolve_Should_ReturnNoOrchestrator_WhenNoProfileMatchesCurrentHour(), Resolve_Should_ReturnNoOrchestrator_WhenWorkflowDefinitionMissing() (+4 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.17
Nodes (12): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenStatusIsUnknown_LogsWarningAndSkips(), XPosterContainerPollingFunctionTests, RunAsync_WhenUnexpectedExceptionThrown_LogsErrorAndRethrows(), XPoster.Tests, RunAsync_WhenStatusIsError_MarksFailedAndCleansUp(), RunAsync_WhenNoPendingContainers_DoesNothing(), RunAsync_WhenBlobDeleteFails_LogsError() (+4 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.32
Nodes (12): AzureFoundryService.cs, AzureFoundryService.cs, GetImageGenerationEndpoint(), catch(), GenerateImageAsync(), AzureFoundryService(), GenerateTextAsync(), GetChatCompletionsEndpoint() (+4 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, GenerateImageAsync_EmptyUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_Returns429_LogsWarning(), GenerateImageAsync_WhitespacePrompt_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithMultipleSegments_PreservesSlashesInUri(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_LogsError(), GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray(), GenerateImageAsync_MalformedJson_ReturnsEmptyArray() (+4 more)

### Community 45 - "Entity (Community 45)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, InSenderResilienceTests, BuildSender(), InSender(), SendAsync_WhenLinkedInReturns200_ReturnsTrue(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), XPoster.Tests.SenderPlugins (+3 more)

### Community 44 - "Entity (Community 44)"
Cohesion: 0.35
Nodes (11): AiProviderServiceCollectionExtensionsTests.cs, AiProviderServiceCollectionExtensionsTests.cs, AiProviderServiceCollectionExtensionsTests, XPoster.Tests.Extensions, AddXPosterAiProviders_RegistersPerplexity_AsTextOnly(), AddXPosterAiProviders_RegistersDeepSeek_AsTextOnly(), AddXPosterAiProviders_RegistersFalAi_AsImageOnly(), AddXPosterAiProviders_RegistersOpenAi_AsTextAndImageProvider() (+3 more)

### Community 46 - "Entity (Community 46)"
Cohesion: 0.35
Nodes (11): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, Constructor_Should_SetAllFields(), OrchestratorContextKey_Should_BeNull_WhenNotProvided(), OrchestratorContextKey_Should_BeSet_WhenProvided(), TwoSlotsWithSameOrchestratorType_Should_CarryIndependentContextKeys(), Constructor_Should_PreserveOrderOfSenderPlatforms(), typeof() (+3 more)

### Community 47 - "Entity (Community 47)"
Cohesion: 0.18
Nodes (11): IgSenderTests.cs, BuildSender(), MessageMaxLength_Returns2200(), Constructor_WithNullHttpClientFactory_ThrowsArgumentNullException(), Constructor_InitializesCorrectly(), new(), Constructor_WithNullContainerStateStore_ThrowsArgumentNullException(), Constructor_WithNullLogger_ThrowsArgumentNullException() (+3 more)

### Community 55 - "Entity (Community 55)"
Cohesion: 0.38
Nodes (10): XSenderResilienceTests.cs, XSenderResilienceTests.cs, SendAsync_WhenMediaTweetFails_ReturnsFalseAndLogsError(), SendAsync_WhenPostIsNull_ReturnsFalseAndLogsWarning(), XSender(), SendAsync_WhenTextTweetFails_ReturnsFalseAndLogsError(), XPoster.Tests.SenderPlugins, XSenderResilienceTests (+2 more)

### Community 54 - "Entity (Community 54)"
Cohesion: 0.38
Nodes (10): XFunctionTests.cs, XFunctionTests.cs, Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), Run_Should_LogError_When_OrchestrateAsync_ReturnsEmptyDictionary(), XPoster.Tests, Run_Should_LogWarning_AndNotRethrow_When_CancelledGracefully(), XFunctionTests(), Run_Should_Rethrow_When_Factory_Throws() (+2 more)

### Community 49 - "Entity (Community 49)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, OrchestrateAsync_ReturnsEmptyList(), Name_IsNoOrchestrator(), Build(), NoOrchestratorTests, SendIt_Set_ThrowsNotImplementedException(), SupportedPlatforms_IsEmpty() (+2 more)

### Community 48 - "Entity (Community 48)"
Cohesion: 0.38
Nodes (10): IgSenderSendAsyncTests.cs, IgSenderSendAsyncTests.cs, SendAsync_WithNullPost_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithNoImage_ReturnsFalse(), SendAsync_WithEmptyImageArray_ReturnsFalse(), BuildSender(), SendAsync_WithCaptionExceedingMaxLength_TruncatesCaption() (+2 more)

### Community 51 - "Entity (Community 51)"
Cohesion: 0.38
Nodes (10): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, Validate_WithMultipleInvalidFields_ReturnsAllFailures(), ValidOptions(), Validate_WithValidOptions_ReturnsSuccess(), XPoster.Tests.Models, PerplexityOptionsValidatorTests, Validate_WhenApiKeyIsEmpty_ReturnsFailed() (+2 more)

### Community 52 - "Entity (Community 52)"
Cohesion: 0.38
Nodes (10): FbSenderSendAsyncTests.cs, FbSenderSendAsyncTests.cs, FbSenderSendAsyncTests, BuildFactory(), BuildCreds(), SendAsync_WithCaptionLongerThanMax_StillPublishes_ReturnsTrue(), SendAsync_WithEmptyImage_PublishesTextOnly_ReturnsTrue(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning() (+2 more)

### Community 50 - "Entity (Community 50)"
Cohesion: 0.38
Nodes (10): MetaPublishingService.cs, MetaPublishingService.cs, GetContainerStatusAsync(), GetApiVersion(), catch(), if(), PublishContainerAsync(), MetaPublishingService() (+2 more)

### Community 53 - "Entity (Community 53)"
Cohesion: 0.38
Nodes (10): FbSender.cs, FbSender.cs, catch(), PublishPhotoAsync(), HandleResponseAsync(), if(), SendAsync(), PublishTextOnlyAsync() (+2 more)

### Community 65 - "Entity (Community 65)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, GetCryptoValue_ReturnsParsedValue_WhenNumericString(), CryptoServiceTests, CryptoService(), MakeService(), XPoster.Tests.Services, GetCryptoValue_ReturnsZero_AndLogsError_OnException() (+1 more)

### Community 64 - "Entity (Community 64)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse(), XSenderSendAsyncTests(), XPoster.Tests.SenderPlugins (+1 more)

### Community 57 - "Entity (Community 57)"
Cohesion: 0.22
Nodes (9): FbSenderResilienceTests.cs, SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), FbSenderResilienceTests, SendAsync_WhenFacebookReturns503_ReturnsFalseAndLogsError(), HttpResponseMessage(), SendAsync_WhenTextPublishReturns200WithEmptyId_ReturnsFalse(), SendAsync_WhenTextPublishReturns200WithId_ReturnsTrue(), SendAsync_WhenTextPublishReturns200WithoutId_ReturnsFalse() (+1 more)

### Community 56 - "Entity (Community 56)"
Cohesion: 0.42
Nodes (9): HttpClientExtensionsTests.cs, HttpClientExtensionsTests.cs, AddHttpClients_RegistersIHttpClientFactory(), AddHttpClients_ReturnsSameServiceCollection(), foreach(), HttpClientExtensionsTests, XPoster.Tests.Extensions, AddHttpClients_CanCreateAllExpectedNamedClients() (+1 more)

### Community 58 - "Entity (Community 58)"
Cohesion: 0.22
Nodes (9): InSender.cs, generatePayLoad(), Exception(), catch(), ResolveAuthorUrn(), using(), XPoster.SenderPlugins, SendAsync() (+1 more)

### Community 69 - "Entity (Community 69)"
Cohesion: 0.42
Nodes (9): AiModelCatalog.cs, AiModelCatalog.cs, Supports(), XPoster.Models, TryGet(), if(), AiModelCatalog(), GetRequired() (+1 more)

### Community 60 - "Entity (Community 60)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, HttpResponseMessage(), BuildDelayedHandler(), BuildSequenceHandler(), BuildProviderWithHandler(), var(), XPoster.Tests.Integration (+1 more)

### Community 59 - "Entity (Community 59)"
Cohesion: 0.42
Nodes (9): RSSFeedTests.cs, RSSFeedTests.cs, RSSFeed_RecordEquality_SameValues_AreEqual(), XPoster.Tests.Models, RSSFeedTests, RSSFeed_DefaultPublishDateIsMinValue(), RSSFeed_CanSetPublishDate(), RSSFeed_CanCreateWithRequiredProperties() (+1 more)

### Community 63 - "Entity (Community 63)"
Cohesion: 0.22
Nodes (9): XPosterContainerPollingFunctionTests.cs, CreateTimerInfo(), RunAsync_WhenCancelled_StopsGracefully(), RunAsync_WhenStatusIsFinished_PublishesAndCleansUp(), PendingContainer(), RunAsync_WhenUpdateStatusThrows_PropagatesException(), RunAsync_WhenPublishFails_MarksFailedAndCleansUp(), RunAsync_WhenStatusIsExpired_MarksFailedAndCleansUp() (+1 more)

### Community 66 - "Entity (Community 66)"
Cohesion: 0.42
Nodes (9): FacebookResiliencePipelineTests.cs, FacebookResiliencePipelineTests.cs, Polly_Facebook_RetriesOn429_AndEventuallySucceeds(), catch(), Polly_Facebook_OnRetry_LogEntryIsEmitted(), Polly_Facebook_CircuitBreaker_OpensAfterConsecutiveFailures(), for(), Polly_Facebook_AttemptTimeout_CancelsSlowRequest() (+1 more)

### Community 68 - "Entity (Community 68)"
Cohesion: 0.42
Nodes (9): WorkflowExecutionEngine.cs, WorkflowExecutionEngine.cs, ExecuteAsync(), WorkflowExecutionEngine(), WorkflowExecutionResult(), XPoster.Workflows.Engine, if(), while() (+1 more)

### Community 67 - "Entity (Community 67)"
Cohesion: 0.22
Nodes (9): FbSenderImageFlowTests.cs, BuildCreds(), FbSenderImageFlowTests, SendAsync_WhenPhotoPublishThrows_FallsBackToTextOnly(), SendAsync_WhenImageNormalizationFails_FallsBackToTextOnly(), XPoster.Tests.SenderPlugins, HttpRequestException(), BuildFactory() (+1 more)

### Community 61 - "Entity (Community 61)"
Cohesion: 0.42
Nodes (9): AcquireCryptoValueNodeTests.cs, AcquireCryptoValueNodeTests.cs, WorkflowNodeInput(), Execute_ReturnsZero_WhenCryptoServiceReturnsZero(), Input(), Execute_UsesDefaultSymbol_WhenNotProvided(), AcquireCryptoValueNodeTests(), Execute_ReturnsCryptoValue_WhenSymbolParameterProvided() (+1 more)

### Community 62 - "Entity (Community 62)"
Cohesion: 0.22
Nodes (9): BaseOrchestratorTests.cs, XPoster.Tests.Orchestrators, PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_SkipsNullPost_ReturnsFalse(), PostAsync_ReturnsFalse_WhenSenderListIsEmpty(), PostAsync_ReturnsFalse_WhenOneSenderFails() (+1 more)

### Community 83 - "Entity (Community 83)"
Cohesion: 0.46
Nodes (8): FanOutSendNode.cs, FanOutSendNode.cs, ExecuteAsync(), if(), XPoster.Workflows.Nodes, WorkflowNodeResult(), FanOutSendNode(), foreach()

### Community 81 - "Entity (Community 81)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, XPoster.Tests.Contracts, GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(), GetLabel_DescriptionMatchesEnumName(), GetLabel_DescriptionDiffersFromEnumName(), AiProviderExtensionsTests, GetLabel_UnknownProvider_ReturnsFallbackToString()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.25
Nodes (8): AiServiceHelper.cs, BuildChatPayload(), ExtractFalAiBytesAsync(), ExtractAzureFoundryBytesAsync(), XPoster.Services, ParseImageResponseAsync(), LogAndReturnEmpty(), ExtractOpenAiBytes()

### Community 86 - "Entity (Community 86)"
Cohesion: 0.46
Nodes (8): WorkflowContext.cs, WorkflowContext.cs, KeyNotFoundException(), if(), HasData(), WorkflowContext, XPoster.Workflows.Models, SetData()

### Community 85 - "Entity (Community 85)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, CaptureLogger(), Dispose(), IsEnabled(), CaptureLoggerProvider(), CreateLogger(), XPoster.Tests.Integration

### Community 70 - "Entity (Community 70)"
Cohesion: 0.25
Nodes (8): AiTextNodeTests.cs, XPoster.Tests.Workflows.Nodes, WorkflowNodeInput(), Execute_Throws_WhenProviderNameIsUnknown(), Execute_ReturnsFailure_WhenProviderReturnsEmpty(), return(), static(), AiTextNodeTests

### Community 84 - "Entity (Community 84)"
Cohesion: 0.46
Nodes (8): FetchRssNode.cs, FetchRssNode.cs, ExecuteAsync(), WorkflowNodeResult(), if(), XPoster.Workflows.Nodes, foreach(), FetchRssNode()

### Community 73 - "Entity (Community 73)"
Cohesion: 0.46
Nodes (8): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, XPoster.Tests.Models, Validate_MissingRequiredProperties_Fails(), ValidOptions(), Validate_ValidOptions_Succeeds(), DeepSeekOptionsValidatorTests, Validate_AccumulatesAllFailures_WhenMultipleRulesViolated()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, InSenderSendAsyncTests(), SendAsync_WithNullPost_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse()

### Community 75 - "Entity (Community 75)"
Cohesion: 0.46
Nodes (8): FalAiImageService.cs, FalAiImageService.cs, catch(), GetImageGenerationEndpoint(), GenerateImageAsync(), XPoster.Services, if(), FalAiImageService()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.25
Nodes (8): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), BaseOrchestratorTests(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), PostAsync_DispatchesEachPostToAlignedSender(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), PostAsync_ReturnsFalse_WhenSenderPlatformNotInDictionary(), TestOrchestrator()

### Community 72 - "Entity (Community 72)"
Cohesion: 0.25
Nodes (8): BuildPowerLawPostNodeTests.cs, Execute_ComputesFairValueAndAppendsDelta_WhenActualPositive(), CreateNode(), Execute_CalculatesCorrectPowerLawValue_ForFixedDate(), new(), WorkflowNodeInput(), XPoster.Tests.Workflows.Nodes, Execute_OmitsDelta_WhenActualValueZeroOrMissing()

### Community 71 - "Entity (Community 71)"
Cohesion: 0.25
Nodes (8): FetchRssNodeTests.cs, Execute_ReturnsFailure_WhenNoContentRetrieved(), XPoster.Tests.Workflows.Nodes, foreach(), static(), Execute_ReturnsFailure_WhenNoUrlsProvided(), FetchRssNodeTests, return()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.46
Nodes (8): BlobStorageService.cs, BlobStorageService.cs, if(), DeleteAsync(), XPoster.Services, BlobUploadResult(), BlobStorageService(), UploadAsync()

### Community 78 - "Entity (Community 78)"
Cohesion: 0.25
Nodes (8): OrchestratorFactoryTests.cs, CreateFactoryWithProfiles(), new(), CreateFactory(), SetupMocksForOrchestratorFactory(), WorkflowOrchestrator_SupportedPlatforms_ContainsAllExpectedPlatforms(), WorkflowProfile(), OrchestratorFactoryTests()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.46
Nodes (8): AIResponse.cs, AIResponse.cs, AIResponse, Choice, Message, XPoster.Models, OpenAIImageResponse, ImageData

### Community 79 - "Entity (Community 79)"
Cohesion: 0.46
Nodes (8): PostTests.cs, PostTests.cs, XPoster.Tests.Models, Post_CanSetAndGetAllProperties(), Firm_IsNotNullOrEmpty(), Post_DefaultImageIsNull(), Post_EmptyContent_IsAllowed(), PostTests

### Community 96 - "Entity (Community 96)"
Cohesion: 0.52
Nodes (7): AiTextNode.cs, AiTextNode.cs, if(), ExecuteAsync(), AiTextNode(), XPoster.Workflows.Nodes, WorkflowNodeResult()

### Community 94 - "Entity (Community 94)"
Cohesion: 0.29
Nodes (7): OpenAiService.cs, var(), XPoster.Services, while(), GenerateImageAsync(), catch(), GenerateTextAsync()

### Community 95 - "Entity (Community 95)"
Cohesion: 0.52
Nodes (7): TagReplacementService.cs, TagReplacementService.cs, TagReplacementService(), XPoster.Services, if(), Apply(), foreach()

### Community 90 - "Entity (Community 90)"
Cohesion: 0.52
Nodes (7): XFunction.cs, XFunction.cs, catch(), XFunction(), Run(), XPoster, if()

### Community 88 - "Entity (Community 88)"
Cohesion: 0.29
Nodes (7): OrchestratorFactory.cs, ResolveSenders(), XPoster.Orchestrators, WorkflowOrchestrator(), catch(), NoOrchestrator(), Resolve()

### Community 89 - "Entity (Community 89)"
Cohesion: 0.29
Nodes (7): CredentialsStartupValidator.cs, Validate(), if(), CredentialsStartupValidator(), catch(), XPoster.Credentials, InvalidOperationException()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.52
Nodes (7): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, ValidOptions(), Validate_MissingRequiredProperties_Fails(), AzureFoundryOptionsValidatorTests, Validate_ValidOptions_Succeeds(), XPoster.Tests.Models

### Community 97 - "Entity (Community 97)"
Cohesion: 0.52
Nodes (7): AiImageNode.cs, AiImageNode.cs, AiImageNode(), WorkflowNodeResult(), XPoster.Workflows.Nodes, ExecuteAsync(), if()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.29
Nodes (7): FbSenderImageFlowTests.cs, HttpResponseMessage(), CreateValidJpegBytes(), SendAsync_WhenDeleteFails_AfterSuccessfulPhotoPublish_ReturnsTrue(), SendAsync_WhenUploadThrows_FallsBackToTextOnly(), SendAsync_WithSupportedImage_UploadsPublishesPhotoAndDeletesBlob(), if()

### Community 91 - "Entity (Community 91)"
Cohesion: 0.52
Nodes (7): InMemoryContainerStateStore.cs, InMemoryContainerStateStore.cs, InMemoryContainerStateStore, SaveAsync(), GetPendingAsync(), XPoster.Services, UpdateStatusAsync()

### Community 87 - "Entity (Community 87)"
Cohesion: 0.52
Nodes (7): WorkflowServiceCollectionExtensions.cs, WorkflowServiceCollectionExtensions.cs, foreach(), AddWorkflows(), if(), InvalidOperationException(), XPoster.Workflows.Configuration

### Community 93 - "Entity (Community 93)"
Cohesion: 0.52
Nodes (7): IgSender.cs, IgSender.cs, SendAsync(), XPoster.SenderPlugins, IgSender(), if(), catch()

### Community 99 - "Entity (Community 99)"
Cohesion: 0.52
Nodes (7): IContainerStateStore.cs, IContainerStateStore.cs, IContainerStateStore, GetPendingAsync(), XPoster.Contracts, UpdateStatusAsync(), SaveAsync()

### Community 111 - "Entity (Community 111)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, GetCurrentTime_ReturnsUtcTime(), GetCurrentTime_ReturnsCurrentDateTime(), TimeProviderTests, XPoster.Tests.Providers

### Community 109 - "Entity (Community 109)"
Cohesion: 0.60
Nodes (6): FacebookCredentialsValidator.cs, FacebookCredentialsValidator.cs, FacebookCredentialsValidator, if(), XPoster.Credentials, Validate()

### Community 110 - "Entity (Community 110)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, var(), MakeNoOpClient(), JsonResponse(), MakeDownloadClient(), HttpClient()

### Community 119 - "Entity (Community 119)"
Cohesion: 0.60
Nodes (6): WorkflowDefinitionValidator.cs, WorkflowDefinitionValidator.cs, XPoster.Workflows.Engine, foreach(), HasCycle(), if()

### Community 117 - "Entity (Community 117)"
Cohesion: 0.33
Nodes (6): NodeParameterExtractor.cs, GetProvider(), IsJsonLike(), return(), XPoster.Workflows.Utilities, catch()

### Community 118 - "Entity (Community 118)"
Cohesion: 0.60
Nodes (6): BuildPowerLawPostNode.cs, BuildPowerLawPostNode.cs, BuildPowerLawPostNode(), ExecuteAsync(), if(), XPoster.Workflows.Nodes

### Community 106 - "Entity (Community 106)"
Cohesion: 0.60
Nodes (6): Program.cs, Program.cs, BlobServiceClient(), DefaultAzureCredential(), if(), Uri()

### Community 108 - "Entity (Community 108)"
Cohesion: 0.33
Nodes (6): IgSenderTests.cs, IgSender(), Constructor_WithNullBlobStorageService_ThrowsArgumentNullException(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), IgSender_ImplementsISender(), IgSenderTests()

### Community 107 - "Entity (Community 107)"
Cohesion: 0.60
Nodes (6): IWorkflowContext.cs, IWorkflowContext.cs, HasData(), IWorkflowContext, SetData(), XPoster.Workflows.Models

### Community 126 - "Entity (Community 126)"
Cohesion: 0.33
Nodes (6): FetchRssNodeTests.cs, Execute_ConcatenatesMultipleFeeds(), WorkflowNodeInput(), var(), Input(), Execute_CallsFeedServiceForMultipleUrls()

### Community 127 - "Entity (Community 127)"
Cohesion: 0.60
Nodes (6): IMetaPublishingService.cs, IMetaPublishingService.cs, XPoster.Contracts, PublishContainerAsync(), IMetaPublishingService, GetContainerStatusAsync()

### Community 123 - "Entity (Community 123)"
Cohesion: 0.60
Nodes (6): OpenAiOptionsValidator.cs, OpenAiOptionsValidator.cs, if(), Validate(), nameof(), XPoster.Models

### Community 125 - "Entity (Community 125)"
Cohesion: 0.33
Nodes (6): AiImageNodeTests.cs, var(), Execute_ReturnsNullOutput_OnEmptyArray(), Execute_ReturnsSuccess_WhenRequired_AndImageProduced(), Execute_PassesStepOptionsToImagePromptRequest(), Execute_Throws_WhenProviderNameIsUnknown()

### Community 124 - "Entity (Community 124)"
Cohesion: 0.60
Nodes (6): AcquireCryptoValueNode.cs, AcquireCryptoValueNode.cs, ExecuteAsync(), WorkflowNodeResult(), AcquireCryptoValueNode(), XPoster.Workflows.Nodes

### Community 122 - "Entity (Community 122)"
Cohesion: 0.60
Nodes (6): PerplexityOptionsValidator.cs, PerplexityOptionsValidator.cs, XPoster.Models, Validate(), if(), nameof()

### Community 120 - "Entity (Community 120)"
Cohesion: 0.60
Nodes (6): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptionsTests, XPoster.Tests.Models

### Community 121 - "Entity (Community 121)"
Cohesion: 0.33
Nodes (6): BuildPowerLawPostNodeTests.cs, Execute_DateBeforeGenesis_ReturnsFailure(), BuildPowerLawPostNodeTests(), Execute_UsesSymbol_ForPostTag(), Input(), if()

### Community 114 - "Entity (Community 114)"
Cohesion: 0.60
Nodes (6): InstagramCredentialsValidator.cs, InstagramCredentialsValidator.cs, InstagramCredentialsValidator, Validate(), XPoster.Credentials, if()

### Community 115 - "Entity (Community 115)"
Cohesion: 0.60
Nodes (6): TagReplacementServiceTests.cs, TagReplacementServiceTests.cs, Apply_Does_Not_Replace_Words_Already_Prefixed_With_Hashtag(), Apply_Replaces_Only_First_Occurrence_For_Each_Word(), XPoster.Tests.Services, Apply_Returns_Input_Unchanged_When_Text_Is_Empty_Or_Whitespace()

### Community 116 - "Entity (Community 116)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, StringContent(), Polly_AiClient_AttemptTimeout_CancelsSlowRequest(), XPoster.Tests.Integration, Polly_AiClient_RetriesOn429_AndEventuallySucceeds()

### Community 103 - "Entity (Community 103)"
Cohesion: 0.33
Nodes (6): OrchestratorFactory.cs, OrchestratorFactory(), ResolveWorkflowOrchestrator(), nameof(), CreateEmptyNoOrchestrator(), if()

### Community 105 - "Entity (Community 105)"
Cohesion: 0.60
Nodes (6): DeepSeekOptionsValidator.cs, DeepSeekOptionsValidator.cs, Validate(), if(), nameof(), XPoster.Models

### Community 104 - "Entity (Community 104)"
Cohesion: 0.60
Nodes (6): AzureFoundryOptionsValidator.cs, AzureFoundryOptionsValidator.cs, XPoster.Models, if(), nameof(), Validate()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, if(), XPoster.SenderPlugins, SendAsync(), DryRunSender()

### Community 102 - "Entity (Community 102)"
Cohesion: 0.60
Nodes (6): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests, XPoster.Tests.Models, AzureFoundryOptions_Defaults_AreCorrect(), AzureFoundryOptions_DoesNotExpose_ApiVersionProperty()

### Community 112 - "Entity (Community 112)"
Cohesion: 0.33
Nodes (6): AiTextNodeTests.cs, var(), Execute_ReturnsGeneratedText(), Execute_PassesStepOptionsToPromptRequest(), Input(), Execute_Throws_WhenValidProviderNotRegistered()

### Community 113 - "Entity (Community 113)"
Cohesion: 0.60
Nodes (6): IBlobStorageService.cs, IBlobStorageService.cs, IBlobStorageService, UploadAsync(), XPoster.Contracts, DeleteAsync()

### Community 100 - "Entity (Community 100)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), XPoster.Tests.Integration, Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), for()

### Community 140 - "Entity (Community 140)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, XPoster.Providers, GetCurrentTime(), LocalOverrideTimeProvider()

### Community 141 - "Entity (Community 141)"
Cohesion: 0.40
Nodes (5): FeedService.cs, catch(), XPoster.Services, Exception(), GetFeedsAsync()

### Community 142 - "Entity (Community 142)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, IOrchestrator, XPoster.Contracts, PostAsync()

### Community 144 - "Entity (Community 144)"
Cohesion: 0.70
Nodes (5): ImageTestData.cs, ImageTestData.cs, CreateValidJpeg(), CreateValidPng(), XPoster.Tests.Helpers

### Community 143 - "Entity (Community 143)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, GetCurrentTime(), XPoster.Contracts, ITimeProvider

### Community 137 - "Entity (Community 137)"
Cohesion: 0.70
Nodes (5): ICredentialsStartupValidator.cs, ICredentialsStartupValidator.cs, ICredentialsStartupValidator, Validate(), XPoster.Contracts

### Community 136 - "Entity (Community 136)"
Cohesion: 0.70
Nodes (5): IAiProviderOptions.cs, IAiProviderOptions.cs, IAiProviderSection, XPoster.Contracts, IAiProviderOptions

### Community 139 - "Entity (Community 139)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, XPoster.Providers, TimeProvider, GetCurrentTime()

### Community 138 - "Entity (Community 138)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, XPoster.Contracts, IFeedService, GetFeedsAsync()

### Community 154 - "Entity (Community 154)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), catch(), Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), XPoster.Tests.Integration

### Community 150 - "Entity (Community 150)"
Cohesion: 0.70
Nodes (5): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests, XPoster.Tests.Models, ValidOptions()

### Community 151 - "Entity (Community 151)"
Cohesion: 0.70
Nodes (5): MaskUrlTelemetryProcessor.cs, MaskUrlTelemetryProcessor.cs, MaskUrlTelemetryProcessor(), if(), Process()

### Community 153 - "Entity (Community 153)"
Cohesion: 0.70
Nodes (5): ITextToTextProvider.cs, ITextToTextProvider.cs, ITextToTextProvider, XPoster.Contracts, GenerateTextAsync()

### Community 152 - "Entity (Community 152)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, Resolve(), XPoster.Contracts, IOrchestratorFactory

### Community 133 - "Entity (Community 133)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, ISender, SendAsync(), XPoster.Contracts

### Community 134 - "Entity (Community 134)"
Cohesion: 0.70
Nodes (5): LinkedInCredentialsValidator.cs, LinkedInCredentialsValidator.cs, if(), XPoster.Credentials, Validate()

### Community 135 - "Entity (Community 135)"
Cohesion: 0.70
Nodes (5): ITagReplacementProvider.cs, ITagReplacementProvider.cs, GetReplacements(), ITagReplacementProvider, XPoster.Contracts

### Community 129 - "Entity (Community 129)"
Cohesion: 0.40
Nodes (5): OpenAiService.cs, GetChatCompletionsEndpoint(), if(), OpenAiService(), GetImageGenerationEndpoint()

### Community 128 - "Entity (Community 128)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, XPoster.Contracts, ITextToImageProvider, GenerateImageAsync()

### Community 149 - "Entity (Community 149)"
Cohesion: 0.40
Nodes (5): PerplexityService.cs, XPoster.Services, var(), GenerateTextAsync(), if()

### Community 145 - "Entity (Community 145)"
Cohesion: 0.70
Nodes (5): AiProviderValidationHelper.cs, AiProviderValidationHelper.cs, if(), ValidateConnectivity(), XPoster.Models

### Community 146 - "Entity (Community 146)"
Cohesion: 0.70
Nodes (5): ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider.cs, XPoster.Providers, GetReplacements(), ConfigurationTagReplacementProvider()

### Community 147 - "Entity (Community 147)"
Cohesion: 0.40
Nodes (5): DeepSeekService.cs, var(), GenerateTextAsync(), if(), XPoster.Services

### Community 148 - "Entity (Community 148)"
Cohesion: 0.70
Nodes (5): PromptRequest.cs, PromptRequest.cs, ImagePromptRequest, PromptRequest, XPoster.Models

### Community 160 - "Entity (Community 160)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, GetProfiles(), ISlotProfileProvider, XPoster.Contracts

### Community 155 - "Entity (Community 155)"
Cohesion: 0.70
Nodes (5): WorkflowDefinitionOptions.cs, WorkflowDefinitionOptions.cs, ToDefinition(), WorkflowDefinition(), XPoster.Workflows.Configuration

### Community 157 - "Entity (Community 157)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, XPoster.Contracts, ICryptoService, GetCryptoValue()

### Community 159 - "Entity (Community 159)"
Cohesion: 0.70
Nodes (5): IWorkflowNode.cs, IWorkflowNode.cs, ExecuteAsync(), IWorkflowNode, XPoster.Workflows.Abstractions

### Community 158 - "Entity (Community 158)"
Cohesion: 0.70
Nodes (5): ITagReplacementService.cs, ITagReplacementService.cs, ITagReplacementService, XPoster.Contracts, Apply()

### Community 156 - "Entity (Community 156)"
Cohesion: 0.70
Nodes (5): IWorkflowEngine.cs, IWorkflowEngine.cs, IWorkflowEngine, XPoster.Workflows.Engine, ExecuteAsync()

### Community 132 - "Entity (Community 132)"
Cohesion: 0.70
Nodes (5): IStepOptionsResolver.cs, IStepOptionsResolver.cs, XPoster.Workflows.Services, Resolve(), IStepOptionsResolver

### Community 130 - "Entity (Community 130)"
Cohesion: 0.70
Nodes (5): ConfigurationStepOptionsResolver.cs, ConfigurationStepOptionsResolver.cs, Resolve(), ConfigurationStepOptionsResolver(), XPoster.Workflows.Services

### Community 131 - "Entity (Community 131)"
Cohesion: 0.70
Nodes (5): WorkflowOrchestrator.cs, WorkflowOrchestrator.cs, XPoster.Orchestrators, WorkflowOrchestrator(), if()

### Community 190 - "Entity (Community 190)"
Cohesion: 0.83
Nodes (4): ITerminalNode.cs, ITerminalNode.cs, ITerminalNode, XPoster.Workflows.Abstractions

### Community 191 - "Entity (Community 191)"
Cohesion: 0.83
Nodes (4): DryRunMaxLengthSender.cs, DryRunMaxLengthSender.cs, XPoster.SenderPlugins, DryRunMaxLengthSender()

### Community 197 - "Entity (Community 197)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, XPoster.Orchestrators, NoOrchestrator()

### Community 193 - "Entity (Community 193)"
Cohesion: 0.50
Nodes (4): ConfigurationSlotProfileProvider.cs, GetProfiles(), XPoster.Providers, ConfigurationSlotProfileProvider()

### Community 192 - "Entity (Community 192)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, GetLabel(), XPoster.Contracts

### Community 194 - "Entity (Community 194)"
Cohesion: 0.50
Nodes (4): WorkflowDefinitionValidatorTests.cs, ExecuteAsync(), Node(), new()

### Community 195 - "Entity (Community 195)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile(), XPoster.Models

### Community 196 - "Entity (Community 196)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, RSSFeed, XPoster.Models

### Community 182 - "Entity (Community 182)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, if(), return(), catch()

### Community 174 - "Entity (Community 174)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, Post, XPoster.Models

### Community 180 - "Entity (Community 180)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, catch(), StringContent(), Polly_LinkedIn_OnRetry_LogEntryIsEmitted()

### Community 181 - "Entity (Community 181)"
Cohesion: 0.83
Nodes (4): WorkflowNodeResult.cs, WorkflowNodeResult.cs, XPoster.Workflows.Abstractions, WorkflowNodeResult()

### Community 179 - "Entity (Community 179)"
Cohesion: 0.83
Nodes (4): WorkflowDefinition.cs, WorkflowDefinition.cs, XPoster.Workflows.Engine, WorkflowDefinition()

### Community 178 - "Entity (Community 178)"
Cohesion: 0.83
Nodes (4): MediaAttachment.cs, MediaAttachment.cs, XPoster.Workflows.Models, MediaAttachment()

### Community 175 - "Entity (Community 175)"
Cohesion: 0.83
Nodes (4): WorkflowNodeDefinition.cs, WorkflowNodeDefinition.cs, WorkflowNodeDefinition(), XPoster.Workflows.Engine

### Community 176 - "Entity (Community 176)"
Cohesion: 0.83
Nodes (4): WorkflowExecutionResult.cs, WorkflowExecutionResult.cs, XPoster.Workflows.Engine, WorkflowExecutionResult()

### Community 177 - "Entity (Community 177)"
Cohesion: 0.50
Nodes (4): FalAiOptionsValidator.cs, foreach(), Validate(), XPoster.Models

### Community 166 - "Entity (Community 166)"
Cohesion: 0.83
Nodes (4): BlobUploadResult.cs, BlobUploadResult.cs, XPoster.Models, BlobUploadResult()

### Community 161 - "Entity (Community 161)"
Cohesion: 0.83
Nodes (4): SenderPluginsServiceCollectionExtensions.cs, SenderPluginsServiceCollectionExtensions.cs, XPoster.Extensions, AddXPosterSenderPlugins()

### Community 165 - "Entity (Community 165)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, GetCryptoValue(), XPoster.Services, catch()

### Community 162 - "Entity (Community 162)"
Cohesion: 0.83
Nodes (4): AiProviderOptionsCompositionExtensions.cs, AiProviderOptionsCompositionExtensions.cs, XPoster.Extensions, AddAiProviderOptions()

### Community 163 - "Entity (Community 163)"
Cohesion: 0.50
Nodes (4): XSender.cs, SendAsync(), catch(), XPoster.SenderPlugins

### Community 164 - "Entity (Community 164)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, XPoster.Orchestrators, PostAsync(), BaseOrchestrator()

### Community 183 - "Entity (Community 183)"
Cohesion: 0.83
Nodes (4): WorkflowNodeInput.cs, WorkflowNodeInput.cs, XPoster.Workflows.Abstractions, WorkflowNodeInput()

### Community 189 - "Entity (Community 189)"
Cohesion: 0.50
Nodes (4): CredentialsStartupValidator.cs, ValidateOptions(), foreach(), resolve()

### Community 184 - "Entity (Community 184)"
Cohesion: 0.50
Nodes (4): PerplexityService.cs, GetChatCompletionsEndpoint(), PerplexityService(), while()

### Community 185 - "Entity (Community 185)"
Cohesion: 0.50
Nodes (4): DeepSeekService.cs, DeepSeekService(), GetChatCompletionsEndpoint(), while()

### Community 186 - "Entity (Community 186)"
Cohesion: 0.83
Nodes (4): DryRunShortLengthSender.cs, DryRunShortLengthSender.cs, DryRunShortLengthSender(), XPoster.SenderPlugins

### Community 187 - "Entity (Community 187)"
Cohesion: 0.50
Nodes (4): HttpClientExtensions.cs, AddHttpClients(), AddResilientHttpClient(), XPoster.Extensions

### Community 188 - "Entity (Community 188)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, AddXPosterAiProviders(), XPoster.Extensions

### Community 173 - "Entity (Community 173)"
Cohesion: 0.83
Nodes (4): PendingContainer.cs, PendingContainer.cs, XPoster.Models, PendingContainer()

### Community 167 - "Entity (Community 167)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, var(), XPoster.Tests.Helpers, BuildSequenceHandler()

### Community 169 - "Entity (Community 169)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, for(), StringContent(), Polly_Instagram_AttemptTimeout_CancelsSlowRequest()

### Community 171 - "Entity (Community 171)"
Cohesion: 0.83
Nodes (4): CredentialsExtensions.cs, CredentialsExtensions.cs, XPoster.Credentials, AddCredentials()

### Community 170 - "Entity (Community 170)"
Cohesion: 0.50
Nodes (4): WorkflowExecutionEngineTests.cs, var(), new(), StubNode()

### Community 168 - "Entity (Community 168)"
Cohesion: 0.50
Nodes (4): WorkflowOrchestratorTests.cs, WorkflowExecutionResult(), var(), new()

### Community 172 - "Entity (Community 172)"
Cohesion: 0.50
Nodes (4): FanOutSendNodeTests.cs, var(), SetupSender(), if()

### Community 199 - "Entity (Community 199)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, XPoster.Contracts, AiProvider.cs

### Community 198 - "Entity (Community 198)"
Cohesion: 1.00
Nodes (3): InstagramCredentials.cs, InstagramCredentials.cs, XPoster.Credentials

### Community 213 - "Entity (Community 213)"
Cohesion: 1.00
Nodes (3): FacebookCredentials.cs, FacebookCredentials.cs, XPoster.Credentials

### Community 226 - "Entity (Community 226)"
Cohesion: 0.67
Nodes (3): FeedService.cs, FeedService(), if()

### Community 228 - "Entity (Community 228)"
Cohesion: 0.67
Nodes (3): XSender.cs, XSender(), if()

### Community 227 - "Entity (Community 227)"
Cohesion: 1.00
Nodes (3): WorkflowContextKeys.cs, WorkflowContextKeys.cs, XPoster.Workflows.Models

### Community 225 - "Entity (Community 225)"
Cohesion: 1.00
Nodes (3): XPoster.Workflows.Models, PromptStepOptions.cs, PromptStepOptions.cs

### Community 223 - "Entity (Community 223)"
Cohesion: 1.00
Nodes (3): MediaType.cs, MediaType.cs, XPoster.Workflows.Models

### Community 214 - "Entity (Community 214)"
Cohesion: 0.67
Nodes (3): InSender.cs, if(), InSender()

### Community 222 - "Entity (Community 222)"
Cohesion: 1.00
Nodes (3): XPoster.Models, SlotScheduleOptions.cs, SlotScheduleOptions.cs

### Community 224 - "Entity (Community 224)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, if(), CryptoService()

### Community 215 - "Entity (Community 215)"
Cohesion: 1.00
Nodes (3): ContainerStatus.cs, XPoster.Contracts, ContainerStatus.cs

### Community 216 - "Entity (Community 216)"
Cohesion: 0.67
Nodes (3): NodeParameterExtractor.cs, if(), InvalidOperationException()

### Community 217 - "Entity (Community 217)"
Cohesion: 1.00
Nodes (3): LinkedInCredentials.cs, LinkedInCredentials.cs, XPoster.Credentials

### Community 218 - "Entity (Community 218)"
Cohesion: 1.00
Nodes (3): TagReplacementOptions.cs, TagReplacementOptions.cs, XPoster.Models

### Community 220 - "Entity (Community 220)"
Cohesion: 1.00
Nodes (3): XCredentials.cs, XPoster.Credentials, XCredentials.cs

### Community 221 - "Entity (Community 221)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, DeepSeekOptions.cs, XPoster.Models

### Community 219 - "Entity (Community 219)"
Cohesion: 0.67
Nodes (3): BaseOrchestrator.cs, DispatchAsync(), if()

### Community 200 - "Entity (Community 200)"
Cohesion: 0.67
Nodes (3): FbSenderResilienceTests.cs, BuildCreds(), BuildFactory()

### Community 212 - "Entity (Community 212)"
Cohesion: 0.67
Nodes (3): XCredentialsValidator.cs, Validate(), XPoster.Credentials

### Community 211 - "Entity (Community 211)"
Cohesion: 0.67
Nodes (3): ConfigurationSlotProfileProvider.cs, foreach(), if()

### Community 203 - "Entity (Community 203)"
Cohesion: 1.00
Nodes (3): PerplexityOptions.cs, XPoster.Models, PerplexityOptions.cs

### Community 205 - "Entity (Community 205)"
Cohesion: 0.67
Nodes (3): HttpClientExtensions.cs, if(), IsTransientHttpFailure()

### Community 204 - "Entity (Community 204)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, XPoster.Models, FalAiOptions.cs

### Community 201 - "Entity (Community 201)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, XPoster.Models, AzureFoundryOptions.cs

### Community 202 - "Entity (Community 202)"
Cohesion: 1.00
Nodes (3): XPoster.Models, OpenAiOptions.cs, OpenAiOptions.cs

### Community 208 - "Entity (Community 208)"
Cohesion: 0.67
Nodes (3): FalAiOptionsValidator.cs, nameof(), if()

### Community 210 - "Entity (Community 210)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, params(), BuildFactory()

### Community 209 - "Entity (Community 209)"
Cohesion: 1.00
Nodes (3): XPoster.Contracts, SenderPlatform.cs, SenderPlatform.cs

### Community 207 - "Entity (Community 207)"
Cohesion: 1.00
Nodes (3): BlobStorageOptions.cs, XPoster.Models, BlobStorageOptions.cs

### Community 206 - "Entity (Community 206)"
Cohesion: 1.00
Nodes (3): AiModelClass.cs, XPoster.Contracts, AiModelClass.cs

### Community 229 - "Entity (Community 229)"
Cohesion: 1.00
Nodes (2): XCredentialsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._


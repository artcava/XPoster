# Graph Report - XPoster  (2026-09-19)

## Summary
- 2041 nodes · 3467 edges · 250 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Tests.Models` - 2 edges
2. `XPoster.SenderPlugins` - 2 edges
3. `DeepSeekOptionsValidatorTests` - 2 edges
4. `XPoster.Tests.Workflows.Nodes` - 2 edges
5. `XPoster.Tests.Providers` - 2 edges
6. `XPoster.Tests` - 2 edges
7. `XPosterContainerPollingFunctionTests` - 2 edges
8. `XPoster.Tests.Orchestrators` - 2 edges
9. `ConfigurationStepOptionsResolverTests` - 2 edges
10. `InMemoryContainerStateStoreTests` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, ParseImageResponseAsync_OpenAi_MissingDataArray_ReturnsEmptyArray(), ParseImageResponseAsync_OpenAi_MissingB64JsonProperty_ReturnsEmptyArray(), AiServiceHelperTests, OpenAiB64Json(), new(), ParseChatCompletionResponseAsync_WhenResponseBodyIsEmpty_ReturnsFalseAndEmpty() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.09
Nodes (43): AzureFoundryServiceTests.cs, AzureFoundryServiceTests.cs, GenerateTextAsync_RequestBodyContainsSystemAndUserMessagesFromRequest(), GenerateTextAsync_RequestBodyContainsModelFromOptions(), GenerateImageAsync_WhenInputTextIsEmpty_LogsWarning(), GenerateImageAsync_WhenHttpRequestExceptionOnPost_LogsError(), GenerateImageAsync_WhenHttpRequestExceptionOnPost_ReturnsEmptyByteArray(), HttpResponseMessage() (+35 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.11
Nodes (36): OpenAiServiceTests.cs, OpenAiServiceTests.cs, OpenAiService(), OpenAiServiceTests, XPoster.Tests.Services, new(), MakeHandlerMock(), MakeHandler() (+28 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, AiServiceHelperImageTests, Parse_FalAi_MissingUrlProperty_ReturnsEmpty(), Parse_FalAi_EmptyUrl_ReturnsEmpty(), Parse_FalAi_MissingImagesProperty_ReturnsEmpty(), Parse_FalAi_EmptyImagesArray_ReturnsEmpty(), return(), Parse_UnsupportedProvider_LogsError() (+24 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.12
Nodes (32): DryRunSenderTests.cs, DryRunSenderTests.cs, MaxSender_Platform_IsDryRunMaxLength(), MaxSender_MessageMaxLength_IsIntMaxValue(), MaxSender_ImplementsISender(), DryRunShortLengthSender(), SendAsync_WithNullContent_StillReturnsTrueWhenKeyPresent(), SendAsync_WithImageAttached_ReturnsTrueAndLogsImagePresent() (+24 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, AddFalAiOptions_BindsOptionsFromCorrectSection(), AddFalAiOptions_RegistersValidator(), AddOpenAiOptions_BindsOptionsFromCorrectSection(), AddDeepSeekOptions_BindsOptionsFromCorrectSection(), AddAzureFoundryOptions_BindsOptionsFromCorrectSection(), AddAzureFoundryOptions_RegistersValidator() (+21 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.14
Nodes (28): PerplexityServiceTests.cs, PerplexityServiceTests.cs, XPoster.Tests.Services, new(), PerplexityService(), PerplexityServiceTests, MakeHandlerMock(), GenerateTextAsync_WhenTextExceedsMaxOutputLength_CallsApiAndReturnsContent() (+20 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.15
Nodes (26): FbSenderTests.cs, FbSenderTests.cs, FbSender(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), Constructor_WithNullFactory_ThrowsArgumentNullException(), Constructor_WithNullLogger_ThrowsArgumentNullException(), Constructor_InitializesCorrectly(), BuildCreds() (+18 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.16
Nodes (25): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, GenerateTextAsync_WhenApiReturnsInternalServerError_ReturnsEmptyString(), GenerateTextAsync_UsesSystemAndUserTemplatesFromRequest_NotFromOptions(), GenerateTextAsync_WhenApiReturnsBadGateway_ReturnsEmptyString(), GenerateTextAsync_WhenApiReturns429_ReturnsEmptyString(), XPoster.Tests.Services, MakeHandlerMock() (+17 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.16
Nodes (25): NodeParameterExtractorTests.cs, NodeParameterExtractorTests.cs, NodeParameterExtractorTests, GetProvider_Throws_WhenEmptyName(), GetProvider_UsesProvidedDefault_WhenMissing(), GetProvider_Throws_WhenUnknownName(), GetProvider_MissingParameter_ReturnsDefaultProvider(), GetParameter_PlainString_StillConverts() (+17 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.10
Nodes (21): WorkflowExecutionEngineTests.cs, Execute_MissingRef_ReturnsFailure_WithDescriptiveError(), Execute_Diamond_ExecutesAllNodes_AndResolvesDependencies(), Execute_EmptyNodesDefinition_Succeeds(), Execute_LinearChain_ExecutesInOrder_AndStoresOutputs(), foreach(), Execute_PowerLawChain_AcquireThenBuildThenFanOut_StoresOutputs(), Execute_UnregisteredNodeType_ReturnsFailure() (+13 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.11
Nodes (19): HttpResponseBodyLoggingHandlerTests.cs, LogWasCalled(), HttpClient(), if(), HttpResponseBodyLoggingHandlerTests, SendAsync_4xx_LogsResponseHeaders(), SendAsync_CallerStillReadsBodyAfterLogging(), SendAsync_4xx5xx_LogsAtErrorLevel() (+11 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.11
Nodes (19): XSenderTests.cs, XSenderTests, SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), XPoster.Tests.SenderPlugins, XSender(), SendAsync_PngImagePost_PublishesTweetWithImagePngMediaType(), Platform_ReturnsX(), SendAsync_ImagePost_WhenUploadAndTweetSucceed_ReturnsTrue() (+11 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.22
Nodes (18): AiProviderOptionsAbstractionTests.cs, AiProviderOptionsAbstractionTests.cs, ModelCatalog_EmptyModelName_NotExposedAsSupported(), FalAiOptions_ImplementsIAiProviderOptions(), FalAiOptions_NumInferenceSteps_RemainsOnConcreteClass(), FalAiOptions_ModelCatalog_ExposesImageOnly(), DeepSeekOptions_ModelCatalog_ExposesTextOnly(), AzureFoundryOptions_ModelCatalog_ExposesTextAndImage() (+10 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.22
Nodes (18): AiServiceHelperChatPayloadTests.cs, AiServiceHelperChatPayloadTests.cs, BuildChatPayload_SecondMessageRoleIsUser(), BuildRequest(), BuildChatPayload_SubstitutesCustomLabelInUserMessage(), BuildChatPayload_WhenInputTextLabelIsNull_FallsBackToTextPlaceholder(), BuildChatPayload_SystemMessage_NoPlaceholder_IsUnchanged(), BuildChatPayload_MessagesContainsTwoEntries() (+10 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.22
Nodes (18): WorkflowContextTests.cs, WorkflowContextTests.cs, TryGetData_ReturnsFalse_WhenKeyMissing(), WorkflowContextTests, TryGetData_ReturnsTrue_WhenKeyExists(), XPoster.Tests.Workflows.Models, GetData_ThrowsOnTypeMismatch(), catch() (+10 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, BuildRssXml(), BuildFactory(), GetFeedsAsync_ReturnsFeedsFromCache_IfPresent(), new(), SendAsync(), XPoster.Tests.Services (+10 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.22
Nodes (18): IgSenderImageFlowTests.cs, IgSenderImageFlowTests.cs, NormalizeImage_WithInvalidBytes_ReturnsNull(), NormalizeImage_WhenPngDecodesToNull_ReturnsNull(), NormalizeImage_WhenJpegIsAlreadyValid_ReturnsOriginalBytes(), IgSenderImageFlowTests, NormalizeImage_WhenCodecIsNull_ReturnsNull(), SendAsync_WhenBlobUploadSucceeds_CreatesMediaContainerWithCorrectSasUrl() (+10 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.23
Nodes (17): PromptRequestTests.cs, PromptRequestTests.cs, ImagePromptRequest_ImageProperties_DefaultToNull(), ImagePromptRequest_InheritsFrom_PromptRequest(), ImagePromptRequest_IsImmutable_AfterConstruction(), PromptRequest_IsImmutable_AfterConstruction(), ImagePromptRequest_ValueEquality_SameValues_AreEqual(), ImagePromptRequest_ImageProperties_AreSetCorrectly() (+9 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.23
Nodes (17): WorkflowServiceCollectionExtensionsTests.cs, WorkflowServiceCollectionExtensionsTests.cs, XPoster.Tests.Workflows.Configuration, AddWorkflows_WithMultipleTerminalNodes_ThrowsInvalidOperationException(), AddWorkflows_Registers_KeyedNodes(), AddWorkflows_Registers_WorkflowDefinitions_AsKeyedSingletons(), AddWorkflows_Registers_WorkflowEngine(), AddWorkflows_Registers_StepOptionsResolver() (+9 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.23
Nodes (17): MetaPublishingServiceTests.cs, MetaPublishingServiceTests.cs, PublishContainerAsync_WhenRateLimited_Throws(), MetaPublishingService(), PublishContainerAsync_WhenCancelled_ThrowsTaskCanceledException(), PublishContainerAsync_WhenOk_ReturnsPublishId(), PublishContainerAsync_WhenIdIsNull_ReturnsEmptyString(), PublishContainerAsync_WhenResponseBodyIsNull_ThrowsJsonException() (+9 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.24
Nodes (16): ConfigurationSlotProfileProviderTests.cs, ConfigurationSlotProfileProviderTests.cs, XPoster.Tests.Providers, GetProfiles_Should_SkipSlot_WithNoWorkflowKey(), GetProfiles_Should_SkipSlot_WhenNoValidSendersRemain(), GetProfiles_Should_SkipSlot_WithNoSenders(), GetProfiles_Should_SkipUnknownSenders_ButKeepValidOnes(), new() (+8 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.24
Nodes (16): InMemoryContainerStateStoreTests.cs, InMemoryContainerStateStoreTests.cs, SaveAsync_WithEmptyOrWhitespaceCreationId_ThrowsArgumentException(), SaveAsync_WithEmptyOrWhitespaceBlobName_ThrowsArgumentException(), GetPendingAsync_ReturnsOnlyPendingEntries(), InMemoryContainerStateStoreTests, GetPendingAsync_WhenStoreIsEmpty_ReturnsEmptyList(), UpdateStatusAsync_WithEmptyOrWhitespaceCreationId_ThrowsArgumentException() (+8 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.24
Nodes (16): HttpResponseBodySanitizerTests.cs, HttpResponseBodySanitizerTests.cs, Sanitize_ReturnsEmptyForNullOrEmpty(), Sanitize_MasksBearerTokenInHeader(), Sanitize_MasksRefreshTokenField(), Sanitize_MasksBearerTokenInJson(), Sanitize_MasksJsonApiKey(), Sanitize_MasksAccessTokenJsonField() (+8 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.12
Nodes (16): WorkflowDefinitionValidatorTests.cs, ValidateTerminalNodeContract_TerminalDoesNotImplementContract_ReturnsError(), ValidateStructural_EmptyNodes_ReturnsNull(), ValidateStructural_MissingNodeReference_ReturnsError(), ValidateStructural_MultipleTerminalNodes_ReturnsError(), ValidateStructural_ValidLinearDag_ReturnsNull(), TwoTerminals(), Linear() (+8 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.26
Nodes (15): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, PostWithImage(), BuildSender(), new(), IgSender(), IgSenderResilienceTests, SendAsync_WhenNoImage_ReturnsFalseWithoutCallingApi() (+7 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.13
Nodes (15): XApiClientTests.cs, CreateTweetAsync_WithText_ReturnsTweetId(), CreateTweetAsync_WithMediaId_SerializesMediaIdsInPayload(), ContainsSequence(), CreateTweetAsync_WhenApiReturns402_ThrowsXApiExceptionWithParsedDetails(), CreateTweetAsync_WhenBodyCarriesErrorsArray_ThrowsXApiException(), UploadMediaAsync_WhenAppendRejected_ThrowsXApiException(), foreach() (+7 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.26
Nodes (15): BlobStorageServiceTests.cs, BlobStorageServiceTests.cs, DeleteAsync_WhenBlobDoesNotExist_LogsDebugAndDoesNotThrow(), BlobStorageService(), Constructor_WhenContainerNameIsEmpty_UsesDefaultName(), CreateSut(), BlobStorageServiceTests, UploadAsync_WhenStorageThrows_PropagatesException() (+7 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.26
Nodes (15): MaskUrlTelemetryProcessorTests.cs, MaskUrlTelemetryProcessorTests.cs, Initialize_WhenFacebookDataIsMalformedUrl_DataRemainsUnchanged(), Initialize_WhenFacebookUrlHasOnlyAccessToken_TokenIsMasked(), Initialize_WhenFacebookUrlHasAccessToken_TokenIsMasked(), Initialize_WhenFacebookUrlHasNoQueryString_DataUnchanged(), Initialize_WhenFacebookUrlHasNoAccessToken_DataUnchanged(), Initialize_WhenHttpDependencyNotFacebook_DoesNotModifyData() (+7 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.26
Nodes (15): AddAiProviderOptionsTests.cs, AddAiProviderOptionsTests.cs, AddAiProviderOptionsTests, ConfigurationBuilder(), BuildAllProvidersConfig(), XPoster.Tests.Extensions, AddAiProviderOptions_BindsDeepSeekOptions_FromCorrectSection(), AddAiProviderOptions_BindsAzureFoundryOptions_FromCorrectSection() (+7 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, Choice_CanBeCreated_WithMessage(), AIResponse_CanBeCreated_WithChoices(), RSSFeed_CanBeCreated_WithAllProperties(), RSSFeed_PublishDate_DefaultsToMinValue(), XPoster.Tests.Models, Post_CanHold_ImageBytes() (+6 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.27
Nodes (14): XPosterContainerPollingFunction.cs, XPosterContainerPollingFunction.cs, XPoster, XPosterContainerPollingFunction(), switch(), Run(), HandleFinishedAsync(), ProcessContainerAsync() (+6 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.14
Nodes (14): WorkflowOrchestratorTests.cs, MakeDefinitionWithoutImage(), MakeDefinition(), static(), XPoster.Tests.Orchestrators, WorkflowOrchestratorTests, Properties_AreConfigured(), OrchestrateAsync_ReturnsEmptyDictionary_WhenSendResultsMissing() (+6 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.14
Nodes (14): FanOutSendNodeTests.cs, WorkflowNodeInput(), XPoster.Tests.Workflows.Nodes, return(), Execute_StoresSendResultsInContext(), FanOutSendNodeTests, Execute_TwoSenders_ResummarisesForSmallSenderAndKeepsVariantForWideSender(), Input() (+6 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_WhitespaceModelId_Fails(), Validate_ImageModelNameWithAllowedSpecialChars_Succeeds(), Validate_ImageModelNameWithUnsafeCharacters_Fails(), Validate_ValidOptions_Succeeds(), Validate_MissingModelId_Fails(), Validate_MissingApiKey_Fails() (+5 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.29
Nodes (13): XOAuth1SignerTests.cs, XOAuth1SignerTests.cs, ComputeSignatureBaseString_PhotoExample_ReturnsExpectedBaseString(), BuildAuthorizationHeader_MediaUploadInit_PercentEncodesOAuthValuesPerRfc5849(), BuildPhotoParameters(), BuildCredentials(), BuildAuthorizationHeader_PhotoExample_ContainsOAuthParameters(), ComputeSignature_PhotoExample_ReturnsExpectedBase64() (+5 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.15
Nodes (13): InSenderTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn(), SendAsync_TextOnly_WhenPostCreationFails_ReturnsFalse(), SendAsync_WithImage_WhenRegisterUploadFails_ReturnsFalse(), InSender_ImplementsISender(), SendAsync_TextOnly_WithPersonCode_UsesPersonUrn() (+5 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, GetCurrentTime_WhenForceHourIsAbsent_FallsBackToUtcHour(), Constructor_AlwaysEmitsDevOverrideWarning(), BuildProvider(), LocalOverrideTimeProviderTests, GetCurrentTime_WhenForceHourIsNonNumeric_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsValid_ReturnsUtcKind() (+5 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.15
Nodes (13): AiImageNodeTests.cs, Execute_ReturnsFailure_WhenRequired_AndImageMissing(), AiImageNodeTests, Execute_ReturnsMediaAttachment_OnSuccess(), Execute_ReturnsSoftFailure_WhenRequiredFalse_AndImageMissing(), Input(), if(), Execute_Throws_WhenValidProviderNotRegistered() (+5 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.15
Nodes (13): FalAiImageServiceTests.cs, FalAiImageServiceTests, GenerateImageAsync_Returns429_ReturnsEmptyArray(), FalImageJson(), GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithUnsafeChars_PercentEncodesInRequestUri(), GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray() (+5 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.29
Nodes (13): AiModelCatalogTests.cs, AiModelCatalogTests.cs, GetRequired_Throws_WhenNotSupported(), TryGet_ReturnsFalseAndNullModelName_WhenNotSupported(), XPoster.Tests.Models, Supports_ReturnsFalseForMissingModelClass(), TryGet_ReturnsTrueAndPopulatesModelName_WhenSupported(), Supports_ReturnsTrueForRegisteredModelClass() (+5 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.17
Nodes (12): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenUnexpectedExceptionThrown_LogsErrorAndRethrows(), XPoster.Tests, XPosterContainerPollingFunctionTests, RunAsync_WhenStatusIsInProgress_SkipsContainer(), CreateSut(), RunAsync_WhenStatusIsError_MarksFailedAndCleansUp(), RunAsync_WhenBlobDeleteFails_LogsError() (+4 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.17
Nodes (12): InSenderTests.cs, Constructor_InitializesCorrectly(), InSender(), InSenderTests(), SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse(), Platform_ReturnsLinkedIn(), SendAsync_WithEmptyContent_ReturnsFalseAndLogsWarning(), SendAsync_WhenNeitherOrgIdNorOwnerCodeSet_ReturnsFalse() (+4 more)

### Community 46 - "Entity (Community 46)"
Cohesion: 0.17
Nodes (12): OrchestratorFactoryTests.cs, Resolve_Should_ReturnWorkflowOrchestrator_WhenWorkflowDefinitionIsRegistered(), typeof(), XPoster.Tests.Orchestrators, Resolve_Should_ReturnNoOrchestrator_WhenWorkflowDefinitionMissing(), foreach(), Resolve_Should_ReturnNoOrchestrator_WhenNoProfileMatchesCurrentHour(), NoOrchestrator_SupportedPlatforms_IsEmpty() (+4 more)

### Community 47 - "Entity (Community 47)"
Cohesion: 0.32
Nodes (12): ConfigurationStepOptionsResolverTests.cs, ConfigurationStepOptionsResolverTests.cs, foreach(), BuildConfig(), ConfigurationStepOptionsResolverTests, Resolve_BindsImageProperties_WhenPresent(), Resolve_ReturnsStepOptions_WhenSectionExists(), Resolve_Throws_OnNullOrWhitespaceStepId() (+4 more)

### Community 44 - "Entity (Community 44)"
Cohesion: 0.17
Nodes (12): XApiClient.cs, HasErrorPayload(), for(), catch(), CreateTweetAsync(), ArgumentException(), BuildSignedRequest(), XPoster.SenderPlugins (+4 more)

### Community 45 - "Entity (Community 45)"
Cohesion: 0.32
Nodes (12): ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests.cs, Constructor_Should_Throw_When_OptionsIsNull(), ConfigurationTagReplacementProvider(), ConfigurationTagReplacementProviderTests, GetReplacements_Should_PreserveAllEntries_When_MultipleReplacementsConfigured(), GetReplacements_Should_ReturnReadOnlyDictionary(), GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsPropertyIsNull() (+4 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, GenerateImageAsync_MalformedJson_ReturnsEmptyArray(), GenerateImageAsync_EmptyUrlProperty_ReturnsEmptyArray(), FalAiImageService(), MakeRequest(), GenerateImageAsync_ModelIdWithMultipleSegments_PreservesSlashesInUri(), GenerateImageAsync_WhitespacePrompt_ReturnsEmptyArray(), MakeHandlerMock() (+4 more)

### Community 49 - "Entity (Community 49)"
Cohesion: 0.35
Nodes (11): AiProviderServiceCollectionExtensionsTests.cs, AiProviderServiceCollectionExtensionsTests.cs, AddXPosterAiProviders_RegistersPerplexity_AsTextOnly(), AddXPosterAiProviders_RegistersAzureFoundry_AsTextAndImageProvider(), AddXPosterAiProviders_RegistersExpectedNumberOfKeyedServices(), AddXPosterAiProviders_RegistersFalAi_AsImageOnly(), AddXPosterAiProviders_RegistersDeepSeek_AsTextOnly(), AddXPosterAiProviders_RegistersOpenAi_AsTextAndImageProvider() (+3 more)

### Community 48 - "Entity (Community 48)"
Cohesion: 0.35
Nodes (11): XOAuth1Signer.cs, XOAuth1Signer.cs, XPoster.SenderPlugins, PercentEncode(), ParseQueryString(), BuildAuthorizationHeader(), ComputeSignatureBaseString(), GetBaseUri() (+3 more)

### Community 50 - "Entity (Community 50)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, InSenderResilienceTests, BuildSender(), InSender(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), XPoster.Tests.SenderPlugins, ValidPost() (+3 more)

### Community 51 - "Entity (Community 51)"
Cohesion: 0.35
Nodes (11): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, XPoster.Tests.Models, Constructor_Should_PreserveOrderOfSenderPlatforms(), Constructor_Should_SetAllFields(), typeof(), ScheduledOrchestrationProfileTests, TwoSlotsWithSameOrchestratorType_Should_CarryIndependentContextKeys() (+3 more)

### Community 52 - "Entity (Community 52)"
Cohesion: 0.18
Nodes (11): IgSenderTests.cs, BuildSender(), MessageMaxLength_Returns2200(), Constructor_WithNullHttpClientFactory_ThrowsArgumentNullException(), Constructor_InitializesCorrectly(), new(), Constructor_WithNullContainerStateStore_ThrowsArgumentNullException(), Constructor_WithNullLogger_ThrowsArgumentNullException() (+3 more)

### Community 59 - "Entity (Community 59)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, Name_IsNoOrchestrator(), XPoster.Tests.Orchestrators, OrchestrateAsync_ReturnsEmptyList(), NoOrchestratorTests, SendIt_IsAlwaysFalse(), SupportedPlatforms_IsEmpty() (+2 more)

### Community 58 - "Entity (Community 58)"
Cohesion: 0.38
Nodes (10): XFunctionTests.cs, XFunctionTests.cs, Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), Run_Should_LogError_When_OrchestrateAsync_ReturnsEmptyDictionary(), Run_Should_LogWarning_AndNotRethrow_When_CancelledGracefully(), Run_Should_Rethrow_When_Factory_Throws(), XFunctionTests(), XPoster.Tests (+2 more)

### Community 57 - "Entity (Community 57)"
Cohesion: 0.38
Nodes (10): IgSenderSendAsyncTests.cs, IgSenderSendAsyncTests.cs, BuildSender(), IgSenderSendAsyncTests, SendAsync_WithEmptyImageArray_ReturnsFalse(), SendAsync_WithCaptionExceedingMaxLength_TruncatesCaption(), SendAsync_WithNoImage_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse() (+2 more)

### Community 56 - "Entity (Community 56)"
Cohesion: 0.38
Nodes (10): FbSenderSendAsyncTests.cs, FbSenderSendAsyncTests.cs, SendAsync_WithEmptyImage_PublishesTextOnly_ReturnsTrue(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), SendAsync_WithNullImage_PublishesTextOnly_ReturnsTrue(), XPoster.Tests.SenderPlugins, SendAsync_WithCaptionLongerThanMax_StillPublishes_ReturnsTrue(), FbSenderSendAsyncTests (+2 more)

### Community 55 - "Entity (Community 55)"
Cohesion: 0.38
Nodes (10): FbSender.cs, FbSender.cs, SendAsync(), XPoster.SenderPlugins, PublishPhotoAsync(), if(), HandleResponseAsync(), catch() (+2 more)

### Community 54 - "Entity (Community 54)"
Cohesion: 0.38
Nodes (10): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, ValidOptions(), XPoster.Tests.Models, Validate_WhenTextModelNameIsEmpty_ReturnsFailed(), Validate_WhenEndpointIsEmpty_ReturnsFailed(), Validate_WhenApiKeyIsEmpty_ReturnsFailed(), PerplexityOptionsValidatorTests (+2 more)

### Community 53 - "Entity (Community 53)"
Cohesion: 0.38
Nodes (10): MetaPublishingService.cs, MetaPublishingService.cs, XPoster.Services, PublishContainerAsync(), HttpRequestException(), MetaPublishingService(), GetApiVersion(), if() (+2 more)

### Community 70 - "Entity (Community 70)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, BuildProviderWithHandler(), BuildSequenceHandler(), params(), HttpResponseMessage(), XPoster.Tests.Integration, var() (+1 more)

### Community 69 - "Entity (Community 69)"
Cohesion: 0.42
Nodes (9): RSSFeedTests.cs, RSSFeedTests.cs, RSSFeed_DefaultPublishDateIsMinValue(), RSSFeedTests, RSSFeed_CanCreateWithRequiredProperties(), XPoster.Tests.Models, RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeed_RecordEquality_SameValues_AreEqual() (+1 more)

### Community 66 - "Entity (Community 66)"
Cohesion: 0.42
Nodes (9): XSenderResilienceTests.cs, XSenderResilienceTests.cs, SendAsync_WhenPostIsNull_ReturnsFalseAndLogsWarning(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalseAndLogsError(), BuildSender(), SendAsync_WhenContentIsBlank_ReturnsFalseAndLogsWarning(), XPoster.Tests.SenderPlugins, XSenderResilienceTests (+1 more)

### Community 65 - "Entity (Community 65)"
Cohesion: 0.42
Nodes (9): AcquireCryptoValueNodeTests.cs, AcquireCryptoValueNodeTests.cs, WorkflowNodeInput(), XPoster.Tests.Workflows.Nodes, Input(), Execute_ReturnsZero_WhenCryptoServiceReturnsZero(), AcquireCryptoValueNodeTests(), Execute_UsesDefaultSymbol_WhenNotProvided() (+1 more)

### Community 64 - "Entity (Community 64)"
Cohesion: 0.42
Nodes (9): AiModelCatalog.cs, AiModelCatalog.cs, TryGet(), XPoster.Models, InvalidOperationException(), AiModelCatalog(), if(), GetRequired() (+1 more)

### Community 67 - "Entity (Community 67)"
Cohesion: 0.22
Nodes (9): FbSenderImageFlowTests.cs, SendAsync_WhenPhotoPublishThrows_FallsBackToTextOnly(), BuildCreds(), HttpRequestException(), BuildFactory(), SendAsync_WhenImageNormalizationFails_FallsBackToTextOnly(), FbSenderImageFlowTests, InvalidImageBytes() (+1 more)

### Community 68 - "Entity (Community 68)"
Cohesion: 0.22
Nodes (9): BaseOrchestratorTests.cs, XPoster.Tests.Orchestrators, PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_SkipsNullPost_ReturnsFalse(), PostAsync_ReturnsFalse_WhenSenderListIsEmpty(), PostAsync_ReturnsFalse_WhenOneSenderFails() (+1 more)

### Community 63 - "Entity (Community 63)"
Cohesion: 0.42
Nodes (9): WorkflowExecutionEngine.cs, WorkflowExecutionEngine.cs, ExecuteAsync(), while(), WorkflowExecutionEngine(), WorkflowExecutionResult(), XPoster.Workflows.Engine, foreach() (+1 more)

### Community 62 - "Entity (Community 62)"
Cohesion: 0.22
Nodes (9): InSender.cs, generatePayLoad(), XPoster.SenderPlugins, InvalidOperationException(), ResolveAuthorUrn(), SendAsync(), using(), catch() (+1 more)

### Community 60 - "Entity (Community 60)"
Cohesion: 0.22
Nodes (9): FbSenderResilienceTests.cs, FbSenderResilienceTests, HttpResponseMessage(), SendAsync_WhenTextPublishReturns200WithoutId_ReturnsFalse(), SendAsync_WhenTextPublishReturns200WithEmptyId_ReturnsFalse(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WhenTextPublishReturns200WithId_ReturnsTrue() (+1 more)

### Community 61 - "Entity (Community 61)"
Cohesion: 0.42
Nodes (9): HttpClientExtensionsTests.cs, HttpClientExtensionsTests.cs, AddHttpClients_CanCreateAllExpectedNamedClients(), AddHttpClients_RegistersExpectedNamedClients(), XPoster.Tests.Extensions, AddHttpClients_ReturnsSameServiceCollection(), HttpClientExtensionsTests, foreach() (+1 more)

### Community 72 - "Entity (Community 72)"
Cohesion: 0.22
Nodes (9): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenStatusIsExpired_MarksFailedAndCleansUp(), CreateTimerInfo(), RunAsync_WhenPublishFails_MarksFailedAndCleansUp(), RunAsync_WhenCancelled_StopsGracefully(), PendingContainer(), RunAsync_WhenBlobDeleteFails_StillUpdatesStatus(), RunAsync_WhenStatusIsFinished_PublishesAndCleansUp() (+1 more)

### Community 71 - "Entity (Community 71)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, MakeService(), XPoster.Tests.Services, GetCryptoValue_ReturnsParsedValue_WhenNumericString(), CryptoServiceTests, CryptoService(), GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric() (+1 more)

### Community 73 - "Entity (Community 73)"
Cohesion: 0.42
Nodes (9): FacebookResiliencePipelineTests.cs, FacebookResiliencePipelineTests.cs, XPoster.Tests.Integration, Polly_Facebook_RetriesOn429_AndEventuallySucceeds(), Polly_Facebook_AttemptTimeout_CancelsSlowRequest(), Polly_Facebook_OnRetry_LogEntryIsEmitted(), Polly_Facebook_CircuitBreaker_OpensAfterConsecutiveFailures(), catch() (+1 more)

### Community 81 - "Entity (Community 81)"
Cohesion: 0.25
Nodes (8): FetchRssNodeTests.cs, static(), return(), XPoster.Tests.Workflows.Nodes, foreach(), Execute_ReturnsFailure_WhenNoContentRetrieved(), FetchRssNodeTests, Execute_ReturnsFailure_WhenNoUrlsProvided()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.46
Nodes (8): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, XPoster.Tests.Models, Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), DeepSeekOptionsValidatorTests, ValidOptions(), Validate_MissingRequiredProperties_Fails(), Validate_ValidOptions_Succeeds()

### Community 85 - "Entity (Community 85)"
Cohesion: 0.46
Nodes (8): FalAiImageService.cs, FalAiImageService.cs, GenerateImageAsync(), catch(), FalAiImageService(), if(), GetImageGenerationEndpoint(), XPoster.Services

### Community 84 - "Entity (Community 84)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(), GetLabel_UnknownProvider_ReturnsFallbackToString(), XPoster.Tests.Contracts, GetLabel_DescriptionMatchesEnumName(), GetLabel_DescriptionDiffersFromEnumName(), AiProviderExtensionsTests

### Community 89 - "Entity (Community 89)"
Cohesion: 0.46
Nodes (8): PostTests.cs, PostTests.cs, Post_DefaultImageIsNull(), XPoster.Tests.Models, PostTests, Post_EmptyContent_IsAllowed(), Firm_IsNotNullOrEmpty(), Post_CanSetAndGetAllProperties()

### Community 90 - "Entity (Community 90)"
Cohesion: 0.25
Nodes (8): AiServiceHelper.cs, XPoster.Services, ParseImageResponseAsync(), ExtractOpenAiBytes(), BuildChatPayload(), LogAndReturnEmpty(), ExtractFalAiBytesAsync(), ExtractAzureFoundryBytesAsync()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.46
Nodes (8): FanOutSendNode.cs, FanOutSendNode.cs, ExecuteAsync(), FanOutSendNode(), if(), WorkflowNodeResult(), foreach(), XPoster.Workflows.Nodes

### Community 80 - "Entity (Community 80)"
Cohesion: 0.46
Nodes (8): AIResponse.cs, AIResponse.cs, XPoster.Models, AIResponse, OpenAIImageResponse, Choice, ImageData, Message

### Community 75 - "Entity (Community 75)"
Cohesion: 0.25
Nodes (8): BuildPowerLawPostNodeTests.cs, new(), WorkflowNodeInput(), XPoster.Tests.Workflows.Nodes, Execute_OmitsDelta_WhenActualValueZeroOrMissing(), Execute_CalculatesCorrectPowerLawValue_ForFixedDate(), Execute_ComputesFairValueAndAppendsDelta_WhenActualPositive(), CreateNode()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.46
Nodes (8): BlobStorageService.cs, BlobStorageService.cs, BlobStorageService(), if(), BlobUploadResult(), DeleteAsync(), UploadAsync(), XPoster.Services

### Community 78 - "Entity (Community 78)"
Cohesion: 0.25
Nodes (8): OrchestratorFactoryTests.cs, new(), CreateFactory(), CreateFactoryWithProfiles(), OrchestratorFactoryTests(), WorkflowOrchestrator_SupportedPlatforms_ContainsAllExpectedPlatforms(), WorkflowProfile(), SetupMocksForOrchestratorFactory()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, CaptureLogger(), IsEnabled(), XPoster.Tests.Integration, CreateLogger(), Dispose(), CaptureLoggerProvider()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.25
Nodes (8): AiTextNodeTests.cs, Execute_ReturnsFailure_WhenProviderReturnsEmpty(), static(), XPoster.Tests.Workflows.Nodes, Execute_Throws_WhenProviderNameIsUnknown(), return(), WorkflowNodeInput(), AiTextNodeTests

### Community 87 - "Entity (Community 87)"
Cohesion: 0.46
Nodes (8): FetchRssNode.cs, FetchRssNode.cs, WorkflowNodeResult(), if(), ExecuteAsync(), FetchRssNode(), foreach(), XPoster.Workflows.Nodes

### Community 88 - "Entity (Community 88)"
Cohesion: 0.46
Nodes (8): WorkflowContext.cs, WorkflowContext.cs, if(), SetData(), HasData(), KeyNotFoundException(), WorkflowContext, XPoster.Workflows.Models

### Community 86 - "Entity (Community 86)"
Cohesion: 0.25
Nodes (8): BaseOrchestratorTests.cs, PostAsync_DispatchesEachPostToAlignedSender(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), PostAsync_ReturnsFalse_WhenSenderPlatformNotInDictionary(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), TestOrchestrator(), BaseOrchestratorTests()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), InSenderSendAsyncTests(), SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), XPoster.Tests.SenderPlugins

### Community 98 - "Entity (Community 98)"
Cohesion: 0.52
Nodes (7): WorkflowServiceCollectionExtensions.cs, WorkflowServiceCollectionExtensions.cs, InvalidOperationException(), XPoster.Workflows.Configuration, AddWorkflows(), if(), foreach()

### Community 99 - "Entity (Community 99)"
Cohesion: 0.52
Nodes (7): IContainerStateStore.cs, IContainerStateStore.cs, IContainerStateStore, GetPendingAsync(), SaveAsync(), UpdateStatusAsync(), XPoster.Contracts

### Community 100 - "Entity (Community 100)"
Cohesion: 0.52
Nodes (7): TagReplacementService.cs, TagReplacementService.cs, Apply(), foreach(), if(), XPoster.Services, TagReplacementService()

### Community 109 - "Entity (Community 109)"
Cohesion: 0.52
Nodes (7): IgSender.cs, IgSender.cs, if(), catch(), IgSender(), SendAsync(), XPoster.SenderPlugins

### Community 92 - "Entity (Community 92)"
Cohesion: 0.29
Nodes (7): ResilienceTestHelpers.cs, XPoster.Tests.Helpers, StubHttpMessageHandler(), if(), BuildSequenceHandler(), CapturedRequest(), var()

### Community 94 - "Entity (Community 94)"
Cohesion: 0.52
Nodes (7): AiTextNode.cs, AiTextNode.cs, if(), ExecuteAsync(), AiTextNode(), WorkflowNodeResult(), XPoster.Workflows.Nodes

### Community 93 - "Entity (Community 93)"
Cohesion: 0.29
Nodes (7): HttpResponseBodyLoggingHandlerTests.cs, var(), SendAsync(), SendAsync_OptOutHeader_LogsNothing(), SendAsync_NotEnabled_SuccessNotLogged(), static(), return()

### Community 96 - "Entity (Community 96)"
Cohesion: 0.29
Nodes (7): HttpResponseBodyLogger.cs, IsEnabledFor(), foreach(), HttpResponseBodyLogger(), Log(), while(), XPoster.Services

### Community 95 - "Entity (Community 95)"
Cohesion: 0.29
Nodes (7): OpenAiService.cs, catch(), GenerateImageAsync(), GenerateTextAsync(), var(), XPoster.Services, while()

### Community 106 - "Entity (Community 106)"
Cohesion: 0.29
Nodes (7): OrchestratorFactory.cs, Resolve(), catch(), NoOrchestrator(), WorkflowOrchestrator(), XPoster.Orchestrators, ResolveSenders()

### Community 104 - "Entity (Community 104)"
Cohesion: 0.29
Nodes (7): AzureFoundryService.cs, while(), XPoster.Services, GenerateTextAsync(), GenerateImageAsync(), AzureFoundryService(), GetImageGenerationEndpoint()

### Community 105 - "Entity (Community 105)"
Cohesion: 0.29
Nodes (7): CredentialsStartupValidator.cs, catch(), InvalidOperationException(), Validate(), CredentialsStartupValidator(), XPoster.Credentials, if()

### Community 108 - "Entity (Community 108)"
Cohesion: 0.52
Nodes (7): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, ValidOptions(), AzureFoundryOptionsValidatorTests, Validate_ValidOptions_Succeeds(), Validate_MissingRequiredProperties_Fails(), XPoster.Tests.Models

### Community 107 - "Entity (Community 107)"
Cohesion: 0.52
Nodes (7): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, XSenderSendAsyncTests(), SendAsync_WithEmptyContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse()

### Community 91 - "Entity (Community 91)"
Cohesion: 0.52
Nodes (7): InMemoryContainerStateStore.cs, InMemoryContainerStateStore.cs, GetPendingAsync(), SaveAsync(), InMemoryContainerStateStore, XPoster.Services, UpdateStatusAsync()

### Community 97 - "Entity (Community 97)"
Cohesion: 0.52
Nodes (7): XFunction.cs, XFunction.cs, XFunction(), XPoster, Run(), if(), catch()

### Community 102 - "Entity (Community 102)"
Cohesion: 0.52
Nodes (7): AiImageNode.cs, AiImageNode.cs, ExecuteAsync(), AiImageNode(), XPoster.Workflows.Nodes, WorkflowNodeResult(), if()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.52
Nodes (7): XSender.cs, XSender.cs, SendAsync(), catch(), XPoster.SenderPlugins, if(), XSender()

### Community 103 - "Entity (Community 103)"
Cohesion: 0.29
Nodes (7): FbSenderImageFlowTests.cs, CreateValidJpegBytes(), if(), SendAsync_WhenDeleteFails_AfterSuccessfulPhotoPublish_ReturnsTrue(), HttpResponseMessage(), SendAsync_WithSupportedImage_UploadsPublishesPhotoAndDeletesBlob(), SendAsync_WhenUploadThrows_FallsBackToTextOnly()

### Community 138 - "Entity (Community 138)"
Cohesion: 0.60
Nodes (6): IWorkflowContext.cs, IWorkflowContext.cs, HasData(), IWorkflowContext, SetData(), XPoster.Workflows.Models

### Community 139 - "Entity (Community 139)"
Cohesion: 0.33
Nodes (6): IgSenderTests.cs, Constructor_WithNullBlobStorageService_ThrowsArgumentNullException(), IgSender(), IgSenderTests(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), IgSender_ImplementsISender()

### Community 140 - "Entity (Community 140)"
Cohesion: 0.60
Nodes (6): PerplexityOptionsValidator.cs, PerplexityOptionsValidator.cs, if(), nameof(), XPoster.Models, Validate()

### Community 116 - "Entity (Community 116)"
Cohesion: 0.60
Nodes (6): BuildPowerLawPostNode.cs, BuildPowerLawPostNode.cs, BuildPowerLawPostNode(), ExecuteAsync(), if(), XPoster.Workflows.Nodes

### Community 118 - "Entity (Community 118)"
Cohesion: 0.33
Nodes (6): AiTextNodeTests.cs, Execute_ReturnsGeneratedText(), Execute_PassesStepOptionsToPromptRequest(), Execute_Throws_WhenValidProviderNotRegistered(), Input(), var()

### Community 117 - "Entity (Community 117)"
Cohesion: 0.60
Nodes (6): DeepSeekOptionsValidator.cs, DeepSeekOptionsValidator.cs, if(), nameof(), Validate(), XPoster.Models

### Community 115 - "Entity (Community 115)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, var(), JsonResponse(), MakeNoOpClient(), MakeDownloadClient(), HttpClient()

### Community 113 - "Entity (Community 113)"
Cohesion: 0.60
Nodes (6): WorkflowDefinitionValidator.cs, WorkflowDefinitionValidator.cs, if(), XPoster.Workflows.Engine, HasCycle(), foreach()

### Community 114 - "Entity (Community 114)"
Cohesion: 0.60
Nodes (6): AcquireCryptoValueNode.cs, AcquireCryptoValueNode.cs, AcquireCryptoValueNode(), WorkflowNodeResult(), XPoster.Workflows.Nodes, ExecuteAsync()

### Community 123 - "Entity (Community 123)"
Cohesion: 0.33
Nodes (6): BuildPowerLawPostNodeTests.cs, Input(), Execute_DateBeforeGenesis_ReturnsFailure(), BuildPowerLawPostNodeTests(), Execute_UsesSymbol_ForPostTag(), if()

### Community 121 - "Entity (Community 121)"
Cohesion: 0.33
Nodes (6): HttpResponseBodyLoggingHandler.cs, IsBinaryMediaType(), SendAsync(), XPoster.Services, HttpResponseBodyLoggingHandler(), foreach()

### Community 122 - "Entity (Community 122)"
Cohesion: 0.60
Nodes (6): InstagramCredentialsValidator.cs, InstagramCredentialsValidator.cs, InstagramCredentialsValidator, Validate(), XPoster.Credentials, if()

### Community 111 - "Entity (Community 111)"
Cohesion: 0.60
Nodes (6): IBlobStorageService.cs, IBlobStorageService.cs, DeleteAsync(), XPoster.Contracts, UploadAsync(), IBlobStorageService

### Community 110 - "Entity (Community 110)"
Cohesion: 0.60
Nodes (6): IMetaPublishingService.cs, IMetaPublishingService.cs, PublishContainerAsync(), GetContainerStatusAsync(), XPoster.Contracts, IMetaPublishingService

### Community 112 - "Entity (Community 112)"
Cohesion: 0.60
Nodes (6): Program.cs, Program.cs, BlobServiceClient(), Uri(), if(), DefaultAzureCredential()

### Community 135 - "Entity (Community 135)"
Cohesion: 0.60
Nodes (6): FacebookCredentialsValidator.cs, FacebookCredentialsValidator.cs, Validate(), XPoster.Credentials, FacebookCredentialsValidator, if()

### Community 132 - "Entity (Community 132)"
Cohesion: 0.33
Nodes (6): XApiException.cs, foreach(), XPoster.SenderPlugins, XApiException(), BuildMessage(), catch()

### Community 134 - "Entity (Community 134)"
Cohesion: 0.33
Nodes (6): XApiClient.cs, ThrowIfNotSuccess(), FinalizeMediaAsync(), if(), SignRequest(), AppendMediaSegmentsAsync()

### Community 133 - "Entity (Community 133)"
Cohesion: 0.60
Nodes (6): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, XPoster.Tests.Models, AzureFoundryOptions_Defaults_AreCorrect(), AzureFoundryOptionsTests, AzureFoundryOptions_DoesNotExpose_ApiVersionProperty()

### Community 129 - "Entity (Community 129)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, Polly_AiClient_RetriesOn429_AndEventuallySucceeds(), Polly_AiClient_AttemptTimeout_CancelsSlowRequest(), XPoster.Tests.Integration, StringContent()

### Community 126 - "Entity (Community 126)"
Cohesion: 0.60
Nodes (6): AzureFoundryOptionsValidator.cs, AzureFoundryOptionsValidator.cs, Validate(), nameof(), if(), XPoster.Models

### Community 127 - "Entity (Community 127)"
Cohesion: 0.60
Nodes (6): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, XPoster.Tests.Models, DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptionsTests

### Community 128 - "Entity (Community 128)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, for(), Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration, Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest()

### Community 124 - "Entity (Community 124)"
Cohesion: 0.33
Nodes (6): OrchestratorFactory.cs, CreateEmptyNoOrchestrator(), nameof(), OrchestratorFactory(), if(), ResolveWorkflowOrchestrator()

### Community 125 - "Entity (Community 125)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, XPoster.SenderPlugins, SendAsync(), if(), DryRunSender()

### Community 130 - "Entity (Community 130)"
Cohesion: 0.60
Nodes (6): OpenAiOptionsValidator.cs, OpenAiOptionsValidator.cs, nameof(), Validate(), XPoster.Models, if()

### Community 131 - "Entity (Community 131)"
Cohesion: 0.60
Nodes (6): TagReplacementServiceTests.cs, TagReplacementServiceTests.cs, Apply_Returns_Input_Unchanged_When_Text_Is_Empty_Or_Whitespace(), Apply_Does_Not_Replace_Words_Already_Prefixed_With_Hashtag(), XPoster.Tests.Services, Apply_Replaces_Only_First_Occurrence_For_Each_Word()

### Community 136 - "Entity (Community 136)"
Cohesion: 0.33
Nodes (6): NodeParameterExtractor.cs, catch(), IsJsonLike(), return(), GetProvider(), XPoster.Workflows.Utilities

### Community 137 - "Entity (Community 137)"
Cohesion: 0.33
Nodes (6): AiImageNodeTests.cs, Execute_ReturnsSuccess_WhenRequired_AndImageProduced(), Execute_Throws_WhenProviderNameIsUnknown(), Execute_ReturnsNullOutput_OnEmptyArray(), Execute_PassesStepOptionsToImagePromptRequest(), var()

### Community 119 - "Entity (Community 119)"
Cohesion: 0.33
Nodes (6): FetchRssNodeTests.cs, Execute_CallsFeedServiceForMultipleUrls(), Input(), var(), Execute_ConcatenatesMultipleFeeds(), WorkflowNodeInput()

### Community 120 - "Entity (Community 120)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, XPoster.Tests.Providers, TimeProviderTests, GetCurrentTime_ReturnsUtcTime(), GetCurrentTime_ReturnsCurrentDateTime()

### Community 141 - "Entity (Community 141)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, IOrchestrator, PostAsync(), XPoster.Contracts

### Community 173 - "Entity (Community 173)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, XPoster.Providers, TimeProvider, GetCurrentTime()

### Community 169 - "Entity (Community 169)"
Cohesion: 0.70
Nodes (5): IWorkflowEngine.cs, IWorkflowEngine.cs, XPoster.Workflows.Engine, ExecuteAsync(), IWorkflowEngine

### Community 170 - "Entity (Community 170)"
Cohesion: 0.40
Nodes (5): FeedService.cs, catch(), XPoster.Services, GetFeedsAsync(), Exception()

### Community 171 - "Entity (Community 171)"
Cohesion: 0.70
Nodes (5): WorkflowDefinitionOptions.cs, WorkflowDefinitionOptions.cs, XPoster.Workflows.Configuration, ToDefinition(), WorkflowDefinition()

### Community 172 - "Entity (Community 172)"
Cohesion: 0.70
Nodes (5): ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider.cs, GetReplacements(), ConfigurationTagReplacementProvider(), XPoster.Providers

### Community 152 - "Entity (Community 152)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, ITextToImageProvider, GenerateImageAsync(), XPoster.Contracts

### Community 154 - "Entity (Community 154)"
Cohesion: 0.70
Nodes (5): ITagReplacementProvider.cs, ITagReplacementProvider.cs, XPoster.Contracts, GetReplacements(), ITagReplacementProvider

### Community 155 - "Entity (Community 155)"
Cohesion: 0.40
Nodes (5): HttpClientExtensions.cs, AddResilientHttpClient(), AddHttpResponseBodyLogging(), AddHttpClients(), XPoster.Extensions

### Community 153 - "Entity (Community 153)"
Cohesion: 0.40
Nodes (5): XApiClientTests.cs, BuildApiClient(), OkJson(), if(), HttpResponseMessage()

### Community 159 - "Entity (Community 159)"
Cohesion: 0.70
Nodes (5): AiProviderValidationHelper.cs, AiProviderValidationHelper.cs, if(), ValidateConnectivity(), XPoster.Models

### Community 160 - "Entity (Community 160)"
Cohesion: 0.70
Nodes (5): IWorkflowNode.cs, IWorkflowNode.cs, IWorkflowNode, ExecuteAsync(), XPoster.Workflows.Abstractions

### Community 161 - "Entity (Community 161)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, GetCurrentTime(), XPoster.Contracts, ITimeProvider

### Community 163 - "Entity (Community 163)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, GetProfiles(), ISlotProfileProvider, XPoster.Contracts

### Community 162 - "Entity (Community 162)"
Cohesion: 0.70
Nodes (5): PromptRequest.cs, PromptRequest.cs, ImagePromptRequest, XPoster.Models, PromptRequest

### Community 144 - "Entity (Community 144)"
Cohesion: 0.70
Nodes (5): IAiProviderOptions.cs, IAiProviderOptions.cs, IAiProviderSection, IAiProviderOptions, XPoster.Contracts

### Community 143 - "Entity (Community 143)"
Cohesion: 0.40
Nodes (5): ResilienceTestHelpers.cs, SendAsync(), _responder(), params(), BuildFactory()

### Community 142 - "Entity (Community 142)"
Cohesion: 0.70
Nodes (5): ITextToTextProvider.cs, ITextToTextProvider.cs, GenerateTextAsync(), XPoster.Contracts, ITextToTextProvider

### Community 168 - "Entity (Community 168)"
Cohesion: 0.70
Nodes (5): LinkedInCredentialsValidator.cs, LinkedInCredentialsValidator.cs, Validate(), if(), XPoster.Credentials

### Community 164 - "Entity (Community 164)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, IOrchestratorFactory, XPoster.Contracts, Resolve()

### Community 165 - "Entity (Community 165)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, ICryptoService, GetCryptoValue(), XPoster.Contracts

### Community 167 - "Entity (Community 167)"
Cohesion: 0.40
Nodes (5): HttpResponseBodyLogger.cs, SanitizeAndTruncate(), TruncateUtf8(), FormatResponseHeaders(), if()

### Community 166 - "Entity (Community 166)"
Cohesion: 0.70
Nodes (5): MaskUrlTelemetryProcessor.cs, MaskUrlTelemetryProcessor.cs, MaskUrlTelemetryProcessor(), Process(), if()

### Community 148 - "Entity (Community 148)"
Cohesion: 0.40
Nodes (5): DeepSeekService.cs, var(), GenerateTextAsync(), if(), XPoster.Services

### Community 145 - "Entity (Community 145)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, catch(), XPoster.Tests.Integration, Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures()

### Community 147 - "Entity (Community 147)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, XPoster.Contracts, GetFeedsAsync(), IFeedService

### Community 146 - "Entity (Community 146)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, XPoster.Contracts, SendAsync(), ISender

### Community 179 - "Entity (Community 179)"
Cohesion: 0.70
Nodes (5): ITagReplacementService.cs, ITagReplacementService.cs, Apply(), ITagReplacementService, XPoster.Contracts

### Community 174 - "Entity (Community 174)"
Cohesion: 0.70
Nodes (5): IStepOptionsResolver.cs, IStepOptionsResolver.cs, IStepOptionsResolver, Resolve(), XPoster.Workflows.Services

### Community 176 - "Entity (Community 176)"
Cohesion: 0.70
Nodes (5): ConfigurationStepOptionsResolver.cs, ConfigurationStepOptionsResolver.cs, XPoster.Workflows.Services, ConfigurationStepOptionsResolver(), Resolve()

### Community 178 - "Entity (Community 178)"
Cohesion: 0.70
Nodes (5): WorkflowOrchestrator.cs, WorkflowOrchestrator.cs, if(), WorkflowOrchestrator(), XPoster.Orchestrators

### Community 177 - "Entity (Community 177)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider(), XPoster.Providers, GetCurrentTime()

### Community 175 - "Entity (Community 175)"
Cohesion: 0.40
Nodes (5): OpenAiService.cs, if(), OpenAiService(), GetImageGenerationEndpoint(), GetChatCompletionsEndpoint()

### Community 151 - "Entity (Community 151)"
Cohesion: 0.40
Nodes (5): AzureFoundryService.cs, var(), if(), GetChatCompletionsEndpoint(), catch()

### Community 149 - "Entity (Community 149)"
Cohesion: 0.70
Nodes (5): ICredentialsStartupValidator.cs, ICredentialsStartupValidator.cs, Validate(), ICredentialsStartupValidator, XPoster.Contracts

### Community 150 - "Entity (Community 150)"
Cohesion: 0.70
Nodes (5): ImageTestData.cs, ImageTestData.cs, XPoster.Tests.Helpers, CreateValidPng(), CreateValidJpeg()

### Community 156 - "Entity (Community 156)"
Cohesion: 0.40
Nodes (5): HttpResponseBodyLoggingPipelineTests.cs, ResponseBodyLogging_429Sequence_LogsEachRetryAttemptAndFinalSuccess(), return(), static(), XPoster.Tests.Integration

### Community 158 - "Entity (Community 158)"
Cohesion: 0.70
Nodes (5): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, ValidOptions(), OpenAiOptionsValidatorTests, XPoster.Tests.Models

### Community 157 - "Entity (Community 157)"
Cohesion: 0.40
Nodes (5): PerplexityService.cs, var(), XPoster.Services, if(), GenerateTextAsync()

### Community 209 - "Entity (Community 209)"
Cohesion: 0.50
Nodes (4): WorkflowDefinitionValidatorTests.cs, ExecuteAsync(), new(), Node()

### Community 210 - "Entity (Community 210)"
Cohesion: 0.50
Nodes (4): XSenderTests.cs, HttpResponseMessage(), BuildSender(), if()

### Community 216 - "Entity (Community 216)"
Cohesion: 0.83
Nodes (4): BlobUploadResult.cs, BlobUploadResult.cs, BlobUploadResult(), XPoster.Models

### Community 212 - "Entity (Community 212)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, XPoster.Models, Post

### Community 211 - "Entity (Community 211)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, RSSFeed, XPoster.Models

### Community 213 - "Entity (Community 213)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, catch(), StringContent(), Polly_LinkedIn_OnRetry_LogEntryIsEmitted()

### Community 214 - "Entity (Community 214)"
Cohesion: 0.83
Nodes (4): PendingContainer.cs, PendingContainer.cs, PendingContainer(), XPoster.Models

### Community 215 - "Entity (Community 215)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, XPoster.Orchestrators, BaseOrchestrator(), PostAsync()

### Community 201 - "Entity (Community 201)"
Cohesion: 0.50
Nodes (4): PerplexityService.cs, PerplexityService(), while(), GetChatCompletionsEndpoint()

### Community 193 - "Entity (Community 193)"
Cohesion: 0.50
Nodes (4): WorkflowOrchestratorTests.cs, var(), WorkflowExecutionResult(), new()

### Community 199 - "Entity (Community 199)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, AddXPosterAiProviders(), XPoster.Extensions

### Community 200 - "Entity (Community 200)"
Cohesion: 0.50
Nodes (4): CredentialsStartupValidator.cs, ValidateOptions(), resolve(), foreach()

### Community 198 - "Entity (Community 198)"
Cohesion: 0.50
Nodes (4): DeepSeekService.cs, while(), DeepSeekService(), GetChatCompletionsEndpoint()

### Community 197 - "Entity (Community 197)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, StringContent(), for(), Polly_Instagram_AttemptTimeout_CancelsSlowRequest()

### Community 194 - "Entity (Community 194)"
Cohesion: 0.50
Nodes (4): HttpResponseBodyLoggingPipelineTests.cs, ResponseBodyLogging_402_LogsSanitizedBodyAtErrorWithHeaders(), ResponseBodyLogging_SuccessLogsBodyReadableByConsumer(), var()

### Community 195 - "Entity (Community 195)"
Cohesion: 0.83
Nodes (4): SenderPluginsServiceCollectionExtensions.cs, SenderPluginsServiceCollectionExtensions.cs, XPoster.Extensions, AddXPosterSenderPlugins()

### Community 196 - "Entity (Community 196)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, NoOrchestrator(), XPoster.Orchestrators

### Community 192 - "Entity (Community 192)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, XPoster.Contracts, GetLabel()

### Community 186 - "Entity (Community 186)"
Cohesion: 0.83
Nodes (4): ITerminalNode.cs, ITerminalNode.cs, ITerminalNode, XPoster.Workflows.Abstractions

### Community 188 - "Entity (Community 188)"
Cohesion: 0.50
Nodes (4): ConfigurationSlotProfileProvider.cs, ConfigurationSlotProfileProvider(), GetProfiles(), XPoster.Providers

### Community 190 - "Entity (Community 190)"
Cohesion: 0.83
Nodes (4): WorkflowDefinition.cs, WorkflowDefinition.cs, XPoster.Workflows.Engine, WorkflowDefinition()

### Community 189 - "Entity (Community 189)"
Cohesion: 0.83
Nodes (4): WorkflowNodeResult.cs, WorkflowNodeResult.cs, XPoster.Workflows.Abstractions, WorkflowNodeResult()

### Community 187 - "Entity (Community 187)"
Cohesion: 0.83
Nodes (4): WorkflowNodeInput.cs, WorkflowNodeInput.cs, XPoster.Workflows.Abstractions, WorkflowNodeInput()

### Community 191 - "Entity (Community 191)"
Cohesion: 0.50
Nodes (4): FalAiOptionsValidator.cs, foreach(), XPoster.Models, Validate()

### Community 202 - "Entity (Community 202)"
Cohesion: 0.50
Nodes (4): WorkflowExecutionEngineTests.cs, var(), new(), StubNode()

### Community 208 - "Entity (Community 208)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, XPoster.Models, ScheduledOrchestrationProfile()

### Community 203 - "Entity (Community 203)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, catch(), GetCryptoValue(), XPoster.Services

### Community 204 - "Entity (Community 204)"
Cohesion: 0.83
Nodes (4): AiProviderOptionsCompositionExtensions.cs, AiProviderOptionsCompositionExtensions.cs, AddAiProviderOptions(), XPoster.Extensions

### Community 205 - "Entity (Community 205)"
Cohesion: 0.50
Nodes (4): FanOutSendNodeTests.cs, if(), var(), SetupSender()

### Community 206 - "Entity (Community 206)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, catch(), if(), return()

### Community 207 - "Entity (Community 207)"
Cohesion: 0.83
Nodes (4): CredentialsExtensions.cs, CredentialsExtensions.cs, AddCredentials(), XPoster.Credentials

### Community 185 - "Entity (Community 185)"
Cohesion: 0.83
Nodes (4): WorkflowExecutionResult.cs, WorkflowExecutionResult.cs, WorkflowExecutionResult(), XPoster.Workflows.Engine

### Community 180 - "Entity (Community 180)"
Cohesion: 0.83
Nodes (4): MediaAttachment.cs, MediaAttachment.cs, XPoster.Workflows.Models, MediaAttachment()

### Community 184 - "Entity (Community 184)"
Cohesion: 0.50
Nodes (4): HttpResponseBodySanitizer.cs, foreach(), SanitizeUrl(), XPoster.Services

### Community 181 - "Entity (Community 181)"
Cohesion: 0.83
Nodes (4): DryRunShortLengthSender.cs, DryRunShortLengthSender.cs, XPoster.SenderPlugins, DryRunShortLengthSender()

### Community 182 - "Entity (Community 182)"
Cohesion: 0.83
Nodes (4): DryRunMaxLengthSender.cs, DryRunMaxLengthSender.cs, XPoster.SenderPlugins, DryRunMaxLengthSender()

### Community 183 - "Entity (Community 183)"
Cohesion: 0.83
Nodes (4): WorkflowNodeDefinition.cs, WorkflowNodeDefinition.cs, WorkflowNodeDefinition(), XPoster.Workflows.Engine

### Community 218 - "Entity (Community 218)"
Cohesion: 1.00
Nodes (3): BlobStorageOptions.cs, XPoster.Models, BlobStorageOptions.cs

### Community 217 - "Entity (Community 217)"
Cohesion: 0.67
Nodes (3): NodeParameterExtractor.cs, if(), InvalidOperationException()

### Community 232 - "Entity (Community 232)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, AzureFoundryOptions.cs, XPoster.Models

### Community 219 - "Entity (Community 219)"
Cohesion: 1.00
Nodes (3): XCredentials.cs, XCredentials.cs, XPoster.Credentials

### Community 231 - "Entity (Community 231)"
Cohesion: 1.00
Nodes (3): LinkedInCredentials.cs, LinkedInCredentials.cs, XPoster.Credentials

### Community 230 - "Entity (Community 230)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, InstagramCredentials.cs, InstagramCredentials.cs

### Community 222 - "Entity (Community 222)"
Cohesion: 0.67
Nodes (3): XCredentialsValidator.cs, XPoster.Credentials, Validate()

### Community 224 - "Entity (Community 224)"
Cohesion: 0.67
Nodes (3): HttpClientExtensions.cs, if(), IsTransientHttpFailure()

### Community 223 - "Entity (Community 223)"
Cohesion: 1.00
Nodes (3): XPoster.Workflows.Models, MediaType.cs, MediaType.cs

### Community 220 - "Entity (Community 220)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, XPoster.Models, FalAiOptions.cs

### Community 221 - "Entity (Community 221)"
Cohesion: 0.67
Nodes (3): ConfigurationSlotProfileProvider.cs, if(), foreach()

### Community 228 - "Entity (Community 228)"
Cohesion: 0.67
Nodes (3): FbSenderResilienceTests.cs, BuildCreds(), BuildFactory()

### Community 229 - "Entity (Community 229)"
Cohesion: 1.00
Nodes (3): FacebookCredentials.cs, XPoster.Credentials, FacebookCredentials.cs

### Community 225 - "Entity (Community 225)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, DeepSeekOptions.cs, XPoster.Models

### Community 227 - "Entity (Community 227)"
Cohesion: 0.67
Nodes (3): FeedService.cs, FeedService(), if()

### Community 226 - "Entity (Community 226)"
Cohesion: 0.67
Nodes (3): HttpResponseBodyLoggingHandler.cs, if(), TryLogAsync()

### Community 233 - "Entity (Community 233)"
Cohesion: 1.00
Nodes (3): OpenAiOptions.cs, XPoster.Models, OpenAiOptions.cs

### Community 246 - "Entity (Community 246)"
Cohesion: 0.67
Nodes (3): InSender.cs, InSender(), if()

### Community 245 - "Entity (Community 245)"
Cohesion: 1.00
Nodes (3): XPoster.Models, TagReplacementOptions.cs, TagReplacementOptions.cs

### Community 247 - "Entity (Community 247)"
Cohesion: 1.00
Nodes (3): ContainerStatus.cs, ContainerStatus.cs, XPoster.Contracts

### Community 242 - "Entity (Community 242)"
Cohesion: 0.67
Nodes (3): FalAiOptionsValidator.cs, nameof(), if()

### Community 243 - "Entity (Community 243)"
Cohesion: 1.00
Nodes (3): SlotScheduleOptions.cs, SlotScheduleOptions.cs, XPoster.Models

### Community 244 - "Entity (Community 244)"
Cohesion: 0.67
Nodes (3): HttpResponseBodySanitizer.cs, Sanitize(), if()

### Community 234 - "Entity (Community 234)"
Cohesion: 1.00
Nodes (3): XPoster.Models, PerplexityOptions.cs, PerplexityOptions.cs

### Community 235 - "Entity (Community 235)"
Cohesion: 1.00
Nodes (3): WorkflowContextKeys.cs, WorkflowContextKeys.cs, XPoster.Workflows.Models

### Community 236 - "Entity (Community 236)"
Cohesion: 1.00
Nodes (3): XPoster.Workflows.Models, PromptStepOptions.cs, PromptStepOptions.cs

### Community 237 - "Entity (Community 237)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, AiProvider.cs, XPoster.Contracts

### Community 238 - "Entity (Community 238)"
Cohesion: 0.67
Nodes (3): BaseOrchestrator.cs, DispatchAsync(), if()

### Community 240 - "Entity (Community 240)"
Cohesion: 1.00
Nodes (3): AiModelClass.cs, XPoster.Contracts, AiModelClass.cs

### Community 241 - "Entity (Community 241)"
Cohesion: 1.00
Nodes (3): SenderPlatform.cs, SenderPlatform.cs, XPoster.Contracts

### Community 239 - "Entity (Community 239)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, CryptoService(), if()

### Community 249 - "Entity (Community 249)"
Cohesion: 1.00
Nodes (2): XApiException.cs, if()

### Community 248 - "Entity (Community 248)"
Cohesion: 1.00
Nodes (2): XCredentialsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._


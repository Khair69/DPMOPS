--Admin Account: ( email:admin@admin.com  password: KKK_6699420_kkk )
--Global Password: "MYz8:.a~68XPSW$"

USE [DPMOPS]
GO
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (N'7a05980f-8f75-4ce7-97d6-0865fc663292', N'دمشق')
GO
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (N'0e2141f6-b00e-4013-8ce8-156044aa4d30', N'الرقة')
GO
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (N'122758ff-79a6-40c7-91d3-1757c3789ad5', N'حلب')
GO
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (N'e4d0466b-cc8b-4320-baed-1e32d46a7c9c', N'الحسكة')
GO
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (N'96962b64-f7eb-4cd6-b2fc-24dd962096aa', N'درعا')
GO
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (N'14df2676-ba78-4f84-bd1d-367d3254e0b1', N'ادلب')
GO
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (N'88fc5aa2-cdff-4848-aff2-4ef64616a4b5', N'السويداء')
GO
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (N'0179c741-6f39-433e-8b2b-60155747ed1d', N'اللاذقية')
GO
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (N'df67e9b1-c48b-40b7-bf47-8f7b87f6c6cd', N'طرطوس')
GO
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (N'736aade7-0f79-4853-85af-aa11eadfe668', N'دير الزور')
GO
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (N'f1fddc1b-a154-45ed-85dd-b1cb3b716d06', N'ريف دمشق')
GO
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (N'c5dfe01b-9b67-4202-90a0-ba319db4321c', N'حماة')
GO
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (N'fba45a28-4476-495c-a772-d1bc2faed3e0', N'حمص')
GO
INSERT [dbo].[Organizations] ([OrganizationId], [Name], [CityId]) VALUES (N'99872214-5f38-4b9d-b2d8-0c7ca3fbb7e4', N'مؤسسة الكهرباء في دمشق', N'7a05980f-8f75-4ce7-97d6-0865fc663292')
GO
INSERT [dbo].[Organizations] ([OrganizationId], [Name], [CityId]) VALUES (N'dab2645f-0749-44db-8222-17cfc373075b', N'البريد في دمشق', N'7a05980f-8f75-4ce7-97d6-0865fc663292')
GO
INSERT [dbo].[Organizations] ([OrganizationId], [Name], [CityId]) VALUES (N'778125e1-6e45-4175-ab34-1e7f429727f0', N'مؤسسة المياه في حماة', N'c5dfe01b-9b67-4202-90a0-ba319db4321c')
GO
INSERT [dbo].[Organizations] ([OrganizationId], [Name], [CityId]) VALUES (N'fdd0b83a-92aa-450b-b4ee-39930545d3e8', N'مؤسسة الكهرباء في حماة', N'c5dfe01b-9b67-4202-90a0-ba319db4321c')
GO
INSERT [dbo].[Organizations] ([OrganizationId], [Name], [CityId]) VALUES (N'e8d3535c-4230-46f0-b424-65f8b8d80dc7', N'بلدية حمص', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Organizations] ([OrganizationId], [Name], [CityId]) VALUES (N'fca7062e-05c3-44d1-b69f-684e5da2fff0', N'مؤسسة المياه في دمشق', N'7a05980f-8f75-4ce7-97d6-0865fc663292')
GO
INSERT [dbo].[Organizations] ([OrganizationId], [Name], [CityId]) VALUES (N'7ca3e4ed-0906-4ec8-a747-77f8a2ed9f5a', N'بلدية حماة', N'c5dfe01b-9b67-4202-90a0-ba319db4321c')
GO
INSERT [dbo].[Organizations] ([OrganizationId], [Name], [CityId]) VALUES (N'364a030b-70bb-4426-9502-8a13433ff83e', N'مؤسسة الكهرباء في حمص', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Organizations] ([OrganizationId], [Name], [CityId]) VALUES (N'8cb6269c-c0ee-48a0-bf4a-92ce2867a939', N'مؤسسة المياه في حمص', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Organizations] ([OrganizationId], [Name], [CityId]) VALUES (N'7f13d8d6-8e09-41a9-9d36-befaaea640ec', N'بلدية دمشق', N'7a05980f-8f75-4ce7-97d6-0865fc663292')
GO
INSERT [dbo].[Organizations] ([OrganizationId], [Name], [CityId]) VALUES (N'2e8d15e1-e1f4-474b-a3b4-c315d3ff9116', N'البريد في حماة', N'c5dfe01b-9b67-4202-90a0-ba319db4321c')
GO
INSERT [dbo].[Organizations] ([OrganizationId], [Name], [CityId]) VALUES (N'32cd6aeb-8e24-4478-8cca-da432409378b', N'البريد في حمص', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'2600c98a-2ceb-4091-a58e-027044e3f4ec', N'القنوات', N'7a05980f-8f75-4ce7-97d6-0865fc663292')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'5c58070a-99d5-4b19-b021-03b67800cee6', N'حارة الطب', N'c5dfe01b-9b67-4202-90a0-ba319db4321c')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'1ed05fd8-22ed-4190-bd87-06131a9dc79d', N'سوق الغنم', N'c5dfe01b-9b67-4202-90a0-ba319db4321c')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'a2222430-35ff-4f89-99a3-071d74f6815d', N'كرم الشامي', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'e542f787-87c0-4e48-8ba7-085caf28e13d', N'الزهراء', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'e4f2e40b-740e-4348-a034-09c76ed5eb9b', N'جوبر', N'7a05980f-8f75-4ce7-97d6-0865fc663292')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'06dd9f4c-1290-4a0d-9ab4-0a15c225059a', N'حي النصر', N'c5dfe01b-9b67-4202-90a0-ba319db4321c')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'aa713215-5617-41a9-85e8-0a65e3a27fdd', N'الكورنيش', N'df67e9b1-c48b-40b7-bf47-8f7b87f6c6cd')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'e67fe9b3-3cff-40ee-8c57-0b0b0d713c8b', N'المحطة', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'a1f95126-204e-4843-88ff-103cff4d2462', N'الاندلس', N'c5dfe01b-9b67-4202-90a0-ba319db4321c')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'026e958c-5cf7-4312-a561-1095d18fc35e', N'مشاع الفروسية', N'c5dfe01b-9b67-4202-90a0-ba319db4321c')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'97ccb95a-5550-4215-88a9-12626831a770', N'الغوطة', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'7fd31cda-c713-4ca3-8f24-157a28e7f048', N'غرناطة', N'c5dfe01b-9b67-4202-90a0-ba319db4321c')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'537f569e-98c6-4631-b506-16501ac89b4f', N'بستان الديوان', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'9cd8e1bc-f4f0-43a2-aae4-17a808bc0c95', N'المهاجرين', N'7a05980f-8f75-4ce7-97d6-0865fc663292')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'd40b4c75-ea40-4478-9c0c-1bc7d14bf349', N'العدوية', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'cff597f2-df63-431c-aadc-1d9897ef4337', N'القرابيص', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'6ebc0352-d7be-4960-b090-208309226ce5', N'الفيحاء', N'c5dfe01b-9b67-4202-90a0-ba319db4321c')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'8cea2b48-4cab-465a-b801-226c6c384936', N'الوعر القديم', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'31e01458-5131-4256-92bd-24ff640f8e50', N'الصناعة', N'c5dfe01b-9b67-4202-90a0-ba319db4321c')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'2b6b0acd-fbdc-4078-8b84-258501953bef', N'الدباغة', N'c5dfe01b-9b67-4202-90a0-ba319db4321c')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'2ba9f3a9-ce2b-4b61-afdd-3120f614f181', N'الشياح', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'b9e8e216-9100-481c-b5a4-3a656f09d169', N'كازو', N'c5dfe01b-9b67-4202-90a0-ba319db4321c')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'ee27f1d8-ce86-451a-a7d5-4195a6eb7d99', N'جب الجندلي', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'9b98108d-7b3d-4280-bdc3-42c73ed9d988', N'ركن الدين', N'7a05980f-8f75-4ce7-97d6-0865fc663292')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'560712f3-02fb-4d43-8e8e-42f53b90e0f9', N'باب تدمر', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'6017442e-6c8c-430b-b54f-45c35a9d423d', N'الفراية', N'c5dfe01b-9b67-4202-90a0-ba319db4321c')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'47d512d6-3840-489d-bef0-45cee7a12233', N'برزة', N'7a05980f-8f75-4ce7-97d6-0865fc663292')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'84a7ac38-9d40-43ef-abe5-49038f98454f', N'الخالدية', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'78856c02-accd-4ea4-940a-49178dcf8969', N'عشيرة', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'f165cd24-0dce-4ea9-a26e-4cf38d3ebb00', N'عكرمة القديمة', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'6dee1ec4-cf0a-4520-ba54-4e0ade477693', N'حي البعث', N'c5dfe01b-9b67-4202-90a0-ba319db4321c')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'd9184937-adc9-405d-b0b4-4f7109f0188b', N'باب التركمان', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'7af79e60-ae35-4719-83f4-512be558a0a2', N'تشرين', N'c5dfe01b-9b67-4202-90a0-ba319db4321c')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'30271aa1-2f8f-40ac-a6d4-512c957b42ea', N'الغوطة', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'f3612830-958f-4df9-a9e6-5323e103b6be', N'البياضة', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'9433e240-a8ce-4f4e-b4b7-577a76f9475f', N'جنوب الملعب', N'c5dfe01b-9b67-4202-90a0-ba319db4321c')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'f6c30fd4-9da9-4578-99e8-5b44ae0322ab', N'المزة', N'7a05980f-8f75-4ce7-97d6-0865fc663292')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'78c8f92b-7249-4fbb-8072-5f5d19972d7e', N'الشاغور', N'7a05980f-8f75-4ce7-97d6-0865fc663292')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'0300ad81-be1f-4aa0-a0dd-6583fe357d43', N'الدبلان', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'30b4617f-9896-4756-829e-674f7ccaab26', N'دمر', N'7a05980f-8f75-4ce7-97d6-0865fc663292')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'20d991b8-6c8c-42d1-b825-6be96b245409', N'المحطة', N'c5dfe01b-9b67-4202-90a0-ba319db4321c')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'6dcdcf4d-e568-4a23-9658-6c13150294d8', N'القابون', N'7a05980f-8f75-4ce7-97d6-0865fc663292')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'b18afbcd-8a3b-4464-b641-6c8cbbd93a69', N'الحمراء', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'0522320d-a9c1-4b65-80cb-6ceb4363537f', N'القصور', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'5a144d73-2356-4fa3-a683-6d1b2ac52940', N'وادي الذهب', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'4f693807-85ea-47aa-81cf-72c89dbf48c7', N'اليرموك', N'7a05980f-8f75-4ce7-97d6-0865fc663292')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'aed9358f-9559-4e85-a6e0-791703ca0ab6', N'المخيم', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'b67dcdd5-533c-43d4-a73f-79c778cab1a2', N'باب توما', N'7a05980f-8f75-4ce7-97d6-0865fc663292')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'84607521-1024-4f43-bc81-80416bb33883', N'الشماس', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'2d6a9283-61df-4be8-9c5c-81b72dc57d84', N'البارودية', N'c5dfe01b-9b67-4202-90a0-ba319db4321c')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'b8d3266c-56ba-4b6b-af73-866d2be39bcc', N'بني السباعي', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'c150191e-5523-4f93-82e3-86ed9b27019b', N'الورشة', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'ac8d0101-ca9a-49e9-b5a7-87ecce3cf68b', N'القدم', N'7a05980f-8f75-4ce7-97d6-0865fc663292')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'0c04a044-37da-4413-8dc9-898be62a20bb', N'باب هود', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'b3b37377-d4f1-4371-98d4-8b068798f3c3', N'الجراجمة', N'c5dfe01b-9b67-4202-90a0-ba319db4321c')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'84c640f3-1eb2-4546-b5d3-90acac17a9da', N'عكرمة الجديدة', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'be90f9e9-97f9-4483-af2a-9128a50a2b21', N'الجامعة', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'24e184b4-02b2-4e6e-afc8-913f6253d137', N'باب السباع', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'37228587-2f89-440a-9921-95887e73c9da', N'باب الدريب', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'be994ff6-a738-4f0e-89d0-95e72c5b966e', N'الخضر', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'e24630d4-326d-4298-9fbc-96099e28cadd', N'النزهة', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'b5f1833b-e398-4c13-8480-9dffcc2927cd', N'دير بعلبة', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'2ef8c12d-64d5-4ab7-bc3f-9e6bc13c4c98', N'المخيم', N'c5dfe01b-9b67-4202-90a0-ba319db4321c')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'166e8519-3ae6-481a-903a-a316110460ae', N'التوزيع الإجباري', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'2f9ae2d6-0942-41dc-901b-b1ce58d8395f', N'سوق الحشيش', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'5cd6eeab-3d56-4818-99d2-b42c7b335ce9', N'الحمرا', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'f5363336-0798-4f20-9e94-b4a3db23bb99', N'ساروجة', N'7a05980f-8f75-4ce7-97d6-0865fc663292')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'fcd31625-9b32-4cd3-8d9b-b5bc7f4aed69', N'كفر سوسة', N'7a05980f-8f75-4ce7-97d6-0865fc663292')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'5f0514c3-31ab-4c74-b0a2-b65812438cfb', N'الإنشاءات', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'e8f02a1a-d07b-4418-8901-b86ccc1ced96', N'العليليات', N'c5dfe01b-9b67-4202-90a0-ba319db4321c')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'29e0b04c-793c-47db-a198-ba2736bde1d3', N'الحميدية', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'b792a492-fcfe-4568-840b-bc0e34cceae6', N'عين اللوزة', N'c5dfe01b-9b67-4202-90a0-ba319db4321c')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'5ede4170-d9cc-4801-8ac4-bc4efc47f521', N'الملعب', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'0df1c5d0-8207-43b6-a545-bc96849907c4', N'الصالحية', N'7a05980f-8f75-4ce7-97d6-0865fc663292')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'22106f05-3fce-457d-975a-c96225fba2ab', N'طريق حلب', N'c5dfe01b-9b67-4202-90a0-ba319db4321c')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'a52d1d16-b572-420a-9b9d-ce864a48737f', N'الاربعين', N'c5dfe01b-9b67-4202-90a0-ba319db4321c')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'9c46067c-2aac-4896-9cea-cef4e8717e39', N'غرب المشتل', N'c5dfe01b-9b67-4202-90a0-ba319db4321c')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'3193e747-ef2d-4ac6-83c5-cf4b33b484cf', N'كرم الزيتون', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'794b069f-5669-463d-9892-d96affdfdf49', N'الشريعة', N'c5dfe01b-9b67-4202-90a0-ba319db4321c')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'd90c4bb9-ad80-4f35-a016-df8733994c2d', N'أبي الفداء', N'c5dfe01b-9b67-4202-90a0-ba319db4321c')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'32de7a47-bbd1-4faa-b972-e480ae642979', N'الوعر الجديد', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'571977a0-745f-4061-9dae-e66aed2fdd75', N'الوادي', N'c5dfe01b-9b67-4202-90a0-ba319db4321c')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'd3f9653a-6108-471d-a09d-e8b962427b18', N'الميدان', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'03a38048-455a-4975-9436-e8f8f0504b82', N'الصابونية', N'c5dfe01b-9b67-4202-90a0-ba319db4321c')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'398755ca-7e47-4bac-893e-e984d3f0fa04', N'الميدان', N'7a05980f-8f75-4ce7-97d6-0865fc663292')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'e658df08-fac3-4d87-a86d-f43f0346205e', N'كرم اللوز', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'e03aca42-5324-4aa1-9ddd-f6d8914a525f', N'بابا عمرو', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'01739023-8697-4c83-9e3c-f73b31dfaf85', N'جوبر', N'fba45a28-4476-495c-a772-d1bc2faed3e0')
GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [CityId]) VALUES (N'03080d97-53ed-4c2d-a7d1-fc4d8e8215c4', N'باب قبلي', N'c5dfe01b-9b67-4202-90a0-ba319db4321c')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DateCreated], [FirstName], [LastName], [DistrictId], [OrganizationId]) VALUES (N'009323cc-b1d0-4e0f-9d93-f36c55df9b8d', N'safaaHashimi@gmail.com', N'SAFAAHASHIMI@GMAIL.COM', N'safaaHashimi@gmail.com', N'SAFAAHASHIMI@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEDIhxFRZ3HoL2c3UFIWJb4f3iOgLfTFva52nN6nXm3dZo/KDUUBi/XZiO7Trl9CS4w==', N'IIAOM45CUGW5C2WMPW3UST67ZHBFVBU4', N'5a2d5def-c2d2-46ac-8fa7-23e22fde7f22', N'0912345678', 0, 0, NULL, 1, 0, CAST(N'2025-06-07T09:53:53.2159351' AS DateTime2), N'صفاء', N'الهاشمي', N'2ef8c12d-64d5-4ab7-bc3f-9e6bc13c4c98', N'7ca3e4ed-0906-4ec8-a747-77f8a2ed9f5a')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DateCreated], [FirstName], [LastName], [DistrictId], [OrganizationId]) VALUES (N'0e616a58-163f-4eb3-9efa-35df398c4d43', N'bushraOmari@gmail.com', N'BUSHRAOMARI@GMAIL.COM', N'bushraOmari@gmail.com', N'BUSHRAOMARI@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEAzoTQE19Mie9KwJdEkwN7V0pvhJ5DTkFUA7R7MKqYqf9JL/MYuBXSfhB+1watMHPA==', N'C6TYTBFSETF3GPM5FRSIEEQPAKWZKELP', N'7eb29058-2e1e-460a-8c94-2c7a0fda2a43', N'0923456789', 0, 0, NULL, 1, 0, CAST(N'2025-06-07T10:00:56.8037595' AS DateTime2), N'بشرى', N'العمري', N'560712f3-02fb-4d43-8e8e-42f53b90e0f9', N'e8d3535c-4230-46f0-b424-65f8b8d80dc7')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DateCreated], [FirstName], [LastName], [DistrictId], [OrganizationId]) VALUES (N'1773b7bb-c874-4708-b0cc-0ea0e0932b3c', N'amalRawee@gmail.com', N'AMALRAWEE@GMAIL.COM', N'amalRawee@gmail.com', N'AMALRAWEE@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEAzoTQE19Mie9KwJdEkwN7V0pvhJ5DTkFUA7R7MKqYqf9JL/MYuBXSfhB+1watMHPA==', N'7DB67GFIXA6W5UMTU2YKD5BCJPNBTKL6', N'f1f015ef-8d8d-4d9c-bc9c-1bfc74d783bc', N'0934567890', 0, 0, NULL, 1, 0, CAST(N'2025-06-07T10:06:37.7295612' AS DateTime2), N'أمل', N'الراوي', N'b67dcdd5-533c-43d4-a73f-79c778cab1a2', N'7f13d8d6-8e09-41a9-9d36-befaaea640ec')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DateCreated], [FirstName], [LastName], [DistrictId], [OrganizationId]) VALUES (N'183c311d-3152-441a-8f7b-22d7a2918882', N'ayaabdulkareem@gmail.com', N'AYAABDULKAREEM@GMAIL.COM', N'ayaabdulkareem@gmail.com', N'AYAABDULKAREEM@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEAzoTQE19Mie9KwJdEkwN7V0pvhJ5DTkFUA7R7MKqYqf9JL/MYuBXSfhB+1watMHPA==', N'TGADPEYMJQO5PRNAGIOVASZC76G3AGNY', N'2a4a28a3-68de-4b9f-9d47-31dcb5905085', N'0945678901', 0, 0, NULL, 1, 0, CAST(N'2025-06-07T10:09:09.9904956' AS DateTime2), N'آية', N'عبد الكريم', N'ac8d0101-ca9a-49e9-b5a7-87ecce3cf68b', N'7f13d8d6-8e09-41a9-9d36-befaaea640ec')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DateCreated], [FirstName], [LastName], [DistrictId], [OrganizationId]) VALUES (N'1841c929-375a-456e-a5c8-2fa3b5ec84aa', N'aymanAwees@outlook.com', N'AYMANAWEES@OUTLOOK.COM', N'aymanAwees@outlook.com', N'AYMANAWEES@OUTLOOK.COM', 1, N'AQAAAAIAAYagAAAAEAzoTQE19Mie9KwJdEkwN7V0pvhJ5DTkFUA7R7MKqYqf9JL/MYuBXSfhB+1watMHPA==', N'G2HFYZF3F4WRKIIPIUCEQIM74CQ7BPPM', N'a7cedff6-6fd3-442d-8be2-ec5c5bb95b2d', N'0956789012', 0, 0, NULL, 1, 0, CAST(N'2025-06-07T09:57:39.8960137' AS DateTime2), N'أيمن', N'العويس', N'32de7a47-bbd1-4faa-b972-e480ae642979', N'e8d3535c-4230-46f0-b424-65f8b8d80dc7')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DateCreated], [FirstName], [LastName], [DistrictId], [OrganizationId]) VALUES (N'1b564b5e-27c8-44b0-af03-d1766e740851', N'samyShahbani@gmail.com', N'SAMYSHAHBANI@GMAIL.COM', N'samyShahbani@gmail.com', N'SAMYSHAHBANI@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEAzoTQE19Mie9KwJdEkwN7V0pvhJ5DTkFUA7R7MKqYqf9JL/MYuBXSfhB+1watMHPA==', N'AVGAXGYI3WEKH5HS6QMFWLV3XCEFB5TM', N'206812b1-b389-4749-a1ff-59f3d96aaf73', N'0967890123', 0, 0, NULL, 1, 0, CAST(N'2025-06-07T10:00:05.6904180' AS DateTime2), N'سامي', N'الشهابي', N'e03aca42-5324-4aa1-9ddd-f6d8914a525f', N'e8d3535c-4230-46f0-b424-65f8b8d80dc7')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DateCreated], [FirstName], [LastName], [DistrictId], [OrganizationId]) VALUES (N'259b2149-d3db-46cd-9f9b-758106768987', N'ahmadali@hotmail.com', N'AHMADALI@HOTMAIL.COM', N'ahmadali@hotmail.com', N'AHMADALI@HOTMAIL.COM', 1, N'AQAAAAIAAYagAAAAEAzoTQE19Mie9KwJdEkwN7V0pvhJ5DTkFUA7R7MKqYqf9JL/MYuBXSfhB+1watMHPA==', N'UKEZLRY4HYDDFNG6DXIHNUWIQ3FLHH3B', N'a0ac94f1-c2b6-43e0-8912-76a08f4273ab', N'0978901234', 0, 0, NULL, 1, 0, CAST(N'2025-06-07T09:38:05.7469849' AS DateTime2), N'أحمد', N'العلي', N'd3f9653a-6108-471d-a09d-e8b962427b18', N'364a030b-70bb-4426-9502-8a13433ff83e')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DateCreated], [FirstName], [LastName], [DistrictId], [OrganizationId]) VALUES (N'2905888d-0fcf-4b88-8afe-ea85357590ed', N'do3aaKaisa@gmail.com', N'DO3AAKAISA@GMAIL.COM', N'do3aaKaisa@gmail.com', N'DO3AAKAISA@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEAzoTQE19Mie9KwJdEkwN7V0pvhJ5DTkFUA7R7MKqYqf9JL/MYuBXSfhB+1watMHPA==', N'D3IX2NFA4TLBI7BIWEYBC2ZAUOUJZVMK', N'b5bf698e-cc05-4f8f-8cd2-ae56bd60b3ec', N'0989012345', 0, 0, NULL, 1, 0, CAST(N'2025-06-07T10:02:12.5687010' AS DateTime2), N'دعاء', N'القيسي', N'5ede4170-d9cc-4801-8ac4-bc4efc47f521', N'364a030b-70bb-4426-9502-8a13433ff83e')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DateCreated], [FirstName], [LastName], [DistrictId], [OrganizationId]) VALUES (N'291cb8d0-db7c-459b-809a-5702b4700a08', N'halaFayez@gmail.com', N'HALAFAYEZ@GMAIL.COM', N'halaFayez@gmail.com', N'HALAFAYEZ@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEAzoTQE19Mie9KwJdEkwN7V0pvhJ5DTkFUA7R7MKqYqf9JL/MYuBXSfhB+1watMHPA==', N'FC4EY6BLUUHZAD63BT33YV7PZUWMZYRU', N'2051a090-7238-45fa-bb8b-6c5756bc8fcd', N'0990123456', 0, 0, NULL, 1, 0, CAST(N'2025-06-07T09:50:55.8309876' AS DateTime2), N'هالة', N'الفايز', N'03080d97-53ed-4c2d-a7d1-fc4d8e8215c4', N'7ca3e4ed-0906-4ec8-a747-77f8a2ed9f5a')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DateCreated], [FirstName], [LastName], [DistrictId], [OrganizationId]) VALUES (N'2f512516-eadb-46cb-8a01-4dbbeae904fc', N'admin@admin.com', N'ADMIN@ADMIN.COM', N'admin@admin.com', N'ADMIN@ADMIN.COM', 1, N'AQAAAAIAAYagAAAAEAEem3iKImJ0ETyJvUQvnC2NEX2FvcFEgu5rHCrbZyYA8czPd7FHyk4q3Aj0gbxllQ==', N'A6LXB7FNUR64UCECFXA2BC7NGVNRLAKV', N'b8508a72-ca9e-4c9b-b4c1-1b5d87b0e3d8', N'0901234567', 0, 0, NULL, 1, 0, CAST(N'2025-06-07T10:13:24.2443447' AS DateTime2), N'kkk', N'admin', N'794b069f-5669-463d-9892-d96affdfdf49', NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DateCreated], [FirstName], [LastName], [DistrictId], [OrganizationId]) VALUES (N'31fc208f-03ec-40da-a8c1-832f324f4d91', N'hayaEisa@gmail.com', N'HAYAEISA@GMAIL.COM', N'hayaEisa@gmail.com', N'HAYAEISA@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEAzoTQE19Mie9KwJdEkwN7V0pvhJ5DTkFUA7R7MKqYqf9JL/MYuBXSfhB+1watMHPA==', N'SZPJ3XKRKIULHQ5MJVRYHLNUEEHDKME6', N'0417aa0c-1344-4fba-b707-a4611332fc25', N'0911122233', 0, 0, NULL, 1, 0, CAST(N'2025-06-07T12:36:07.5230566' AS DateTime2), N'هيا', N'عيسى', N'b3b37377-d4f1-4371-98d4-8b068798f3c3', NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DateCreated], [FirstName], [LastName], [DistrictId], [OrganizationId]) VALUES (N'325ae99f-e9d2-4182-9f8c-d5451019e779', N'LinaDarwish@gmail.com', N'LINADARWISH@GMAIL.COM', N'LinaDarwish@gmail.com', N'LINADARWISH@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEAzoTQE19Mie9KwJdEkwN7V0pvhJ5DTkFUA7R7MKqYqf9JL/MYuBXSfhB+1watMHPA==', N'LLVSXEYC2RTQEBD6O2CKJM3NA3GEKID3', N'11d07763-0c98-4a1b-bcf0-29b5abc1de00', N'0922233344', 0, 0, NULL, 1, 0, CAST(N'2025-06-07T12:34:37.8044262' AS DateTime2), N'لينا', N'درويش', N'398755ca-7e47-4bac-893e-e984d3f0fa04', NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DateCreated], [FirstName], [LastName], [DistrictId], [OrganizationId]) VALUES (N'3aeb36e2-b03b-4d9a-becd-99e6b5a10ed0', N'fahedAteebe@yahoo.com', N'FAHEDATEEBE@YAHOO.COM', N'fahedAteebe@yahoo.com', N'FAHEDATEEBE@YAHOO.COM', 1, N'AQAAAAIAAYagAAAAEAzoTQE19Mie9KwJdEkwN7V0pvhJ5DTkFUA7R7MKqYqf9JL/MYuBXSfhB+1watMHPA==', N'2PLMU76FABPVHIT32PKPNBZXVXV6GBLF', N'128a2a6c-f58b-447e-a4f9-ce918f087083', N'0933344455', 0, 0, NULL, 1, 0, CAST(N'2025-06-07T09:48:37.2631764' AS DateTime2), N'فهد', N'العتيبي', N'6dee1ec4-cf0a-4520-ba54-4e0ade477693', N'7ca3e4ed-0906-4ec8-a747-77f8a2ed9f5a')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DateCreated], [FirstName], [LastName], [DistrictId], [OrganizationId]) VALUES (N'467914c6-6737-4a5d-b935-525356e11d0c', N'nbeelFadel@hotmail.com', N'NBEELFADEL@HOTMAIL.COM', N'nbeelFadel@hotmail.com', N'NBEELFADEL@HOTMAIL.COM', 1, N'AQAAAAIAAYagAAAAEAzoTQE19Mie9KwJdEkwN7V0pvhJ5DTkFUA7R7MKqYqf9JL/MYuBXSfhB+1watMHPA==', N'CWV3RSBUDS3GS5J432CZVSXNRQIBAAQG', N'd4516c96-389e-437f-b2e3-243dbc9611a2', N'0944455566', 0, 0, NULL, 1, 0, CAST(N'2025-06-07T10:05:59.8114299' AS DateTime2), N'نبيل', N'الفاضل', N'f6c30fd4-9da9-4578-99e8-5b44ae0322ab', N'7f13d8d6-8e09-41a9-9d36-befaaea640ec')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DateCreated], [FirstName], [LastName], [DistrictId], [OrganizationId]) VALUES (N'4e0a189a-ec03-4424-b4b8-823f1967dbe6', N'janaFaheed@gmail.com', N'JANAFAHEED@GMAIL.COM', N'janaFaheed@gmail.com', N'JANAFAHEED@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEAzoTQE19Mie9KwJdEkwN7V0pvhJ5DTkFUA7R7MKqYqf9JL/MYuBXSfhB+1watMHPA==', N'JLSRESRE4Y6DPGS7XYYG5VWS6HSGQUAC', N'9096c0c1-dac1-4687-8d6b-522fb865fe51', N'0955566677', 0, 0, NULL, 1, 0, CAST(N'2025-06-07T10:07:55.7220527' AS DateTime2), N'جنى', N'الفهيد', N'9cd8e1bc-f4f0-43a2-aae4-17a808bc0c95', N'99872214-5f38-4b9d-b2d8-0c7ca3fbb7e4')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DateCreated], [FirstName], [LastName], [DistrictId], [OrganizationId]) VALUES (N'5060c2fa-4bff-475d-afe9-fd92c6c7bda0', N'abdulSalem@gmail.com', N'ABDULSALEM@GMAIL.COM', N'abdulSalem@gmail.com', N'ABDULSALEM@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEAzoTQE19Mie9KwJdEkwN7V0pvhJ5DTkFUA7R7MKqYqf9JL/MYuBXSfhB+1watMHPA==', N'6DAKQ7RQ6AYTTL3QHTSPPXDH5HMQMQUI', N'0c371867-cdf9-49e1-a349-20d5f62c3d21', N'0966677788', 0, 0, NULL, 1, 0, CAST(N'2025-06-07T10:07:21.3504651' AS DateTime2), N'عبد الله', N'السالم', N'0df1c5d0-8207-43b6-a545-bc96849907c4', N'99872214-5f38-4b9d-b2d8-0c7ca3fbb7e4')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DateCreated], [FirstName], [LastName], [DistrictId], [OrganizationId]) VALUES (N'52308437-3e5b-43be-9ee4-fb35e64b02f9', N'RyanMasri@gmail.com', N'RYANMASRI@GMAIL.COM', N'RyanMasri@gmail.com', N'RYANMASRI@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEAzoTQE19Mie9KwJdEkwN7V0pvhJ5DTkFUA7R7MKqYqf9JL/MYuBXSfhB+1watMHPA==', N'ZRSNYP4K5DW3KA4KZDY536QGEH6NLGQN', N'd0c4031c-a5d6-4939-9083-305aac7830b8', N'0977788899', 0, 0, NULL, 1, 0, CAST(N'2025-06-07T12:38:01.2321194' AS DateTime2), N'ريان', N'المصري', N'be994ff6-a738-4f0e-89d0-95e72c5b966e', NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DateCreated], [FirstName], [LastName], [DistrictId], [OrganizationId]) VALUES (N'5a31a898-3e62-4af9-8f1f-01c03e131112', N'MazenAbdul@outlook.com', N'MAZENABDUL@OUTLOOK.COM', N'MazenAbdul@outlook.com', N'MAZENABDUL@OUTLOOK.COM', 1, N'AQAAAAIAAYagAAAAEAzoTQE19Mie9KwJdEkwN7V0pvhJ5DTkFUA7R7MKqYqf9JL/MYuBXSfhB+1watMHPA==', N'YNAL6653VSWCGMT6Y5KR6WNCAAKOAGHJ', N'2c7d288a-2894-48e8-b42b-6b095bff25eb', N'0988899900', 0, 0, NULL, 1, 0, CAST(N'2025-06-07T09:50:21.8117555' AS DateTime2), N'مازن', N'العبدالله', N'9433e240-a8ce-4f4e-b4b7-577a76f9475f', N'fdd0b83a-92aa-450b-b4ee-39930545d3e8')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DateCreated], [FirstName], [LastName], [DistrictId], [OrganizationId]) VALUES (N'67ba101f-557e-46db-8b2e-002462ee1c80', N'yousefAlhasan@gmail.com', N'YOUSEFALHASAN@GMAIL.COM', N'yousefAlhasan@gmail.com', N'YOUSEFALHASAN@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEAzoTQE19Mie9KwJdEkwN7V0pvhJ5DTkFUA7R7MKqYqf9JL/MYuBXSfhB+1watMHPA==', N'MMSQIJW26LOR2FIS55RCCBY76IMUU3M2', N'd4f89296-4207-4d1b-9d27-50f343c9580a', N'0999900011', 0, 0, NULL, 1, 0, CAST(N'2025-06-07T09:40:24.2377967' AS DateTime2), N'يوسف', N'الحسن', N'03a38048-455a-4975-9436-e8f8f0504b82', N'fdd0b83a-92aa-450b-b4ee-39930545d3e8')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DateCreated], [FirstName], [LastName], [DistrictId], [OrganizationId]) VALUES (N'6b7957dd-41b1-40c5-a841-aad5e9170b28', N'JamilaBaghdady@hotmail.com', N'JAMILABAGHDADY@HOTMAIL.COM', N'JamilaBaghdady@hotmail.com', N'JAMILABAGHDADY@HOTMAIL.COM', 1, N'AQAAAAIAAYagAAAAEAzoTQE19Mie9KwJdEkwN7V0pvhJ5DTkFUA7R7MKqYqf9JL/MYuBXSfhB+1watMHPA==', N'5QAFP7WFECI2UJBI2WYZIWY2RO6F5BTG', N'51b1aaa6-c261-456a-945c-9063c14ea6fa', N'0900011223', 0, 0, NULL, 1, 0, CAST(N'2025-06-07T09:52:25.4225963' AS DateTime2), N'جميلة', N'البغدادي', N'06dd9f4c-1290-4a0d-9ab4-0a15c225059a', N'fdd0b83a-92aa-450b-b4ee-39930545d3e8')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DateCreated], [FirstName], [LastName], [DistrictId], [OrganizationId]) VALUES (N'6cd00492-102f-4b13-af27-4c84ebd7ce15', N'hudakabi@gmail.com', N'HUDAKABI@GMAIL.COM', N'hudakabi@gmail.com', N'HUDAKABI@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEAzoTQE19Mie9KwJdEkwN7V0pvhJ5DTkFUA7R7MKqYqf9JL/MYuBXSfhB+1watMHPA==', N'L2LYILYZRGDDGW2BWPUBS62LUKELL34C', N'0849be06-38a1-49fc-a11d-ef35b6023252', N'0912233445', 0, 0, NULL, 1, 0, CAST(N'2025-06-07T09:47:29.3888571' AS DateTime2), N'هدى', N'الكعبي', N'22106f05-3fce-457d-975a-c96225fba2ab', N'778125e1-6e45-4175-ab34-1e7f429727f0')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DateCreated], [FirstName], [LastName], [DistrictId], [OrganizationId]) VALUES (N'7341ef0e-deb1-4333-81e0-40e41626db87', N'omarNajar@outlook.com', N'OMARNAJAR@OUTLOOK.COM', N'omarNajar@outlook.com', N'OMARNAJAR@OUTLOOK.COM', 1, N'AQAAAAIAAYagAAAAEAzoTQE19Mie9KwJdEkwN7V0pvhJ5DTkFUA7R7MKqYqf9JL/MYuBXSfhB+1watMHPA==', N'BMOOIVMZECLJTST2AXDWR5QPV7V33Q5E', N'aad10e40-af4b-4668-b6fe-8a99393c089b', N'0923344556', 0, 0, NULL, 1, 0, CAST(N'2025-06-07T09:42:45.4859309' AS DateTime2), N'عمر', N'النجار', N'20d991b8-6c8c-42d1-b825-6be96b245409', N'778125e1-6e45-4175-ab34-1e7f429727f0')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DateCreated], [FirstName], [LastName], [DistrictId], [OrganizationId]) VALUES (N'894ce12b-01e6-4c31-a54d-e3b85d2b4583', N'raedJabouri@hotmail.com', N'RAEDJABOURI@HOTMAIL.COM', N'raedJabouri@hotmail.com', N'RAEDJABOURI@HOTMAIL.COM', 1, N'AQAAAAIAAYagAAAAEAzoTQE19Mie9KwJdEkwN7V0pvhJ5DTkFUA7R7MKqYqf9JL/MYuBXSfhB+1watMHPA==', N'JJ5ISOH46OPLHY4UXICZRDYUPL2KRYZ7', N'c8b3306b-74b0-40bb-914e-5b95e9c97a74', N'0945879584', 0, 0, NULL, 1, 0, CAST(N'2025-06-07T09:51:32.9235914' AS DateTime2), N'رائد', N'الجبوري', N'571977a0-745f-4061-9dae-e66aed2fdd75', N'778125e1-6e45-4175-ab34-1e7f429727f0')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DateCreated], [FirstName], [LastName], [DistrictId], [OrganizationId]) VALUES (N'8bb5c60f-1ea9-40e1-893f-5267d6f24c60', N'mariamSaady@gmail.com', N'MARIAMSAADY@GMAIL.COM', N'mariamSaady@gmail.com', N'MARIAMSAADY@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEAzoTQE19Mie9KwJdEkwN7V0pvhJ5DTkFUA7R7MKqYqf9JL/MYuBXSfhB+1watMHPA==', N'V6TNVQZYAVADVT3LW4OTYGMJOFHAPWT3', N'7dc9716b-da58-4984-a6ec-9e8b1d922c17', N'0934455667', 0, 0, NULL, 1, 0, CAST(N'2025-06-07T09:49:34.4647536' AS DateTime2), N'مريم', N'السعدي', N'b792a492-fcfe-4568-840b-bc0e34cceae6', N'2e8d15e1-e1f4-474b-a3b4-c315d3ff9116')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DateCreated], [FirstName], [LastName], [DistrictId], [OrganizationId]) VALUES (N'9f2546f1-5e05-4d29-a6f3-e4d450d7bef6', N'nourTamimi@hotmail.com', N'NOURTAMIMI@HOTMAIL.COM', N'nourTamimi@hotmail.com', N'NOURTAMIMI@HOTMAIL.COM', 1, N'AQAAAAIAAYagAAAAEAzoTQE19Mie9KwJdEkwN7V0pvhJ5DTkFUA7R7MKqYqf9JL/MYuBXSfhB+1watMHPA==', N'ZR4DEJSW2D63T22UEDG36X44LDCE643S', N'a78d1d8d-6c8e-448b-a69c-8788463a7e21', N'0945566778', 0, 0, NULL, 1, 0, CAST(N'2025-06-07T09:45:20.9806673' AS DateTime2), N'نور', N'التميمي', N'fcd31625-9b32-4cd3-8d9b-b5bc7f4aed69', N'99872214-5f38-4b9d-b2d8-0c7ca3fbb7e4')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DateCreated], [FirstName], [LastName], [DistrictId], [OrganizationId]) VALUES (N'a1cd1108-43fb-47f5-98f2-2e0a959a5223', N'shimaaKrde@gmail.com', N'SHIMAAKRDE@GMAIL.COM', N'shimaaKrde@gmail.com', N'SHIMAAKRDE@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEAzoTQE19Mie9KwJdEkwN7V0pvhJ5DTkFUA7R7MKqYqf9JL/MYuBXSfhB+1watMHPA==', N'KMH4ROBINQQTXJXBTYZO26N7S4YYRVZK', N'9d8038f8-077a-4808-8961-bda467abd9bb', N'0956677889', 0, 0, NULL, 1, 0, CAST(N'2025-06-07T09:57:04.1596711' AS DateTime2), N'شيماء', N'الكردي', N'0522320d-a9c1-4b65-80cb-6ceb4363537f', N'364a030b-70bb-4426-9502-8a13433ff83e')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DateCreated], [FirstName], [LastName], [DistrictId], [OrganizationId]) VALUES (N'a48b2b60-3564-482c-98ac-dc2b19b56a61', N'YasmeenAwadi@gmail.com', N'YASMEENAWADI@GMAIL.COM', N'YasmeenAwadi@gmail.com', N'YASMEENAWADI@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEAzoTQE19Mie9KwJdEkwN7V0pvhJ5DTkFUA7R7MKqYqf9JL/MYuBXSfhB+1watMHPA==', N'KVO2VFEKIRK3RGF22BNCFVLQFFXAISRU', N'87a5ff3a-ab40-4102-82f4-c48e347ddbd1', N'0967788990', 0, 0, NULL, 1, 0, CAST(N'2025-06-07T10:03:31.6201351' AS DateTime2), N'ياسمين', N'العوضي', N'0522320d-a9c1-4b65-80cb-6ceb4363537f', N'8cb6269c-c0ee-48a0-bf4a-92ce2867a939')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DateCreated], [FirstName], [LastName], [DistrictId], [OrganizationId]) VALUES (N'abbe8f78-26a0-484e-bbc2-118a7809cecc', N'ziadShamy@gmail.com', N'ZIADSHAMY@GMAIL.COM', N'ziadShamy@gmail.com', N'ZIADSHAMY@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEAzoTQE19Mie9KwJdEkwN7V0pvhJ5DTkFUA7R7MKqYqf9JL/MYuBXSfhB+1watMHPA==', N'7XYPIQY6GM4GWTOQ4PYFSWMQA33L3UBK', N'e91dab46-31a5-4d4b-ad0b-1fec389e7c29', N'0978899001', 0, 0, NULL, 1, 0, CAST(N'2025-06-07T10:04:44.2047088' AS DateTime2), N'كرم', N'الشامي', N'4f693807-85ea-47aa-81cf-72c89dbf48c7', N'fca7062e-05c3-44d1-b69f-684e5da2fff0')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DateCreated], [FirstName], [LastName], [DistrictId], [OrganizationId]) VALUES (N'ad428a99-bc1a-4c9e-91ef-712aab608987', N'hannanGhamdi@gmail.com', N'HANNANGHAMDI@GMAIL.COM', N'hannanGhamdi@gmail.com', N'HANNANGHAMDI@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEAzoTQE19Mie9KwJdEkwN7V0pvhJ5DTkFUA7R7MKqYqf9JL/MYuBXSfhB+1watMHPA==', N'YT34QLW2ZLN5YCOLENOZZMXAIJFALFJC', N'4ea82dfb-475a-48e9-8f60-35d4a4723fb5', N'0989900112', 0, 0, NULL, 1, 0, CAST(N'2025-06-07T10:05:21.2235997' AS DateTime2), N'حنان', N'الغامدي', N'9b98108d-7b3d-4280-bdc3-42c73ed9d988', N'fca7062e-05c3-44d1-b69f-684e5da2fff0')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DateCreated], [FirstName], [LastName], [DistrictId], [OrganizationId]) VALUES (N'c21d68e2-9d7f-496e-8454-0a11c3b16fa0', N'zainKhatab@gmail.com', N'ZAINKHATAB@GMAIL.COM', N'zainKhatab@gmail.com', N'ZAINKHATAB@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEAzoTQE19Mie9KwJdEkwN7V0pvhJ5DTkFUA7R7MKqYqf9JL/MYuBXSfhB+1watMHPA==', N'ATB5ESW3UJ7OGNEQNJLNECZSTDFXQ2SL', N'82951cb8-8fb0-4e0e-8870-3238ef61e61a', N'0990011223', 0, 0, NULL, 1, 0, CAST(N'2025-06-07T12:36:51.9544863' AS DateTime2), N'زين الدين', N'خطاب', N'e8f02a1a-d07b-4418-8901-b86ccc1ced96', NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DateCreated], [FirstName], [LastName], [DistrictId], [OrganizationId]) VALUES (N'c8f52bef-ff01-44c8-85a5-2162f6953654', N'husamMaghribi@gmail.com', N'HUSAMMAGHRIBI@GMAIL.COM', N'husamMaghribi@gmail.com', N'HUSAMMAGHRIBI@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEAzoTQE19Mie9KwJdEkwN7V0pvhJ5DTkFUA7R7MKqYqf9JL/MYuBXSfhB+1watMHPA==', N'LQAT6LRZLHQBNJICV7XHK2UFHIO34VNC', N'6800c5df-f18f-439d-8a78-65f0be8f9bce', N'0901122334', 0, 0, NULL, 1, 0, CAST(N'2025-06-07T10:01:37.7130565' AS DateTime2), N'حسام', N'المغربي', N'3193e747-ef2d-4ac6-83c5-cf4b33b484cf', N'8cb6269c-c0ee-48a0-bf4a-92ce2867a939')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DateCreated], [FirstName], [LastName], [DistrictId], [OrganizationId]) VALUES (N'cf156d6e-2b91-430f-a643-5b8b569250cb', N'SaraKhateeb@gmail.com', N'SARAKHATEEB@GMAIL.COM', N'SaraKhateeb@gmail.com', N'SARAKHATEEB@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEAzoTQE19Mie9KwJdEkwN7V0pvhJ5DTkFUA7R7MKqYqf9JL/MYuBXSfhB+1watMHPA==', N'KWHZN4VGVBS4KWWB63UYY6TQ344RGIYT', N'7d4b043b-1ca4-4e14-a533-e58e5631ce44', N'0913344556', 0, 0, NULL, 1, 0, CAST(N'2025-06-07T09:39:12.6729527' AS DateTime2), N'سارة', N'الخطيب', N'30b4617f-9896-4756-829e-674f7ccaab26', N'fca7062e-05c3-44d1-b69f-684e5da2fff0')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DateCreated], [FirstName], [LastName], [DistrictId], [OrganizationId]) VALUES (N'd0fc3259-1292-46dc-9911-0b366b993ff8', N'ziadMohammad@gmail.com', N'ZIADMOHAMMAD@GMAIL.COM', N'ziadMohammad@gmail.com', N'ZIADMOHAMMAD@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEAzoTQE19Mie9KwJdEkwN7V0pvhJ5DTkFUA7R7MKqYqf9JL/MYuBXSfhB+1watMHPA==', N'CK67U4SPYUXNQE6O3Y256KSYW5BZBIKX', N'7a546110-beac-4185-9a8a-22b12b30b488', N'0924455667', 0, 0, NULL, 1, 0, CAST(N'2025-06-07T10:09:48.9742230' AS DateTime2), N'زياد', N'المحمد', N'fcd31625-9b32-4cd3-8d9b-b5bc7f4aed69', N'dab2645f-0749-44db-8222-17cfc373075b')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DateCreated], [FirstName], [LastName], [DistrictId], [OrganizationId]) VALUES (N'd609e23d-58cd-4b5e-9a52-29cd5d07c401', N'nasserAseere@hotmail.com', N'NASSERASEERE@HOTMAIL.COM', N'nasserAseere@hotmail.com', N'NASSERASEERE@HOTMAIL.COM', 1, N'AQAAAAIAAYagAAAAEAzoTQE19Mie9KwJdEkwN7V0pvhJ5DTkFUA7R7MKqYqf9JL/MYuBXSfhB+1watMHPA==', N'GBZJA32EUQCUUKOWIAHQ3AKDD72SLNZN', N'68986369-3e5c-4878-b331-783e35fa92c2', N'0935566778', 0, 0, NULL, 1, 0, CAST(N'2025-06-07T10:02:50.4186333' AS DateTime2), N'ناصر', N'العسيري', N'd40b4c75-ea40-4478-9c0c-1bc7d14bf349', N'8cb6269c-c0ee-48a0-bf4a-92ce2867a939')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DateCreated], [FirstName], [LastName], [DistrictId], [OrganizationId]) VALUES (N'd97472fc-f369-45fa-be9c-c236c12e2060', N'jadMorad@hotmail.com', N'JADMORAD@HOTMAIL.COM', N'jadMorad@hotmail.com', N'JADMORAD@HOTMAIL.COM', 1, N'AQAAAAIAAYagAAAAEAzoTQE19Mie9KwJdEkwN7V0pvhJ5DTkFUA7R7MKqYqf9JL/MYuBXSfhB+1watMHPA==', N'AIDKHIEL3JES5XLB7X4K5DMPODXG567I', N'c27f4ccb-9016-4e3e-9928-f428565a864e', N'0946677889', 0, 0, NULL, 1, 0, CAST(N'2025-06-07T12:35:28.3372172' AS DateTime2), N'جاد', N'مراد', N'b67dcdd5-533c-43d4-a73f-79c778cab1a2', NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DateCreated], [FirstName], [LastName], [DistrictId], [OrganizationId]) VALUES (N'db8d1b06-4ec8-4ab1-94ab-3d3aeea57a8e', N'anasBloshe@icloud.com', N'ANASBLOSHE@ICLOUD.COM', N'anasBloshe@icloud.com', N'ANASBLOSHE@ICLOUD.COM', 1, N'AQAAAAIAAYagAAAAEAzoTQE19Mie9KwJdEkwN7V0pvhJ5DTkFUA7R7MKqYqf9JL/MYuBXSfhB+1watMHPA==', N'MO2JZIXTPT6XEI7CIEZUEEKG3SY5B7Z3', N'a9bbe73b-d281-4851-9899-9b1f8aff9f6a', N'0957788990', 0, 0, NULL, 1, 0, CAST(N'2025-06-07T09:56:27.8597713' AS DateTime2), N'أنس', N'البلوشي', N'0300ad81-be1f-4aa0-a0dd-6583fe357d43', N'32cd6aeb-8e24-4478-8cca-da432409378b')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DateCreated], [FirstName], [LastName], [DistrictId], [OrganizationId]) VALUES (N'e377dcb6-0973-4cc4-a581-3b3ba4ba0db3', N'taimKahtani@gmail.com', N'TAIMKAHTANI@GMAIL.COM', N'taimKahtani@gmail.com', N'TAIMKAHTANI@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEAzoTQE19Mie9KwJdEkwN7V0pvhJ5DTkFUA7R7MKqYqf9JL/MYuBXSfhB+1watMHPA==', N'QYAC5X67YMRYBOU5HADA6DGPUG5OATOW', N'24901f30-1a68-47b5-a987-cc70edcc336b', N'0968899001', 0, 0, NULL, 1, 0, CAST(N'2025-06-07T10:08:32.3760977' AS DateTime2), N'تيم', N'القحطاني', N'9cd8e1bc-f4f0-43a2-aae4-17a808bc0c95', N'dab2645f-0749-44db-8222-17cfc373075b')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DateCreated], [FirstName], [LastName], [DistrictId], [OrganizationId]) VALUES (N'e5bdf68b-4308-49ff-b99d-ce3bec73d5dd', N'TarekRasheed@gmail.com', N'TAREKRASHEED@GMAIL.COM', N'TarekRasheed@gmail.com', N'TAREKRASHEED@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEAzoTQE19Mie9KwJdEkwN7V0pvhJ5DTkFUA7R7MKqYqf9JL/MYuBXSfhB+1watMHPA==', N'ATMC4YITCKNWO2FOLCMUWD33QFXNZZV3', N'40010d14-23d6-4194-b4c5-bf6c565ad72d', N'0979900112', 0, 0, NULL, 1, 0, CAST(N'2025-06-07T09:53:05.4932870' AS DateTime2), N'طارق', N'الرشيد', N'5c58070a-99d5-4b19-b021-03b67800cee6', N'2e8d15e1-e1f4-474b-a3b4-c315d3ff9116')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DateCreated], [FirstName], [LastName], [DistrictId], [OrganizationId]) VALUES (N'e8c1a878-1053-46b0-a8ab-1ec13d4da6a0', N'khaledDaleeme@gmail.com', N'KHALEDDALEEME@GMAIL.COM', N'khaledDaleeme@gmail.com', N'KHALEDDALEEME@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEAzoTQE19Mie9KwJdEkwN7V0pvhJ5DTkFUA7R7MKqYqf9JL/MYuBXSfhB+1watMHPA==', N'7PD46XCSKKS3NWSIHN26E5O3R4LM7ZSO', N'17a9696e-30b7-4551-b88d-24e39d5459ac', N'0980011223', 0, 0, NULL, 1, 0, CAST(N'2025-06-07T09:44:12.5960597' AS DateTime2), N'خالد', N'الدليمي', N'47d512d6-3840-489d-bef0-45cee7a12233', N'dab2645f-0749-44db-8222-17cfc373075b')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DateCreated], [FirstName], [LastName], [DistrictId], [OrganizationId]) VALUES (N'edf383e1-0665-4bcc-a5d0-387880d2016e', N'reemShamari@icloud.com', N'REEMSHAMARI@ICLOUD.COM', N'reemShamari@icloud.com', N'REEMSHAMARI@ICLOUD.COM', 1, N'AQAAAAIAAYagAAAAEAzoTQE19Mie9KwJdEkwN7V0pvhJ5DTkFUA7R7MKqYqf9JL/MYuBXSfhB+1watMHPA==', N'E6EXGJT6MVG2LMWZLNVWUKBUOHZBJO2O', N'764c602b-888e-47a2-8006-f5cf86144023', N'0991122334', 0, 0, NULL, 1, 0, CAST(N'2025-06-07T09:43:23.8369820' AS DateTime2), N'ريم', N'الشمري', N'2b6b0acd-fbdc-4078-8b84-258501953bef', N'2e8d15e1-e1f4-474b-a3b4-c315d3ff9116')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DateCreated], [FirstName], [LastName], [DistrictId], [OrganizationId]) VALUES (N'f08011b8-7b8a-423f-9fe7-c1412e1b24e2', N'talaNasser@gmail.com', N'TALANASSER@GMAIL.COM', N'talaNasser@gmail.com', N'TALANASSER@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEAzoTQE19Mie9KwJdEkwN7V0pvhJ5DTkFUA7R7MKqYqf9JL/MYuBXSfhB+1watMHPA==', N'NLBNMVAMZYFTLCOHAFXAP5DILRWON643', N'fce9662a-ce91-4910-8127-85b7d17a23a6', N'0902233445', 0, 0, NULL, 1, 0, CAST(N'2025-06-07T12:37:29.6452587' AS DateTime2), N'تالا', N'ناصر', N'84607521-1024-4f43-bc81-80416bb33883', NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DateCreated], [FirstName], [LastName], [DistrictId], [OrganizationId]) VALUES (N'f98f5ee1-39f6-43a0-bf51-53cd01ab0a50', N'laylaZahrani@gmail.com', N'LAYLAZAHRANI@GMAIL.COM', N'laylaZahrani@gmail.com', N'LAYLAZAHRANI@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEAzoTQE19Mie9KwJdEkwN7V0pvhJ5DTkFUA7R7MKqYqf9JL/MYuBXSfhB+1watMHPA==', N'2QYCX7B32NZS2VQYZSLPVIXPPEQXODDW', N'b459eab0-14b8-45d2-8367-b1fcc20b02fc', N'0914455667', 0, 0, NULL, 1, 0, CAST(N'2025-06-07T09:41:34.4635773' AS DateTime2), N'ليلى', N'الزهراني', N'5f0514c3-31ab-4c74-b0a2-b65812438cfb', N'32cd6aeb-8e24-4478-8cca-da432409378b')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DateCreated], [FirstName], [LastName], [DistrictId], [OrganizationId]) VALUES (N'f9ea9167-517f-4f59-bf5d-da39f46eaa8e', N'nadaSbe3e@gmail.com', N'NADASBE3E@GMAIL.COM', N'nadaSbe3e@gmail.com', N'NADASBE3E@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEAzoTQE19Mie9KwJdEkwN7V0pvhJ5DTkFUA7R7MKqYqf9JL/MYuBXSfhB+1watMHPA==', N'LM6PTKDSSFYMPHKHDTEA5SGQNJ3GBOWW', N'a4c28e9d-df25-4e20-8706-52c77667e3cc', N'0925566778', 0, 0, NULL, 1, 0, CAST(N'2025-06-07T09:58:21.2517381' AS DateTime2), N'ندى', N'السبيعي', N'e24630d4-326d-4298-9fbc-96099e28cadd', N'32cd6aeb-8e24-4478-8cca-da432409378b')
GO
SET IDENTITY_INSERT [dbo].[AspNetUserClaims] ON 
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (13, N'2f512516-eadb-46cb-8a01-4dbbeae904fc', N'IsAdmin', N'true')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (14, N'009323cc-b1d0-4e0f-9d93-f36c55df9b8d', N'IsOrgAdmin', N'true')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (15, N'1773b7bb-c874-4708-b0cc-0ea0e0932b3c', N'IsOrgAdmin', N'true')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (16, N'0e616a58-163f-4eb3-9efa-35df398c4d43', N'IsOrgAdmin', N'true')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (17, N'5a31a898-3e62-4af9-8f1f-01c03e131112', N'IsOrgAdmin', N'true')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (18, N'4e0a189a-ec03-4424-b4b8-823f1967dbe6', N'IsOrgAdmin', N'true')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (19, N'259b2149-d3db-46cd-9f9b-758106768987', N'IsOrgAdmin', N'true')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (21, N'8bb5c60f-1ea9-40e1-893f-5267d6f24c60', N'IsOrgAdmin', N'true')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (22, N'a48b2b60-3564-482c-98ac-dc2b19b56a61', N'IsOrgAdmin', N'true')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (23, N'db8d1b06-4ec8-4ab1-94ab-3d3aeea57a8e', N'IsOrgAdmin', N'true')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (24, N'abbe8f78-26a0-484e-bbc2-118a7809cecc', N'IsOrgAdmin', N'true')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (26, N'd0fc3259-1292-46dc-9911-0b366b993ff8', N'IsOrgAdmin', N'true')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (28, N'009323cc-b1d0-4e0f-9d93-f36c55df9b8d', N'OrganizationId', N'7ca3e4ed-0906-4ec8-a747-77f8a2ed9f5a')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (29, N'0e616a58-163f-4eb3-9efa-35df398c4d43', N'OrganizationId', N'e8d3535c-4230-46f0-b424-65f8b8d80dc7')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (30, N'1773b7bb-c874-4708-b0cc-0ea0e0932b3c', N'OrganizationId', N'7f13d8d6-8e09-41a9-9d36-befaaea640ec')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (31, N'183c311d-3152-441a-8f7b-22d7a2918882', N'OrganizationId', N'7f13d8d6-8e09-41a9-9d36-befaaea640ec')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (32, N'1841c929-375a-456e-a5c8-2fa3b5ec84aa', N'OrganizationId', N'e8d3535c-4230-46f0-b424-65f8b8d80dc7')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (33, N'1b564b5e-27c8-44b0-af03-d1766e740851', N'OrganizationId', N'e8d3535c-4230-46f0-b424-65f8b8d80dc7')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (34, N'259b2149-d3db-46cd-9f9b-758106768987', N'OrganizationId', N'364a030b-70bb-4426-9502-8a13433ff83e')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (35, N'2905888d-0fcf-4b88-8afe-ea85357590ed', N'OrganizationId', N'364a030b-70bb-4426-9502-8a13433ff83e')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (36, N'291cb8d0-db7c-459b-809a-5702b4700a08', N'OrganizationId', N'7ca3e4ed-0906-4ec8-a747-77f8a2ed9f5a')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (37, N'3aeb36e2-b03b-4d9a-becd-99e6b5a10ed0', N'OrganizationId', N'7ca3e4ed-0906-4ec8-a747-77f8a2ed9f5a')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (38, N'467914c6-6737-4a5d-b935-525356e11d0c', N'OrganizationId', N'7f13d8d6-8e09-41a9-9d36-befaaea640ec')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (39, N'4e0a189a-ec03-4424-b4b8-823f1967dbe6', N'OrganizationId', N'99872214-5f38-4b9d-b2d8-0c7ca3fbb7e4')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (40, N'5060c2fa-4bff-475d-afe9-fd92c6c7bda0', N'OrganizationId', N'99872214-5f38-4b9d-b2d8-0c7ca3fbb7e4')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (41, N'5a31a898-3e62-4af9-8f1f-01c03e131112', N'OrganizationId', N'fdd0b83a-92aa-450b-b4ee-39930545d3e8')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (42, N'67ba101f-557e-46db-8b2e-002462ee1c80', N'OrganizationId', N'fdd0b83a-92aa-450b-b4ee-39930545d3e8')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (43, N'6b7957dd-41b1-40c5-a841-aad5e9170b28', N'OrganizationId', N'fdd0b83a-92aa-450b-b4ee-39930545d3e8')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (44, N'6cd00492-102f-4b13-af27-4c84ebd7ce15', N'OrganizationId', N'778125e1-6e45-4175-ab34-1e7f429727f0')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (45, N'7341ef0e-deb1-4333-81e0-40e41626db87', N'OrganizationId', N'778125e1-6e45-4175-ab34-1e7f429727f0')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (46, N'894ce12b-01e6-4c31-a54d-e3b85d2b4583', N'OrganizationId', N'778125e1-6e45-4175-ab34-1e7f429727f0')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (47, N'8bb5c60f-1ea9-40e1-893f-5267d6f24c60', N'OrganizationId', N'2e8d15e1-e1f4-474b-a3b4-c315d3ff9116')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (48, N'9f2546f1-5e05-4d29-a6f3-e4d450d7bef6', N'OrganizationId', N'99872214-5f38-4b9d-b2d8-0c7ca3fbb7e4')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (49, N'a1cd1108-43fb-47f5-98f2-2e0a959a5223', N'OrganizationId', N'364a030b-70bb-4426-9502-8a13433ff83e')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (50, N'a48b2b60-3564-482c-98ac-dc2b19b56a61', N'OrganizationId', N'8cb6269c-c0ee-48a0-bf4a-92ce2867a939')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (51, N'abbe8f78-26a0-484e-bbc2-118a7809cecc', N'OrganizationId', N'fca7062e-05c3-44d1-b69f-684e5da2fff0')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (52, N'ad428a99-bc1a-4c9e-91ef-712aab608987', N'OrganizationId', N'fca7062e-05c3-44d1-b69f-684e5da2fff0')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (53, N'c8f52bef-ff01-44c8-85a5-2162f6953654', N'OrganizationId', N'8cb6269c-c0ee-48a0-bf4a-92ce2867a939')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (54, N'cf156d6e-2b91-430f-a643-5b8b569250cb', N'OrganizationId', N'fca7062e-05c3-44d1-b69f-684e5da2fff0')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (55, N'd0fc3259-1292-46dc-9911-0b366b993ff8', N'OrganizationId', N'dab2645f-0749-44db-8222-17cfc373075b')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (56, N'd609e23d-58cd-4b5e-9a52-29cd5d07c401', N'OrganizationId', N'8cb6269c-c0ee-48a0-bf4a-92ce2867a939')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (57, N'db8d1b06-4ec8-4ab1-94ab-3d3aeea57a8e', N'OrganizationId', N'32cd6aeb-8e24-4478-8cca-da432409378b')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (58, N'e377dcb6-0973-4cc4-a581-3b3ba4ba0db3', N'OrganizationId', N'dab2645f-0749-44db-8222-17cfc373075b')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (59, N'e5bdf68b-4308-49ff-b99d-ce3bec73d5dd', N'OrganizationId', N'2e8d15e1-e1f4-474b-a3b4-c315d3ff9116')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (60, N'e8c1a878-1053-46b0-a8ab-1ec13d4da6a0', N'OrganizationId', N'dab2645f-0749-44db-8222-17cfc373075b')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (61, N'edf383e1-0665-4bcc-a5d0-387880d2016e', N'OrganizationId', N'2e8d15e1-e1f4-474b-a3b4-c315d3ff9116')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (62, N'f98f5ee1-39f6-43a0-bf51-53cd01ab0a50', N'OrganizationId', N'32cd6aeb-8e24-4478-8cca-da432409378b')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (63, N'f9ea9167-517f-4f59-bf5d-da39f46eaa8e', N'OrganizationId', N'32cd6aeb-8e24-4478-8cca-da432409378b')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (72, N'6cd00492-102f-4b13-af27-4c84ebd7ce15', N'IsOrgAdmin', N'true')
GO
SET IDENTITY_INSERT [dbo].[AspNetUserClaims] OFF
GO

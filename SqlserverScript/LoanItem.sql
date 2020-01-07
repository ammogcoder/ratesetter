SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoanItem](
	[LoanId] [bigint] IDENTITY(1,1) NOT NULL,
	[LoanAmount] [real] NOT NULL,
	[LoanName] [nvarchar](max) NULL,
	[LoanStatus] [nvarchar](max) NULL,
	[RequestedBy] [nvarchar](max) NULL,
	[FundedBy] [nvarchar](max) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[RequestedAt] [datetime2](7) NOT NULL,
	[FundedAt] [datetime2](7) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[LoanItem] ADD  CONSTRAINT [PK_LoanItem] PRIMARY KEY CLUSTERED 
(
	[LoanId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY]
GO

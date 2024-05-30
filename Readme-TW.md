其他語系：[簡中](Readme-CN.md)、[英文](Readme.md)

### 1.專案介紹
HrAdm 是一套簡單的人事管理系統，使用的開發工具為 ASP.NET Core 6、jQuery 3、Bootstrap 5、Visual Studio 2022 Community，它用來介紹 Web 系統常見的功能和實作方式，這些功能整理如下：
- CRUD：單個或多個資料表的新增、查詢、修改、刪除功能。 
- 自訂輸入欄位：SSR MVC 自訂輸入欄位。
- 權設設定：設定使用者、角色、功能以及可以存取的資料範圍。
- 匯出 Word 檔案：使用範本將資料匯出 Word 檔案。
- CMS（Content Management System）：以簡便的方式來維護各種 CMS 資料。
- 簽核流程功能：流程設計、建立和應用。
- 簡單報表：以簡單的方式來處理大量的報表需求。
- 資料庫異動記錄：記錄和查詢資料庫的異動內容。

HrAdm 的主畫面如下：
![主畫面](_md/zh-TW/image/main.png)

### 2.操作畫面
進入主畫面後，左側功能表有13個功能項目：
1. [請假作業](_md/zh-TW/Leave.md)：建立假單
2. [待簽核假單](_md/zh-TW/LeaveSign.md)：簽核假單
3. [流程維護](_md/zh-TW/XpFlow.md)：維護流程資料
4. [簽核資料查詢](_md/zh-TW/XpFlowSign.md)：查詢簽核資料
5. [用戶管理](_md/zh-TW/User.md)：維護用戶、用戶角色資料
6. [角色維護](_md/zh-TW/XpRole.md)：維護角色、用戶角色、角色功能資料
7. [功能維護](_md/zh-TW/XpProg.md)：維護功能、角色功能資料
8. [用戶經歷維護](_md/zh-TW/UserExt.md)：維護用戶經歷資料
9. [自訂輸入欄位](_md/zh-TW/CustInput.md)：維護自訂輸入欄位資料
10. [匯入用戶資料](_md/zh-TW/UserImport.md)：匯入用戶資料
11. [最新消息維護](_md/zh-TW/CmsMsg.md)：維護最新消息資料
12. [簡單報表維護](_md/zh-TW/XpEasyRpt.md)：維護簡單報表資料
13. [異動記錄查詢](_md/zh-TW/XpTranLog.md)：查詢資料庫的異動記錄

### 3.下載 & 安裝
執行 HrAdm 需要從 GitHub 下載以下兩個 Repo 檔案，解壓縮到本機目錄，並且確保 HrAdm 可以正確參照 BaseWeb 專案：
  - Base：包含 Base、BaseApi、BaseWeb、BaseEther 四個專案，內容為基本的公用程式。HrAdm 必須參照 BaseWeb 專案，下載的網址為 https://github.com/bruce68tw/Base
  - HrAdm：內容為 HrAdm 主程式。

### 4.目錄說明
以下是 HrAdm 專案下的目錄，其中底線開頭的目錄表示特殊用途：
  - _data：包含許多工作檔案，其中createDb.sql 用來建立本系統的資料表以及產生資料內容；Tables.docx是利用本系統所產生的資料庫檔案。
  - _log：系統運行所產生 Log 檔案。
  - _template：各種功能所需的範本檔案。
  - Controllers：Controller類別檔案。
  - Enums：列舉類別，如果檔案名稱結尾是Enum表示是數字型，如果是Estr，則表示為字串型，例如：InputTypeEstr.cs
  - Models：系統所需要Model類別，檔案名稱後面為Dto表示Data Transfer Object，Vo表示 View Object
  - Resources：多國語資料檔案，這裡用於View頁面。
  - Services：服務類別。
  - Views：網頁檔案。
  - wwwroot：Web 前端 CSS、JavaScript 檔案。
  - Tables：使用 Database First 所產生的 Entity Model。

### 5.組態設定
HrAdm/appsettings.json 裡面的 FunConfig 區段記錄系統執行時所需要的組態內容，
它包含以下的欄位：
  - Db：標準的資料庫連線字串，用於 ADO.NET 和 Entity Framework，並且加入 MultipleActiveResultSets=True 讓每一次連線可以多次存取資料庫。
  - Locale：指定的多國語語系，目前允許的輸入值分別為：zh-TW（繁體中文）、zh-CN（簡體中文）、en-US（英文），設定這個欄位，執行時系統即會呈現不同的語系。
  - LogSql：是否記錄SQL的內容到 Log 檔案，預設false，所有Log檔案會存放在 _log 目錄底下，這一類的檔案名稱後綴為 sql。

### 6.建立資料庫
HrAdm 的資料庫名稱為 Hr，種類為 LocalDB、SQL Express、MS SQL 皆可，進入SQL Server Management Studio（SSMS），建立一個空白的資料庫 Hr，然後執行HrAdm/_data/createDb.sql，這個檔案會建立以下的資料表和內容：
- Cms：CMS（Content Management System）設定資料
- CustInput：自定輸入欄位資料
- Dept：部門資料
- Leave：假單資料
- User：用戶基本資料
- UserJob：用戶工作經驗
- UserLang：用戶精通語言
- UserLicense：用戶取得證照
- UserSchool：用戶學歷資料
- UserSkill：用戶特殊技能
- XpCode：雜項檔，這個資料表用來儲存Key-Value的對應資料，名稱加上Xp表示系統用途。
- XpEasyRpt：快速報表設定資料
- XpFlow：流程設定資料
- XpFlowLine：流程線設定資料
- XpFlowNode：流程節點資料
- XpFlowSign：包含所有流程的簽核資料
- XpImportLog：匯入資料紀錄
- XpTranLog：資料異動紀錄
- XpProg：系統功能基本資料
- XpRole：角色基本資料
- XpRoleProg：角色功能資料
- XpUserRole：用戶角色資料

### 7.參與專案
您可以透過以下方式來參與本專案：
 - 反映系統問題：[GitHub Issues](https://github.com/bruce68tw/HrAdm/issues)
 - 修改程式並且提交請求：[Pull Request](https://github.com/bruce68tw/HrAdm/pulls)
 - 到[臉書](https://www.facebook.com/groups/softblocks)參與討論。
 - 贈送 GitHub Star。
 - 購買[書籍](https://www.tenlong.com.tw/products/9789865029883)。

### 8.作者
 - Bruce Chen - *Initial work*

### 9.版權說明
本專案使用 [MIT 授權許可](https://zh.wikipedia.org/zh-tw/MIT許可證)。
# Accounting Document Management

## Giới thiệu
Dự án gồm hai phần chính:
- **ManagementApi**: Backend API được xây dựng với ASP.NET Core 8.
- **ManagementSpa**: Frontend SPA sử dụng React và Vite 19.

---

## Cấu trúc thư mục

### Backend - ManagementApi
```
📂 ManagementApi
│── 📂 AccountingDocument.Api             # ASP.NET Core API
│── 📂 AccountingDocument.Application     # Chứa logic nghiệp vụ (Service, DTOs)
│── 📂 AccountingDocument.Domain          # Chứa Models (Entities)
│── 📂 AccountingDocument.Infrastructure  # Chứa DbContext, Repositories
│── 📄 AccountingDocument.sln             # Solution file
```
### Frontend - ManagementSpa
```
📂 ManagementSpa
│── 📂 src
│   ├── 📂 components              # Các component dùng chung
│   ├── 📂 pages                   # Các trang chính
│   │   ├── 📄 Home.jsx            # Trang danh sách chứng từ
│   │   ├── 📄 DocumentForm.jsx    # Trang thêm/sửa chứng từ
│   │   ├── 📄 DocumentDetails.jsx # Chi tiết chứng từ
│   ├── 📂 services                # Giao tiếp API
│   │   ├── 📄 api.js              # Cấu hình Axios
│   │   ├── 📄 documentService.js  # Gọi API cho chứng từ
│   │   ├── 📄 detailService.js    # Gọi API cho chi tiết chứng từ
│   ├── 📄 App.jsx                 # File chính
│   ├── 📄 main.jsx                # Entry point
│── 📄 package.json
│── 📄 vite.config.js
```
---

## Cài đặt và chạy dự án

### 1. Cấu hình Backend (API)
#### **Yêu cầu:**
- Cài đặt .NET 8
- Cài đặt MySQL

#### **Các bước thực hiện:**
```sh
cd Management.Api
```
Thực hiện migration database MySQL:
```sh
dotnet ef migrations add InitialCreate --project "../Management.Infrastructure/Management.Infrastructure.csproj" # Đã có thư mục migrations, nếu chưa có hãy chạy lệnh này
dotnet ef database update --project "../Management.Infrastructure/Management.Infrastructure.csproj"
```
Chạy API:
```sh
dotnet run --project AccountingDocument.Api
```
Backend sẽ chạy tại `https://localhost:7078` hoặc `http://localhost:5002`

### 2. Cấu hình Frontend (SPA)
#### **Yêu cầu:**
- Cài đặt Node.js

#### **Các bước thực hiện:**
```sh
cd ManagementSpa
npm install
npm run dev
```
Ứng dụng sẽ chạy tại `http://localhost:5173`

---
## Liên hệ
Nếu có vấn đề hoặc cần hỗ trợ, vui lòng liên hệ qua mail của Haph.


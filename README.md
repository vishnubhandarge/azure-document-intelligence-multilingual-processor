# azure-document-intelligence-multilingual-processor
Implemented an AI-based document ingestion pipeline using .NET 8, Azure AI Document Intelligence, and Azure Translator to extract, normalize, and persist multilingual document data into Azure SQL Database.
Here is a **polished GitHub README ready to copy-paste** with **clean sections, emojis, and symbols** for a professional look.

---

# 🚀 Azure AI Document Intelligence Multilingual Processing Pipeline

An **AI-powered document processing system** built with **.NET 8** that automatically extracts, translates, and stores structured data from PDF documents using Azure AI services.

This solution eliminates manual data entry by converting tabular document data into structured database records while supporting **multilingual data normalization**.

---

# 🧠 Powered By

* Azure AI Document Intelligence
* Azure AI Translator
* Azure SQL Database

Additional technologies:

* ⚙️ .NET 8 Web API
* 🗄 Entity Framework Core
* ☁️ Microsoft Azure Cloud

---

# 🏗️ System Architecture

```
📄 Upload PDF
      │
      ▼
⚙️ .NET 8 Web API
      │
      ▼
🧠 Azure AI Document Intelligence
Extract table data
      │
      ▼
🌍 Azure Translator
Translate extracted fields
      │
      ▼
🗄 Azure SQL Database
Store structured records
```

---

# ✨ Key Features

✔️ Automatic **table extraction from PDF documents**
✔️ **Multilingual translation support (100+ languages)**
✔️ Automatic **database insertion**
✔️ Eliminates **manual data entry**
✔️ Handles **large datasets efficiently**

---

# 📄 Example Input → Output

### Input Document

The uploaded PDF contains structured tabular data.

Example structure:

```
Name | Email | Phone | City | SourceLanguage | CreatedAt
```

---

### Result After Processing

The system extracts, translates, and stores the records in the database.

📸 **Processing Example**

![Processing Example](./assets/output-example.png)

🔼 **Top:** Input PDF table
🔽 **Bottom:** Extracted and translated records stored in SQL database

---

# 🔄 Example Transformation

| Original Data   | Stored in Database |
| --------------- | ------------------ |
| City: San Diego | सॅन डिएगो          |
| City: Toronto   | टोरांटो            |
| City: Berlin    | बर्लिन             |

---

# 🌐 API Endpoint

Upload document for processing.

```
POST /api/document/upload
```

Optional parameter:

```
targetLanguage=hi
```

Example request:

```
POST /api/document/upload?targetLanguage=hi
```

---

# 📦 Example API Response

```json
[
 {
  "name": "एलेनोर वेंस",
  "email": "eleanor.vance@example.com",
  "phone": "555-123-4567",
  "city": "सैन डिएगो"
 }
]
```

---

# 🗄 Database Schema

```
Persons
-------
Id
Name
Email
Phone
City
SourceLanguage
CreatedAt
```

---

# 💼 Use Cases

This system can be used for:

📑 Invoice processing
🏢 HR document ingestion
🏛 Government form digitization
🌍 International document processing
📊 Large-scale data entry automation

---

# 🔮 Future Enhancements

⚡ Batch translation optimization
⚡ Background document processing
⚡ Automatic language detection
⚡ Support for additional document formats

---

# 🏆 Project Highlights

⭐ Built using **Azure AI Services**
⭐ Demonstrates **real-world AI document processing**
⭐ Shows **cloud-native backend architecture**
⭐ Scalable design for **enterprise data ingestion**

---

💡 *This project demonstrates how AI can automate document processing pipelines and transform unstructured documents into structured multilingual data.*

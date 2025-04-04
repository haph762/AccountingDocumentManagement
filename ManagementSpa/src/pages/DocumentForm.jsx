import React, { useState, useEffect } from "react";
import { useParams, useNavigate } from "react-router-dom";
import {
  createDocument,
  getDocumentById,
  updateDocument,
} from "../services/documentService";

const DocumentForm = () => {
  const { id } = useParams();
  const navigate = useNavigate();
  const [document, setDocument] = useState({
    documentNumber: "",
    documentDate: "",
    documentType: "",
    description: "",
    totalAmount: 0,
  });

  useEffect(() => {
    if (id) {
      fetchDocument(id);
    }
  }, [id]);

  const fetchDocument = async (docId) => {
    const data = await getDocumentById(docId);
    setDocument(data);
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setDocument({ ...document, [name]: value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    if (id) {
      await updateDocument(id, document);
    } else {
      await createDocument(document);
    }
    navigate("/");
  };

  return (
    <div className="container d-flex justify-content-center align-items-center min-vh-100">
      <div className="card shadow-lg p-4" style={{ width: "40rem" }}>
        <h2 className="text-center mb-4">
          {id ? "Chỉnh Sửa" : "Thêm"} Chứng từ
        </h2>
        <form onSubmit={handleSubmit}>
          <div className="mb-3">
            <label>Số chứng từ - duy nhất</label>
            <input
              type="text"
              name="documentNumber"
              className="form-control"
              value={document.documentNumber}
              onChange={handleChange}
              required
            />
          </div>
          <div className="mb-3">
            <label>Ngày lập</label>
            <input
              type="date"
              name="documentDate"
              className="form-control"
              value={document.documentDate}
              onChange={handleChange}
              required
            />
          </div>
          <div className="mb-3">
            <label>Loại</label>
            <input
              type="text"
              name="documentType"
              className="form-control"
              value={document.documentType}
              onChange={handleChange}
              required
            />
          </div>
          <div className="mb-3">
            <label>Diễn giải</label>
            <textarea
              name="description"
              className="form-control"
              value={document.description}
              onChange={handleChange}
            ></textarea>
          </div>
          <div className="mb-3">
            <label>Tổng tiền</label>
            <input
              type="number"
              name="totalAmount"
              className="form-control"
              value={document.totalAmount}
              onChange={handleChange}
              required
            />
          </div>
          <div className="d-flex justify-content-between">
            <button
              type="button"
              className="btn btn-secondary"
              onClick={() => navigate("/")}
            >
              🔙 Quay lại
            </button>
            <button type="submit" className="btn btn-success">
              💾 Lưu
            </button>
          </div>
        </form>
      </div>
    </div>
  );
};

export default DocumentForm;

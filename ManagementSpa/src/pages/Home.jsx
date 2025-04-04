import React, { useEffect, useState } from "react";
import { getDocuments, deleteDocument } from "../services/documentService";
import { useNavigate } from "react-router-dom";

const Home = () => {
  const [documents, setDocuments] = useState([]);
  const navigate = useNavigate();

  useEffect(() => {
    fetchDocuments();
  }, []);

  const fetchDocuments = async () => {
    const data = await getDocuments();
    setDocuments(data);
  };

  const handleDelete = async (id) => {
    if (window.confirm("Bạn có chắc chắn muốn xóa chứng từ này?")) {
      await deleteDocument(id);
      fetchDocuments();
    }
  };

  return (
    <div className="container mt-4">
      <h2 className="text-center text-primary mb-4">Quản lý Chứng từ</h2>
      <div className="d-flex justify-content-between mb-3">
        <button className="btn btn-success" onClick={() => navigate("/add")}>
          + Thêm Chứng Từ
        </button>
      </div>
      <div className="card shadow-lg">
        <div className="card-body">
          <table className="table table-hover text-center">
            <thead className="table-while">
              <tr>
                <th>#</th>
                <th>Số chứng từ</th>
                <th>Loại</th>
                <th>Ngày lập</th>
                <th>Tổng tiền</th>
                <th>Hành động</th>
              </tr>
            </thead>
            <tbody>
              {documents.map((doc, index) => (
                <tr key={doc.id}>
                  <td>{index + 1}</td>
                  <td>{doc.documentNumber}</td>
                  <td>{doc.documentType}</td>
                  <td>{new Date(doc.documentDate).toLocaleDateString()}</td>
                  <td>{doc.totalAmount.toLocaleString()} VND</td>
                  <td>
                    <button
                      className="btn btn-warning btn-sm mx-1"
                      onClick={() => navigate(`/edit/${doc.id}`)}
                    >
                      ✏️ Sửa
                    </button>
                    <button
                      className="btn btn-danger btn-sm mx-1"
                      onClick={() => handleDelete(doc.id)}
                    >
                      ❌ Xóa
                    </button>
                    <button
                      className="btn btn-info btn-sm mx-1"
                      onClick={() => navigate(`/details/${doc.id}`)}
                    >
                      🔍 Chi tiết
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>
    </div>
  );
};

export default Home;

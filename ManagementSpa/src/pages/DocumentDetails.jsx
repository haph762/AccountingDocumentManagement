import React, { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import {
  getDetailsByDocumentId,
  createDetail,
  deleteDetail,
} from "../services/detailService";

const DocumentDetails = () => {
  const { id } = useParams();
  const navigate = useNavigate();
  const [details, setDetails] = useState([]);
  const [newDetail, setNewDetail] = useState({
    documentId: id,
    accountCode: "",
    description: "",
    amount: "",
    transactionType: "Debit",
  });

  useEffect(() => {
    fetchDetails();
  }, []);

  const fetchDetails = async () => {
    const data = await getDetailsByDocumentId(id);
    setDetails(data);
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setNewDetail({ ...newDetail, [name]: value });
  };

  const handleAddDetail = async (e) => {
    e.preventDefault();
    await createDetail(newDetail);
    fetchDetails();
    setNewDetail({
      ...newDetail,
      accountCode: "",
      description: "",
      amount: "",
    });
  };

  const handleDelete = async (detailId) => {
    if (window.confirm("Bạn có chắc chắn muốn xóa chi tiết này?")) {
      await deleteDetail(detailId);
      fetchDetails();
    }
  };

  return (
    <div className="container mt-4">
      <h2>Chi Tiết Chứng Từ #{id}</h2>
      <button className="btn btn-secondary mb-3" onClick={() => navigate("/")}>
        Quay lại
      </button>

      <form onSubmit={handleAddDetail} className="mb-4">
        <div className="row">
          <div className="col-md-2">
            <input
              type="text"
              name="accountCode"
              className="form-control"
              placeholder="Mã tài khoản"
              value={newDetail.accountCode}
              onChange={handleChange}
              required
            />
          </div>
          <div className="col-md-3">
            <input
              type="text"
              name="description"
              className="form-control"
              placeholder="Diễn giải"
              value={newDetail.description}
              onChange={handleChange}
              required
            />
          </div>
          <div className="col-md-2">
            <input
              type="number"
              name="amount"
              className="form-control"
              placeholder="Số tiền"
              value={newDetail.amount}
              onChange={handleChange}
              required
            />
          </div>
          <div className="col-md-2">
            <select
              name="transactionType"
              className="form-control"
              value={newDetail.transactionType}
              onChange={handleChange}
            >
              <option value="Debit">Nợ</option>
              <option value="Credit">Có</option>
            </select>
          </div>
          <div className="col-md-2">
            <button type="submit" className="btn btn-success">
              Thêm
            </button>
          </div>
        </div>
      </form>

      <table className="table table-bordered">
        <thead>
          <tr>
            <th>#</th>
            <th>Mã tài khoản</th>
            <th>Diễn giải</th>
            <th>Số tiền</th>
            <th>Loại giao dịch</th>
            <th>Hành động</th>
          </tr>
        </thead>
        <tbody>
          {details.map((detail, index) => (
            <tr key={detail.id}>
              <td>{index + 1}</td>
              <td>{detail.accountCode}</td>
              <td>{detail.description}</td>
              <td>{detail.amount.toLocaleString()} VND</td>
              <td>{detail.transactionType === "Debit" ? "Nợ" : "Có"}</td>
              <td>
                <button
                  className="btn btn-danger"
                  onClick={() => handleDelete(detail.id)}
                >
                  Xóa
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default DocumentDetails;

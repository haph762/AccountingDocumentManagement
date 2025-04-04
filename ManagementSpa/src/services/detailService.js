import api from "./api";

export const getDetailsByDocumentId = async (documentId) => {
  const response = await api.get(`/AccountingDocuments/${documentId}/details`);
  return response.data;
};

export const createDetail = async (detail) => {
  const response = await api.post("/AccountingDocumentDetails", detail);
  return response.data;
};

export const updateDetail = async (id, detail) => {
  await api.put(`/AccountingDocumentDetails/${id}`, detail);
};

export const deleteDetail = async (id) => {
  await api.delete(`/AccountingDocumentDetails/${id}`);
};

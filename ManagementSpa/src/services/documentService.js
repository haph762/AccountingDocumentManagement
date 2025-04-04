import api from "./api";

export const getDocuments = async () => {
  const response = await api.get("/AccountingDocuments");
  return response.data;
};

export const getDocumentById = async (id) => {
  const response = await api.get(`/AccountingDocuments/${id}`);
  return response.data;
};

export const createDocument = async (document) => {
  const response = await api.post("/AccountingDocuments", document);
  return response.data;
};

export const updateDocument = async (id, document) => {
  await api.put(`/AccountingDocuments/${id}`, document);
};

export const deleteDocument = async (id) => {
  await api.delete(`/AccountingDocuments/${id}`);
};

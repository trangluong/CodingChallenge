import httprequest from "./httprequest";

class TaskService {
  getAll() {
    return httprequest.get("/Tasks");
  }

  getTaskById(id) {
    return httprequest.get(`/Tasks/${id}`)
  }

  createTask(task) {
    return httprequest.post("/Tasks", task);
  }

  updateTask(id, task) {
    return httprequest.put(`/Tasks/${id}`, task);
  }

  deleteTask(id) {
    return httprequest.delete(`/Tasks/${id}`);
  }
}

export default new TaskService();
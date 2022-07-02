<template>
  <div class="text-end p-2">
    <button class="btn btn-link" @click="createTask"> + Create a new task</button>
  </div>
  <div class="container">
    <div class="row border py-3 header">
      <div class="col-1 col-md-1">Completed</div>
      <div class="col-11 col-md-11 text-start">Details</div>
    </div>
    <div class="row border py-3 data" v-for="task in taskList" :key="task.id">
      <span class="col-1 col-md-1">
        <input class="checkbox" :class="{ checked: task.completed }" type="checkbox" :checked="task.completed"
          name="complete" @change="completeTask(task.id)">
      </span>

      <div class="col-10 col-md-10 text-start" data-toggle="tooltip" data-placement="bottom" :title="task.details">{{
          shortDetail(task.details)
      }}</div>
      <div class="col-1 col-md-1 text-end actions">
        <i class="bi bi-pencil-square px-1" @click="editTask(task.id)"></i>
        <i class="bi bi-trash3" @click="showDeleteBox(task.id)"></i>
      </div>

    </div>
  </div>
  <ModalPopup v-if="showModal" :close-modal="toggleModal">
    <div class="modal-wrapper form">
      <div class="modal-title">{{ modalTitle }}</div>
      <div class="modal-message px-5">
        <div class="message-description">
          <div>Details</div>
          <small class="text-danger">Required</small>
        </div>
        <textarea class="message-content" v-model="details"></textarea>
      </div>
      <div class="modal-button-wrapper px-5 py-3">
        <button class="btn modal-button modal-button-cancel" @click="toggleModal">Cancel</button>
        <button class="btn btn-primary modal-button modal-button-save " @click="saveTask">Save</button>
      </div>
    </div>
  </ModalPopup>

  <ModalPopup v-if="showConfirmation" :close-modal="toggleModalConfirmation">
    <div class="modal-wrapper confirmation">
      <div class="modal-title">Confirmation</div>
      <div class="modal-message px-5">
        Are you sure that you want to delete this task?
      </div>
      <div class="modal-button-wrapper px-5 py-3">
        <button class="btn modal-button modal-button-cancel" @click="toggleModalConfirmation">Cancel</button>
        <button class="btn btn-primary modal-button modal-button-save" @click="deleteTask">Yes</button>
      </div>
    </div>
  </ModalPopup>

  <!-- Toast message -->
  <teleport to="#app">
    <transition name="slide-fade">
      <div v-if="showToast" class="snackbar" :class="snack.mode">
        <i class="bi bi-exclamation-circle"></i>
        <p>{{ snack.message }}</p>
      </div>
    </transition>
  </teleport>
</template>

<script>
import TaskService from '@/service/TaskService'
import ModalPopup from '../shared/ModalPopup.vue';

export default {
  name: "TaskTable",
  components: { ModalPopup },
  data() {
    return {
      taskList: [],
      showModal: false,
      isCreating: false,
      details: "",
      selectedId: "",
      showConfirmation: false,
      showToast: false,
      snack: {
        mode: 'error',
        message: "One or more required fields haven't been filled in.",
        show: false
      },
    };
  },
  computed: {
    modalTitle() {
      return this.isCreating ? "Create task" : "Edit task";
    },
    shortDetail() {
      return details => {
        return details.length > 150 ? `${details.slice(0, 100)} ...` : details;
      }
    }
  },
  mounted() {
    this.getAllTask();
  },
  methods: {
    toggleModal(event) {
      event.stopPropagation();
      this.showModal = !this.showModal
    },
    toggleModalConfirmation(event) {
      event.stopPropagation();
      this.showConfirmation = !this.showConfirmation
    },
    showDeleteBox(id) {
      this.selectedId = id;
      this.showConfirmation = !this.showConfirmation;
    },
    getAllTask() {
      TaskService.getAll().then(res => this.taskList = res.data)
        .catch(e => console.log(e));
    },
    createTask() {
      this.details = "";
      this.isCreating = true;
      this.showModal = true;
    },
    editTask(id) {
      this.selectedId = id;
      TaskService.getTaskById(id).then(res => this.details = res.data).catch(e => console.log(e));
      this.isCreating = false;
      this.showModal = true;
    },
    deleteTask() {
      TaskService.deleteTask(this.selectedId)
        .then(() => {
          this.showConfirmation = false;
          this.getAllTask();
        })
        .catch(e => console.log(e));
    },
    completeTask(id) {
      TaskService.updateTask(id, { "completed": true })
    },
    saveTask() {
      if (!this.details.length) {
        this.showToast = true;
        setTimeout(() => {
          this.showToast = false;
        }, 3000);
        return;
      }
      const promises = this.isCreating ?
        TaskService.createTask({ "details": this.details }) :
        TaskService.updateTask(this.selectedId, { "details": this.details });

      promises.then(() => {
        this.getAllTask();
      })
        .catch((e) => console.log(e))
        .finally(() => {
          this.showModal = false;
        })
    }
  }
}
</script>

<style lang="scss" scoped>
.checkbox {
  height: 16px;
  width: 16px;
}

.checkbox.checked {
  accent-color: #52CEEF;

}

.container {
  font: normal 14px "Poppins", sans-serif;
  border-radius: 5px;

  .row.header {
    background-color: #e7eaf5;
    text-transform: uppercase;
    font-weight: 600;
    border-top-left-radius: 5px;
    border-top-right-radius:5px
  }

  .row.data:hover{
    background-color: #EBF9FC ;
  }
  .row:last-child{
    border-bottom-left-radius: 5px;
    border-bottom-right-radius:5px
  }
}

.add-task {
  background-color: #52CEEF;
  border-radius: 10px;
  border: none;
  color: white;
}

.form {
  width: 50vw;
  min-width: 400px;
  min-height: 250px;
  height: 30vw;
}

.confirmation {
  min-width: 200px;
  min-height: 150px;
}

.modal-wrapper {
  background-color: white;
  display: flex;
  flex-direction: column;
  border-radius: 5px;
}

.modal-title {
  height: 18%;
  display: flex;
  align-items: center;
  justify-content: center;
  font-size: 20px;
  font-weight: 600;
  margin-top: 15px;
}

.modal-message {
  flex: 1;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;

  .message-description {
    width: 100%;
    display: flex;
    justify-content: space-between;
    font: 600 14px "Poppins", sans-serif;
    padding-bottom: 10px;
  }

  .message-content {
    width: 100%;
    height: 100%;
    border-color: #C0C0C0;
    border-radius: 5px;
  }
}

.modal-button-wrapper {
  display: flex;
  justify-content: flex-end;
  gap: 20px;

  .modal-button {
    padding: 0 14px;
    border-radius: 999px;
    line-height: 36px;
  }

  .modal-button-cancel {
    color: #00B2D5;
    border: #00B2D5 1px solid;
  }

  .modal-button-cancel:hover {
    background: #00b2d5;
    color: #fff;
  }

  .modal-button-save {
    background-color: #00B2D5;
    color: white;
    border: none;
  }

  .modal-button-save:hover {
    box-shadow: 0px 3px 6px #00000029;
  }

}

.snackbar {
  position: absolute;
  // top: 16px;
  left: 50%;
  transform: translateX(-50%);
  border-radius: 4px;
  display: flex;
  align-items: center;
  padding: 8px 16px 8px 8px;
  z-index: 9999;
  color: white;

  & i {
    margin-right: 16px;
  }

  & p {
    margin: 0;
    font-weight: 500;
  }

  &.error {
    background-color: #f44336;
  }
}

.slide-fade-enter-active,
.slide-fade-leave-active {
  transition: all 0.3s ease-out;
}

.slide-fade-enter-from,
.slide-fade-leave-to {
  transform: translateX(-50%) translateY(-10px);
  opacity: 0;
}
</style>
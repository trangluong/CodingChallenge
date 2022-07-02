<template>
  <div class="shared-modal-wrapper">
    <div class="shared-modal">
      <button
        class="modal-close-button icon-x-close"
        @click="closeModal"
      ><i class="bi bi-x"></i></button>
      <slot></slot>
    </div>
  </div>
</template>
<script>

export default {
  name: "ModalPopup",
  props: {
    closeModal: {
      type: Function,
      required: true,
    },
  },
  methods: {
  },
};
</script>

<style scoped>
* {
  transition: all 0.2s;
}

@keyframes show {
  from {
    opacity: 0;
    transform: translateY(30px);
  }
  to {
    opacity: 1;
    transform: translateY(0);
  }
}

.shared-modal-wrapper {
  position: fixed;
  top: 0;
  left: 0;
  z-index: 1000;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.5);
  display: flex;
  justify-content: center;
  align-items: center;
  animation: show 0.2s ease-out;
  
}

.shared-modal {
  position: relative;
  box-shadow: 1px 1px 20px 1px rgba(0, 0, 0, 0.2);
  overscroll-behavior: contain;
}

.shared-modal.mobile_view {
  height: 90%;
}

.modal-close-button {
  border-radius: 50%;
  position: absolute;
  background-color: initial;
  top: 10px;
  right: 10px;
  padding: initial;
  font-size: 26px;
  line-height: initial;
  width: 1em;
  height: 1em;
  border: none;

}
.shared-modal.mobile_view > .modal-close-button {
  top: 0;
}

.modal-close-button:hover {
  background-color: #eaeaea;
}

.modal-close-button::before {
  font-size: 2em;
  color: #707070;
}
</style>
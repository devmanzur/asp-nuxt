<template>
  <div>
    <button
      class="
        mx-2
        px-4
        py-1
        text-sm text-blue-600
        font-semibold
        rounded-full
        border border-blue-200
        hover:text-white hover:bg-blue-600 hover:border-transparent
        focus:outline-none focus:ring-2 focus:ring-blue-600 focus:ring-offset-2
      "
      @click="$emit('on-selected')"
    >
      {{ title }}
    </button>
  </div>
</template>

<script>
export default {
  props: {
    title: {
      type: String,
      required: true,
    },
  },
};
</script>

<style>
</style>